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
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Text = "Usuário";

            base.generics.Add(new GenericField("user", 20, 20, "Usuário"));
            base.generics.Add(new GenericField("password", 20, 90, "Senha", 240, 15, '*'));

            bttnLogin = new Generic.FieldOnButton("Conectar", 80,25, 100,170);
            bttnLogin.Click += new EventHandler(this.ClickOnLoginBttn);

            bttnRegister = new Generic.FieldOnButton("Cadastrar novo usuário!", 80,25, 100,200);
            bttnRegister.Click += new EventHandler(this.ClickOnRegisterBttn);

            bttnExit = new Generic.FieldOnButton("Sair", 150, 220, 100, 30);
            bttnExit.Click += new EventHandler(this.ClickOnExitBttn);

          
            this.Controls.Add(this.bttnLogin);
            this.Controls.Add(this.bttnRegister);
            this.Controls.Add(this.bttnExit);
            foreach (GenericField generic in base.generics)
            {
                this.Controls.Add(generic.label);
                this.Controls.Add(generic.textBox);
            }
        }

        public void ClickOnLoginBttn(object sender, EventArgs e)
        {
            GenericField fieldLogin = base.generics.Find((GenericField field) => field.id == "Usuário");
            GenericField fieldSenha = base.generics.Find((GenericField field) => field.id == "Senha");

            try
            {
                Usuario.Auth(fieldLogin.textBox.Text, fieldSenha.textBox.Text);
                (new MenuForm()).Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
          private void ClickOnRegisterBttn(object sender, EventArgs e)
        {
            UsuarioCadastro new UserForm(Function.Create).Show();
            this.Dispose();
        }
        public void ClickOnExitBttn(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
