using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace posforKotaStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double burger= 30;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Large Burger"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + burger
                        ;
                }
            }
            dataGridView1.Rows.Add("Large Burger", "1", burger);
            totalCost();


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            double coke = 15;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Coca-Cola original"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + coke;
                }
            }
            dataGridView1.Rows.Add("Coka-Cola original", "1", coke);
            totalCost();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double pizza = 70;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Large Pizza"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + pizza;
                }
            }
            dataGridView1.Rows.Add("Large Pizza", "1", pizza);
            totalCost();


        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            double SPizza = 10;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Special Pizza"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + SPizza;
                }
            }
            dataGridView1.Rows.Add("Special Pizza", "1", SPizza);
            totalCost();


        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            double kota = 20;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Large Kota"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + kota;
                }
            }
            dataGridView1.Rows.Add("Large Kota", "1", kota);
            totalCost();


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int h = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = h;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            try
            {
                txtChange.Text = "";
                txtCost.Text = "";
                txtMethod.Text = "";
                txtSubTotal.Text = "";
                txtTax.Text = "";
                txtTotal.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void digits(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (txtCost.Text == "0")
            {
                txtCost.Text = "";
                txtCost.Text = b.Text;

            }
            else if (b.Text == ".")
            {
                if (!txtCost.Text.Contains("."))
                {
                    txtCost.Text = txtCost.Text + b.Text;

                }
               
            }
            else
            {
                txtCost.Text = txtCost.Text + b.Text;
            }



        }
        public double AccumCost()
        {
            double sum = 0;
            //int i = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum;
        }

        private void totalCost()
        {
            Double tax = 15;
            if (dataGridView1.Rows.Count>0)
            {
                
                   Double dblTax=((( AccumCost() * tax )/ 100));
                txtTax.Text = dblTax.ToString();
                Double dbtSubtot= (AccumCost());
                txtSubTotal.Text = dbtSubtot.ToString();
                Double dblTotal = (AccumCost() * (tax / 100)) + AccumCost();
                txtTotal.Text = dblTotal.ToString();

            }
        }
        public void Change()
        {
            Double tax = 15;
            if(dataGridView1.Rows.Count>0){


                Double dblChange = (( Convert.ToInt32(txtCost.Text)) - ((AccumCost() * (tax / 100)) + AccumCost()));
                txtChange.Text = dblChange.ToString();
            }
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            txtCost.Text = "0";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (txtMethod.Text == "Cash")
            {
                Change();
            }
            else
            {
                txtChange.Text = "";
                txtCost.Text = "0";

            }
        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            double pizza = 10;
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if((bool)(row.Cells[0].Value="Small Pizza"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + pizza;
                }
            }
            dataGridView1.Rows.Add("Small Pizza", "1", pizza);
            totalCost();


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            totalCost();
            if (txtMethod.Text == "Cash")
            {
                Change();
            }
            else
            {
                txtChange.Text = "";
                txtCost.Text = "0";

            }
        }

        private void btnKotaSmall_Click(object sender, EventArgs e)
        {
            double KOTA = 10;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Small Kota"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + KOTA;
                }
            }
            dataGridView1.Rows.Add("Small Kota", "1", KOTA);
            totalCost();



        }

        private void btnGwinya_Click(object sender, EventArgs e)
        {
            double fatty = 2;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Fatty"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + fatty;
                }
            }
            dataGridView1.Rows.Add("Single Fatty", "1",fatty);
            totalCost();

        }

        private void button24_Click(object sender, EventArgs e)
        {
            double Specialkota = 10;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Special Kota"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) + Specialkota;
                }
            }
            dataGridView1.Rows.Add("Special Kota", "1", Specialkota);
            totalCost();

        }
    }
}
