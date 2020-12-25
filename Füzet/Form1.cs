using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Füzet
{

    public partial class Form1 : Form
    {
        private List<Elemek> GetElem()
        {
            var list = new List<Elemek>();

            string filePath = "fuzet.csv";
            if (!File.Exists("fuzet.csv"))
            {
                using (FileStream fs = File.Create(filePath)) ;
            }
            StreamReader file = new StreamReader("fuzet.csv");

            while (!file.EndOfStream)
            {
                string[] data = file.ReadLine().Split(';');

                switch (data.Length)
                {
                    case 5:
                        list.Add(new Elemek()
                        {
                            SorSzam = int.Parse(data[0]),
                            Datum = data[1],
                            Tema = data[2],
                            Leiras = data[3],
                            Megjegyzes = data[4],
                        });
                        break;
                }
            }
            file.Close();
            return list;
        }

        public List<Elemek> Elem { set; get; }
        public Form1()
        {
            Elem = GetElem();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var elem = this.Elem;
            dataGridView1.DataSource = elem;
            dataGridView1.Columns["SorSzam"].Visible = false;
            dataGridView1.Columns["Datum"].HeaderText = "Dátum";
            dataGridView1.Columns["Tema"].HeaderText = "Téma";
            dataGridView1.Columns["Leiras"].HeaderText = "Leírás";
            dataGridView1.Columns["Megjegyzes"].HeaderText = "Megjegyzés";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedElemek = dataGridView1.SelectedRows[0].DataBoundItem as Elemek;
                if (checkBox2.Checked == true)
                {
                    textBox1.Text = selectedElemek.Datum;
                    textBox2.Text = selectedElemek.Tema;
                    textBox3.Text = selectedElemek.Leiras;
                    textBox4.Text = selectedElemek.Megjegyzes;
                }
                if (checkBox3.Checked == true)
                {
                    MessageBox.Show(

                   "Téma: " + selectedElemek.Tema
                   + "\nLeírás: " + selectedElemek.Leiras
                   + "\nMegjegyzés: " + selectedElemek.Megjegyzes, selectedElemek.Datum);
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Hiba: " + ex.Message + " - " + ex.Source); }
        }
        private void DatumGomb_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = DateTime.Now.ToString("yyyy.MM.dd. (HH:mm:ss)"); }
        }
        private void HozzAadGomb_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string filePath = ("fuzet.csv");
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines) ;
                lines.Add(lines.Count + 1 + ";" + textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text + ";" + textBox4.Text);
                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Sikeresen mentve", textBox1.Text);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                Elem = GetElem();
                var elem = this.Elem;
                dataGridView1.DataSource = elem;
            }
            else { MessageBox.Show("Töltsön ki minden mezőt", "Hiba"); }
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox4.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                panel2.Visible = true;
            }
            else
            {
                checkBox4.Enabled = false;
                checkBox4.Checked = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                panel2.Visible = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                textBox5.Enabled = false;
            }
        }

        private void TemaGomb_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            { textBox2.Text = "-"; }
        }

        private void LeirasGomb_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            { textBox3.Text = "-"; }
        }

        private void MegjegyzesGomb_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            { textBox4.Text = "-"; }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {

            if (checkBox4.Checked == true)
            {
                textBox5.Enabled = true;
                button6.Visible = true;
            }
            else
            {
                textBox5.Enabled = false;
                textBox5.Text = "";
                button6.Visible = false;
                Elem = GetElem();
                var elem = this.Elem;
                dataGridView1.DataSource = elem;
            }
        }
        private List<Elemek> Keres()
        {
            var kereseslist = new List<Elemek>();
           // string filePath = "fuzet.csv";
            string s = textBox5.Text;
            StreamReader filee = new StreamReader("fuzet.csv");
            while (!filee.EndOfStream)
            {
                string[] data = filee.ReadLine().Split(';');
                  
               
                if (data[1].Contains(s)|| data[2].Contains(s) || data[3].Contains(s) || data[4].Contains(s) )
                {
                    kereseslist.Add(new Elemek()
                    {
                        SorSzam = int.Parse(data[0]),
                        Datum = data[1],
                        Tema = data[2],
                        Leiras = data[3],
                        Megjegyzes = data[4],
                    });   
                }
            }
            filee.Close();
            return kereseslist;
        }
        
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Elem = Keres();
            var kereslist = this.Elem;
            dataGridView1.DataSource = kereslist;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true && textBox1.Text != "")
            {
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text + "\n" + textBox2.Text + "\n" + textBox3.Text + "\n" + textBox4.Text, new Font("Time New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            Elem = Keres();
            var kereslist = this.Elem;
            dataGridView1.DataSource = kereslist;
            MessageBox.Show("duplaKlikk oké", "Szöveg");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
    }
}
