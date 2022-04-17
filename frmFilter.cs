using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryInformation
{
    public partial class frmFilter : Form
    {
        public static String check = "";
        public static String search = "";
        public frmFilter()
        {
            InitializeComponent();

            chkBoxName.Checked = check.Contains("Name");
            chkBoxType.Checked = check.Contains("Type");
            chkBoxPages.Checked = check.Contains("Pages");
            chkBoxYear.Checked = check.Contains("Year");

            txtSearch.Text = search;
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            if (search == String.Empty)
            {
                txtSearch.Text = "Write name of type, type, etc";
                txtSearch.ForeColor = Color.Gray;
            }
        }
        private void txtSearch_Enter(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            txtSearch.Text = search;
            txtSearch.ForeColor = Color.Black;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            check = "";

            if (chkBoxName.Checked)
                check += "Name";
            if (chkBoxType.Checked)
                check += "Type";
            if (chkBoxPages.Checked)
                check += "Pages";
            if (chkBoxYear.Checked)
                 check += "Year";

            search = txtSearch.Text;

            this.Close();
        }
    }
}
