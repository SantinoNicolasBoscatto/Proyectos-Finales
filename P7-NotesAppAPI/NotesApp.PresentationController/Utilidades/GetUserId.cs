using Microsoft.AspNetCore.Identity;
using NotesApp.Application.Excepciones;

namespace NotesApp.PresentationController.Utilidades
{
    public static class GetUserId
    {
        public static async Task<string> Get(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            var claim = httpContextAccessor.HttpContext!.User.Claims.Where(x => x.Type == "email").FirstOrDefault();
            var email = claim!.Value;
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) throw new GenericException("Usuario no encontrado");
            return user!.Id;
        }
    }
}
