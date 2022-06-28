using System;
using System.Windows.Forms;
using System.Drawing;
using Models;
using Controllers;
using lib;

namespace Views
{
    public class CategoriaView : Form
    {
        private System.ComponentModel.IContainer components = null;
        ListView listView;
        Button bttnInsert;
        Button bttnUpdate;
        Button bttnReturn;
        Button bttnDelete;
        

        public CategoriaView() 
        {
            this.ClientSize = new System.Drawing.Size(470, 470);
            this.Text = "Categorias";

            bttnInsert = new Generic.FieldOnButton("Cadastrar", 130, 450, 100, 30);
            bttnInsert.Click += new EventHandler(this.ClickOnInsertBttn);

            bttnUpdate = new Generic.FieldOnButton("Editar", 345, 450, 100, 30);
            bttnUpdate.Click += new EventHandler(this.ClickOnUpdateBttn);

            bttnReturn = new Generic.FieldOnButton("Voltar", 25, 450, 100, 30);
			bttnReturn.Click += new EventHandler(this.ClickOnReturnBttn);
      
            bttnDelete = new Generic.FieldOnButton("Deletar", 235, 450, 100, 30);
			bttnDelete.Click += new EventHandler(this.ClickOnDeleteBttn);

        // Select dos registros

            string[] fields = {"Nome", "Descricao"};
            this.listaView = new LabelListView<Models.Categoria>(this.Controls, "Lista de Categorias", Models.Categoria.ListaCategoria(), fields);

            this.components = new System.ComponentModel.Container();

            this.Controls.Add(listView);
            this.Controls.Add(bttnInsert);
            this.Controls.Add(bttnUpdate);
            this.Controls.Add(bttnReturn);
            this.Controls.Add(bttnDelete);
            
        }

        private void ClickOnInsertBttn(object sender, EventArgs e)
        {
            new FormCategoria(Operation.Create).Show();
            this.Dispose();
        }

        private void ClickOnUpdateBttn(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                new FormCategoria(Operation.Update, Convert.ToInt32(selectedItem.Text)).Show();
                this.Dispose();
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
                int categoriaId = Convert.ToInt32(selectedItem.Text);
                DialogResult result = MessageBox.Show($"Deseja excluir a categoria {categoriaId}?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    CategoriaController.RemoverItem(categoriaId);
                }
                this.Close();
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
