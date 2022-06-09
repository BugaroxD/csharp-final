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

  public abstract class GenericBase : Form
  {
    public List<GenericField> generics;

    public GenericBase()
    {
      this.generics = new List<GenericField>();
    }
  }
}