using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpManager.Backend;

namespace SharpManager
{
	public partial class FrmLogin : Form
	{
		public FrmLogin()
		{
			InitializeComponent();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void FrmLogin_Load(object sender, EventArgs e)
		{
			Global.Backend = new BackendDataContext();

			lstGebruiker.Items.AddRange(Global.Backend.Gebruikers.Select(g => g.GebruikerNaam).ToArray());

			if (lstGebruiker.Items.Count == 0)
			{
				Application.Exit();
			}

			lstGebruiker.SelectedIndex = 0;
		}

		private void btnInloggen_Click(object sender, EventArgs e)
		{
			Global.Gebruiker = Gebruikers.Login(lstGebruiker.SelectedItem.ToString());

			Hide();


			if (Global.Gebruiker != null)
				(new Manager()).ShowDialog();

			Close();
		}

		private void btnSluiten_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
