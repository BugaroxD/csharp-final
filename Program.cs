using System;
using System.Windows.Forms;
using Views;
//using Controllers;

namespace EncryptMe
{
  public class Program
  {
    public static void Main(string[] args)
    {

      try
      {
        Application.EnableVisualStyles();
        Application.Run(new LoginForm());
      }
      catch (Exception err)
      {
        MessageBox.Show(err.Message);
      }
    }
  }
}