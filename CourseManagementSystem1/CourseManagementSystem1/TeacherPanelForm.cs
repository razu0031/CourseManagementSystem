using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementSystem1
{
    public partial class TeacherPanelForm : Form
    {
        ManageDataDatabaseControlClass manageDataDatabaseControlClass = new ManageDataDatabaseControlClass();
        RoutineManagementDatabaseControlClass routineManagementDatabaseControlClass = new RoutineManagementDatabaseControlClass();

        string[] yearArray = new string[] { "1st", "2nd", "3rd", "4th" };

        string[] semesterArray = new string[] { "1st", "2nd" };

        string[] sectionArray = new string[] { "A", "B", "C" };

        string[] dayArray = new string[] { "Saturday", "Sunday", "Monday", "Tuesdaay","Wednesday","Thursday" };

        string[] searchSelectionArray = new string[] { "by Teacher", "by Room", "by Time","by Day" };

        string[] saturday800 = new string[3];
        string[] saturday850 = new string[3];
        string[] saturday940 = new string[3];
        string[] saturday1030 = new string[3];
        string[] saturday1120 = new string[3];
        string[] saturday1210 = new string[3];
        string[] saturday100 = new string[3];
        string[] saturday150 = new string[3];
        string[] saturday240 = new string[3];
        string[] saturday330 = new string[3];
        string[] saturday420 = new string[3];

        string[] sunday800 = new string[3];
        string[] sunday850 = new string[3];
        string[] sunday940 = new string[3];
        string[] sunday1030 = new string[3];
        string[] sunday1120 = new string[3];
        string[] sunday1210 = new string[3];
        string[] sunday100 = new string[3];
        string[] sunday150 = new string[3];
        string[] sunday240 = new string[3];
        string[] sunday330 = new string[3];
        string[] sunday420 = new string[3];

        string[] monday800 = new string[3];
        string[] monday850 = new string[3];
        string[] monday940 = new string[3];
        string[] monday1030 = new string[3];
        string[] monday1120 = new string[3];
        string[] monday1210 = new string[3];
        string[] monday100 = new string[3];
        string[] monday150 = new string[3];
        string[] monday240 = new string[3];
        string[] monday330 = new string[3];
        string[] monday420 = new string[3];

        string[] tuesday800 = new string[3];
        string[] tuesday850 = new string[3];
        string[] tuesday940 = new string[3];
        string[] tuesday1030 = new string[3];
        string[] tuesday1120 = new string[3];
        string[] tuesday1210 = new string[3];
        string[] tuesday100 = new string[3];
        string[] tuesday150 = new string[3];
        string[] tuesday240 = new string[3];
        string[] tuesday330 = new string[3];
        string[] tuesday420 = new string[3];

        string[] wednesday800 = new string[3];
        string[] wednesday850 = new string[3];
        string[] wednesday940 = new string[3];
        string[] wednesday1030 = new string[3];
        string[] wednesday1120 = new string[3];
        string[] wednesday1210 = new string[3];
        string[] wednesday100 = new string[3];
        string[] wednesday150 = new string[3];
        string[] wednesday240 = new string[3];
        string[] wednesday330 = new string[3];
        string[] wednesday420 = new string[3];

        string[] thursday800 = new string[3];
        string[] thursday850 = new string[3];
        string[] thursday940 = new string[3];
        string[] thursday1030 = new string[3];
        string[] thursday1120 = new string[3];
        string[] thursday1210 = new string[3];
        string[] thursday100 = new string[3];
        string[] thursday150 = new string[3];
        string[] thursday240 = new string[3];
        string[] thursday330 = new string[3];
        string[] thursday420 = new string[3];


        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]


        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);


        public TeacherPanelForm()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(950, 600);

            YearInputRoutineComboBox.Items.AddRange(yearArray);
            SemesterInputRoutineComboBox.Items.AddRange(semesterArray);
            SectionInputRoutineComboBox.Items.AddRange(sectionArray);
            DayNameComboBox.Items.AddRange(dayArray);
            SearchByComboBox.Items.AddRange(searchSelectionArray);

            manageDataDatabaseControlClass.StudentPanelRefreshDepartmentCombobox(DepartmentInputRoutineComboBox);

            SendMessage(TeacherNameTextBox.Handle, EM_SETCUEBANNER, 1, "Teacher Name");
            SendMessage(searchNameTextBox.Handle, EM_SETCUEBANNER, 1, "Type what to search");

        }

        private void TeacherPanelForm_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageDataHeaderLabelName_Click(object sender, EventArgs e)
        {

        }

        private void TeacherPanelForm_Resize(object sender, EventArgs e)
        {
            int size1 = TeacherPanelHeaderLabelName.Height;
            int size2 = (int)(size1 * .3);
            if (size2 > 0) TeacherPanelHeaderLabelName.Font = new Font("Cambria", size2);

            int size3 = (int)(size1 * .17);
            if (size3 > 0)
            {
                InputRoutineBaseTableLayoutPanel.Font = new Font("Cambria", size3 + 1);
                tabControl1.Font = new Font("Cambria", size3 + 1);
            }

            int size5 = TeacherPanelHeaderLabelName.Height;
            int size4 = (int)(size5 * .17);
            if (size4 > 0)
            {
                DepartmentInputRoutineComboBox.Font = new Font("Cambria", size4 + 3);
                YearInputRoutineComboBox.Font = new Font("Cambria", size4 + 3);
                SemesterInputRoutineComboBox.Font = new Font("Cambria", size4 + 3);

            }
        }


        public void refreshListBoxes(int routineIdHere)
        {
            string dayHere = null;
            string timeHere = null;


            saturday800 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "8:00-8:50");
            saturday850 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "8:50-9:40");
            saturday940 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "9:40-10:30");
            saturday1030 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "10:30-11:20");
            saturday1120 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "11:20-12:10");
            saturday1210 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "12:10-1:00");
            saturday100 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "1:00-1:50");
            saturday150 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "1:50-2:40");
            saturday240 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "2:40-3:30");
            saturday330 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "3:30-4:20");
            saturday420 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "4:20-5:10");

            sunday800 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "8:00-8:50");
            sunday850 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "8:50-9:40");
            sunday940 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "9:40-10:30");
            sunday1030 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "10:30-11:20");
            sunday1120 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "11:20-12:10");
            sunday1210 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "12:10-1:00");
            sunday100 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "1:00-1:50");
            sunday150 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "1:50-2:40");
            sunday240 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "2:40-3:30");
            sunday330 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "3:30-4:20");
            sunday420 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Sunday", "4:20-5:10");

            monday800 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "8:00-8:50");
            monday850 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "8:50-9:40");
            monday940 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "9:40-10:30");
            monday1030 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "10:30-11:20");
            monday1120 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "11:20-12:10");
            monday1210 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "12:10-1:00");
            monday100 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "1:00-1:50");
            monday150 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "1:50-2:40");
            monday240 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "2:40-3:30");
            monday330 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "3:30-4:20");
            monday420 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Monday", "4:20-5:10");

            tuesday800 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "8:00-8:50");
            tuesday850 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "8:50-9:40");
            tuesday940 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "9:40-10:30");
            tuesday1030 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "10:30-11:20");
            tuesday1120 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "11:20-12:10");
            tuesday1210 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "12:10-1:00");
            tuesday100 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "1:00-1:50");
            tuesday150 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "1:50-2:40");
            tuesday240 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "2:40-3:30");
            tuesday330 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "3:30-4:20");
            tuesday420 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Tuesday", "4:20-5:10");

            wednesday800 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "8:00-8:50");
            wednesday850 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "8:50-9:40");
            wednesday940 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "9:40-10:30");
            wednesday1030 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "10:30-11:20");
            wednesday1120 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "11:20-12:10");
            wednesday1210 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "12:10-1:00");
            wednesday100 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "1:00-1:50");
            wednesday150 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "1:50-2:40");
            wednesday240 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "2:40-3:30");
            wednesday330 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "3:30-4:20");
            wednesday420 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Wednesday", "4:20-5:10");

            thursday800 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "8:00-8:50");
            thursday850 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "8:50-9:40");
            thursday940 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "9:40-10:30");
            thursday1030 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "10:30-11:20");
            thursday1120 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "11:20-12:10");
            thursday1210 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "12:10-1:00");
            thursday100 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "1:00-1:50");
            thursday150 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "1:50-2:40");
            thursday240 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "2:40-3:30");
            thursday330 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "3:30-4:20");
            thursday420 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Thursday", "4:20-5:10");

            //clearListBoxes();
            populateListBoxes();
        }

        public string[] getAClassInfo(int idHere, string dayHere, string Time)
        {
            string[] dayTimeOfClass = new string[3];


            try
            {
                string courseCodeHere = "";
                string roomNoHere = "";
                string teacherNameHere = "";

                try
                {
                    if (!string.IsNullOrEmpty(courseCodeHere.Trim())) dayTimeOfClass[0] = courseCodeHere;
                    else dayTimeOfClass[0] = "";
                }
                catch (NullReferenceException ex) { dayTimeOfClass[0] = ""; }

                try
                {
                    if (!string.IsNullOrEmpty(roomNoHere.Trim())) dayTimeOfClass[1] = roomNoHere;
                    else dayTimeOfClass[1] = "";
                }
                catch (NullReferenceException ex) { dayTimeOfClass[1] = ""; }

                try
                {
                    if (!string.IsNullOrEmpty(teacherNameHere.Trim())) dayTimeOfClass[2] = teacherNameHere;
                    else dayTimeOfClass[2] = "";
                }
                catch (NullReferenceException ex) { dayTimeOfClass[2] = ""; }

                return dayTimeOfClass;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
                //dayTimeOfClass = "";
            }

            return dayTimeOfClass;
        }

        public void populateListBoxes()
        {
            clearListBoxes();

            try
            {

                Saturday800ListBox.Items.AddRange(saturday800);
                Saturday850ListBox.Items.AddRange(saturday850);
                Saturday940ListBox.Items.AddRange(saturday940);
                Saturday1030ListBox.Items.AddRange(saturday1030);
                Saturday1120ListBox.Items.AddRange(saturday1120);
                Saturday1210ListBox.Items.AddRange(saturday1210);
                Saturday100ListBox.Items.AddRange(saturday100);
                Saturday150ListBox.Items.AddRange(saturday150);
                Saturday240ListBox.Items.AddRange(saturday240);
                Saturday330ListBox.Items.AddRange(saturday330);
                Saturday420ListBox.Items.AddRange(saturday420);

                Sunday800ListBox.Items.AddRange(sunday800);
                Sunday850ListBox.Items.AddRange(sunday850);
                Sunday940ListBox.Items.AddRange(sunday940);
                Sunday1030ListBox.Items.AddRange(sunday1030);
                Sunday1120ListBox.Items.AddRange(sunday1120);
                Sunday1210ListBox.Items.AddRange(sunday1210);
                Sunday100ListBox.Items.AddRange(sunday100);
                Sunday150ListBox.Items.AddRange(sunday150);
                Sunday240ListBox.Items.AddRange(sunday240);
                Sunday330ListBox.Items.AddRange(sunday330);
                Sunday420ListBox.Items.AddRange(sunday420);

                Monday800ListBox.Items.AddRange(monday800);
                Monday850ListBox.Items.AddRange(monday850);
                Monday940ListBox.Items.AddRange(monday940);
                Monday1030ListBox.Items.AddRange(monday1030);
                Monday1120ListBox.Items.AddRange(monday1120);
                Monday1210ListBox.Items.AddRange(monday1210);
                Monday100ListBox.Items.AddRange(monday100);
                Monday150ListBox.Items.AddRange(monday150);
                Monday240ListBox.Items.AddRange(monday240);
                Monday330ListBox.Items.AddRange(monday330);
                Monday420ListBox.Items.AddRange(monday420);

                Tuesday800ListBox.Items.AddRange(tuesday800);
                Tuesday850ListBox.Items.AddRange(tuesday850);
                Tuesday940ListBox.Items.AddRange(tuesday940);
                Tuesday1030ListBox.Items.AddRange(tuesday1030);
                Tuesday1120ListBox.Items.AddRange(tuesday1120);
                Tuesday1210ListBox.Items.AddRange(tuesday1210);
                Tuesday100ListBox.Items.AddRange(tuesday100);
                Tuesday150ListBox.Items.AddRange(tuesday150);
                Tuesday240ListBox.Items.AddRange(tuesday240);
                Tuesday330ListBox.Items.AddRange(tuesday330);
                Tuesday420ListBox.Items.AddRange(tuesday420);

                Wednesday800ListBox.Items.AddRange(wednesday800);
                Wednesday850ListBox.Items.AddRange(wednesday850);
                Wednesday940ListBox.Items.AddRange(wednesday940);
                Wednesday1030ListBox.Items.AddRange(wednesday1030);
                Wednesday1120ListBox.Items.AddRange(wednesday1120);
                Wednesday1210ListBox.Items.AddRange(wednesday1210);
                Wednesday100ListBox.Items.AddRange(wednesday100);
                Wednesday150ListBox.Items.AddRange(wednesday150);
                Wednesday240ListBox.Items.AddRange(wednesday240);
                Wednesday330ListBox.Items.AddRange(wednesday330);
                Wednesday420ListBox.Items.AddRange(wednesday420);

                Thursday800ListBox.Items.AddRange(thursday800);
                Thursday850ListBox.Items.AddRange(thursday850);
                Thursday940ListBox.Items.AddRange(thursday940);
                Thursday1030ListBox.Items.AddRange(thursday1030);
                Thursday1120ListBox.Items.AddRange(thursday1120);
                Thursday1210ListBox.Items.AddRange(thursday1210);
                Thursday100ListBox.Items.AddRange(thursday100);
                Thursday150ListBox.Items.AddRange(thursday150);
                Thursday240ListBox.Items.AddRange(thursday240);
                Thursday330ListBox.Items.AddRange(thursday330);
                Thursday420ListBox.Items.AddRange(thursday420);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }

        public void clearListBoxes()
        {
            Saturday800ListBox.Items.Clear();
            Saturday850ListBox.Items.Clear();
            Saturday940ListBox.Items.Clear();
            Saturday1030ListBox.Items.Clear();
            Saturday1120ListBox.Items.Clear();
            Saturday1210ListBox.Items.Clear();
            Saturday100ListBox.Items.Clear();
            Saturday150ListBox.Items.Clear();
            Saturday240ListBox.Items.Clear();
            Saturday330ListBox.Items.Clear();
            Saturday420ListBox.Items.Clear();

            Sunday800ListBox.Items.Clear();
            Sunday850ListBox.Items.Clear();
            Sunday940ListBox.Items.Clear();
            Sunday1030ListBox.Items.Clear();
            Sunday1120ListBox.Items.Clear();
            Sunday1210ListBox.Items.Clear();
            Sunday100ListBox.Items.Clear();
            Sunday150ListBox.Items.Clear();
            Sunday240ListBox.Items.Clear();
            Sunday330ListBox.Items.Clear();
            Sunday420ListBox.Items.Clear();

            Monday800ListBox.Items.Clear();
            Monday850ListBox.Items.Clear();
            Monday940ListBox.Items.Clear();
            Monday1030ListBox.Items.Clear();
            Monday1120ListBox.Items.Clear();
            Monday1210ListBox.Items.Clear();
            Monday100ListBox.Items.Clear();
            Monday150ListBox.Items.Clear();
            Monday240ListBox.Items.Clear();
            Monday330ListBox.Items.Clear();
            Monday420ListBox.Items.Clear();

            Tuesday800ListBox.Items.Clear();
            Tuesday850ListBox.Items.Clear();
            Tuesday940ListBox.Items.Clear();
            Tuesday1030ListBox.Items.Clear();
            Tuesday1120ListBox.Items.Clear();
            Tuesday1210ListBox.Items.Clear();
            Tuesday100ListBox.Items.Clear();
            Tuesday150ListBox.Items.Clear();
            Tuesday240ListBox.Items.Clear();
            Tuesday330ListBox.Items.Clear();
            Tuesday420ListBox.Items.Clear();

            Wednesday800ListBox.Items.Clear();
            Wednesday850ListBox.Items.Clear();
            Wednesday940ListBox.Items.Clear();
            Wednesday1030ListBox.Items.Clear();
            Wednesday1120ListBox.Items.Clear();
            Wednesday1210ListBox.Items.Clear();
            Wednesday100ListBox.Items.Clear();
            Wednesday150ListBox.Items.Clear();
            Wednesday240ListBox.Items.Clear();
            Wednesday330ListBox.Items.Clear();
            Wednesday420ListBox.Items.Clear();

            Thursday800ListBox.Items.Clear();
            Thursday850ListBox.Items.Clear();
            Thursday940ListBox.Items.Clear();
            Thursday1030ListBox.Items.Clear();
            Thursday1120ListBox.Items.Clear();
            Thursday1210ListBox.Items.Clear();
            Thursday100ListBox.Items.Clear();
            Thursday150ListBox.Items.Clear();
            Thursday240ListBox.Items.Clear();
            Thursday330ListBox.Items.Clear();
            Thursday420ListBox.Items.Clear();
        }

        private void InputRoutineButton_Click(object sender, EventArgs e)
        {
            int routineIdForeignKeyHere = 0;

            try
            {
                string departmentNameHere = DepartmentInputRoutineComboBox.Text;
                string yearHere = YearInputRoutineComboBox.SelectedItem.ToString();
                string semesterHere = SemesterInputRoutineComboBox.SelectedItem.ToString();
                string sectionHere = SectionInputRoutineComboBox.SelectedItem.ToString();

                if (!String.IsNullOrEmpty(departmentNameHere.Trim()) &&
                    !String.IsNullOrEmpty(yearHere.Trim()) &&
                    !String.IsNullOrEmpty(semesterHere.Trim()) &&
                    !String.IsNullOrEmpty(sectionHere.Trim())
                   )
                {

                    routineIdForeignKeyHere = routineManagementDatabaseControlClass.getRoutineId(departmentNameHere, yearHere, semesterHere, sectionHere);

                    if (routineIdForeignKeyHere > 0) refreshListBoxes(routineIdForeignKeyHere);
                    else MessageBox.Show("Routine does not exist");
                }
                else MessageBox.Show("Select all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }
        }

        private void DeleteRoutineInputRoutineButton_Click(object sender, EventArgs e)
        {
            Rectangle bounds = Bounds;


            using (Bitmap bitmap = new Bitmap(1355, 553))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(3, 170, 0, 0, bounds.Size);
                }

                Bitmap bmp_1000_570 = new Bitmap(1000, 570);
                Graphics g_1000_570 = Graphics.FromImage(bmp_1000_570);
                g_1000_570.DrawImage(bitmap, 0, 0, 1000, 570);

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.DefaultExt = "bmp";
                saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff|png files (*.png)|*.png";
                saveFileDialog1.Title = "Save screenshot to...";
                saveFileDialog1.ShowDialog();
                string ScreenPath = saveFileDialog1.FileName;

                bmp_1000_570.Save(ScreenPath, ImageFormat.Jpeg);
            }
        }

        private void ShowTheDayRoutineButtonName_Click(object sender, EventArgs e)
        {
            TeacherClassDataGridView.Show();

            try
            {
                string teacherNameHere = TeacherNameTextBox.Text;
                string dayHere = DayNameComboBox.SelectedItem.ToString();

                if (!String.IsNullOrEmpty(teacherNameHere.Trim()) &&
                    !String.IsNullOrEmpty(dayHere.Trim()) 
                   )
                {
                    routineManagementDatabaseControlClass.SearchTheDayOfTeacher(dayHere, TeacherClassDataGridView, teacherNameHere);
                }
                else MessageBox.Show("Select all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }
        }

        private void SearchWeekRoutineButtonName_Click(object sender, EventArgs e)
        {
            TeacherClassDataGridView.Show();

            try
            {
                string teacherNameHere = TeacherNameTextBox.Text;

                if (!String.IsNullOrEmpty(teacherNameHere.Trim()))
                {
                    routineManagementDatabaseControlClass.SearchTheWeekOfTeacher(TeacherClassDataGridView, teacherNameHere);
                }
                else MessageBox.Show("Select all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }
        }

        private void BackFromTeacherButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchDataGridView.Show();

            try
            {
                string searchNameHere = searchNameTextBox.Text;
                string searchBy = SearchByComboBox.SelectedItem.ToString();

                if (!String.IsNullOrEmpty(searchNameHere.Trim()) &&
                    !String.IsNullOrEmpty(searchBy.Trim())
                   )
                {
                    routineManagementDatabaseControlClass.ExtendedSearch(SearchDataGridView, searchNameHere, searchBy);
                }
                else MessageBox.Show("Select all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }
        }
    }
}
