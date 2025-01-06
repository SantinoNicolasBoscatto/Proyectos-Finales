using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Application.Contracts.Security;
using NotesApp.Application.Excepciones;
using NotesApp.Domain.Users;
using System.Security.Claims;

namespace NotesApp.PresentationController.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserControllers : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ISecurityTokenConstructor _tokenConstructor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserControllers(UserManager<IdentityUser> userManager, ISecurityTokenConstructor tokenConstructor, SignInManager<IdentityUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _tokenConstructor = tokenConstructor;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<RespuestaAutenticacion>> Registrar([FromForm]CredencialesUsuario cred)
        {
            var user = new IdentityUser { UserName = cred.Email, Email = cred.Email };
            var result = await _userManager.CreateAsync(user, cred.Password);
            if (!result.Succeeded) return BadRequest(result);
            return await _tokenConstructor.ConstruirToken(cred);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<RespuestaAutenticacion>> Login([FromForm] CredencialesUsuario cred)
        {
            var result = await _signInManager.PasswordSignInAsync(cred.Email!, cred.Password!, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded) return await _tokenConstructor.ConstruirToken(cred);
            else return BadRequest(result);
        }

        [HttpGet("renovartoken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RespuestaAutenticacion>> Renovar()
        {
            var claim = HttpContext.User.Claims.Where(x => x.Type == "email").FirstOrDefault();
            var email = claim!.Value;
            var credenciales = new CredencialesUsuario
            {
                Email = email
            };
            return await _tokenConstructor.ConstruirToken(credenciales);
        }

        [HttpPost("haceradmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
        public async Task<ActionResult> HacerAdmin(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);
            if (usuario == null) throw new GenericException("Usuario no encontrado");
            await _userManager.AddClaimAsync(usuario!, new Claim("EsAdmin", "1"));
            return NoContent();
        }

    }
}
