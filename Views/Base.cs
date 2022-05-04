using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using lib;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Models;

namespace Views
{

  public abstract class Base : Form
  {
    public List<Field> fields;

    public Base()
    {
      this.fields = new List<Field>();
    }
  }
}