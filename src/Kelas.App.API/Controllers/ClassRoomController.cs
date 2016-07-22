using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kelas.App.Core.ClassRoom;
using System.Net;

namespace Kelas.App.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassRoomController : Controller
    {
        private IClassRoomService _classRoomSvc;
        
        public ClassRoomController(IClassRoomService classRoomSvc)
        {
            _classRoomSvc = classRoomSvc;
        }

        [HttpGet]
        [Route("", Name = "GetItems")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _classRoomSvc.GetClassRooms());
        }

        [HttpGet]
        [Route("{id}", Name = "GetItemById")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _classRoomSvc.GetClassRoom(id));
        }

        [HttpPost]
        [Route("", Name = "CreateItem")]
        public async Task<IActionResult> Post([FromBody] NewClassRoom item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var classRoom = await _classRoomSvc.CreateClassRoom(item);
            var uri = Url.Link("GetItemById", new { id = classRoom.Id });
            return Created(uri, classRoom);
        }

        [HttpPut]
        [Route("{id}", Name = "UpdateItem")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EditClassRoom item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classRoom = await _classRoomSvc.UpdateClassRoom(id, item);
            return Ok(classRoom);
        }

        [HttpDelete]
        [Route("{id}", Name = "DeleteItem")]
        public async Task<IActionResult> Delete(Guid id)
        {
            int rowsCount = await _classRoomSvc.DeleteClassRoom(id);

            if (rowsCount > 0)
                return StatusCode((int)HttpStatusCode.NoContent);
            else
                return NotFound();
        }
    }
}
