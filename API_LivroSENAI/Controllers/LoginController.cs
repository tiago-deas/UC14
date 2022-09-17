using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API_LivroSENAI.Interfaces;
using API_LivroSENAI.ViewModels;
using API_LivroSENAI.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace API_LivroSENAI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IusuarioRepository _iusuarioRepository;
        private IusuarioRepository? iUsuarioRepository;

        public LoginController(IusuarioRepository iUsarioRepository)
        {
            _iusuarioRepository = iUsuarioRepository;
        }

        [HttpGet]   

        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuario usuarioBuscado = _iusuarioRepository.Login(dadosLogin.email, dadosLogin.senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new {msg = "E-mail e/ou Senha incorretos"});
                }

                var minhasClains = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("API_LivroSENAI-autenticacao"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                    issuer: "API_LivrosSENAI", 
                    audience: "API_LivrosSENAI",
                    claims: minhasClains,   
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credenciais
                    );

                return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(meuToken)});
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
