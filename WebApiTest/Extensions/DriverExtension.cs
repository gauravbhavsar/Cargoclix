using System;
using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.ViewModels;
namespace WebApiTest.Extensions {
    public static class DriverExtentions {

        public static DriverViewModel ToDriverViewModels(this Driver x) {
            var result = new DriverViewModel {
                Email = x.Email,
                Id = int.Parse(x.Id),
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName,
            };
            return result;
        }

        public static DriverCreateCommand ToCommand(this DriverCreateViewModel model) {
            return new DriverCreateCommand() {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
        }

        public static DriverUpdateCommand ToCommand(this DriverUpdateViewModel model) {
            return new DriverUpdateCommand() {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
            };
        }

        public static Driver ToEntity(this DriverCreateCommand command) {
            var entity = new Driver {
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                UserName = command.UserName,
            };
            return entity;
        }

        public static Driver ToEntity(this DriverUpdateCommand command, Driver entity) {
            entity.Email = command.Email;
            entity.PhoneNumber = command.PhoneNumber;
            entity.UserName = command.UserName;
            return entity;
        }
    }
}