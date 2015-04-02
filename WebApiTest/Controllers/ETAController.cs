using System.Web.Http;
using WebApiTest.Services;
using WebApiTest.ViewModels;
using System.Net.Http;
using WebApiTest.Extensions;
using WebApiTest.Commands;

namespace WebApiTest.Controllers {
    [Authorize]
    [RoutePrefix("api/eta")]
    public class ETAController:BasicApiController {
        private readonly IETAService _service;

        public ETAController(IETAService service) {
            _service = service;
        }

        [HttpGet, Route("{id}")]
        public ETAViewModel Get([FromUri]int id) {
            var item = _service.ById(id);
            return item;
        }

        [HttpPut, Route]
        public HttpResponseMessage Put(ETACreateViewModel model) {
            if(ModelState.IsValid) {
                var item = _service.Execute(model.ToCommand());
                return Accepted(item.Entity);
            }
            return Bad(ModelState);
        }

        [HttpPost, Route]
        public HttpResponseMessage Post(ETAUpdateViewModel model) {
            if(ModelState.IsValid) {
                var item = _service.Execute(model.ToCommand());
                return Accepted(item);
            }
            return Bad(ModelState);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage Delete([FromUri]int id) {
            if(ModelState.IsValid) {
                var item = _service.Execute(new ETADeleteCommand() { Id = id });
                return Accepted(item);
            }
            return Bad(ModelState);
        }
    }
}