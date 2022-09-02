namespace WindowsFormsApp1
{
    partial class FormDataStructureWiki
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listViewDataStructure = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.textBoxDefinition = new System.Windows.Forms.TextBox();
            this.labelDefinition = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelStructure = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxStructure = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(16, 294);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.toolTip1.SetToolTip(this.buttonAdd, "Add a record to the list");
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(97, 294);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Edit";
            this.toolTip1.SetToolTip(this.buttonEdit, "Edit an existing record from the list");
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(178, 294);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.toolTip1.SetToolTip(this.buttonDelete, "Delete a record from the list");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listViewDataStructure
            // 
            this.listViewDataStructure.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderCategory});
            this.listViewDataStructure.FullRowSelect = true;
            this.listViewDataStructure.HideSelection = false;
            this.listViewDataStructure.Location = new System.Drawing.Point(259, 25);
            this.listViewDataStructure.Name = "listViewDataStructure";
            this.listViewDataStructure.Size = new System.Drawing.Size(237, 263);
            this.listViewDataStructure.TabIndex = 16;
            this.listViewDataStructure.UseCompatibleStateImageBehavior = false;
            this.listViewDataStructure.View = System.Windows.Forms.View.Details;
            this.listViewDataStructure.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewDataStructure_MouseClick);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 120;
            // 
            // columnHeaderCategory
            // 
            this.columnHeaderCategory.Text = "Category";
            this.columnHeaderCategory.Width = 120;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(340, 294);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.toolTip1.SetToolTip(this.buttonSave, "Save the list of records");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(421, 294);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 12;
            this.buttonLoad.Text = "Load";
            this.toolTip1.SetToolTip(this.buttonLoad, "Load a list of records");
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // textBoxDefinition
            // 
            this.textBoxDefinition.Location = new System.Drawing.Point(15, 143);
            this.textBoxDefinition.Multiline = true;
            this.textBoxDefinition.Name = "textBoxDefinition";
            this.textBoxDefinition.Size = new System.Drawing.Size(238, 145);
            this.textBoxDefinition.TabIndex = 3;
            // 
            // labelDefinition
            // 
            this.labelDefinition.AutoSize = true;
            this.labelDefinition.Location = new System.Drawing.Point(13, 127);
            this.labelDefinition.Name = "labelDefinition";
            this.labelDefinition.Size = new System.Drawing.Size(54, 13);
            this.labelDefinition.TabIndex = 15;
            this.labelDefinition.Text = "Definition:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 14;
            this.labelName.Text = "Name:";
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(12, 48);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(52, 13);
            this.labelCategory.TabIndex = 13;
            this.labelCategory.Text = "Category:";
            // 
            // labelStructure
            // 
            this.labelStructure.AutoSize = true;
            this.labelStructure.Location = new System.Drawing.Point(13, 87);
            this.labelStructure.Name = "labelStructure";
            this.labelStructure.Size = new System.Drawing.Size(53, 13);
            this.labelStructure.TabIndex = 12;
            this.labelStructure.Text = "Structure:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(15, 25);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(238, 20);
            this.textBoxName.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxName, "Double click to clear all text boxes");
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            this.textBoxName.DoubleClick += new System.EventHandler(this.textBoxName_DoubleClick);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(15, 64);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(238, 20);
            this.textBoxCategory.TabIndex = 1;
            // 
            // textBoxStructure
            // 
            this.textBoxStructure.Location = new System.Drawing.Point(15, 104);
            this.textBoxStructure.Name = "textBoxStructure";
            this.textBoxStructure.Size = new System.Drawing.Size(238, 20);
            this.textBoxStructure.TabIndex = 2;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(16, 323);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.buttonClear, "Clear all text boxes");
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(97, 323);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 8;
            this.buttonSort.Text = "Sort";
            this.toolTip1.SetToolTip(this.buttonSort, "Sort the list alphabetically");
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(178, 323);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Search";
            this.toolTip1.SetToolTip(this.buttonSearch, "Search the list");
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(12, 349);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(75, 13);
            this.labelSearch.TabIndex = 11;
            this.labelSearch.Text = "Name Search:";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(15, 365);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(238, 20);
            this.textBoxSearch.TabIndex = 10;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 394);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(509, 22);
            this.statusStrip.TabIndex = 17;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // FormDataStructureWiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 416);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxStructure);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelStructure);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelDefinition);
            this.Controls.Add(this.textBoxDefinition);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listViewDataStructure);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Name = "FormDataStructureWiki";
            this.Text = "Data Structure Wiki";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ListView listViewDataStructure;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox textBoxDefinition;
        private System.Windows.Forms.Label labelDefinition;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelStructure;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxStructure;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderCategory;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

