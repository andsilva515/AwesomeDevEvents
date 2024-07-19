using AwesomeDevEventsAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEventsAPI.Controllers
{
    [Route("api/[dev-events]")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;

        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(d => d.IsDeleted).ToList();
            
            return Ok(devEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            return Ok(devEvent);

        }


        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {

        }      

        //api-/dev-events/12312421 PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent devEvent)
        {

        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {

        }
        

    }

}
