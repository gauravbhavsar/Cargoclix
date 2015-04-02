using System.Web.Http;
using WebApiTest.Services;
using WebApiTest.ViewModels;
using System.Linq;
using System.Net.Http;
using WebApiTest.Extensions;
using WebApiTest.Commands;
using System.Net;
using Newtonsoft.Json;

namespace WebApiTest.Controllers
{
    [Authorize]
    [RoutePrefix("api/schedule")]
    public class ScheduleController:BasicApiController {
        private readonly IScheduleService _service;
        
        public ScheduleController(IScheduleService service) {
            _service = service;
        }

        [HttpGet, Route("{id}")]
        public ScheduleViewModel Get([FromUri]int id) {
            var item = _service.ById(id);
            return item;
        }

        [HttpPut, Route]
        public HttpResponseMessage Put(ScheduleCreateViewModel model) {
            if(ModelState.IsValid) {
                var item = _service.Execute(model.ToCommand());
                return Accepted(item.Entity);
            }
            return Bad(ModelState);
        }

        [HttpPost, Route]
        public HttpResponseMessage Post(ScheduleUpdateViewModel model) {
            if(ModelState.IsValid) {
                var item = _service.Execute(model.ToCommand());
                return Accepted(item);
            }
            return Bad(ModelState);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage Delete([FromUri]int id) {
            if(ModelState.IsValid) {
                var item = _service.Execute(new ScheduleDeleteCommand() { Id = id });
                return Accepted(item);
            }
            return Bad(ModelState);
        }
    }
}