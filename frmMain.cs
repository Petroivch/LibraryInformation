using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LibraryInformation
{
    public partial class frmMain : Form
    {
        DataTable table;
        string[] temp1;
        String check = "";
        String search = "";
        String LastPath = "";
        String SuperPath = "";
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbBox.Items.Add("CSV");
            cmbBox.Items.Add("TXT");
            cmbBox.Items.Add("JSON");
            cmbBox.Items.Add("XML");
            cmbBox.Items.Add("All formats");
            cmbBox.SelectedItem = "All formats";
            cmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Count", typeof(string));
            table.Columns.Add("Year", typeof(string));
            table.Columns.Add("Format", typeof(string));

            AddToDgr("journal.txt", 0);
            AddToDgr("topic.csv", 1);
            AddToDgr("edition.xml", 2);
            AddToDgr("section.txt", 3);

            /*for (int i = 0; i < lbr.Count; i++)
            {
                table.Rows.Add(lbr[i].getName());
            }
            for (int i = 0; i < lbr.Count; i++)
            {
                table.Rows[i][1] = lbr[i].getType();
                table.Rows[i][2] = lbr[i].getPages();
                table.Rows[i][3] = lbr[i].getYear();
            }

            dgrTable.DataSource = table;

            dgrTable.RowHeadersVisible = false;
            dgrTable.ColumnHeadersVisible = true;
            dgrTable.AllowUserToAddRows = false;*/

            /*
            dgrTable.Columns[0].Width = (int)(dgrTable.Width * 0.15);
            dgrTable.Columns[1].Width = (int)(dgrTable.Width * 0.15);
            dgrTable.Columns[2].Width = (int)(dgrTable.Width * 0.15);
            dgrTable.Columns[3].Width = (int)(dgrTable.Width * 0.15);
            dgrTable.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgrTable.Rows[0].Height = (int)(dgrTable.Height * 0.2);
            dgrTable.Rows[1].Height = (int)(dgrTable.Height * 0.2);
            dgrTable.Rows[2].Height = (int)(dgrTable.Height * 0.2);
            dgrTable.Rows[3].Height = (int)(dgrTable.Height * 0.2);*/
        }
        public void AddToDgr(string path, int index)
        {
            //path = Path.GetFullPath(path);
            String path1 = convertToTXT("res\\"+path);
            table.Rows.Add(1);
            List<String> lines = new List<string>();
            using (StreamReader fs = new StreamReader(path1))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp != null)
                        temp1 = temp.Split(", ").ToArray();

                    if (temp == null) break;

                    lines.Add(temp);
                }
            }
            for (int i = 0; i < temp1.Length; i++)
            {
                table.Rows[index][i] = temp1[i];
            }
            table.Rows[index][temp1.Length] = Path.GetExtension(path);
            dgrTable.DataSource = table;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmFilter newForm = new frmFilter();
            newForm.ShowDialog();
        }

        private void cmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedFormat = cmbBox.SelectedIndex.ToString();
            dgrTable.CurrentCell = null;
            //CSV
            if (selectedFormat.Contains("0"))
            {
                for (int i = 0; i < dgrTable.Rows.Count - 1; i++)
                    dgrTable.Rows[i].Visible = dgrTable[4, i].Value.ToString() == ".csv";
            }
            //TXT
            else if (selectedFormat.Contains("1"))
            {
                for (int i = 0; i < dgrTable.Rows.Count - 1; i++)
                    dgrTable.Rows[i].Visible = dgrTable[4, i].Value.ToString() == ".txt";
            }
            //JSON
            else if (selectedFormat.Contains("2"))
            {
                for (int i = 0; i < dgrTable.Rows.Count - 1; i++)
                    dgrTable.Rows[i].Visible = dgrTable[4, i].Value.ToString() == ".json";
            }
            //XML
            else if (selectedFormat.Contains("3"))
            {
                for (int i = 0; i < dgrTable.Rows.Count - 1; i++)
                    dgrTable.Rows[i].Visible = dgrTable[4, i].Value.ToString() == ".xml";
            }
            else
            {
                for (int i = 0; i < dgrTable.Rows.Count - 1; i++)
                    dgrTable.Rows[i].Visible = true;
            }
        }

        private void dgrTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String path = "";
            int row = dgrTable.CurrentCell.RowIndex;
            int column = dgrTable.CurrentCell.ColumnIndex;
            path = dgrTable[1, row].Value.ToString() + dgrTable[4, row].Value.ToString();
            path = Path.GetFullPath("res\\" + path);
            path = path.Replace(" ", "");
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(path)
            {
                UseShellExecute = true,
                Arguments = "explorer.com"
            };
            p.Start();
        }
        public String convertToTXT(String FilePath)
        {
            List<Library> libraries = new List<Library>();
            String LastPath1 = FilePath;
            //JSON
            if (FilePath.Contains(".json"))
            {
                LastPath1 = FilePath.Replace(".json", ".txt");
                string json = File.ReadAllText(FilePath);
                libraries = JsonConvert.DeserializeObject<List<Library>>(json);
                using (StreamWriter sw = new StreamWriter(LastPath1))
                {
                    foreach (Library item in libraries)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            //CSV
            else if (FilePath.Contains(".csv"))
            {
                LastPath1 = FilePath.Replace(".csv", ".txt");
                string[] lns = File.ReadAllLines(FilePath);
                List<String> lnes = new List<String>();
                using (StreamReader fs = new StreamReader(FilePath))
                {
                    while (true)
                    {
                        string temp = fs.ReadLine();

                        if (temp == null) break;

                        lnes.Add(temp);
                    }
                }
                using (StreamWriter sw = new StreamWriter(LastPath1))
                {
                    foreach (String item in lnes)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            //XML
            else if (FilePath.Contains(".xml"))
            {
                LastPath1 = FilePath.Replace(".xml", ".txt");
                XmlTextReader reader = new XmlTextReader(FilePath);
                String s = "";
                while (reader.Read())
                {
                    int i = 0;
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            while (reader.MoveToNextAttribute()) // Read the attributes.
                                s += reader.Value;
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            s += ", " + reader.Value;
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            if (reader.Name == "Name")
                            {
                                s += "\n";
                            }
                            break;
                    }
                }
                string[] values = s.Split("\n");
                using (TextWriter tw = new StreamWriter(LastPath1))
                {
                    foreach (String q in values)
                    {
                        if (!q.Equals(""))
                            tw.WriteLine(q);
                    }
                }
            }
            return LastPath1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.InitialDirectory = Directory.GetCurrentDirectory() + "\\output";
            SFD.Filter = "JSON|*.json|CSV|*.csv|XML|*.xml|XLSX|*.xlsx";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                LastPath = SFD.FileName;
                //SaveFile(LastPath);
            }
            MessageBox.Show("Ваш файл находится в " + LastPath);
        }
        /*private void SaveFile(String LastPath)
        {
            if (!FilePath.Contains(".txt"))
            {
                FilePath = Area.convertToTXT(LastPath, FilePath);
            }
            List<String> lines = new List<string>();
            using (StreamReader fs = new StreamReader(FilePath))
            {
                while (true)
                {
                    string temp = fs.ReadLine();

                    if (temp == null) break;

                    lines.Add(temp);
                }
            }
            int convert = cs.convert;
            switch (convert)
            {
                case 0:
                    Area.convertToJSON(LastPath, FilePath, lines);
                    break;
                case 1:
                    Area.convertToCSV(LastPath, FilePath, lines);
                    break;
                case 2:
                    Area.convertToXML(LastPath, FilePath, lines);
                    break;
                case 3:
                    Area.convertToXLSX(LastPath, FilePath, lines);
                    break;
            }
            //using (StreamWriter sw = new StreamWriter(LastPath))
            //{
            //    foreach (String item in lines)
            //    {
            //        sw.WriteLine(item);
            //    }
            //} 

        }*/
    }
}
