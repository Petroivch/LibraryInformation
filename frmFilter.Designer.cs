
namespace LibraryInformation
{
    partial class frmFilter
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.chkBoxName = new System.Windows.Forms.CheckBox();
            this.chkBoxType = new System.Windows.Forms.CheckBox();
            this.chkBoxPages = new System.Windows.Forms.CheckBox();
            this.chkBoxYear = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(45, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // chkBoxName
            // 
            this.chkBoxName.AutoSize = true;
            this.chkBoxName.Location = new System.Drawing.Point(60, 42);
            this.chkBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBoxName.Name = "chkBoxName";
            this.chkBoxName.Size = new System.Drawing.Size(58, 19);
            this.chkBoxName.TabIndex = 1;
            this.chkBoxName.Text = "Name";
            this.chkBoxName.UseVisualStyleBackColor = true;
            // 
            // chkBoxType
            // 
            this.chkBoxType.AutoSize = true;
            this.chkBoxType.Location = new System.Drawing.Point(60, 65);
            this.chkBoxType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBoxType.Name = "chkBoxType";
            this.chkBoxType.Size = new System.Drawing.Size(50, 19);
            this.chkBoxType.TabIndex = 2;
            this.chkBoxType.Text = "Type";
            this.chkBoxType.UseVisualStyleBackColor = true;
            // 
            // chkBoxPages
            // 
            this.chkBoxPages.AutoSize = true;
            this.chkBoxPages.Location = new System.Drawing.Point(60, 88);
            this.chkBoxPages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBoxPages.Name = "chkBoxPages";
            this.chkBoxPages.Size = new System.Drawing.Size(57, 19);
            this.chkBoxPages.TabIndex = 3;
            this.chkBoxPages.Text = "Pages";
            this.chkBoxPages.UseVisualStyleBackColor = true;
            // 
            // chkBoxYear
            // 
            this.chkBoxYear.AutoSize = true;
            this.chkBoxYear.Location = new System.Drawing.Point(60, 111);
            this.chkBoxYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBoxYear.Name = "chkBoxYear";
            this.chkBoxYear.Size = new System.Drawing.Size(48, 19);
            this.chkBoxYear.TabIndex = 4;
            this.chkBoxYear.Text = "Year";
            this.chkBoxYear.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(196, 23);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(174, 134);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 22);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 170);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkBoxYear);
            this.Controls.Add(this.chkBoxPages);
            this.Controls.Add(this.chkBoxType);
            this.Controls.Add(this.chkBoxName);
            this.Controls.Add(this.lblSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.frmFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox chkBoxName;
        private System.Windows.Forms.CheckBox chkBoxType;
        private System.Windows.Forms.CheckBox chkBoxPages;
        private System.Windows.Forms.CheckBox chkBoxYear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnOk;
    }
}