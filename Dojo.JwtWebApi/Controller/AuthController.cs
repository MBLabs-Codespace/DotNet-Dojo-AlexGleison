// Dojo/Dojo.JwtWebApi/AuthController.cs/03/07/2021

#region USINGS

using System.Threading.Tasks;

using Dojo.JwtWebApi.Domain.Dto;
using Dojo.JwtWebApi.Domain.Repository;
using Dojo.JwtWebApi.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Dojo.JwtWebApi.Controller {


	public class AuthController : ControllerBase {

		[HttpPost]
		[Route("login")]
		public ActionResult<dynamic> Authenticate([FromBody] User model) {
			
			var user = new UsersRepository().GetUser(model.Username, model.Password);

			if (user == null)
				return NotFound(new { message = "Usuário ou senha inválidos" });

			var token = TokenService.GenerateToken(user);

			user.Password = "";

			return new {
				user = user,
				token = token
			};
		}

		[Authorize]
		[HttpGet]
		public ActionResult<User> GetInfo()
		{
			return new User();
		}
	}
}
