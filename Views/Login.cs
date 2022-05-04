using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Models;

namespace Views
{
  public class FormLogin : FormBase
  {
    public List<Field> fields;
    Button buttonConfirmar;
    Button buttonFechar;
    Button buttonCadastrar;

    public FormLogin() : base()
    {
      this.ClientSize = new System.Drawing.Size(280, 280);
      this.Text = "Login";

      base.fields.Add(new Field("login", 20, 20, "Login"));
      base.fields.Add(new Field("password", 20, 90, "Senha", 240, 15, '*'));

      buttonConfirmar = new Button();
      buttonConfirmar.Text = "Confirmar";
      buttonConfirmar.Size = new Size(80, 25);
      buttonConfirmar.Location = new Point(100, 170);
      buttonConfirmar.Click += new EventHandler(this.buttonConfirmarClick);

      buttonCadastrar = new Button();
      buttonCadastrar.Text = "Cadastrar";
      buttonCadastrar.Size = new Size(80, 25);
      buttonCadastrar.Location = new Point(100, 200);
      buttonCadastrar.Click += new EventHandler(this.buttonCadastrarClick);

      buttonFechar = new Button();
      buttonFechar.Text = "Fechar";
      buttonFechar.Size = new Size(80, 25);
      buttonFechar.Location = new Point(100, 230);
      buttonFechar.Click += new EventHandler(this.buttonFecharClick);

      foreach (Field field in base.fields)
      {
        this.Controls.Add(field.label);
        this.Controls.Add(field.textBox);
      }
      this.Controls.Add(buttonConfirmar);
      this.Controls.Add(buttonCadastrar);
      this.Controls.Add(buttonFechar);
    }

    private void buttonConfirmarClick(object sender, EventArgs e)
    {
      Field fieldLogin = base.fields.Find((Field field) => field.id == "login");
      Field fieldSenha = base.fields.Find((Field field) => field.id == "password");

      try
      {
        Usuario.Auth(fieldLogin.textBox.Text, fieldSenha.textBox.Text);
        (new FormMenu()).Show();
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