﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace LibraryInformation
{
    public partial class frmMain : Form
    {
        public DataTable table;
        public DataTable table_filter;

        string[] temp1;
        String LastPath = "";
        static String LOG_FILENAME = "log.txt";
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LogMessageToFile("Program has been closed");
            Application.Exit();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LogMessageToFile("Program has been started");
            cmbBox.Items.Add("All types");
            cmbBox.SelectedItem = "All types";
            cmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Pages", typeof(int));
            table.Columns.Add("Year", typeof(int));

            table_filter = new DataTable();
            table_filter.Columns.Add("Name", typeof(string));
            table_filter.Columns.Add("Type", typeof(string));
            table_filter.Columns.Add("Pages", typeof(int));
            table_filter.Columns.Add("Year", typeof(int));
        }
        public void LoadData(String lsFileName)
        {
            LogMessageToFile("File has been loaded");
            table.Clear();

            String lsFileNameTXT = convertToTXT(lsFileName);

            int i = 0;
            using (StreamReader fs = new StreamReader(lsFileNameTXT))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp != null)
                        temp1 = temp.Split(", ").ToArray();

                    if (temp == null) break;

                    table.Rows.Add();
                    for (int j = 0; j < temp1.Length; j++)
                    {
                        table.Rows[i][j] = temp1[j];
                    }
                    i++;
                }
            }
            dgrTable.DataSource = table;
            File.Delete(lsFileNameTXT);
            FillTypeBox();

            dgrTable.Columns[0].Width = (int)(dgrTable.Width * 0.23);
            dgrTable.Columns[1].Width = (int)(dgrTable.Width * 0.23);
            dgrTable.Columns[2].Width = (int)(dgrTable.Width * 0.23);
            dgrTable.Columns[3].Width = (int)(dgrTable.Width * 0.23);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            frmFilter newForm = new frmFilter();
            newForm.ShowDialog();
            LogMessageToFile("Filter has been opened");
            filter();
            FillTypeBox();
        }
        public void filter()
        {
            EnumerableRowCollection<DataRow> results = null;

            results = from myRow in table.AsEnumerable()
                      select myRow;
            try
            {
                if (frmFilter.check.Contains("Name"))
                {
                    results = from myRow in table.AsEnumerable()
                              where myRow.Field<String>("Name").Contains(frmFilter.search)
                              select myRow;
                }
                if (frmFilter.check.Contains("Type"))
                {
                    results = from myRow in table.AsEnumerable()
                              where myRow.Field<String>("Type").Contains(frmFilter.search)
                              select myRow;
                }
                if (frmFilter.check.Contains("Pages"))
                {
                    results = from myRow in table.AsEnumerable()
                              where myRow.Field<int>("Pages") == Convert.ToInt32(frmFilter.search)
                              select myRow;
                }
                if (frmFilter.check.Contains("Year"))
                {
                    results = from myRow in table.AsEnumerable()
                                where myRow.Field<int>("Year") == Convert.ToInt32(frmFilter.search)
                                select myRow;
                }
            }
            catch { }

            table_filter.Clear();


            foreach (DataRow row in results)
            {
                table_filter.ImportRow(row);
            }

            dgrTable.DataSource = table_filter;
        }

        private void cmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgrTable.CurrentCell = null;
            if (cmbBox.SelectedItem.ToString() != "All types")
            {
                for (int i = 0; i < dgrTable.Rows.Count - 1; i++)
                    dgrTable.Rows[i].Visible = dgrTable[1, i].Value.ToString() == cmbBox.SelectedItem.ToString();
            }
            else
            {
                for (int i = 0; i < dgrTable.Rows.Count - 1; i++)
                    dgrTable.Rows[i].Visible = true;
            }
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
            SFD.Filter = "JSON|*.json|CSV|*.csv|XML|*.xml";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                LastPath = SFD.FileName;
                int convert = SFD.FilterIndex;
                SaveFile(LastPath, convert);
                lblFile.Text = String.Format("Data:   {0}", SFD.FileName);
            }
            //MessageBox.Show("Ваш файл находится в " + LastPath);
            LogMessageToFile("File has been saved");
        }

        public void FillTypeBox()
        {
            cmbBox.Items.Clear();
            cmbBox.Items.Add("All types");
            cmbBox.SelectedItem = "All types";
            foreach (DataGridViewRow row in dgrTable.Rows)
            {
                if ((row.Cells[1].Value != null) && (!cmbBox.Items.Contains(row.Cells[1].Value)))
                    cmbBox.Items.Add(row.Cells[1].Value);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.InitialDirectory = Directory.GetCurrentDirectory() + "\\res";
            FillTypeBox();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                LoadData(OPF.FileName);
            }
            lblFile.Text = String.Format("Data:   {0}", OPF.FileName);
            LogMessageToFile("User opened OpenFileDialog");
        }
        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(LOG_FILENAME)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void SaveFile(String LastPath, int convert)
        {
            FileStream fs = new FileStream(@"1.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);
            for (int j = 0; j < dgrTable.Rows.Count - 1; j++)
            {
                for (int i = 0; i < dgrTable.Rows[j].Cells.Count; i++)
                {
                    if (i != dgrTable.Rows[j].Cells.Count - 1)
                        streamWriter.Write(dgrTable.Rows[j].Cells[i].Value + ", ");
                    else
                        streamWriter.Write(dgrTable.Rows[j].Cells[i].Value);
                }
                streamWriter.WriteLine();
            }
            streamWriter.Close();
            fs.Close();
            List<String> lines = new List<string>();
            using (StreamReader fs1 = new StreamReader(@"1.txt"))
            {
                while (true)
                {
                    string temp = fs1.ReadLine();

                    if (temp == null) break;

                    lines.Add(temp);
                }
            }
            switch (convert)
            {
                case 1:
                    convertToJSON(LastPath, lines);
                    break;
                case 2:
                    convertToCSV(LastPath, lines);
                    break;
                case 3:
                    convertToXML(LastPath, lines);
                    break;
            }
            File.Delete(@"1.txt");
        }

        public static void convertToJSON(String LastPath, List<String> lines)
        {
            var model = lines.Select(p => new
            {
                name = p.Split(", ")[0],
                type = p.Split(", ")[1],
                countPages = p.Split(", ")[2],
                foundationYear = p.Split(", ")[3],
            });
            var json = System.Text.Json.JsonSerializer.Serialize(model);
            LastPath = LastPath.Replace(".txt", ".json");
            using (StreamWriter sw = new StreamWriter(LastPath))
            {
                sw.WriteLine(json);
            }
        }

        public static void convertToCSV(String LastPath, List<String> lines)
        {
            LastPath = LastPath.Replace(".txt", ".csv");
            using (StreamWriter sw = new StreamWriter(LastPath))
            {
                foreach (String item in lines)
                {
                    sw.WriteLine(item);
                }
            }
        }
        public static void convertToXML(String LastPath, List<String> lines)
        {
            var sr = new StreamReader(@"1.txt");
            var xmlTree = new XStreamingElement("Root",
                from line in sr.Lines()
                let items = line.Split(',')
                select new XElement("Name",
                            new XAttribute("name", items[0]),
                            new XElement("Type", items[1]),
                            new XElement("countPages", items[2]),
                            new XElement("foundationYear", items[3])
                        )
            );
            using (StreamWriter sw = new StreamWriter(LastPath))
            {
                sw.WriteLine(xmlTree);
            }
            sr.Close();
        }

        private void dgrTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            FillTypeBox();
            LogMessageToFile("Row has been removed");
        }

        private void dgrTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            FillTypeBox();
            LogMessageToFile("Cell Value has been changed");
        }

        private void dgrTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LogMessageToFile("Row has been added");
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            dgrTable.DataSource = table;
            LogMessageToFile("Reset filter");
            FillTypeBox();
        }

        public static void LogMessageToFile(string msg)
        {
            try
            {
                System.IO.FileInfo f = new System.IO.FileInfo(LOG_FILENAME);
                long lLength = f.Length;

                if (lLength > 100 * 1024 * 1024)
                    f.Delete();
            }
            catch { }

            msg = string.Format("{0:G}: {1}\r\n", DateTime.Now, msg);
            System.IO.File.AppendAllText(LOG_FILENAME, msg);
        }
    }
    public static class StreamReaderSequence
    {
        public static IEnumerable<string> Lines(this StreamReader source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            string line;
            while ((line = source.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
