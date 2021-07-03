// Dojo/Dojo.JwtWebApi/UsersRepository.cs/03/07/2021

#region USINGS

using System;
using System.Collections.Generic;
using System.Linq;

using Dojo.JwtWebApi.Domain.Dto;

#endregion

namespace Dojo.JwtWebApi.Domain.Repository
{
	public class UsersRepository
	{

		public User GetUser(string username, string password)
		{
			var users = new List<User>
			{
				new User(1, "teste", "Admin", "Administrador"),
				new User(2, "teste123", "User", "Usuario"),
			};

			return users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.CurrentCultureIgnoreCase) && u.Password == password);
		}
	}
}
