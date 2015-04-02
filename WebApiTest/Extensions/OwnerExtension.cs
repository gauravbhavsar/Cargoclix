using System;
using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.ViewModels;
namespace WebApiTest.Extensions {
    public static class OwnerExtentions {

        public static OwnerViewModel ToOwnerViewModels(this Owner x) {
            var result = new OwnerViewModel {
                Email = x.Email,
                Id = int.Parse(x.Id),
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName,
            };
            return result;
        }

        public static OwnerCreateCommand ToCommand(this OwnerCreateViewModel model) {
            return new OwnerCreateCommand() {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
        }

        public static OwnerUpdateCommand ToCommand(this OwnerUpdateViewModel model) {
            return new OwnerUpdateCommand() {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
            };
        }

        public static Owner ToEntity(this OwnerCreateCommand command) {
            var entity = new Owner {
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                UserName = command.UserName,
            };
            return entity;
        }

        public static Owner ToEntity(this OwnerUpdateCommand command, Owner entity) {
            entity.Email = command.Email;
            entity.PhoneNumber = command.PhoneNumber;
            entity.UserName = command.UserName;
            return entity;
        }
    }
}