using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Controllers;
using Models;

namespace Views
{
    // Funções de Usuário
    public class UserForm : GenericBase
    {
        public static Function option;
        public static int userId;
        public List<GenericField> generics;
        Button bttnConfirm;
        Button bttnCancel;
        public UserForm(
            Function function,
            int id = 0
        ) : base()
        {
            option = function;
            userId = id;

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
            bttnConfirm.Click += new EventHandler(this.ClickOnConfirmBttn);
        
            bttnCancel = new Button();
            bttnCancel.Text = "Cancelar";
            bttnCancel.Size = new Size(80, 25);
            bttnCancel.Location = new Point(110, 255);
            bttnCancel.Click += new EventHandler(this.ClickOnCancelBttn);

            foreach (GenericField generics in base.generics)
            {
                this.Controls.Add(generics.label);
                this.Controls.Add(generics.textBox);
            }

            this.Controls.Add(bttnConfirm);
            this.Controls.Add(bttnCancel);
        }

        private void ClickOnConfirmBttn(object sender, EventArgs e)
        {
            GenericField genericName = base.generics.Find((GenericField generic) => generic.id == "name");
            GenericField genericEmail = base.generics.Find((GenericField generic) => generic.id == "email");
            GenericField genericsenha = base.generics.Find((GenericField generic) => generic.id == "senha");
            try
            {
                if (option == Function.Create)
                {
                    UsuarioController.InserirUsuario(
                        genericName.textBox.Text,
                        genericEmail.textBox.Text,
                        genericsenha.textBox.Text
                    );
                    MessageBox.Show("Usuário criado com sucesso");
                }
                else if (option == Function.Update)
                {
                   UsuarioController.AlterarUsuario(
                        userId,
                        genericName.textBox.Text,
                        genericEmail.textBox.Text,
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

        private void ClickOnCancelBttn(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Funções de Senha   
    public class PassForm : GenericBase
    {
        public static Senha senha = null;
        public static SenhaTag senhaTag;
        public static Function option;
        public static int categoryId;
        public static int passId;
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
            passId = id;

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
            int order = 0;
            foreach (Tag item in TagController.VisualizarTag())
            {
                this.checkBoxTags.Items.Add(item.ToString());
                if (senha != null)
                {
                    SenhaTag theTagSenha =  TagSenhaController.GetBySenhaTag(senha.Id, item.Id);
                    if (theTagSenha != null)
                    {
                        this.checkBoxTags.SetItemChecked(order, true);
                    }
                }
                order++;
            }
            this.checkBoxTags.SelectionMode = SelectionMode.One;
            this.checkBoxTags.CheckOnClick = true;            

            bttnConfirm = new Button();
            bttnConfirm.Text = "Confirmar";
            bttnConfirm.Size = new Size(80, 25);
            bttnConfirm.Location = new Point(110, 680);
            bttnConfirm.Click += new EventHandler(this.ClickOnConfirmBttn);
        
            bttnCancel = new Button();
            bttnCancel.Text = "Cancelar";
            bttnCancel.Size = new Size(80, 25);
            bttnCancel.Location = new Point(110, 710);
            bttnCancel.Click += new EventHandler(this.ClickOnCancelBttn);

            foreach (GenericField field in base.generics)
            {
                this.Controls.Add(field.label);
                this.Controls.Add(field.textBox);
            }

            if (senha != null) 
            {
                this.comboCategory.Text = senha.Categoria.ToString();
                this.txtProcedure.Text = senha.Procedimento;
            }

            this.Controls.Add(lblTags);
            this.Controls.Add(checkBoxTags);
            this.Controls.Add(lblProcedure);
            this.Controls.Add(txtProcedure);
            this.Controls.Add(lblCategory);
            this.Controls.Add(comboCategory);
            this.Controls.Add(bttnConfirm);
            this.Controls.Add(bttnCancel);
        }

        private void ClickOnConfirmBttn(object sender, EventArgs e)
        {
            
            GenericField genericName = base.generics.Find((GenericField field) => field.id == "name");
            GenericField genericUrl = base.generics.Find((GenericField field) => field.id == "url");
            GenericField genericUsuario = base.generics.Find((GenericField field) => field.id == "user");
            GenericField genericSenhaEncrypt = base.generics.Find((GenericField field) => field.id == "pass");
            try
            {
            var category = comboCategory.SelectedItem.ToString();
            var startId = category.IndexOf("- ");
            var categoryId = category.Substring(0, startId - 1);
            }
            catch (Exception)
            {
               ErrorMessage.Show("Campo categoria não pode ser vazio, favor inserir informação referente!");
            }
            try
            {
                if (option == Function.Create)
                {
                    SenhaController.InserirSenha(
                        genericName.textBox.Text,
                        Convert.ToInt32(categoryId),
                        genericUrl.textBox.Text,
                        genericUsuario.textBox.Text,
                        genericSenhaEncrypt.textBox.Text,
                        txtProcedure.Text
                    );
                    TagSenhaController.InserirSenhaTag(
                        99,
                        Convert.ToInt32(checkBoxTags.SelectedItems[0])
                    );
                    MessageBox.Show("Senha criada com sucesso");
                    this.Close();
                }
                else if (option == Function.Update)
                {
                   SenhaController.AlterarSenha(
                        passId,
                        genericName.textBox.Text,
                        Convert.ToInt32(categoryId),
                        genericUrl.textBox.Text,
                        genericUsuario.textBox.Text,
                        genericSenhaEncrypt.textBox.Text,
                        txtProcedure.Text
                    );
                    MessageBox.Show("Success","Senha alterada com sucesso!", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void ClickOnCancelBttn(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Funções da Tag
    public class TagForm : GenericBase
    {
        public static Function option;
        public static int tagId;
        public List<GenericField> generics;
        Button bttnConfirm;
        Button bttnCancel;
        public TagForm(
            Function function,
            int id = 0
        ) : base()
        {
            option = function;
            tagId = id;

            Tag tag = null;
            if (id > 0)
            {
                tag = TagController.GetTag(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = function == Function.Create
                ? "Criar"
                : "Alterar";

            base.generics.Add(new GenericField("description", 10, 90, "Descrição", 280, 15, ' ', tag != null ? tag.Descricao : null));
        
            bttnConfirm = new Button();
            bttnConfirm.Text = "Confirmar";
            bttnConfirm.Size = new Size(80, 25);
            bttnConfirm.Location = new Point(110, 205);
            bttnConfirm.Click += new EventHandler(this.ClickOnConfirmBttn);
        
            bttnCancel = new Button();
            bttnCancel.Text = "Cancelar";
            bttnCancel.Size = new Size(80, 25);
            bttnCancel.Location = new Point(110, 240);
            bttnCancel.Click += new EventHandler(this.ClickOnCancelBttn);

            foreach (GenericField generic in base.generics)
            {
                this.Controls.Add(generic.label);
                this.Controls.Add(generic.textBox);
            }

            this.Controls.Add(bttnConfirm);
            this.Controls.Add(bttnCancel);
        }

        private void ClickOnConfirmBttn(object sender, EventArgs e)
        {
            
            GenericField genericDescription = base.generics.Find((GenericField generic) => generic.id == "description");
            try
            {
                if (option == Function.Create)
                {
                    TagController.InserirTag(
                        genericDescription.textBox.Text
                    );
                    MessageBox.Show("Tag criada com sucesso");
                }
                else if (option == Function.Update)
                {
                   TagController.AlterarTag(
                        tagId,
                        genericDescription.textBox.Text
                    );
                    MessageBox.Show("Tag alterada com sucesso");
                }
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void ClickOnCancelBttn(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Funções de Categoria
    public class CategoryForm : GenericBase
    {
        public static Function option;
        public static int categoryId;
        public List<GenericField> generics;
        Button bttnConfirm;
        Button bttnCancel;
        public CategoryForm(
            Function function,
            int id = 0
        ) : base()
        {
            option = function;
            categoryId = id;
            
            Categoria categoria = null;
            if (id > 0) {
                categoria = CategoriaController.GetCategorias(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = function == Function.Create
                ? "Criar"
                : "Alterar";

            base.generics.Add(new GenericField("name", 10, 20, "Nome", 280, 15, ' ', categoria != null ? categoria.Nome : null));
            base.generics.Add(new GenericField("description", 10, 90, "Descrição", 280, 15, ' ', categoria != null ? categoria.Descricao : null));

            bttnConfirm = new Button();
            bttnConfirm.Text = "Confirmar";
            bttnConfirm.Size = new Size(80, 25);
            bttnConfirm.Location = new Point(110, 205);
            bttnConfirm.Click += new EventHandler(this.ClickOnConfirmBttn);
        
            bttnCancel = new Button();
            bttnCancel.Text = "Cancelar";
            bttnCancel.Size = new Size(80, 25);
            bttnCancel.Location = new Point(110, 240);
            bttnCancel.Click += new EventHandler(this.ClickOnCancelBttn);

            foreach (GenericField generic in base.generics)
            {
                this.Controls.Add(generic.label);
                this.Controls.Add(generic.textBox);
            }

            this.Controls.Add(bttnConfirm);
            this.Controls.Add(bttnCancel);
        }

        private void ClickOnConfirmBttn(object sender, EventArgs e)
        {
            
            GenericField genericName = base.generics.Find((GenericField generic) => generic.id == "name");
            GenericField genericDescription = base.generics.Find((GenericField generic) => generic.id == "description");
            try
            {
                if (option == Function.Create)
                {
                    CategoriaController.InserirCategoria(
                        genericName.textBox.Text,
                        genericDescription.textBox.Text
                    );
                    MessageBox.Show("Parabéns sua categoria foi cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK);
                    this.Close();
                }
                else if (option == Function.Update)
                {
                   CategoriaController.AlterarCategoria(
                        categoryId,
                        genericName.textBox.Text,
                        genericDescription.textBox.Text
                    );
                    MessageBox.Show("Parabéns sua categoria foi alterada com sucesso!", "Sucesso", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void ClickOnCancelBttn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    
