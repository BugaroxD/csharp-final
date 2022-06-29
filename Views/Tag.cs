using System;
using System.Windows.Forms;
using System.Drawing;
using Models;
using Controllers;
using lib;

namespace Views
{
    public class TagView : Form
    {
        ListView listView;
        Button bttnInsert;
        Button bttnUpdate;
        Button bttnDelete;
        Button bttnReturn;

        public TagView()
        {
            this.ClientSize = new System.Drawing.Size(470, 470);
            this.Text = "Tags";

             bttnInsert = new Generic.FieldOnButton("Cadastrar", 130, 450, 100, 30);
            bttnInsert.Click += new EventHandler(this.ClickOnInsertBttn);

            bttnUpdate = new Generic.FieldOnButton("Editar", 345, 450, 100, 30);
            bttnUpdate.Click += new EventHandler(this.ClickOnUpdateBttn);

            bttnReturn = new Generic.FieldOnButton("Voltar", 25, 450, 100, 30);
			bttnReturn.Click += new EventHandler(this.ClickOnReturnBttn);
      
            bttnDelete = new Generic.FieldOnButton("Deletar", 235, 450, 100, 30);
			bttnDelete.Click += new EventHandler(this.ClickOnDeleteBttn);


            string[] generics = {"Id", "Descrição"};
            this.listView = new ListViewItems<Models.Tag>(this.Controls, "Lista de Tags", Models.Tag.GetTags(), generics);

            this.Controls.Add(this.bttnInsert);
            this.Controls.Add(this.bttnUpdate);
            this.Controls.Add(this.bttnReturn);
            this.Controls.Add(this.bttnDelete);
        }

        private void ClickOnInsertBttn(object sender, EventArgs e)
        {
            new TagForm(Function.Create).Show();
            this.Dispose();
        }

        private void ClickOnUpdateBttn(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                new TagForm(Function.Update, Convert.ToInt32(selectedItem.Text)).Show();
                this.Dispose();
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void ClickOnDeleteBttn(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                int tagId = Convert.ToInt32(selectedItem.Text);
                DialogResult result = MessageBox.Show($"Deseja excluir a tag {tagId}?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    TagController.RemoverTag(tagId);
                }
                this.Close();
            }
            catch (Exception)
            {
                ErrorMessage.Show();
            }
        }

        private void ClickOnReturnBttn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}