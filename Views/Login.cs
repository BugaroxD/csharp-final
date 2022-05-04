using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Models;

namespace Views
{
  public class Login : Base
  {
    public List<Field> fields;
    Button bttnConfirmar;
    Button bttnFechar;
    Button bttnCadastrar;

    public Login() : base()
    {
      this.ClientSize = new System.Drawing.Size(280, 280);
      this.Text = "Login";

      base.fields.Add(new Field("login", 20, 20, "Login"));
      base.fields.Add(new Field("password", 20, 90, "Senha", 240, 15, '*'));

      bttnConfirmar = new Button();
      bttnConfirmar.Text = "Confirmar";
      bttnConfirmar.Size = new Size(80, 25);
      bttnConfirmar.Location = new Point(100, 170);
      bttnConfirmar.Click += new EventHandler(this.buttonConfirmarClick);

      bttnCadastrar = new Button();
      bttnCadastrar.Text = "Cadastrar";
      bttnCadastrar.Size = new Size(80, 25);
      bttnCadastrar.Location = new Point(100, 200);
      bttnCadastrar.Click += new EventHandler(this.buttonCadastrarClick);

      bttnFechar = new Button();
      bttnFechar.Text = "Fechar";
      bttnFechar.Size = new Size(80, 25);
      bttnFechar.Location = new Point(100, 230);
      bttnFechar.Click += new EventHandler(this.buttonFecharClick);

      foreach (Field field in base.fields)
      {
        this.Controls.Add(field.label);
        this.Controls.Add(field.textBox);
      }
      this.Controls.Add(bttnConfirmar);
      this.Controls.Add(bttnCadastrar);
      this.Controls.Add(bttnFechar);
    }

    private void buttonConfirmarClick(object sender, EventArgs e)
    {
      Field fieldLogin = base.fields.Find((Field field) => field.id == "login");
      Field fieldSenha = base.fields.Find((Field field) => field.id == "password");

      try
      {
        Usuario.Auth(fieldLogin.textBox.Text, fieldSenha.textBox.Text);
        (new Menu()).Show();
      }
      catch (Exception err)
      {
        MessageBox.Show(err.Message);
      }
    }

    private void buttonFecharClick(object sender, EventArgs e)
    {
      this.Close();
    }

    private void buttonCadastrarClick(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}