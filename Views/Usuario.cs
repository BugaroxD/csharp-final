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
            this.ClientSize = new System.Drawing.Size(305, 450);
            this.Text = "Usuários";

            bttnInsert = new Generic.FieldOnButton("Cadastrar", 100, 30, 35, 370, this.ClickOnInsertBttn);
            bttnUpdate = new Generic.FieldOnButton("Editar", 100, 30, 165, 370, this.ClickOnUpdateBttn);
            bttnReturn = new Generic.FieldOnButton("Voltar", 100, 30,  165, 410, this.ClickOnReturnBttn);
            bttnDelete = new Generic.FieldOnButton("Deletar", 100, 30, 35, 410, this.ClickOnDeleteBttn);
           
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
            this.Dispose();
        }

        private void ClickOnUpdateBttn(object sender, EventArgs e)
        {
            try
            {
                
                new UserForm(Function.Update).Show();
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
                int userId = Convert.ToInt32(listView.CheckedItems[0].Text);
                DialogResult result = MessageBox.Show($"Para efetuar a exclusão do usuário {userId} clicar em SIM! Se for engano clique em NÃO", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    UsuarioController.ExcluirUsuario(userId);
                }
                this.Close();
            }
            catch (Exception)
            {
                ErrorMessage.Show("Deu ruim!");
            }
            
        }

        private void ClickOnReturnBttn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
