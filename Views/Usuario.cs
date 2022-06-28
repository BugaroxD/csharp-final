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

            bttnReturn = new Generic.FieldOnButton("Voltar", 25, 450, 100, 30);
			bttnReturn.Click += new EventHandler(this.ClickOnReturnBttn);
            
            bttnInsert = new Generic.FieldOnButton("Cadastrar", 130, 450, 100, 30);
            bttnInsert.Click += new EventHandler(this.ClickOnInsertBttn);

            bttnDelete = new Generic.FieldOnButton("Deletar", 235, 450, 100, 30);
			bttnDelete.Click += new EventHandler(this.ClickOnDeleteBttn);

            bttnUpdate = new Generic.FieldOnButton("Editar", 345, 450, 100, 30);
            bttnUpdate.Click += new EventHandler(this.ClickOnUpdateBttn);

        // Select dos registros

            string[] fields = {"Nome", "Descricao"};
            this.listaView = new LabelListView<Models.Categoria>(this.Controls, "Lista de Categorias", Models.Categoria.ListaCategoria(), fields);

            this.components = new System.ComponentModel.Container();

            this.Controls.Add(this.listView);
            this.Controls.Add(this.bttnReturn);
            this.Controls.Add(this.bttnInsert);
            this.Controls.Add(this.bttnDelete);
            this.Controls.Add(this.bttnUpdate);
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
