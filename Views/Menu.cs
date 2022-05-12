using System;
using System.Windows.Forms;
using lib;
using Models;
using System.Drawing;

namespace Telas
{
    public class Menu : Form
    {
        Form parent;
        private System.ComponentModel.IContainer components = null;

        Label lblTitle;

        Button bttnUser;
        Button bttnExit;
        Button bttnCategory;
        Button bttnTags;
        Button bttnPassword;

        public Menu(Form parent)
        {
            this.parent = parent;

            this.lblTitle = new Fields.TamOnLabelField($"Bem vindo(a)!", 120, 15, 150, 30);

            this.bttnUser = new Fields.FieldOnButton("Usuário", 100, 170, 100, 30);
            bttnUser.Click += new EventHandler(this.ClickOnUserBttn);

            this.bttnPassword = new Fields.FieldOnButton("Senhas", 100, 130, 100, 30);
            bttnPassword.Click += new EventHandler(this.ClickOnPasswordBttns);

            this.bttnCategory = new Fields.FieldOnButton("Categoria", 100, 50, 100, 30);
            bttnCategory.Click += new EventHandler(this.ClickOnCategoryBttn);

            this.bttnTags = new Fields.FieldOnButton("Tags", 100, 90, 100, 30);
            bttnTags.Click += new EventHandler(this.ClickOnTagBttn);





            this.bttnExit = new Fields.FieldOnButton("Sair", 100, 210, 100, 30);
            this.bttnExit.Click += new EventHandler(this.ClickOnExitBttn);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.bttnCategory);
            this.Controls.Add(this.bttnTags);
            this.Controls.Add(this.bttnPassword);
            this.Controls.Add(this.bttnUser);
            this.Controls.Add(this.bttnExit);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Menu";
        }

        public void ClickOnExitBttn(object sender, EventArgs e)
        {
            this.parent.Close();
        }
        /*
        public void ClickOnCategoryBttn(object sender, EventArgs e)
        {
            CategoriaView CategoriaViews = new CategoriaView();
            CategoriaViews.ShowDialog();
        }

        public void btnSenhaClick(object sender, EventArgs e)
        {
            SenhaView SenhaViews = new SenhaView();
            SenhaViews.ShowDialog();
        }

        public void btnUsuarioClick(object sender, EventArgs e)
        {
            UsuarioView UsuarioViews = new UsuarioView();
            UsuarioViews.ShowDialog();
        }

        public void btnTagClick(object sender, EventArgs e)
        {
            TagView TagViews = new TagView(this);
            TagViews.ShowDialog();
        }
        */

    }

}