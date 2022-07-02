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
                usuario = UsuarioController.GetUsuario(id);
            }

            this.ClientSize = new System.Drawing.Size(345, 280);
            this.Text = function == Function.Create
                ? "Cadastro de usuário"
                : "Alteração usuário";

            base.generics.Add(new GenericField("name", 20, 30, "Nome", 300, 35, ' ', usuario != null ? usuario.Nome : null));
            base.generics.Add(new GenericField("email", 20, 90, "Email", 300, 35 , ' ', usuario != null ? usuario.Email : null));
            base.generics.Add(new GenericField("senha", 20, 150, "Senha", 300, 35, '*', usuario != null ? usuario.Senha : null));

            bttnConfirm = new Generic.FieldOnButton("Confirmar", 90, 40, 60,220, this.ClickOnConfirmBttn);
            bttnCancel = new Generic.FieldOnButton( "Cancelar", 90, 40, 180, 220, this.ClickOnCancelBttn);
           
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
            GenericField genericSenha = base.generics.Find((GenericField generic) => generic.id == "senha");
            try
            {
                if (option == Function.Create)
                {
                    UsuarioController.InserirUsuario(
                        genericName.textBox.Text,
                        genericEmail.textBox.Text,
                        genericSenha.textBox.Text
                    );
                    MessageBox.Show("Usuário criado com sucesso");
                }
                else if (option == Function.Update)
                {
                   UsuarioController.AlterarUsuario(
                        userId,
                        genericName.textBox.Text,
                        genericEmail.textBox.Text,
                        genericSenha.textBox.Text
                    );
                    MessageBox.Show("Usuário alterado com sucesso");
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
                senha = SenhaController.GetSenha(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 720);
            this.Text = function == Function.Create
                ? "Cadastro de senha"
                : "Alteração de senha";

            base.generics.Add(new GenericField("name", 10, 20, "Nome", 280, 15, ' ', senha != null ? senha.Nome : null));
            base.generics.Add(new GenericField("url", 10, 90, "Url", 280, 15, ' ', senha != null ? senha.Url : null));
            base.generics.Add(new GenericField("user", 10, 160, "Usuário", 280, 15, ' ', senha != null ? senha.Usuario : null));
            base.generics.Add(new GenericField("pass", 10, 230, "Senha", 280, 15, '*', senha != null ? senha.SenhaEncrypt : null));

            lblCategory = new Generic.FieldOnLabel("Categoria", 280, 15, 10, 300);

            string[] categoria = {};
			this.comboCategory = new ComboBox();
			foreach (Categoria item in CategoriaController.VisualizarCategoria())
			{
				this.comboCategory.Items.Add(item.ToString());
			}
			this.comboCategory.Location = new Point(10, 325);
			this.comboCategory.Size = new Size(280, 15);

            lblProcedure = new Generic.FieldOnLabel("Procedimento", 280, 15, 10, 370);

            this.txtProcedure = new TextBox();
            this.txtProcedure.Multiline = true;
            this.txtProcedure.ScrollBars = ScrollBars.Vertical;
            this.txtProcedure.AcceptsReturn = true;
            this.txtProcedure.WordWrap = true;
            this.txtProcedure.Location = new Point(10, 400);
            this.txtProcedure.Size = new Size(280, 100);

            lblTags = new Generic.FieldOnLabel("Tags", 280, 15, 10, 525);

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

            bttnConfirm = new Generic.FieldOnButton("Confirmar", 90, 35, 40, 665, this.ClickOnConfirmBttn);
            bttnCancel = new Generic.FieldOnButton( "Cancelar", 90, 35, 165, 665, this.ClickOnCancelBttn);

            foreach (GenericField generic in base.generics)
            {
                this.Controls.Add(generic.label);
                this.Controls.Add(generic.textBox);
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
            var categoryId = Convert.ToInt32(category.Substring(0, startId - 1));
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
                    foreach (var item in checkBoxTags.CheckedItems)
                    {
                        var tag = item.ToString();
                        var startId = tag.IndexOf("- ");
                        var tagId = tag.Substring(0, startId - 1);
                        TagSenhaController.InserirSenhaTag(
                            senha.Id,
                            Convert.ToInt32(tagId)
                        );
                    }
                    MessageBox.Show("Success","Senha cadastrada com sucesso!", MessageBoxButtons.OK);
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
                    foreach (var item in checkBoxTags.CheckedItems)
                        {
                            var tag = item.ToString();
                            var startId = tag.IndexOf("- ");
                            var tagId = tag.Substring(0, startId - 1);
                            TagSenhaController.InserirSenhaTag(
                                senha.Id,
                                Convert.ToInt32(tagId)
                        );
                    }
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

            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Text = function == Function.Create
                ? "Cadastro de tag"
                : "Alteração de tag";

            base.generics.Add(new GenericField("description", 10, 30, "Descrição", 280, 5, ' ', tag != null ? tag.Descricao : null));
        

            bttnConfirm = new Generic.FieldOnButton("Confirmar", 90, 35, 40, 120, this.ClickOnConfirmBttn);
            bttnCancel = new Generic.FieldOnButton( "Cancelar", 90, 35, 170, 120, this.ClickOnCancelBttn);

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
            this.Close();
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
                categoria = CategoriaController.GetCategoria(id);
            }

            this.ClientSize = new System.Drawing.Size(300, 240);
            this.Text = function == Function.Create
                ? "Cadastro de categoria"
                : "Alteração de categoria";

            base.generics.Add(new GenericField("name", 10, 20, "Nome", 280, 15, ' ', categoria != null ? categoria.Nome : null));
            base.generics.Add(new GenericField("description", 10, 90, "Descrição", 280, 15, ' ', categoria != null ? categoria.Descricao : null));

            bttnConfirm = new Generic.FieldOnButton("Confirmar", 90, 35, 40, 170, this.ClickOnConfirmBttn);
            bttnCancel = new Generic.FieldOnButton( "Cancelar", 90, 35, 170, 170, this.ClickOnCancelBttn);

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
    
