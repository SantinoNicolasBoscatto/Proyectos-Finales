using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NotesApp.Application.Contracts.Security;
using NotesApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Security
{
    public class SecurityTokenConstructor : ISecurityTokenConstructor
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration configuration;
        public SecurityTokenConstructor(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario cred)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", cred.Email)
            };
            var usuario = await _userManager.FindByEmailAsync(cred.Email);
            claims.AddRange(await _userManager.GetClaimsAsync(usuario!));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var exp = DateTime.UtcNow.AddHours(12);
            var token = new JwtSecurityToken(issuer: null, audience: null, expires: exp, claims: claims, signingCredentials: creds);

            return new RespuestaAutenticacion
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = exp
            };
        }
    }
}
