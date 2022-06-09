using System;
using System.Windows.Forms;
using lib;
using Models;
using Controllers;
using System.Drawing;

namespace Views
{
    public class UsuarioView : Form
    {

        ListView listView;
        Button bttnReturn;
        Button bttnInsert;
        Button bttnDelete;
        Button bttnUpdate;

        public UsuarioView()
        {

            bttnReturn = new Generic.FieldOnButton("Voltar", 25, 450, 100, 30);
			bttnReturn.Click += new EventHandler(this.bttnReturnClick);
            
            bttnInsert = new Generic.FieldOnButton("Cadastrar", 130, 450, 100, 30);
            bttnInsert.Click += new EventHandler(this.bttnInsertClick);

            bttnDelete = new Generic.FieldOnButton("Deletar", 235, 450, 100, 30);
			bttnDelete.Click += new EventHandler(this.bttnDeleteClick);

            bttnUpdate = new Generic.FieldOnButton("Editar", 345, 450, 100, 30);
            bttnUpdate.Click += new EventHandler(this.bttnUpdateClick);

        // Select dos registros

            listView = new Generic.ViewOnFieldList(25, 25, 450, 400);
			listView.View = View.Details;
			foreach(Usuario item in UsuarioController.VisualizarUsuario())
            {
                ListViewItem list = new ListViewItem(item.Id + "");
                list.SubItems.Add(item.Nome);	
                list.SubItems.Add(item.Email);
                listView.Items.AddRange(new ListViewItem[]{list});
            }
			listView.Columns.Add("Id", -2, HorizontalAlignment.Left);
    		listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Email", -2, HorizontalAlignment.Left);
            
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.AllowColumnReorder = true;
			listView.Sorting = SortOrder.Ascending;

            this.Controls.Add(this.listView);
            this.Controls.Add(this.bttnReturn);
            this.Controls.Add(this.bttnInsert);
            this.Controls.Add(this.bttnDelete);
            this.Controls.Add(this.bttnUpdate);
        }

        // Funções dos botões
       private void bttnInsertClick(object sender, EventArgs e)
        {
            new UserForm(Function.Create).Show();
        }

        private void bttnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                new UserForm(Function.Update, Convert.ToInt32(selectedItem.Text)).Show();
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void bttnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                UsuarioController.ExcluirUsuario(Convert.ToInt32(selectedItem.Text)); 
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
            
        }

        private void bttnReturnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}