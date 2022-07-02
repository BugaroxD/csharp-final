using System;
using System.Windows.Forms;
using System.Drawing;
using Models;
using Controllers;
using lib;

namespace Views
{
    public class SenhaView : Form
    {
        ListView listView;
        Button bttnInsert;
        Button bttnUpdate;
        Button bttnDelete;
        Button bttnReturn;

        public SenhaView()
        {
            this.ClientSize = new System.Drawing.Size(305, 450);
            this.Text = "Senhas";

            bttnInsert = new Generic.FieldOnButton("Cadastrar", 100, 30, 35, 370, this.ClickOnInsertBttn);
            bttnUpdate = new Generic.FieldOnButton("Editar", 100, 30, 165, 370, this.ClickOnUpdateBttn);
            bttnReturn = new Generic.FieldOnButton("Voltar", 100, 30,  165, 410, this.ClickOnReturnBttn);
            bttnDelete = new Generic.FieldOnButton("Deletar", 100, 30, 35, 410, this.ClickOnDeleteBttn);

        // Select dos registros

            string[] generics = {"Nome", "CategoriaId", "Url", "Usuario", "SenhaEncrypt", "Procedimento"};
            this.listView = new ListViewItems<Models.Senha>(this.Controls, "Lista de Senhas", Models.Senha.GetSenhas(), generics);

            this.Controls.Add(this.bttnInsert);
            this.Controls.Add(this.bttnUpdate);
            this.Controls.Add(this.bttnReturn);
            this.Controls.Add(this.bttnDelete);
        }

        // Funções dos botões
        
        private void ClickOnInsertBttn(object sender, EventArgs e)
        {
            new PassForm(Function.Create).Show();
            this.Dispose();
        }

        private void ClickOnUpdateBttn(object sender, EventArgs e)
        {
            try
            {
                new PassForm(Function.Update).Show();
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
                int passId = Convert.ToInt32(listView.CheckedItems[0].Text);
                DialogResult result = MessageBox.Show($"Para efetuar a exclusão da senha {passId} clicar em SIM! Se for engano clique em NÃO!", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    SenhaController.ExcluirSenha(passId);
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
