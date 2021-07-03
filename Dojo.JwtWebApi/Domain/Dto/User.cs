// Dojo/Dojo.JwtWebApi/User.cs/03/07/2021

namespace Dojo.JwtWebApi.Domain.Dto
{
	public class User
	{

		public User(int id, string password, string role, string username)
		{
			Id = id;
			Password = password;
			Role = role;
			Username = username;
		}

		public User(int id, string password, string role, string username, string token)
		{
			Id = id;
			Password = password;
			Role = role;
			Username = username;
			Token = token;
		}

		public User()
		{
			
		}

		public int Id { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public string Token { get; set; }
		public string Username { get; set; }
	}
}
