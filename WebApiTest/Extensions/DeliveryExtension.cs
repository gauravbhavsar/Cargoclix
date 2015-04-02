using System;
using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.ViewModels;
namespace WebApiTest.Extensions {
    public static class DeliveryExtentions {

        public static DeliveryViewModel ToDeliveryViewModels(this Delivery x) {
            var result = new DeliveryViewModel {
                Id = x.Id,
                deliveredTime = x.deliveredTime,
                deliveredTo = x.deliveredTo,
                IsDelivered = x.IsDelivered
            };
            return result;
        }

        public static DeliveryCreateCommand ToCommand(this DeliveryCreateViewModel model) {
            return new DeliveryCreateCommand() {
                deliveredTime = model.deliveredTime,
                deliveredTo = model.deliveredTo,
                IsDelivered = model.IsDelivered
            };
        }

        public static DeliveryUpdateCommand ToCommand(this DeliveryUpdateViewModel model) {
            return new DeliveryUpdateCommand() {
                deliveredTo = model.deliveredTo,
                IsDelivered = model.IsDelivered
            };
        }

        public static Delivery ToEntity(this DeliveryCreateCommand command) {
            var entity = new Delivery {
                deliveredTime = command.deliveredTime,
                deliveredTo = command.deliveredTo,
                IsDelivered = command.IsDelivered
            };
            return entity;
        }

        public static Delivery ToEntity(this DeliveryUpdateCommand command, Delivery entity) {
            entity.Id = command.Id;
            entity.IsDelivered = command.IsDelivered;
            return entity;
        }
    }
}