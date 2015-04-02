using System.Web.Http;
using WebApiTest.Services;
using WebApiTest.ViewModels;
using System.Linq;
using System.Net.Http;
using WebApiTest.Extensions;
using WebApiTest.Commands;
using System.Net;
using Newtonsoft.Json;

namespace WebApiTest.Controllers {
    [Authorize]
    [RoutePrefix("api/delivery")]
    public class DeliveryController:BasicApiController {
        private readonly IDeliveryService _service;

        public DeliveryController(IDeliveryService service) {
            _service = service;
        }

        [HttpGet, Route("{id}")]
        public DeliveryViewModel Get([FromUri]int id) {
            var item = _service.ById(id);
            return item;
        }

        [HttpPut, Route]
        public HttpResponseMessage Put(DeliveryCreateViewModel model) {
            if(ModelState.IsValid) {
                var item = _service.Execute(model.ToCommand());
                return Accepted(item.Entity);
            }
            return Bad(ModelState);
        }

        [HttpPost, Route]
        public HttpResponseMessage Post(DeliveryUpdateViewModel model) {
            if(ModelState.IsValid) {
                var item = _service.Execute(model.ToCommand());
                return Accepted(item);
            }
            return Bad(ModelState);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage Delete([FromUri]int id) {
            if(ModelState.IsValid) {
                var item = _service.Execute(new DeliveryDeleteCommand() { Id = id });
                return Accepted(item);
            }
            return Bad(ModelState);
        }
    }
}