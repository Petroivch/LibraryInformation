
namespace LibraryInformation
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgrTable = new System.Windows.Forms.DataGridView();
            this.lblType = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbBox = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrTable
            // 
            this.dgrTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrTable.Location = new System.Drawing.Point(10, 50);
            this.dgrTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrTable.Name = "dgrTable";
            this.dgrTable.RowHeadersWidth = 51;
            this.dgrTable.RowTemplate.Height = 29;
            this.dgrTable.Size = new System.Drawing.Size(920, 231);
            this.dgrTable.TabIndex = 0;
            this.dgrTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrTable_CellValueChanged);
            this.dgrTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgrTable_RowsAdded);
            this.dgrTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgrTable_RowsRemoved);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(10, 22);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 15);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(849, 306);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 22);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(29, 306);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(82, 22);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 306);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 22);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbBox
            // 
            this.cmbBox.FormattingEnabled = true;
            this.cmbBox.Location = new System.Drawing.Point(67, 20);
            this.cmbBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBox.Name = "cmbBox";
            this.cmbBox.Size = new System.Drawing.Size(133, 23);
            this.cmbBox.TabIndex = 5;
            this.cmbBox.SelectedIndexChanged += new System.EventHandler(this.cmbBox_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(241, 306);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(82, 22);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Set filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(231, 22);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(0, 15);
            this.lblFile.TabIndex = 7;
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(761, 306);
            this.btnOpenLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(82, 22);
            this.btnOpenLog.TabIndex = 8;
            this.btnOpenLog.Text = "Open a log";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(329, 306);
            this.btnResetFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(82, 22);
            this.btnResetFilter.TabIndex = 9;
            this.btnResetFilter.Text = "Reset filter";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 338);
            this.Controls.Add(this.btnResetFilter);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cmbBox);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.dgrTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(958, 377);
            this.MinimumSize = new System.Drawing.Size(958, 377);
            this.Name = "frmMain";
            this.Text = "Library information";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrTable;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbBox;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.Button btnResetFilter;
    }
}

