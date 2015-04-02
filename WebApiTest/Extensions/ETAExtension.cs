using System;
using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.ViewModels;
namespace WebApiTest.Extensions {
    public static class ETAExtentions {

        public static ETAViewModel ToETAViewModels(this ETA x) {
            var result = new ETAViewModel {
                Id = x.Id,
                DeliveryId = x.DeliveryId,
                Reason = x.Reason,
                ReasonEnum = x.ReasonEnum,
                When = x.When
            };
            return result;
        }

        public static ETACreateCommand ToCommand(this ETACreateViewModel model) {
            return new ETACreateCommand() {
                DeliveryId = model.DeliveryId,
                Reason = model.Reason,
                ReasonEnum = model.ReasonEnum,
                When = model.When
            };
        }

        public static ETAUpdateCommand ToCommand(this ETAUpdateViewModel model) {
            return new ETAUpdateCommand() {
                 Reason  =model.Reason,
                 ReasonEnum = model.ReasonEnum,
                 When = model.When
            };
        }

        public static ETA ToEntity(this ETACreateCommand command) {
            var entity = new ETA {
                DeliveryId = command.DeliveryId,
                Reason = command.Reason,
                ReasonEnum = command.ReasonEnum,
                When = command.When
            };
            return entity;
        }

        public static ETA ToEntity(this ETAUpdateCommand command, ETA entity) {
            entity.Id = command.Id;
            entity.Reason = command.Reason;
            entity.ReasonEnum  = command.ReasonEnum;
            entity.When = command.When;
            return entity;
        }
    }
}