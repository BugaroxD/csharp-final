using System;
using System.Windows.Forms;
using System.Drawing;

namespace lib
{
  public class Field
  {
    public string id;
    public TextBox textBox;
    public Label label;

    public Field(
        string id,
        int xPoint,
        int yPoint,
        string label,
        int xSize = 240,
        int ySize = 15,
        char passwordChar = ' '
    )
    {
      this.id = id;

      this.label = new Label();
      this.label.Text = label;
      this.label.Location = new Point(xPoint, yPoint);

      this.textBox = new TextBox();
      this.textBox.Location = new Point(xPoint, yPoint + 25);
      this.textBox.Size = new Size(xSize, ySize);

      if (!Char.IsWhiteSpace(passwordChar))
      {
        this.textBox.PasswordChar = passwordChar;
      }
    }
  }
}