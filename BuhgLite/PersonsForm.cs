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
    public partial class PersonsForm : Form
    {
        DataTable tblPersons = new DataTable();
        SQLiteDataAdapter daPersons;
        BindingSource bsPersons;

        public PersonsForm()
        {
            InitializeComponent();
        }

        private void PersonsForm_Load(object sender, EventArgs e)
        {
                        
            string strCommandText = "SELECT * FROM Persons ORDER BY id;";

            daPersons = new SQLiteDataAdapter(strCommandText, Globals.Connection);
            daPersons.InsertCommand = Globals.Connection.CreateCommand();
            daPersons.InsertCommand.CommandText = "INSERT INTO Persons (name, surname) VALUES (@name, @surname);";
            daPersons.InsertCommand.Parameters.Add("@name", DbType.String, 30, "name");
            daPersons.InsertCommand.Parameters.Add("@surname", DbType.String, 30, "surname");
            daPersons.UpdateCommand = Globals.Connection.CreateCommand();
            daPersons.UpdateCommand.CommandText = "UPDATE Persons SET name=@name, surname=@surname WHERE id=@id;";
            daPersons.UpdateCommand.Parameters.Add("@name", DbType.String, 30, "name");
            daPersons.UpdateCommand.Parameters.Add("@surname", DbType.String, 30, "surname");
            daPersons.UpdateCommand.Parameters.Add("@id", DbType.UInt16, 3, "id");
            daPersons.DeleteCommand = Globals.Connection.CreateCommand();
            daPersons.DeleteCommand.CommandText = "DELETE FROM Persons WHERE id=@id;";
            daPersons.DeleteCommand.Parameters.Add("@id", DbType.UInt16, 3, "id");

            daPersons.Fill(tblPersons);

            bsPersons = new BindingSource();
            bsPersons.DataSource = tblPersons;

            dgvPersons.AutoGenerateColumns = false;
            dgvPersons.DataSource = bsPersons;
            
        }

        private void dgvPersons_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            daPersons.Update(tblPersons);
        }

    }
}
