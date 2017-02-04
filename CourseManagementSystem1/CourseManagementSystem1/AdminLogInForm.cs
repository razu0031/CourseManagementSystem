using Plasmoid.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementSystem1
{
    public partial class AdminLogInForm : Form
    {
        int s;

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        public AdminLogInForm()
        {
            InitializeComponent();

            LogInButtonName.BackColor= Color.FromArgb(0, 200, 200);
            SuperAdminButtonName.BackColor = Color.FromArgb(0, 200, 200);
            BackButtonName.BackColor = Color.FromArgb(0, 200, 200);

            SendMessage(UserNameTextBoxName.Handle, EM_SETCUEBANNER, 1, "User Name");
            SendMessage(PasswordTextBoxName.Handle, EM_SETCUEBANNER, 1, "Password");

           
            //Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox1.Width, groupBox1.Height, 20, 20));
            //Graphics g = new Graphics(;

        }

        private void AdminPanelForm_Resize(object sender, EventArgs e)
        {
            int size1 = AdminHeaderPanel.Height;
            int size2 = (int)(size1 * .25);
            if (size2 > 0) AdminHeaderLabelName.Font = new Font("Cambria", size2);

            int size3 = LogInButtonName.Height;
            int size4 = (int)(size3 * .35);
            if (size4 > 0)
            {
                LogInButtonName.Font = new Font("Cambria", size4);
                SuperAdminButtonName.Font = new Font("Cambria", size4+1);

                UserNameTextBoxName.Font= new Font("Cambria", size4);
                PasswordTextBoxName.Font = new Font("Cambria", size4);

                s = size4;

                UserNameTextBoxName.AutoSize = false;
                PasswordTextBoxName.AutoSize = false;
                //textBox1.Size = new Size(228, size4+5);
            }
        }


        private void LogInButtonName_Click(object sender, EventArgs e)
        {
            try
            {
                string userNameHere = UserNameTextBoxName.Text;
                string passwordHere = PasswordTextBoxName.Text;

                if (!String.IsNullOrEmpty(userNameHere.Trim()) &&
                    !String.IsNullOrEmpty(passwordHere.Trim())
                   )
                {
                    if(userNameHere.Equals("admin") && passwordHere.Equals("admin"))
                    {
                        AdminPanelForm adminPanelFrom = new AdminPanelForm();

                        this.SetVisibleCore(false);
                        adminPanelFrom.ShowDialog();
                        this.SetVisibleCore(true);

                        UserNameTextBoxName.Text=null;
                        PasswordTextBoxName.Text=null;
                    }
                    else MessageBox.Show("Username or Password is Incorrect");

                }
                else MessageBox.Show("Select all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }

            
        }

        private void SuperAdminButtonName_Click(object sender, EventArgs e)
        {

        }

        private void BackButtonName_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            //Upper-right arc:
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            //Lower-right arc:
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            //Lower-left arc:
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            //Upper-left arc:
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminPanelForm_Paint(object sender, PaintEventArgs e)
        {
           /* Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRoundedRectangle(new SolidBrush(ControlPaint.Dark(SystemColors.GradientActiveCaption, 0.2f)), 10, 10, this.Width - 40, this.Height - 60, 10);
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(this.Width / 2, 0),
                new Point(this.Width / 2, this.Height),
                SystemColors.GradientInactiveCaption,
                ControlPaint.Dark(SystemColors.GradientActiveCaption, 0.5f)
                );
            g.FillRoundedRectangle(brush, 12, 12, this.Width - 44, this.Height - 64, 10);
            g.DrawRoundedRectangle(new Pen(ControlPaint.Light(SystemColors.InactiveBorder, 0.00f)), 12, 12, this.Width - 44, this.Height - 64, 10);
            g.FillRoundedRectangle(new SolidBrush(Color.FromArgb(100, 70, 130, 180)), 12, 12 + ((this.Height - 64) / 2), this.Width - 44, (this.Height - 64) / 2, 10);
            */
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            /*Graphics v = e.Graphics;
           DrawRoundRect(v, Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
           //Without rounded corners
           //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
           base.OnPaint(e);
           */
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.Menu,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, AdminLogInFormPanel.Width, AdminLogInFormPanel.Height, 10);
           
        }

        private void LogInButtonName_Paint(object sender, PaintEventArgs e)
        {
            /* Graphics g = e.Graphics;
             Color color = Color.FromArgb(0, 200, 200);

             g.SmoothingMode = SmoothingMode.AntiAlias;
             LinearGradientBrush brush = new LinearGradientBrush(
                 new Point(0, 0),
                 new Point(this.Width, this.Height),
                 color,
                 ControlPaint.Dark(color, 5f)
                 );

             g.FillRoundedRectangle(brush, 0, 0, button1.Width, button1.Height, 5);
             */
        }

        private void LogInButtonName_MouseEnter(object sender, EventArgs e)
        {
            LogInButtonName.BackColor = Color.DarkCyan;
        }

        private void LogInButtonName_MouseLeave(object sender, EventArgs e)
        {
            LogInButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void LogInButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            LogInButtonName.BackColor = Color.LightGray;
        }

        private void LogInButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            LogInButtonName.BackColor = Color.DarkCyan;
        }

        private void SuperAdminButtonName_MouseEnter(object sender, EventArgs e)
        {
            SuperAdminButtonName.BackColor = Color.DarkCyan;
        }

        private void SuperAdminButtonName_MouseLeave(object sender, EventArgs e)
        {
            SuperAdminButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void SuperAdminButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            SuperAdminButtonName.BackColor = Color.LightGray;
        }

        private void SuperAdminButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            SuperAdminButtonName.BackColor = Color.DarkCyan;
        }

        private void BackButtonName_MouseEnter(object sender, EventArgs e)
        {
            BackButtonName.BackColor = Color.DarkCyan;
        }

        private void BackButtonName_MouseLeave(object sender, EventArgs e)
        {
            BackButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void BackButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            BackButtonName.BackColor = Color.LightGray;
        }

        private void BackButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            BackButtonName.BackColor = Color.DarkCyan;
        }

        private void PasswordTextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            PasswordTextBoxName.Font = new Font("Cambria",s+3);
        }

        private void PasswordTextBoxName_Leave(object sender, EventArgs e)
        {
            PasswordTextBoxName.Font = new Font("Cambria",s );
        }
    }
}
