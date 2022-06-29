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
        Button bttnInsert;
        Button bttnUpdate;
        Button bttnReturn;
        Button bttnDelete;
        

        public UsuarioView()
        {
            this.ClientSize = new System.Drawing.Size(470, 470);
            this.Text = "Usuários";

            bttnInsert = new Generic.FieldOnButton("Cadastrar", 35, 450, 100, 45);
            bttnInsert.Click += new EventHandler(this.ClickOnInsertBttn);

            bttnUpdate = new Generic.FieldOnButton("Editar", 155, 450, 100, 45);
            bttnUpdate.Click += new EventHandler(this.ClickOnUpdateBttn);

            bttnReturn = new Generic.FieldOnButton("Voltar", 275, 450, 100, 45);
			bttnReturn.Click += new EventHandler(this.ClickOnReturnBttn);
      
            bttnDelete = new Generic.FieldOnButton("Deletar", 275, 450, 100, 45);
			bttnDelete.Click += new EventHandler(this.ClickOnDeleteBttn);

           
        // Select dos registros

            string[] generics = {"Nome", "Email"};
            this.listView = new ListViewItems<Models.Usuario>(this.Controls, "Lista de Usuarios", Models.Usuario.GetUsuarios(), generics);

            this.Controls.Add(this.bttnInsert);
            this.Controls.Add(this.bttnUpdate);
            this.Controls.Add(this.bttnReturn);
            this.Controls.Add(this.bttnDelete);
            
        }

        // Funções dos botões
       private void ClickOnInsertBttn(object sender, EventArgs e)
        {
            new UserForm(Function.Create).Show();
        }

        private void ClickOnUpdateBttn(object sender, EventArgs e)
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

        private void ClickOnDeleteBttn(object sender, EventArgs e)
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

        private void ClickOnReturnBttn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
