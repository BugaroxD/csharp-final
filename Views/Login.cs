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
        Button bttnExit;
        Button bttnRegister;
        public LoginForm(): base()
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Usuário";

            base.generics.Add(new GenericField(this.Controls, 30, 30, "Usuário"));
            base.generics.Add(new GenericField(this.Controls, 20, 90, "Senha", 240, 15, '*'));

            bttnLogin = new Generic.FieldOnButton("Conectar", 50, 220, 100, 30);
            bttnLogin.Click += new EventHandler(this.ClickOnLoginBttn);

            bttnRegister = new Generic.FieldOnButton("Cadastrar novo usuário!", 50, 220, 100, 30);
            bttnRegister.Click += new EventHandler(this.ClickOnRegisterBttn);

            bttnExit = new Generic.FieldOnButton("Sair", 150, 220, 100, 30);
            bttnExit.Click += new EventHandler(this.ClickOnExitBttn);

          
            this.Controls.Add(this.bttnLogin);
            this.Controls.Add(this.bttnExit);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Login";
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
            new UserForm(Function.Create).Show();
        }
        public void ClickOnExitBttn(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
