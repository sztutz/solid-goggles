using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp1
{
    public partial class FormDataStructureWiki : Form
    {
        // 9.1 Create a global 2D array, use static variables for the dimensions (row, column)
        private static int columns = 4;
        private static int rows = 12;
        string[,] array = new string[rows, columns];
        public FormDataStructureWiki()
        {
            InitializeComponent();
        }

        // 9.2Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string category = textBoxCategory.Text;
            string structure = textBoxStructure.Text;
            string definition = textBoxDefinition.Text;

            for (int i = 0; i < rows; i++)
            {
                if (array[i, 0] == null)
                {
                    array.SetValue(name, i, 0);
                    array.SetValue(category, i, 1);
                    array.SetValue(structure, i, 2);
                    array.SetValue(definition, i, 3);
                }
            }

            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(category);
            listViewDataStructure.Items.Add(item);

            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefinition.Clear();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }

        // 9.9	Create a method so the user can select a definition (Name) from the
        // ListView and all the information is displayed in the appropriate Textboxes
        private void listViewDataStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listViewDataStructure.SelectedIndices[0];
            //textBoxDefinition.Text = listViewDataStructure.Items[index].SubItems[1].Text;
            textBoxDefinition.Text = array[index, 3];
        }

        private void labelDefinition_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
