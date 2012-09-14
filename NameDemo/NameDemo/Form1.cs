using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NameDemo.JustWareApi;

namespace NameDemo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			APICommunicator communicator = new APICommunicator();
			List<Name> names = communicator.QueryForName(textBox1.Text);

			List<string> nameList = names.Select(n => n.FullName).ToList();

			listBox1.DataSource = nameList;

		}

		private void button2_Click(object sender, EventArgs e)
		{
			APICommunicator communicator = new APICommunicator();
			int newNameID = communicator.InsertNewName(tbFirstName.Text, tbLastName.Text);
			MessageBox.Show("New Name inserted with ID: " + newNameID);

			tbFirstName.Text = "";
			tbLastName.Text = "";
		}
	}
}
