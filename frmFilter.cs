using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryInformation
{
    public partial class frmFilter : Form
    {
        public String check = "";
        public String search = "";
        public frmFilter()
        {
            InitializeComponent();
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            txtSearch.Text = "Write name of type, type, etc";
            txtSearch.ForeColor = Color.Gray;
        }
        private void txtSearch_Enter(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            txtSearch.Text = null;
            txtSearch.ForeColor = Color.Black;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkBoxName.Checked)
                check = "Name";
            if (chkBoxType.Checked)
            {
                if (check != null)
                    check += ", Type";
                else
                    check += "Type";
            }
            if (chkBoxPages.Checked)
            {
                if (check != null)
                    check += ", Pages";
                else
                    check += "Pages";
            }
            if (chkBoxYear.Checked)
                if (check != null)
                    check += ", Year";
                else
                    check += "Year";
            search = txtSearch.Text;
            this.Close();
        }
    }
}
