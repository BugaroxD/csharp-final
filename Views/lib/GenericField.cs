using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Reflection;

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
            int sizeA = 240,
            int sizeB = 15,
            char characterPass = ' ',
            string valueDefault = ""
            
        )
        {
            this.id = id;

            this.textBox = new TextBox();
            this.textBox.Location = new Point(pointA, pointB + 25);
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
}