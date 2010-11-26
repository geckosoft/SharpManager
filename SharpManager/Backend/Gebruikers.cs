using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpManager.Backend
{
	public static class Gebruikers
	{
		public static Gebruiker Login(string gebruikersnaam)
		{
			var user = Global.Backend.Gebruikers.Where(g => g.GebruikerNaam == gebruikersnaam).First();

			user.LaatsteLogin = DateTime.Now;
			user.AantalLogins++;

			Global.Backend.SubmitChanges();

			return user;
		}
	}
}
