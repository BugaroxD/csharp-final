using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Models;

namespace Views
{
    public class LoginForm : GenericBase
    {
        public List<GenericField> generics;
        Button bttnLogin;
        Button bttnRegister;
        Button bttnExit;
        
        public LoginForm(): base()
        {
            this.ClientSize = new System.Drawing.Size(280, 280);
            this.Text = "Login";

            base.generics.Add(new GenericField("user", 20, 20, "Usuário"));
            base.generics.Add(new GenericField("password", 20, 90, "Senha", 240, 15, '*'));
            
            bttnLogin = new Generic.FieldOnButton("Conectar", 80, 30, 40, 160, this.ClickOnLoginBttn);
            bttnRegister = new Generic.FieldOnButton("Novo usuário!", 60, 70, 170, 160, this.ClickOnRegisterBttn);
            bttnExit = new Generic.FieldOnButton("Sair", 80, 30, 40, 200, this.ClickOnExitBttn);
            
            foreach (GenericField generic in base.generics)
            {
                this.Controls.Add(generic.label);
                this.Controls.Add(generic.textBox);
            }
            this.Controls.Add(this.bttnLogin);
            this.Controls.Add(this.bttnRegister);
            this.Controls.Add(this.bttnExit);
        }

        // Funções dos botões

        public void ClickOnLoginBttn(object sender, EventArgs e)
        {
            GenericField genericLogin = base.generics.Find((GenericField generic) => generic.id == "user");
            GenericField genericSenha = base.generics.Find((GenericField generic) => generic.id == "password");

            try
            {
                Usuario.Auth(genericLogin.textBox.Text, genericSenha.textBox.Text);
                (new MenuForm()).Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
          private void ClickOnRegisterBttn(object sender, EventArgs e)
        {
            new UserForm(Function.Create).Show();
        }
        public void ClickOnExitBttn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
