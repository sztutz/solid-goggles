using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Structure_Wiki
{
    public partial class Form1 : Form
    {
        private string[,] dataStructureArray = new string[12, 4];
        private string name;
        private string category;
        private string structure;
        private string definition;

        public Form1()
        {
            InitializeComponent();
        }
    }
}
