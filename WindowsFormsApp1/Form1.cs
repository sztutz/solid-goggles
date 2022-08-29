using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;

namespace WindowsFormsApp1
{
    public partial class FormDataStructureWiki : Form
    {
        // 9.1 Create a global 2D array, use static variables for the dimensions (row, column)
        #region Class variables
        private static int columns = 4;
        private static int rows = 12;
        private string[,] array = new string[rows, columns];
        // Pointer variable points to which row, the next item should be added within the array
        private int pointer = 0;
        private string defaultFileName = "default.bin";
        #endregion
        public FormDataStructureWiki()
        {
            InitializeComponent();
        }
        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        #region Add
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Taking input from the text boxes
            string name = textBoxName.Text;
            string category = textBoxCategory.Text;
            string structure = textBoxStructure.Text;
            string definition = textBoxDefinition.Text;
            // Checking if there is space in the array
            if (pointer >= rows)
            {
                MessageBox.Show("The data structure array is full. Please delete a data structure to make space");
            }
            // All text boxes are must contain a value, for an item to be added
            else if (string.IsNullOrEmpty(name) ||
                     string.IsNullOrEmpty(category) ||
                     string.IsNullOrEmpty(structure) ||
                     string.IsNullOrEmpty(definition))
            {
                MessageBox.Show("All text boxes must contain a value to add a data structure");
            }
            else
            {
                // Entering the data into the array
                array.SetValue(name, pointer, 0);
                array.SetValue(category, pointer, 1);
                array.SetValue(structure, pointer, 2);
                array.SetValue(definition, pointer, 3);
                pointer++;
                updateListViewDataStructure();
                clearTextBoxes();
            }
        }
        #endregion
        // 9.3	Create an EDIT button that will allow the user to modify any information
        // from the 4 text boxes in to the 2D array
        #region Edit
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = listViewDataStructure.SelectedIndices[0];
            // Taking input from the text boxes
            string name = textBoxName.Text;
            string category = textBoxCategory.Text;
            string structure = textBoxStructure.Text;
            string definition = textBoxDefinition.Text;
            // Entering the data in to the array
            array.SetValue(name, index, 0);
            array.SetValue(category, index, 1);
            array.SetValue(structure, index, 2);
            array.SetValue(definition, index, 3);

            updateListViewDataStructure();
            clearTextBoxes();
        }
        #endregion
        // 9.4 Create a DELETE button that removes all the information from a single entry
        // of the array; the user must be promted before the final deletion occurs
        #region Delete
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listViewDataStructure.SelectedIndices[0];

                array.SetValue(null, index, 0);
                array.SetValue(null, index, 1);
                array.SetValue(null, index, 2);
                array.SetValue(null, index, 3);
                // Bumping all the items up the array to remove the deleted space
                for (int i = index; i < rows - 1; i++)
                {
                    swap(i);
                }

                pointer--;
                updateListViewDataStructure();
                clearTextBoxes();
            }
            catch
            {
                MessageBox.Show("There is no item selected to delete");
            }
        }
        #endregion
        // 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        #region Clear
        private void clearTextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefinition.Clear();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }
        #endregion
        // 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending,
        // ensure you use a separate swap method that passes the array element to be swapped
        // (do not use any built-in array methods)
        #region Sort
        private void sort()
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
        }
        private void buttonSort_Click(object sender, EventArgs e)
        {
            sort();
            updateListViewDataStructure();
        }
        #endregion
        // 9.7	Write the code for a Binary Search for the Name in the 2D array and display the information
        // in the other textboxes when found, add suitable feedback if the search in not successful and clear
        // the search textbox(do not use any built-in array methods)
        #region Search
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            sort();
            string searchWord = textBoxSearch.Text;
            int low = 0;
            int high = pointer;
            int mid;
            bool flag = false;
            while (flag == false)
            {
                if (high == low)
                {
                    MessageBox.Show("Not found");
                    flag = true;
                }
                mid = (low + high) / 2;
                int comparisonValue = String.Compare(searchWord, array[mid, 0], StringComparison.OrdinalIgnoreCase);
                if (comparisonValue == 0)
                {
                    displayInformation(mid);
                    flag = true;
                }
                else if (comparisonValue < 0)
                {
                    low = mid + 1;
                }
                else if (comparisonValue > 0)
                {
                    high = mid + 1;
                }
            }
        }
        #endregion
        // 9.8	Create a display method that will show the following information in a ListView: Name and Category
        #region Display list view
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
        #endregion
        // 9.9	Create a method so the user can select a definition (Name) from the
        // ListView and all the information is displayed in the appropriate Textboxes
        #region Display text boxes
        private void listViewDataStructure_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listViewDataStructure.SelectedIndices[0];
            displayInformation(index);
        }
        private void displayInformation(int index)
        {
            textBoxName.Text = array[index, 0];
            textBoxCategory.Text = array[index, 1];
            textBoxStructure.Text = array[index, 2];
            textBoxDefinition.Text = array[index, 3];
        }
        #endregion
        // 9.10	Create a SAVE button so the information from the 2D array can be written into a binary file
        // called definitions.dat which is sorted by Name, ensure the user has the option to select an
        // alternative file. Use a file stream and BinaryWriter to create the file
        #region Save
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bin file|=.bin";
            saveFileDialog.Title = "Save a BIN file";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.DefaultExt = "bin";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            if(saveFileDialog.FileName != "")
            {
                saveFile(fileName);
            }
            else
            {
                saveFile(defaultFileName);
            }
        }
        private void saveFile(string saveFileName)
        {
            try
            {
                using (Stream stream = File.Open(saveFileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        for (int x = 0; x < rows; x++)
                        {
                            for (int y = 0; y < columns; y++)
                            {
                                if (array[x, y] != null)
                                {
                                    writer.Write(array[x, y]);
                                }
                            }
                        }
                        writer.Write(pointer);
                    }
                }
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
        // 9.11	Create a LOAD button that will read the information from a binary file called definitions.dat
        // into the 2D array, ensure the user has the option to select an alternative file. Use a file stream
        // and BinaryReader to complete this task
        #region Load
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "BIN FILES|*.bin";
            openFileDialog.Title = "Open a BIN file";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFile(openFileDialog.FileName);
            }
        }
        private void openFile(string openFileName)
        {
            try
            {
                using (Stream stream = File.Open(openFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        int x = 0;
                        Array.Clear(array, 0, array.Length);
                        while (stream.Position < stream.Length - 4)
                        {
                            for (int y = 0; y < columns; y++)
                            {
                                array[x, y] = reader.ReadString();
                            }
                            x++;
                        }
                        // Load pointer
                        reader.ReadInt32();
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            updateListViewDataStructure();
        }
        #endregion
        // Swaps item in array at row with item in array at row + 1
        #region Swap
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
        #endregion
    }
}
