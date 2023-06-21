using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
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
                if (serialPort1.IsOpen == false)
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

            label2.Text = "습도 : " + data[0] + "%";
            label3.Text = "온도 : " + data[1] + "'c";
            label4.Text = "미세먼지 : " + data[2]; // + "mg/m3"  //임시로 다른값

            string date = DateTime.Now.ToString();

            //리스트뷰
            ListViewItem lvi = new ListViewItem();            
            lvi.SubItems.Add(data[0]);  // 습도
            lvi.SubItems.Add(data[1]);  // 온도
            lvi.SubItems.Add(data[2]);  // 미세먼지
            lvi.Text = DateTime.Now.ToString();
            listView1.Items.Add(lvi);   //데이터 추가?
            listView1.EnsureVisible(listView1.Items.Count - 1); // 새로 받아오는 데이터 자동스크롤
        }

        Moniter f; // Form2 
        private void lblForm2_Click(object sender, EventArgs e)
        {
            
            if(f== null)
               f = new Moniter(this);
            f.Show();
            
        }
    }
}
