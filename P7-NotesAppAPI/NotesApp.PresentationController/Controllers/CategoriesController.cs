using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;
using NotesApp.Application.Features.Categorys.Commands.DeleteCategory;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;
using NotesApp.Application.Features.Categorys.Queries;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.Domain;
using NotesApp.PresentationController.Controllers.GenericController;
using NotesApp.PresentationController.Utilidades;

namespace NotesApp.PresentationController.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class CategoriesController : GenericControllers
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {}

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await GetAllBase<Category, GetCategoriesQuery>();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreateCategoryCommand createCategory)
        {
            return await PostBase<CreateCategoryCommand>(createCategory);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Post([FromForm] UpdateCategoryCommand updateCategory, int id)
        {
            updateCategory.Id = id;
            return await PutBase<UpdateCategoryCommand>(updateCategory);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await DeleteBase<DeleteCategoryCommand>(new DeleteCategoryCommand { Id = id});
        }
    }
}
