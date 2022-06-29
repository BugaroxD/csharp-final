using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Reflection;

namespace lib
{
    
    public class Generic : Form
    {
        public Generic()
        {}

        public class TamOnLabelField : Label
        {
            public TamOnLabelField(string Text, int x, int y, int Z, int W)
            {
                this.Text = Text;
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
            }
        }

        public class FieldOnLabel : Label
        {
            public FieldOnLabel(string Text, int x, int y)
            {
                this.Text = Text;
                this.Location = new Point(x, y);
            }
        }

        public class FieldOnButton : Button
        {
            public FieldOnButton(string Text, int x, int y, int Z, int W)
            {
                this.Text = Text;
                this.Size = new Size(x, y);
                this.Location = new Point(Z, W);
                this.BackColor = Color.White;
            }
        }

        public class FieldOnTextBox : TextBox
        {
            public FieldOnTextBox(int x, int y, int Z, int W)
            {
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
            }
        }

        public class ViewOnFieldList : ListView
        {
            public ViewOnFieldList(int x, int y, int Z, int W)
            {
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
            }
        }

        public class Buttons : Form
        {
            public Buttons()
            { }
            public void ClickOnReturnBttn(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
    public class ConfirmMessage
        {
            public static DialogResult Show
                (
                    string Message = 
                        "Mais um click e sua ação sera confirmada, tem certeza de que deseja isto?"
                )
                {
                    return MessageBox.Show
                    (
                        "Confirmar",
                        Message,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                }
            }
    public class CancelMessage
        {
            public static DialogResult Show
                (
                    string Mensagem = 
                        "Mais um click e sua ação sera cancelada, tem certeza de que deseja isto??"
                )
                {
                    return MessageBox.Show(
                        "Cancelar",
                        Mensagem,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                }
            }

    public class ErrorMessage
        {
            public static DialogResult Show
                (
                    string Mensagem = "Error... Contate o técnico responsável"
                )
                {
                    return MessageBox.Show(
                        "Error",
                        $"Houve um erro na execução desta ação: {Mensagem}",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

            }
    public enum Function
            { Create, Update }

    public class ListViewItems<T> : ListView
    {
        public ListViewItems(ControlCollection Ref, string Name, IEnumerable<T> list, string[] generics)
        {
            this.Columns.Add("Id", 100);
            foreach (string generic in generics)
            {
                this.Columns.Add(generic, 100);
            }
            foreach (T item in list)
            {
                Type type = item.GetType();
                PropertyInfo prop = type.GetProperty("Id");
                ListViewItem newItem = new ListViewItem(prop.GetValue(item).ToString());
                foreach (string generic in generics)
                {
                    prop = type.GetProperty(generic);
                    newItem.SubItems.Add(prop.GetValue(item).ToString());
                }
                this.Items.Add(newItem);
            }
            this.Name = Name;
            this.Location = new System.Drawing.Point(10, 10);
            this.ClientSize = new System.Drawing.Size(250, 340);

            this.View = View.Details;
            this.LabelEdit = true;
            this.AllowColumnReorder = true;
            this.CheckBoxes = true;
            this.FullRowSelect = true;
            this.GridLines = true;
            this.Sorting = SortOrder.Ascending;

            Ref.Add(this);
        }
    }
}
