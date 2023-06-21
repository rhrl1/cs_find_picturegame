using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Moniter : Form
    {
        Form1 f;
        public Moniter(Form1 form)
        {
            InitializeComponent();
            f = form;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Form1의 측정값을 불러오기 (Modifiers 속성 public)
            lblHumi.Text = f.label2.Text;
            lblTemp.Text= f.label3.Text;
            label6.Text = f.label4.Text;
        }
    }
}
