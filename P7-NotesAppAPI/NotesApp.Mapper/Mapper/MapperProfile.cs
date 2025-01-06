using AutoMapper;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.Application.Features.Notes.Commands.UpdateNote;
using NotesApp.Application.Features.ToDoTasks.Commands.CreateToDoTask;
using NotesApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;
using NotesApp.Domain;
using NotesApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<StatusModel, Status>().ReverseMap();
            CreateMap<PriorityModel, Priority>().ReverseMap();

            CreateMap<Note, NoteModel>().ReverseMap();
            CreateMap<ToDoTask, ToDoTaskModel>().ReverseMap();
            CreateMap<Expression<Func<Note, bool>>, Expression<Func<NoteModel, bool>>>().ReverseMap();
        }
    }
}
