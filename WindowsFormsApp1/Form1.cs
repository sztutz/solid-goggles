using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private string[,] array = new string[rows, columns];
        private int pointer = 0;
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

            if (pointer >= 11)
            {
                MessageBox.Show("The data structure array is full. Please delete a data structure to make space");
            }
            else if (!string.IsNullOrEmpty(name) &&
                     !string.IsNullOrEmpty(category) &&
                     !string.IsNullOrEmpty(structure) &&
                     !string.IsNullOrEmpty(definition))
            {
                MessageBox.Show("All text boxes must contain a value to add a data structure");
            }
            else
            {
                array.SetValue(name, pointer, 0);
                array.SetValue(category, pointer, 1);
                array.SetValue(structure, pointer, 2);
                array.SetValue(definition, pointer, 3);
                pointer++;
            }

            //    int slot = -1;

            //    string name = textBoxName.Text;
            //    string category = textBoxCategory.Text;
            //    string structure = textBoxStructure.Text;
            //    string definition = textBoxDefinition.Text;

            //    while (slot == -1)
            //    {
            //        for (int i = 0; i < rows; i++)
            //        {
            //            if (array[i, 0] == null)
            //            {
            //                slot = i;
            //                break;
            //            }
            //        }
            //    }
            //    if (slot == -1)
            //    {
            //        MessageBox.Show("The data structure array is full. Please delete a data structure to make space");
            //    }
            //    else if (!string.IsNullOrEmpty(name) &&
            //             !string.IsNullOrEmpty(category) &&
            //             !string.IsNullOrEmpty(structure) &&
            //             !string.IsNullOrEmpty(definition))
            //    {
            //        array.SetValue(name, slot, 0);
            //        array.SetValue(category, slot, 1);
            //        array.SetValue(structure, slot, 2);
            //        array.SetValue(definition, slot, 3);
            //    }
            //    else
            //    {
            //        MessageBox.Show("All text boxes must contain a value to add a data structure");
            //    }

            //    updateListViewDataStructure();
            //    clearTextBoxes();
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

        // 9.4 Create a DELETE button that removes all the information from a single entry
        // of the array; the user must be promted before the final deletion occurs
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listViewDataStructure.SelectedIndices[0];

            array.SetValue(null, index, 0);
            array.SetValue(null, index, 1);
            array.SetValue(null, index, 2);
            array.SetValue(null, index, 3);

            for (int i = index; i < rows - 1; i++)
            {
                swap(i);
            }

            updateListViewDataStructure();
            clearTextBoxes();
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
        // 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        private void clearTextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefinition.Clear();
        }
        // 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending,
        // ensure you use a separate swap method that passes the array element to be swapped
        // (do not use any built-in array methods)
        private void buttonSort_Click(object sender, EventArgs e)
        {
            bool swapped;

            for (int i = 0; i < rows - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < rows - 1; j++)
                {
                    if (array[j, 0] == null)
                    {
                        swap(j);
                        swapped = true;
                    }
                    else if (array[j + 1, 0] != null)
                    {
                        if (String.Compare(array[j, 0], array[j + 1, 0], StringComparison.Ordinal) > 0)
                        {
                            swap(j);
                            swapped = true;
                        }
                    }
                }
                if (swapped == false)
                    break;
            }
            updateListViewDataStructure();    
        }
        // Swaps item in array at row with item in array at row + 1
        private void swap(int row)
        {
            string temp;
            for (int k = 0; k < columns; k++)
            {
                temp = array[row + 1, k];
                array[row + 1, k] = array[row, k];
                array[row, k] = temp;
            }
        }
    }
}
