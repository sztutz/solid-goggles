using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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

        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
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
                        break;
                    }
                }
            updateListViewDataStructure();
            clearTextBoxes();
        }

        // 9.3	Create an EDIT button that will allow the user to modify any information
        // from the 4 text boxes into the 2D array
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = listViewDataStructure.SelectedIndices[0];

            string name = textBoxName.Text;
            string category = textBoxCategory.Text;
            string structure = textBoxStructure.Text;
            string definition = textBoxDefinition.Text;

            array.SetValue(name, index, 0);
            array.SetValue(category, index, 1);
            array.SetValue(structure, index, 2);
            array.SetValue(definition, index, 3);

            updateListViewDataStructure();
            clearTextBoxes();
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

        private void labelDefinition_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        // 9.9	Create a method so the user can select a definition (Name) from the
        // ListView and all the information is displayed in the appropriate Textboxes
        private void listViewDataStructure_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listViewDataStructure.SelectedIndices[0];
            textBoxName.Text = array[index, 0];
            textBoxCategory.Text = array[index, 1];
            textBoxStructure.Text = array[index, 2];
            textBoxDefinition.Text = array[index, 3];
        }

        private void updateListViewDataStructure()
        {
            listViewDataStructure.Items.Clear();
            for (int i = 0; i < rows; i++)
            {
                ListViewItem item = new ListViewItem(array[i, 0]);
                item.SubItems.Add(array[i, 1]);
                listViewDataStructure.Items.Add(item);
            }
        }

        private void clearTextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefinition.Clear();
        }
    }
}
