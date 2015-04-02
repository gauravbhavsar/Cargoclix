using System;
using WebApiTest.Commands;
using WebApiTest.Models;
using WebApiTest.ViewModels;
namespace WebApiTest.Extensions {
    public static class NotesExtentions {

        public static NotesViewModel ToNotesViewModels(this Notes x) {
            var result = new NotesViewModel {
                Id = x.Id,
                Comment = x.Comment,
                ScheduleId = x.ScheduleId
            };
            return result;
        }

        public static NotesCreateCommand ToCommand(this NotesCreateViewModel model) {
            return new NotesCreateCommand() {
                Comment = model.Comment,
                ScheduleId = model.ScheduleId
            };
        }

        public static NotesUpdateCommand ToCommand(this NotesUpdateViewModel model) {
            return new NotesUpdateCommand() {
                Comment = model.Comment,
                ScheduleId = model.ScheduleId,
            };
        }

        public static Notes ToEntity(this NotesCreateCommand command) {
            var entity = new Notes {
                Comment = command.Comment,
                ScheduleId = command.ScheduleId,
            };
            return entity;
        }

        public static Notes ToEntity(this NotesUpdateCommand command, Notes entity) {
            entity.Id = command.Id;
            entity.Comment = command.Comment;
            return entity;
        }
    }
}