using System;
using System.Windows.Forms;
using lib;
using Models;
using System.Drawing;

namespace Views
{
    public class MenuForm : Form
    {
        Label lblMenu;
        Button bttnUser;
        Button bttnExit;
        Button bttnCategory;
        Button bttnTags;
        Button bttnPassword;

        public MenuForm()
        {
            this.ClientSize = new System.Drawing.Size(230, 210);
            this.Text = "Menu";

            this.lblMenu = new Generic.FieldOnLabel($"Olá, {Usuario.UsuarioAuth.Nome}", 220, 20, 0, 20);
            lblMenu.TextAlign = ContentAlignment.MiddleCenter;
            this.bttnUser = new Generic.FieldOnButton("Usuários", 90, 35, 15, 60, this.ClickOnUserBttn);
            this.bttnPassword = new Generic.FieldOnButton("Senhas", 90, 35, 120, 60, this.ClickOnPasswordBttn);
            this.bttnCategory = new Generic.FieldOnButton("Categorias", 90, 35, 15, 110, this.ClickOnCategoryBttn);
            this.bttnTags = new Generic.FieldOnButton("Tags", 90, 35, 120, 110, this.ClickOnTagBttn);
            this.bttnExit = new Generic.FieldOnButton("Sair", 100, 35, 60, 160, this.ClickOnExitBttn);
            
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.bttnCategory);
            this.Controls.Add(this.bttnTags);
            this.Controls.Add(this.bttnPassword);
            this.Controls.Add(this.bttnUser);
            this.Controls.Add(this.bttnExit);
            
        }

        public void ClickOnUserBttn(object sender, EventArgs e)
        {
            new UsuarioView().Show();
        }
        
        public void ClickOnPasswordBttn(object sender, EventArgs e)
        {
            new SenhaView().Show();
        }
               
        public void ClickOnCategoryBttn(object sender, EventArgs e)
        {
           new CategoriaView().Show();
        }

        public void ClickOnTagBttn(object sender, EventArgs e)
        {
            new TagView().Show();
        }
        
        public void ClickOnExitBttn(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
