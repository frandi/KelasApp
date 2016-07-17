using Kelas.App.Core.ClassRoom;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Kelas.App.Core.Test
{
    public class ClassRoomServiceTest
    {
        [Fact]
        public async void GetClassRoom_SuccessTest()
        {
            var idTest = Guid.NewGuid();
            var itemTest = new ClassRoom.ClassRoom() { Id = idTest };

            Mock<IClassRoomRepository> mockRepo = new Mock<IClassRoomRepository>();
            mockRepo.Setup(r => r.GetById(idTest)).Returns(Task.FromResult(itemTest));

            var service = new ClassRoomService(mockRepo.Object);
            var item = await service.GetClassRoom(idTest);

            Assert.Equal(item.Id, idTest);
        }

        [Fact]
        public async void GetClassRoom_FailedTest()
        {
            Mock<IClassRoomRepository> mockRepo = new Mock<IClassRoomRepository>();
         
            var service = new ClassRoomService(mockRepo.Object);
            var exception = await Record.ExceptionAsync(() => service.GetClassRoom(Guid.Empty));

            Assert.NotNull(exception);
        }

        [Fact]
        public async void GetClassRooms_All_SuccessTest()
        {
            var testItems = new List<ClassRoom.ClassRoom>()
            {
                new ClassRoom.ClassRoom() { Id = Guid.NewGuid() },
                new ClassRoom.ClassRoom() { Id = Guid.NewGuid() }
            };

            Mock<IClassRoomRepository> mockRepo = new Mock<IClassRoomRepository>();
            mockRepo.Setup(r => r.Get(null)).Returns(Task.FromResult(testItems.AsEnumerable()));

            var service = new ClassRoomService(mockRepo.Object);
            var items = await service.GetClassRooms();

            Assert.Equal(2, items.Count());
        }

        [Fact]
        public async void GetClassRooms_WithCriteria_SuccessTest()
        {
            var testId = Guid.NewGuid();
            var testItems = new List<ClassRoom.ClassRoom>()
            {
                new ClassRoom.ClassRoom() { Id = testId, Name = "Class A" },
            };

            var criteria = new List<SearchCriteria>()
            {
                new SearchCriteria() { SearchField = "Name", SearchOperator = SearchOperator.Equals, SearchValue = "Class A" }
            };

            Mock<IClassRoomRepository> mockRepo = new Mock<IClassRoomRepository>();
            mockRepo.Setup(r => r.Get(It.Is<List<SearchCriteria>>(c => c.Equals(criteria)))).Returns(Task.FromResult(testItems.AsEnumerable()));
            
            var service = new ClassRoomService(mockRepo.Object);
            var items = await service.GetClassRooms(criteria);

            Assert.Equal(1, items.Count());
            Assert.Equal(testId, items.First().Id);
        }

        [Fact]
        public async void GetClassRooms_EmptyResult_SuccessTest()
        {
            Mock<IClassRoomRepository> mockRepo = new Mock<IClassRoomRepository>();
            mockRepo.Setup(r => r.Get(It.IsAny<List<SearchCriteria>>())).Returns(Task.FromResult((new List<ClassRoom.ClassRoom>()).AsEnumerable()));

            var service = new ClassRoomService(mockRepo.Object);
            var items = await service.GetClassRooms(new List<SearchCriteria>());

            Assert.Empty(items);
        }
    }
}
