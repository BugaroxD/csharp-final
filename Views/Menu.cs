using System;
using System.Windows.Forms;
using lib;
using Models;
using System.Drawing;

namespace Views
{
    public class MenuForm : Form
    {
        
        private System.ComponentModel.IContainer components = null;

        Label lblTitle;

        Button bttnUser;
        Button bttnExit;
        Button bttnCategory;
        Button bttnTags;
        Button bttnPassword;

        public MenuForm()
        {

            this.lblTitle = new Generic.TamOnLabelField($"Bem vindo(a)!", 120, 15, 150, 30);

            this.bttnUser = new Generic.FieldOnButton("Usuário", 100, 170, 100, 30);
            bttnUser.Click += new EventHandler(this.ClickOnUserBttn);

            this.bttnPassword = new Generic.FieldOnButton("Senhas", 100, 130, 100, 30);
            bttnPassword.Click += new EventHandler(this.ClickOnPasswordBttn);

            this.bttnCategory = new Generic.FieldOnButton("Categoria", 100, 50, 100, 30);
            bttnCategory.Click += new EventHandler(this.ClickOnCategoryBttn);

            this.bttnTags = new Generic.FieldOnButton("Tags", 100, 90, 100, 30);
            bttnTags.Click += new EventHandler(this.ClickOnTagBttn);

            this.bttnExit = new Generic.FieldOnButton("Sair", 100, 210, 100, 30);
            this.bttnExit.Click += new EventHandler(this.ClickOnExitBttn);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.bttnCategory);
            this.Controls.Add(this.bttnTags);
            this.Controls.Add(this.bttnPassword);
            this.Controls.Add(this.bttnUser);
            this.Controls.Add(this.bttnExit);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Text = "Menu";
        }

        public void ClickOnExitBttn(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void ClickOnUserBttn(object sender, EventArgs e)
        {
            UsuarioView UsuarioViews = new UsuarioView();
            UsuarioViews.ShowDialog();
        }
        
        public void ClickOnCategoryBttn(object sender, EventArgs e)
        {
            CategoriaView CategoriaViews = new CategoriaView();
            CategoriaViews.ShowDialog();
        }

        public void ClickOnPasswordBttn(object sender, EventArgs e)
        {
            SenhaView SenhaViews = new SenhaView();
            SenhaViews.ShowDialog();
        }

        public void ClickOnTagBttn(object sender, EventArgs e)
        {
            TagView TagViews = new TagView(this);
            TagViews.ShowDialog();
        }
        

    }

}
