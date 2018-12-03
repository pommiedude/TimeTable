using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeTable.Application.Schedule.Commands.CreateSchedule;
using TimeTable.Application.Schedule.Commands.DeleteSchedule;
using TimeTable.Application.Schedule.Queries.GetScheduleDetail;
using TimeTable.Application.Schedule.Queries.GetScheduleList;

namespace TrainTimeTable.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ScheduleListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetScheduleListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetScheduleDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateScheduleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody]UpdateScheduleCommand command)
        //{
        //    if (command == null || command.Id != id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteScheduleCommand { Id = id });
            return NoContent();
        }
    }
}