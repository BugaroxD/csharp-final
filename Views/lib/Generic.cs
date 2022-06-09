using System;
using System.Windows.Forms;
using System.Drawing;

namespace lib
{
    public class GenericField 
    {
        public string id;
        public TextBox textBox;
        public Label label;
        
        public GenericField(
            string id,
            int pointA,
            int pointB,
            string label,
            int sizeA = 280,
            int sizeB = 55,
            char characterPass = ' ',
            string valueDefault = ""
            
        )
        {
            this.id = id;

            this.textBox = new TextBox();
            this.textBox.Location = new Point(pointA, pointB + 30);
            this.textBox.Size = new Size(sizeA, sizeB);
            this.textBox.Text = valueDefault;

            this.label = new Label();
            this.label.Text = label;
            this.label.Location = new Point(pointA, pointB);

            if (!Char.IsWhiteSpace(characterPass))
            {
                this.textBox.PasswordChar = characterPass;
            }
        }
    }
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
                this.Location = new Point(x, y);
                this.Size = new Size(Z, W);
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
}