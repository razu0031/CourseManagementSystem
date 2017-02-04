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
    public partial class StartForm : Form
    {
        
        public StartForm()
        {
            CustomInitializeComponent();
            
        }
        
        public void CustomInitializeComponent()
        {
            InitializeComponent();

            ApplicationHeadingTableLayoutPanel.BackColor = Color.FromArgb(0,120,110);
            BaseTableLayoutPanel.BackColor = Color.FromArgb(190, 255, 255);
            // BaseTableLayoutPanel.BackgroundImage = CourseManagementSystem1.Properties.Resources.bg;
            //TimeLabelName.BackColor = Color.Transparent;
            
            DateTimePickerTimer.Start();
            TimeLabelName.ForeColor= Color.FromArgb(0, 120, 110);
            DayLabelName.ForeColor = Color.FromArgb(0, 120, 110);
            DateLabelName.ForeColor = Color.FromArgb(0, 120, 110);
            //TimeLabelName.BackColor = Color.FromArgb(0, 120, 110);

            makeButtonTranparent(AdminButtonName);
            makeButtonTranparent(TeacherButtonName);
            makeButtonTranparent(StudentButtonName);

            makeLabelTranparent(TimeLabelName);

            // AdminButtonName.SetStyle(ControlStyles.SupportsTransparentBackColor, True);


            // AdminButtonName.BackColor = Color.FromArgb(100, 88, 44, 55);
            //int t=(int)ApplicationHeadingTableLayoutPanel.RowStyles[0].Height;
            //CourseLabelName.Font = new Font("Algerian", 10);
            // CourseLabelName.Text = t.ToString();

        }

        private void StartForm_Resize(object sender, EventArgs e)
        {
            //int t = (int)ApplicationHeadingTableLayoutPanel.RowStyles[0].Height;
            int s1 = ApplicationHeadingTableLayoutPanel.Height;
            int s2 = (int)(s1 * .25);
            if(s2>0)CourseLabelName.Font = new Font("Algerian", s2);
            // ManagementLabelName.Font = new Font("Algerian", s2);

            int buttonSize = AdminButtonName.Height;
            int buttonTextSize = (int)(buttonSize*.4);
            if (buttonTextSize > 0)
            {
                AdminButtonName.Font = new Font("Microsoft Sans Serif", buttonTextSize);
                TeacherButtonName.Font = new Font("Microsoft Sans Serif", buttonTextSize);
                StudentButtonName.Font = new Font("Microsoft Sans Serif", buttonTextSize);

                TimeLabelName.Font = new Font("Microsoft Sans Serif", buttonTextSize);
                DayLabelName.Font = new Font("Microsoft Sans Serif", buttonTextSize);
                DateLabelName.Font = new Font("Microsoft Sans Serif", buttonTextSize);

                ExitButtonName.Width = buttonSize;
                ExitButtonName.Height = buttonSize;

                Image exitButtonBackgroundImageSource = global::CourseManagementSystem1.Properties.Resources.exit2;
                var exitButtonBackgroundImage = new Bitmap(exitButtonBackgroundImageSource, new Size(buttonSize, buttonSize));
                ExitButtonName.BackgroundImage = exitButtonBackgroundImage;

                int m3 = AdminButtonName.Height;

                AdminButtonName.Margin = new System.Windows.Forms.Padding((int)(m3 * .18));
                TeacherButtonName.Margin = new System.Windows.Forms.Padding((int)(m3 * .18));
                StudentButtonName.Margin = new System.Windows.Forms.Padding((int)(m3 * .18));

                Image exitButtonBackgroundImageSource2 = global::CourseManagementSystem1.Properties.Resources.transparentBG;
                var exitButtonBackgroundImage2 = new Bitmap(exitButtonBackgroundImageSource2, new Size(AdminButtonName.Width, AdminButtonName.Height));
                AdminButtonName.BackgroundImage = exitButtonBackgroundImage2;

                TeacherButtonName.BackgroundImage = exitButtonBackgroundImage2;
                StudentButtonName.BackgroundImage = exitButtonBackgroundImage2;
            }

            /* int m = AdminButtonName.Height;
             string m2 = AdminButtonName.Margin.ToString();

             CourseLabelName.Text = m.ToString() + "  " + m2;*/


        }

       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AdminButtonName_Click(object sender, EventArgs e)
        {

            //AdminPanelForm adminPanelFrom = new AdminPanelForm();
            /* Form1 adminPanelFrom = new Form1();
             //this.SetVisibleCore(false);
             adminPanelFrom.ShowDialog();
             AdminPanelForm adminPanelFrom1 = new AdminPanelForm();
             this.SetVisibleCore(false);
             adminPanelFrom1.ShowDialog();
             this.SetVisibleCore(true);
             */

            AdminLogInForm adminPanelFrom = new AdminLogInForm();
            
            this.SetVisibleCore(false);
            adminPanelFrom.ShowDialog();
            this.SetVisibleCore(true);


        }

        
    


        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void DateTimePickerTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            var time = dateTime.ToLongTimeString();
            var day = dateTime.DayOfWeek;
            var month = dateTime.Month;
            var year = dateTime.Year;
            var date = DateTime.DaysInMonth(year, month);

            TimeLabelName.Text = time.ToString();
            DayLabelName.Text = day.ToString();
            DateLabelName.Text = getMonthDateYear(month, date, year);
        }

        public String getMonthDateYear(int month, int date, int year)
        {
            String monthDateYear = null;
            string monthName = null;

            if (month == 1) monthName = "January";
            if (month == 2) monthName = "February";
            if (month == 3) monthName = "March";
            if (month == 4) monthName = "April";
            if (month == 5) monthName = "May";
            if (month == 6) monthName = "June";
            if (month == 7) monthName = "July";
            if (month == 8) monthName = "August";
            if (month == 9) monthName = "September";
            if (month == 10) monthName = "October";
            if (month == 11) monthName = "November";
            if (month == 12) monthName = "December";

            monthDateYear = monthName + " " + date + ", " + year;

            return monthDateYear;
        }

        public void makeButtonTranparent(Button button)
        {
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 200, 200);
            button.BackColor = Color.Transparent;
        }

        public void makeLabelTranparent(Label label)
        {
            label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label.BackColor = Color.Transparent;
        }

        private void ExitButtonName_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TeacherButtonName_Click(object sender, EventArgs e)
        {
            TeacherPanelForm adminPanelFrom = new TeacherPanelForm();
            this.SetVisibleCore(false);
            adminPanelFrom.ShowDialog();
            this.SetVisibleCore(true);
           /* AdminPanelForm adminPanelFrom = new AdminPanelForm();
            this.SetVisibleCore(false);
            adminPanelFrom.ShowDialog();
            this.SetVisibleCore(true);
            */
        }

        private void StudentButtonName_Click(object sender, EventArgs e)
        {
            
            StudentPanelForm studentPanelFrom = new StudentPanelForm();
            this.SetVisibleCore(false);
            studentPanelFrom.ShowDialog();
            this.SetVisibleCore(true);
            
           /* UpdateDataForm u = new UpdateDataForm();
            u.ShowDialog();
            */
            
        }
    }
}
