using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Controllers;
using Models;

namespace Views
{
    // Formulário de Usuário
    public class UserForm : GenericBase
    {
        public static Function option;
        public static int uid;
        public List<GenericField> generics;
        Button bttnConfirm;
        Button bttnCancel;
        public UserForm(
            Function function,
            int id = 0
        ) : base()
        {
            option = function;
            uid = id;

            Usuario usuario = null;
            if (id > 0)
            {
                usuario = UsuarioController.GetUsuarios(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = function == Function.Create
                ? "Criar"
                : "Alterar";

            base.generics.Add(new GenericField("name", 10, 20, "Nome", 280, 15));
            base.generics.Add(new GenericField("email", 10, 80, "Email", 280, 15));
            base.generics.Add(new GenericField("senha", 10, 140, "Senha", 280, 55, '*'));

            bttnConfirm = new Button();
            bttnConfirm.Text = "Confirmar";
            bttnConfirm.Size = new Size(80, 25);
            bttnConfirm.Location = new Point(110, 220);
            bttnConfirm.Click += new EventHandler(this.bttnConfirmClick);
        
            bttnCancel = new Button();
            bttnCancel.Text = "Cancelar";
            bttnCancel.Size = new Size(80, 25);
            bttnCancel.Location = new Point(110, 255);
            bttnCancel.Click += new EventHandler(this.bttnCancelClick);

            foreach (GenericField generics in base.generics)
            {
                this.Controls.Add(generics.label);
                this.Controls.Add(generics.textBox);
            }

            this.Controls.Add(bttnConfirm);
            this.Controls.Add(bttnCancel);
        }

        private void bttnConfirmClick(object sender, EventArgs e)
        {
            GenericField fieldName = base.generics.Find((GenericField field) => field.id == "name");
            GenericField fieldEmail = base.generics.Find((GenericField field) => field.id == "email");
            GenericField genericsenha = base.generics.Find((GenericField field) => field.id == "senha");
            try
            {
                if (option == Function.Create)
                {
                    UsuarioController.InserirUsuario(
                        fieldName.textBox.Text,
                        fieldEmail.textBox.Text,
                        genericsenha.textBox.Text
                    );
                    MessageBox.Show("Usuário criado com sucesso");
                }
                else if (option == Function.Update)
                {
                   UsuarioController.AlterarUsuario(
                        uid,
                        fieldName.textBox.Text,
                        fieldEmail.textBox.Text,
                        genericsenha.textBox.Text
                    );
                    MessageBox.Show("Usuário alterado com sucesso");
                }
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void bttnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Formulário de Senha    
    public class PassForm : GenericBase
    {
        public static Senha senha = null;
        public static SenhaTag senhaTag;
        public static Function option;
        public static int uid;
        public List<GenericField> generics;
        Label lblCategory;
        Label lblProcedure;
        Label lblTags;
        TextBox txtProcedure;
        CheckedListBox checkBoxTags;
        ComboBox comboCategory;
        Button bttnConfirm;
        Button bttnCancel;
        public PassForm(
            Function function,
            int id = 0
        ) : base()
        {
            option = function;
            uid = id;

            if (id > 0)
            {
                senha = SenhaController.GetSenhas(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 770);
            this.Text = function == Function.Create
                ? "Criar"
                : "Alterar";

            base.generics.Add(new GenericField("name", 10, 20, "Nome", 280, 15, ' ', senha != null ? senha.Nome : null));
            base.generics.Add(new GenericField("url", 10, 90, "Url", 280, 15, ' ', senha != null ? senha.Url : null));
            base.generics.Add(new GenericField("user", 10, 160, "Usuário", 280, 15, ' ', senha != null ? senha.Usuario : null));
            base.generics.Add(new GenericField("pass", 10, 230, "Senha", 280, 15, '*', senha != null ? senha.SenhaEncrypt : null));

            this.lblCategory = new Label();
            this.lblCategory.Text = "Categoria";
            this.lblCategory.Location = new Point(10, 300);
            this.lblCategory.Size = new Size(280, 15);

            string[] categoria = {};
			this.comboCategory = new ComboBox();
			foreach (Categoria item in CategoriaController.VisualizarCategoria())
			{
				this.comboCategory.Items.Add(item.ToString());
			}
			this.comboCategory.Location = new Point(10, 325);
			this.comboCategory.Size = new Size(280, 15);

            this.lblProcedure = new Label();
            this.lblProcedure.Text = "Procedimento";
            this.lblProcedure.Location = new Point(10, 370);
            this.lblProcedure.Size = new Size(280, 15);

            this.txtProcedure = new TextBox();
            this.txtProcedure.Multiline = true;
            this.txtProcedure.ScrollBars = ScrollBars.Vertical;
            this.txtProcedure.AcceptsReturn = true;
            this.txtProcedure.WordWrap = true;
            this.txtProcedure.Location = new Point(10, 400);
            this.txtProcedure.Size = new Size(280, 100);

            this.lblTags = new Label();
            this.lblTags.Text = "Tags";
            this.lblTags.Location = new Point(10, 525);
            this.lblTags.Size = new Size(280, 15);

            this.checkBoxTags = new CheckedListBox();
            this.checkBoxTags.Location = new Point(10, 550);
            this.checkBoxTags.Size = new Size(280, 100);
            foreach (Tag item in TagController.VisualizarTag())
            {
                this.checkBoxTags.Items.Add(item.Descricao);
            }
            this.checkBoxTags.SelectionMode = SelectionMode.One;
            this.checkBoxTags.CheckOnClick = true;            

            bttnConfirm = new Button();
            bttnConfirm.Text = "Confirmar";
            bttnConfirm.Size = new Size(80, 25);
            bttnConfirm.Location = new Point(110, 680);
            bttnConfirm.Click += new EventHandler(this.bttnConfirmClick);
        
            bttnCancel = new Button();
            bttnCancel.Text = "Cancelar";
            bttnCancel.Size = new Size(80, 25);
            bttnCancel.Location = new Point(110, 710);
            bttnCancel.Click += new EventHandler(this.bttnCancelClick);

            foreach (GenericField field in base.generics)
            {
                this.Controls.Add(field.label);
                this.Controls.Add(field.textBox);
            }

            if (senha != null) 
            {
                this.comboCategory.Text = senha.Categoria.ToString();
                this.txtProcedure.Text = senha.Procedimento;

                IEnumerable<SenhaTag> senhaTags = SenhaTagController.GetSenhaTag(senhaTag.Id);
                foreach (SenhaTag item in senhaTags)
                {
                    this.checkBoxTags.SelectedItems.Add(item.Tag.Descricao);
                }
            }

            this.Controls.Add(lblCategory);
            this.Controls.Add(comboCategory);
            this.Controls.Add(lblProcedure);
            this.Controls.Add(txtProcedure);
            this.Controls.Add(lblTags);
            this.Controls.Add(checkBoxTags);
            this.Controls.Add(bttnConfirm);
            this.Controls.Add(bttnCancel);
        }

        private void bttnConfirmClick(object sender, EventArgs e)
        {
            
            GenericField fieldName = base.generics.Find((GenericField field) => field.id == "name");
            GenericField fieldUrl = base.generics.Find((GenericField field) => field.id == "url");
            GenericField fieldUsuario = base.generics.Find((GenericField field) => field.id == "user");
            GenericField fieldSenhaEncrypt = base.generics.Find((GenericField field) => field.id == "pass");
            var categoria = comboCategory.SelectedItem.ToString();
            var inicioId = categoria.IndexOf("- ");
            var categoriaId = categoria.Substring(0, inicioId - 1);
            try
            {
                if (option == Function.Create)
                {
                    SenhaController.InserirSenha(
                        fieldName.textBox.Text,
                        Convert.ToInt32(categoriaId),
                        fieldUrl.textBox.Text,
                        fieldUsuario.textBox.Text,
                        fieldSenhaEncrypt.textBox.Text,
                        txtProcedure.Text
                    );
                    SenhaTagController.InserirSenhaTag(
                        99,
                        Convert.ToInt32(checkBoxTags.SelectedItems[0])
                    );
                    MessageBox.Show("Senha criada com sucesso");
                    this.Close();
                }
                else if (option == Function.Update)
                {
                   SenhaController.AlterarSenha(
                        uid,
                        fieldName.textBox.Text,
                        Convert.ToInt32(categoriaId),
                        fieldUrl.textBox.Text,
                        fieldUsuario.textBox.Text,
                        fieldSenhaEncrypt.textBox.Text,
                        txtProcedure.Text
                    );
                    MessageBox.Show("Categoria alterada com sucesso");
                    this.Close();
                }
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void bttnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
    
