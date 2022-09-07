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
using ToolTip = System.Windows.Forms.ToolTip;

namespace DataStructureWiki
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
            // Checking that input text boxes contain some information
            // and checking that there is space in the array
            if (checkInputfromTextBoxes() && spaceInArray())
            {
                // Taking input from the text boxes
                (string name, string category, string structure, string definition) = getInputFromTextBoxes();

                // Adding data to the array
                addToArray(name, category, structure, definition, pointer);

                pointer++;
                updateListViewDataStructure();
                clearTextBoxes();
                toolStripStatusLabel.Text = name + " added";
            }
        }
        #endregion

        // 9.3	Create an EDIT button that will allow the user to modify any information
        // from the 4 text boxes in to the 2D array
        #region Edit
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDataStructure.SelectedIndices.Count == 1)
            {
                if (checkInputfromTextBoxes())
                {
                    var result = MessageBox.Show("Do you want to edit this item?", "Edit",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int index = listViewDataStructure.SelectedIndices[0];
                        // Taking input from the text boxes
                        (string name, string category, string structure, string definition) = getInputFromTextBoxes();
                        // Adding data to the array
                        addToArray(name, category, structure, definition, index);
                        updateListViewDataStructure();
                        clearTextBoxes();
                        toolStripStatusLabel.Text = name + " edited";
                    }
                }
            }
            else
            {
                toolStripStatusLabel.Text = "There is no record selected to edit";
            }
        }
        #endregion

        // 9.4 Create a DELETE button that removes all the information from a single entry
        // of the array; the user must be promted before the final deletion occurs
        #region Delete
        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if (listViewDataStructure.SelectedIndices.Count == 1)
            {
                var result = MessageBox.Show("Do you want to delete this item?", "Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int index = listViewDataStructure.SelectedIndices[0];

                    string name = array[index, 0];

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
                    toolStripStatusLabel.Text = name + " deleted";
                }
            }
            else
            {
                MessageBox.Show("There is no item selected to delete");
            }
        }
        #endregion

        // 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        #region Clear
        // Also clears the search text box
        private void clearTextBoxes()
        {
            textBoxName.Clear();
            textBoxCategory.Clear();
            textBoxStructure.Clear();
            textBoxDefinition.Clear();
            textBoxSearch.Clear();
            toolStripStatusLabel.Text = "Cleared";
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
            if (pointer == 0)
            {
                toolStripStatusLabel.Text = "No records to sort";
            }
            else
            {
                sort();
                updateListViewDataStructure();
                toolStripStatusLabel.Text = "Sorted";
            }
        }
        #endregion

        // 9.7	Write the code for a Binary Search for the Name in the 2D array and display the information
        // in the other textboxes when found, add suitable feedback if the search in not successful and clear
        // the search textbox(do not use any built-in array methods)
        #region Search
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (pointer > 1)
            {
                if (textBoxSearch.Text != "")
                {
                    sort();
                    string searchWord = textBoxSearch.Text;
                    int low = 0;
                    int high = pointer;
                    int mid;
                    bool isSearching = true;
                    int comparisonValue;
                    while (isSearching)
                    {
                        if (low == high)
                        {
                            isSearching = false;
                            //MessageBox.Show("Not found");
                            toolStripStatusLabel.Text = searchWord + " not found";
                        }
                        else
                        {
                            mid = (low + high) / 2;
                            comparisonValue = String.Compare(searchWord, array[mid, 0], StringComparison.OrdinalIgnoreCase);
                            if (comparisonValue == 0)
                            {
                                // Word is found
                                displayInformation(mid);
                                toolStripStatusLabel.Text = searchWord + " found";
                                isSearching = false;
                            }
                            else if (comparisonValue < 0)
                            {
                                // Word is on the left side
                                high = mid;
                            }
                            else
                            {
                                // Word is on the right side
                                low = mid + 1;
                            }
                        }
                    }
                    textBoxSearch.Clear();
                }
                textBoxSearch.Focus();
            }
            else
            {
                toolStripStatusLabel.Text = "No records to search";
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
            saveFileDialog.Filter = "bin file|*.bin";
            saveFileDialog.Title = "Save a bin file";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.DefaultExt = "bin";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            if (saveFileDialog.FileName != "")
            {
                saveFile(fileName);
                toolStripStatusLabel.Text = fileName + " saved";
            }
            else
            {
                saveFile(defaultFileName);
                toolStripStatusLabel.Text = defaultFileName + " saved";
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
            catch (IOException ex)
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
            openFileDialog.Filter = "bin files|*.bin";
            openFileDialog.Title = "Open a bin file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                clearTextBoxes();
                string openFileName = Path.GetFileName(openFileDialog.FileName);
                openFile(openFileDialog.FileName);

                toolStripStatusLabel.Text = openFileName + " loaded";
            }
        }
        private void openFile(string openFileName)
        {
            //toolStripStatusLabel.Text = "wow" + " more wow";
            //Console.WriteLine(defaultFileName);
            //Console.WriteLine("dude");
            //toolStripStatusLabel.Text = openFileName.ToString();
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
                        pointer = reader.ReadInt32();
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
        private void addToArray(string name, string category, string structure, string definition, int row)
        {
            array.SetValue(name, row, 0);
            array.SetValue(category, row, 1);
            array.SetValue(structure, row, 2);
            array.SetValue(definition, row, 3);
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
        // Gets the user input from the text boxes {name, category, structure, definition}
        private (string name, string category, string structure, string definition) getInputFromTextBoxes()
        {
                string name = textBoxName.Text;
                string category = textBoxCategory.Text;
                string structure = textBoxStructure.Text;
                string definition = textBoxDefinition.Text;
                return (name, category, structure, definition);
        }
        // Checks that there is input in the text boxes {name, category, structure, definition}
        private bool checkInputfromTextBoxes()
        {
            if (string.IsNullOrEmpty(textBoxName.Text) ||
                string.IsNullOrEmpty(textBoxCategory.Text) ||
                string.IsNullOrEmpty(textBoxStructure.Text) ||
                string.IsNullOrEmpty(textBoxDefinition.Text))
            {
                MessageBox.Show("Name, Category, Structure, and Definition are required to add or edit a record");
                return false;
            }
            else
            {
                return true;
            }
        }
        // Checks if there is space in the array
        private bool spaceInArray()
        {
            if (pointer >= rows)
            {
                MessageBox.Show("The data structure list is full. Please delete a record to make space");
                toolStripStatusLabel.Text = "Full list";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            clearTextBoxes();
            textBoxName.Focus();
        }
    }
}
