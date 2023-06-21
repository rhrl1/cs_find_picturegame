using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("입력");
            else
            {
                serialPort1.PortName = textBox1.Text;
                if(serialPort1.IsOpen  == false)
                {
                    serialPort1.Open();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string rawdata = label2.Text = serialPort1.ReadLine();

            string[] data = rawdata.Split(',');
            label2.Text = data[0] + "," + data[1] + "," + data[2];
            /*
            label2.Text = "습도 : " + data[0] + "%";
            label3.Text = "온도 : " + data[1] + "'c";
            label4.Text = "체감온도 : " + data[2] + "'c";
            */
        }
    }
}
