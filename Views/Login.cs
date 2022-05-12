using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Models;

namespace Views
{
    public class Login : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblUser;
        Label lblPassword;
        TextBox txtUser;
        TextBox txtPassword;

        Button bttnLogin;
        Button bttnExit;
        public Login()
        {
            this.lblUser = new Fields.FieldOnLabel("Usuário", 120, 30);

            this.txtUser = new Fields.FieldOnTextBox(50, 60, 200, 20);

            this.lblPassword = new Fields.FieldOnLabel("Senha", 120, 100);

            this.txtPassword = new Fields.FieldOnTextBox(50, 130, 200, 20);
            this.txtPassword.PasswordChar = '*';

            bttnLogin = new Fields.FieldOnButton("Conectar", 50, 220, 100, 30);
            bttnLogin.Click += new EventHandler(this.ClickOnLoginBttn);

            bttnExit = new Fields.FieldOnButton("Sair", 150, 220, 100, 30);
            bttnExit.Click += new EventHandler(this.ClickOnExitBttn);

            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.bttnLogin);
            this.Controls.Add(this.bttnExit);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Login";
        }

        public void ClickOnLoginBttn(object sender, EventArgs e)
        {
            try
            {
                Menu Menus = new Menu(this);
                Menus.Show();
                this.Hide();
            }
            catch (Exception err)
            {
                MessageBox.Show("Usuário ou senha inválido", "Erro");
            }
        }
        public void ClickOnExitBttn(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}