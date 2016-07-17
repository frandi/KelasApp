using Kelas.App.Core.ClassRoom;
using Moq;
using System;
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
    }
}
