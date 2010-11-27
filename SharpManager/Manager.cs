using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpManager
{
	public partial class Manager : Form
	{
		private int childFormNumber = 0;

		public Manager()
		{
			InitializeComponent();
		}

		private void ShowNewForm(object sender, EventArgs e)
		{
			Form childForm = new Form();
			childForm.MdiParent = this;
			childForm.Text = "Window " + childFormNumber++;
			childForm.Show();
		}

		private void OpenFile(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string FileName = openFileDialog.FileName;
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string FileName = saveFileDialog.FileName;
			}
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				childForm.Close();
			}
		}

		private void gebruikersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var db = new BackendDataContext();

			var users = db.Gebruikers.Where(g => g.GebruikerId == 1).First();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.IsMdiContainer = true;
		}

		private void tabPage4_Click(object sender, EventArgs e)
		{

		}

		private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void transparantToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void tmrInit_Tick(object sender, EventArgs e)
		{
			toolStrip2.BackColor = telStripNummers.BackColor = Color.FromArgb(0, Color.White);
		}

		#region Telefoonboek
		public void TelSwitchVelden(bool nieuw)
		{
			telAdres.Enabled =
				telBedrijf.Enabled = telNaam.Enabled = telPostcode.Enabled = telVoornaam.Enabled = TelGemeente.Enabled = nieuw;
		}

		public void TelSwitchVelden()
		{
			TelSwitchVelden(!telAdres.Enabled);
		}

		public void TelClearVelden()
		{
			currentContact = null;

			telNaam.Text = telVoornaam.Text = TelGemeente.Text = telPostcode.Text = telAdres.Text = telBedrijf.Text = "";
		}

		public void TelWijzigButton(bool isNieuw)
		{
			if (isNieuw)
				telBtnWijzig.Text = "&Opslaan";
			else
				telBtnWijzig.Text = "&Wijzigen";

			telBtnWijzig.Tag = isNieuw;
			telBtnWijzig.Enabled = true;

			telBtnVerwijder.Enabled = !isNieuw;
		}

		public void TelTabSelected()
		{
			// Haal contacten opnieuw op
			TelRefreshContacten();
		}

		public void TelRefreshContacten()
		{
			TelRefreshContacten("");
		}



		public class TelefoonNummerWrapper
		{
			public Telefoonnummer Nummer;

			public TelefoonNummerWrapper(Telefoonnummer nummer)
			{
				Nummer = nummer;
			}

			public override string ToString()
			{
				return (string.IsNullOrEmpty(Nummer.NummerType)) ? Nummer.Nummer : Nummer.Nummer + " (" + Nummer.NummerType + ")";
			}
		}

		private void TelLoadContact(Contact contact)
		{
			telAdres.Text = contact.Adres;
			telNaam.Text = contact.Naam;
			telVoornaam.Text = contact.Voornaam;
			TelGemeente.Text = contact.Gemeente;
			telPostcode.Text = contact.Postcode;
			telBedrijf.Text = contact.Bedrijf;

			telBtnVerwijder.Enabled = true;
			// laad telefoonnummers
			telLstNummers.Items.Clear();

			var telNummers = Global.Backend.Telefoonnummers.Where(t => t.ContactId == contact.ContactId);
			foreach (var telefoonnummer in telNummers)
			{
				telLstNummers.Items.Add(new TelefoonNummerWrapper(telefoonnummer));
			}
			
			telBtnTelNieuw.Enabled = true;
			TelSwitchTelefoonVelden(false);
			TelWijzigTelefoonButton(false);
		}

		public class ContactWrapper
		{
			public Contact Contact;

			public ContactWrapper(Contact contact)
			{
				Contact = contact;
			}

			public override string ToString()
			{
				return Contact.Naam + " " + Contact.Voornaam;
			}
		}

		public void TelRefreshContacten(string searchString)
		{
			Table<Contact> contacten;

			if (string.IsNullOrEmpty(searchString))
			{
				contacten = Global.Backend.Contacts;
				lstTelefoonboek.Items.Clear();

				foreach (var contact in contacten)
				{
					lstTelefoonboek.Items.Add(new ContactWrapper(contact));
				}
				return;
			}

			var searchResult =
				Global.Backend.Contacts.Where(
					c => c.Naam.ToLower().Contains(searchString.ToLower()) || c.Voornaam.ToLower().Contains(searchString.ToLower()));

			lstTelefoonboek.Items.Clear();

			foreach (var contact in searchResult)
			{
				lstTelefoonboek.Items.Add(new ContactWrapper(contact));
			}
		}

		#endregion

		private void telBtnNieuw_Click(object sender, EventArgs e)
		{
			TelSwitchVelden(true);
			TelClearVelden();
			TelWijzigButton(true);

		}

		private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tabMain.SelectedIndex)
			{
				case 0: // overzicht
					break;

				case 1:
					TelTabSelected();
					break;
			}
		}

		Contact currentContact = null;

		private void telBtnWijzig_Click(object sender, EventArgs e)
		{
			if (telBtnWijzig.Tag != null && (bool)telBtnWijzig.Tag)
			{
				// Opslaan (nieuw)
				if (currentContact == null)
				{
					var contact = new Contact();
					contact.Adres = telAdres.Text;
					contact.Gemeente = TelGemeente.Text;
					contact.Naam = telNaam.Text;
					contact.Voornaam = telVoornaam.Text;
					contact.Postcode = telPostcode.Text;
					contact.Bedrijf = telBedrijf.Text;

					Global.Backend.Contacts.InsertOnSubmit(contact);
					Global.Backend.SubmitChanges();

					TelWijzigButton(false);
					TelSwitchVelden(false);
					currentContact = contact;
					TelRefreshContacten(telTxtSearch.Text);
				}else
				{ 
					// wijzigingen opslaan
					var contact = currentContact;
					contact.Adres = telAdres.Text;
					contact.Gemeente = TelGemeente.Text;
					contact.Naam = telNaam.Text;
					contact.Voornaam = telVoornaam.Text;
					contact.Postcode = telPostcode.Text;
					contact.Bedrijf = telBedrijf.Text;

					Global.Backend.SubmitChanges();

					TelWijzigButton(false);
					TelSwitchVelden(false);
					TelRefreshContacten(telTxtSearch.Text);
				}

				TelLoadContact(currentContact);
			}else
			{
				// edit current
				if (currentContact == null)
					return;

				TelWijzigButton(true);
				TelSwitchVelden(true);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			TelRefreshContacten(telTxtSearch.Text);
		}

		private void lstTelefoonboek_SelectedIndexChanged(object sender, EventArgs e)
		{
			var wrapper = lstTelefoonboek.SelectedItem as ContactWrapper;
			if (wrapper == null) return;

			currentContact = wrapper.Contact;

			TelLoadContact(currentContact);
			TelWijzigButton(false);
			TelSwitchVelden(false);

		}

		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{

		}

		private Telefoonnummer currentTelefoonnummer;


		public void TelSwitchTelefoonVelden(bool nieuw)
		{
			telNummer.ReadOnly = !nieuw;
			telNummerType.Enabled = nieuw;
		}

		public void TelSwitchTelefoonVelden()
		{
			TelSwitchTelefoonVelden(!telNummerType.Enabled);
		}

		public void TelClearTelefoonVelden()
		{
			currentTelefoonnummer = null;

			telNummer.Text = "";
			telNummerType.SelectedText = "";
		}

		public void TelWijzigTelefoonButton(bool isNieuw)
		{
			telBtnTelWijzig.Enabled = false;

			if (isNieuw)
			{
				telBtnTelWijzig.Text = "&Opslaan";
				telBtnTelWijzig.Enabled = true;
			}
			else
				telBtnTelWijzig.Text = "&Wijzigen";

			telBtnTelWijzig.Tag = isNieuw;
		}

		private void telBtnTelNieuw_Click(object sender, EventArgs e)
		{
			TelClearTelefoonVelden();
			TelSwitchTelefoonVelden(true);
			TelWijzigTelefoonButton(true);
		}

		private void textBox1_BorderStyleChanged(object sender, EventArgs e)
		{

		}

		private void telBtnVerwijder_Click(object sender, EventArgs e)
		{
			if (currentContact == null)
				return;

			Global.Backend.Contacts.DeleteOnSubmit(currentContact);
			Global.Backend.SubmitChanges();

			currentContact = null;

			TelClearTelefoonVelden();
			TelSwitchTelefoonVelden(false);
			telBtnTelWijzig.Enabled = false;

			TelRefreshContacten(telTxtSearch.Text);
			telBtnVerwijder.Enabled = false;
		}
	}
}
