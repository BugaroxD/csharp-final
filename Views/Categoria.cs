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
        ListView listView;
        Button bttnInsert;
        Button bttnUpdate;
        Button bttnReturn;
        Button bttnDelete;
        

        public CategoriaView() 
        {
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.Text = "Categorias";

            bttnInsert = new Generic.FieldOnButton("Cadastrar", 100, 30, 40, 370, this.ClickOnInsertBttn);
            bttnUpdate = new Generic.FieldOnButton("Editar", 100, 30, 170, 370, this.ClickOnUpdateBttn);
            bttnReturn = new Generic.FieldOnButton("Voltar", 100, 30,  170, 410, this.ClickOnReturnBttn);
            bttnDelete = new Generic.FieldOnButton("Deletar", 100, 30, 40, 410, this.ClickOnDeleteBttn);
			
        // Select dos registros

            string[] generics = {"Nome", "Descricao"};
            this.listView = new ListViewItems<Models.Categoria>(this.Controls, "Lista de Categorias", Models.Categoria.GetCategorias(), generics);

            this.Controls.Add(this.bttnInsert);
            this.Controls.Add(this.bttnUpdate);
            this.Controls.Add(this.bttnReturn);
            this.Controls.Add(this.bttnDelete);
            
        }

        // Funções dos botões

        private void ClickOnInsertBttn(object sender, EventArgs e)
        {
            new CategoryForm(Function.Create).Show();
            this.Dispose();
        }

        private void ClickOnUpdateBttn(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                new CategoryForm(Function.Update, Convert.ToInt32(selectedItem.Text)).Show();
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
                int categoryId = Convert.ToInt32(selectedItem.Text);
                DialogResult result = MessageBox.Show($"Para efetuar a exclusão da categoria {categoryId} clicar em SIM! Se for engano clique em NÃO!", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    CategoriaController.ExcluirCategoria(categoryId);
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
