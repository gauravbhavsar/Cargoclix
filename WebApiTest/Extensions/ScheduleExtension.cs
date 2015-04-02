using System;
using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.ViewModels;
namespace WebApiTest.Extensions {
    public static class ScheduleExtentions {

        public static ScheduleViewModel ToScheduleViewModels(this Schedule x) {
            var result = new ScheduleViewModel {
                Id = x.Id,
                Created = x.Created,
                DriverId = x.DriverId,
                OwnerId = x.OwnerId,
                Task = x.Task,
                When = x.When
            };
            return result;
        }

        public static ScheduleCreateCommand ToCommand(this ScheduleCreateViewModel model) {
            return new ScheduleCreateCommand() {
                DriverId = model.DriverId,
                OwnerId = model.OwnerId,
                Task = model.Task,
                When = model.When
            };
        }

        public static ScheduleUpdateCommand ToCommand(this ScheduleUpdateViewModel model) {
            return new ScheduleUpdateCommand() {
                Task = model.Task,
                When = model.When,
            };
        }

        public static Schedule ToEntity(this ScheduleCreateCommand command) {
            var entity = new Schedule {
                Created = DateTime.UtcNow,
                DriverId = command.DriverId,
                OwnerId = command.OwnerId,
                Task = command.Task,
                When = DateTime.UtcNow
            };
            return entity;
        }

        public static Schedule ToEntity(this ScheduleUpdateCommand command, Schedule entity){
            entity.Id = command.Id;
            entity.DriverId = command.DriverId;
            entity.OwnerId = command.OwnerId;
            entity.Task = command.Task;
            entity.When = command.When;
            return entity;
        }
    }
}