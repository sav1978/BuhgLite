using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuhgLite
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(Globals.DbName))
            {
                SQLiteConnection.CreateFile(Globals.DbName);

                using (Globals.Connection = new SQLiteConnection("Data Source=" + Globals.DbName + ";Version=3;"))
                {
                    Globals.Connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(Globals.Connection))
                    {
                        command.CommandText = @"CREATE TABLE Persons (
                                                id integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                                                name CHAR(30) NOT NULL,
                                                surname CHAR(30) NOT NULL);";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }

            Globals.Connection = new SQLiteConnection("Data Source=" + Globals.DbName + ";Version=3;");
            Globals.Connection.Open();
        }

        private void btnPersons_Click(object sender, EventArgs e)
        {
            PersonsForm frmPersons = new PersonsForm();
            frmPersons.ShowDialog();
        }

   }
}
