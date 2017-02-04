using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementSystem1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(0, 120, 110);
            tableLayoutPanel1.BackColor = Color.FromArgb(190, 255, 255);
            tableLayoutPanel2.BackColor= Color.FromArgb(0, 120, 110);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*AdminPanelForm adminPanelFrom = new AdminPanelForm();
            this.SetVisibleCore(false);
            adminPanelFrom.ShowDialog();*/
            this.Close();
            // this.SetVisibleCore(true);
        }
    }
}
