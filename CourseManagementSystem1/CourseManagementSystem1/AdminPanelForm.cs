using Plasmoid.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace CourseManagementSystem1
{

    public partial class AdminPanelForm : Form
    {
        ManageDataDatabaseControlClass manageDataDatabaseControlClass = new ManageDataDatabaseControlClass();
        RoutineManagementDatabaseControlClass routineManagementDatabaseControlClass = new RoutineManagementDatabaseControlClass();

        int lastSelectedGridView;

        string departmentName;
        string teacherName;
        string courseName;
        string className;

        string departmentTableName;
        string departmentOldValue;
        string departmentColumnName;
        int departmentIdPrimaryKey;

        string teacherTableName;
        string teacherOldValue;
        string teacherColumnName;
        int teacherIdPrimaryKey;

        string courseTableName;
        string courseOldValue;
        string courseColumnName;
        int courseIdPrimaryKey;

        string classTableName;
        string classColumnName;
        string classOldValue;
        int classIdPrimaryKey;

        string[] yearArray = new string[] { "1st", "2nd", "3rd", "4th" };

        string[] semesterArray = new string[] { "1st", "2nd"};

        string[] sectionArray = new string[] { "A", "B", "C" };

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

        int idOfRoutine = 0;
        int count = 0;

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]


        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public AdminPanelForm()
        {
            InitializeComponent();
            this.MinimumSize = new System.Drawing.Size(950, 600);

            //department
            InsertDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
            UpdateDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
            DeleteDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);

            //teacher
            TeacherInsertButtonName.BackColor = Color.FromArgb(0, 200, 200);
            TeacherUpdateButtonName.BackColor = Color.FromArgb(0, 200, 200);
            TeacherDeleteButtonName.BackColor = Color.FromArgb(0, 200, 200);

            //course
            CourseInsertButtonName.BackColor = Color.FromArgb(0, 200, 200);
            CourseUpdateButtonName.BackColor = Color.FromArgb(0, 200, 200);
            CourseDeleteButtonName.BackColor = Color.FromArgb(0, 200, 200);


            SendMessage(DepartmentFullNameTextBoxName.Handle, EM_SETCUEBANNER, 1, "Department Full Name");
            SendMessage(DepartmentShortNameTextBoxName.Handle, EM_SETCUEBANNER, 1, "Short Name");
            SendMessage(DepartmentCodeTextBoxName.Handle, EM_SETCUEBANNER, 1, "Department Code");

            SendMessage(TeacherNameTextBoxName.Handle, EM_SETCUEBANNER, 1, "Teacher Full Name");
            SendMessage(TeacherDepartmentComboBoxName.Handle, EM_SETCUEBANNER, 1, "Department Name");
            SendMessage(CourseNameTextBoxName.Handle, EM_SETCUEBANNER, 1, "Course Name");
            SendMessage(CourseCodeTextBoxName.Handle, EM_SETCUEBANNER, 1, "Course Code");

            YearInputRoutineComboBox.Items.AddRange(yearArray);
            SemesterInputRoutineComboBox.Items.AddRange(semesterArray);
            SectionInputRoutineComboBox.Items.AddRange(sectionArray);

            YearUpdateRoutineComboBox.Items.AddRange(yearArray);
            SemesterUpdateRoutineComboBox.Items.AddRange(semesterArray);
            SectionUpdateRoutineComboBox.Items.AddRange(sectionArray);

            SendMessage(YearInputRoutineComboBox.Handle, EM_SETCUEBANNER, 1, "Year");
            SendMessage(SemesterInputRoutineComboBox.Handle, EM_SETCUEBANNER, 1, "Semester");
            SendMessage(SectionInputRoutineComboBox.Handle, EM_SETCUEBANNER, 1, "Section");



            //CourseTabPageName.ForeColor = Color.Beige;
            refreshGridView();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courseManagementDatabase1DataSet.DepartmentTable1' table. You can move, or remove it, as needed.
            this.departmentTable1TableAdapter.Fill(this.courseManagementDatabase1DataSet.DepartmentTable1);

            refreshGridView();
        }

        private void AdminPanelForm_Resize(object sender, EventArgs e)
        {
            int size1 = ManageDataHeaderLabelName.Height;
            int size2 = (int)(size1 * .3);
            if (size2 > 0) ManageDataHeaderLabelName.Font = new Font("Cambria", size2);

            int size3 = (int)(size1 * .17);
            if (size3 > 0)
            {
                tabControl1.Font = new Font("Cambria", size3 + 1);
                //tabControl3.Font = new Font("Cambria", size3 + 1);
            }

            int size5 = ManageDataHeaderLabelName.Height;
            int size4 = (int)(size5 * .17);
            if (size4 > 0)
            {

                //Depaetment
                DepartmentFullNameTextBoxName.AutoSize = false;
                DepartmentShortNameTextBoxName.AutoSize = false;
                DepartmentCodeTextBoxName.AutoSize = false;

                DepartmentFullNameTextBoxName.Font = new Font("Cambria", size4 + 3);
                DepartmentShortNameTextBoxName.Font = new Font("Cambria", size4 + 3);
                DepartmentCodeTextBoxName.Font = new Font("Cambria", size4 + 3);

                InsertDepartmentButtonName.Font = new Font("Cambria", size4 + 2);
                UpdateDepartmentButtonName.Font = new Font("Cambria", size4 + 2);
                DeleteDepartmentButtonName.Font = new Font("Cambria", size4 + 2);

                //Teacher
                TeacherNameTextBoxName.AutoSize = false;
                TeacherDepartmentComboBoxName.AutoSize = false;
                TeacherDepartmentComboBoxName.Padding = new Padding(13, 13, 3, 3);
                DepartmentInputRoutineComboBox.AutoSize = false;
                YearInputRoutineComboBox.AutoSize = false;
                SemesterInputRoutineComboBox.AutoSize = false;
                SectionInputRoutineComboBox.AutoSize = false;

                DepartmentUpdateRoutineComboBox.AutoSize = false;
                YearUpdateRoutineComboBox.AutoSize = false;
                SemesterUpdateRoutineComboBox.AutoSize = false;
                SectionUpdateRoutineComboBox.AutoSize = false;

                TeacherNameTextBoxName.Font = new Font("Cambria", size4 + 3);
                TeacherDepartmentComboBoxName.Font = new Font("Cambria", size4 + 4);

                TeacherDeleteButtonName.Font = new Font("Cambria", size4 + 2);
                TeacherUpdateButtonName.Font = new Font("Cambria", size4 + 2);
                TeacherInsertButtonName.Font = new Font("Cambria", size4 + 2);

                //Course
                CourseNameTextBoxName.AutoSize = false;
                CourseCodeTextBoxName.AutoSize = false;
                CourseDepartmentComboBoxName.AutoSize = false;

                CourseNameTextBoxName.Font = new Font("Cambria", size4 + 3);
                CourseCodeTextBoxName.Font = new Font("Cambria", size4 + 3);
                CourseDepartmentComboBoxName.Font = new Font("Cambria", size4 + 4);

                CourseInsertButtonName.Font = new Font("Cambria", size4 + 2);
                CourseUpdateButtonName.Font = new Font("Cambria", size4 + 2);
                CourseDeleteButtonName.Font = new Font("Cambria", size4 + 2);

                //input routine
                DepartmentInputRoutineComboBox.Font = new Font("Cambria", size4 + 3);
                YearInputRoutineComboBox.Font = new Font("Cambria", size4 + 3);
                SemesterInputRoutineComboBox.Font = new Font("Cambria", size4 + 3);
                SectionInputRoutineComboBox.Font = new Font("Cambria", size4 + 3);

                //
                DepartmentUpdateRoutineComboBox.Font = new Font("Cambria", size4 + 3);
                YearUpdateRoutineComboBox.Font = new Font("Cambria", size4 + 3);
                SemesterUpdateRoutineComboBox.Font = new Font("Cambria", size4 + 3);
                SectionUpdateRoutineComboBox.Font = new Font("Cambria", size4 + 3);


                //DataTypeLabelName.Font = new Font("Cambria", size4 + 2);
                // DataTypeComboBox.Font = new Font("Cambria", size4 + 2);
                //tabControl1.Padding = new Point(, 12);
                //ManageDataHeaderLabelName.Text = tabControl1.Padding.ToString();

            }
        }

        public void refreshGridView()
        {
            manageDataDatabaseControlClass.ManageDataRefreshGridView( DepartmentDataGridView1,
                                                            TeacherDataGridView1,
                                                            CourseDataGridView1,
                                                            TeacherDepartmentComboBoxName,
                                                            CourseDepartmentComboBoxName,
                                                            DepartmentInputRoutineComboBox,
                                                            DepartmentUpdateRoutineComboBox
                                                           );

            
        }


        private void DepartmentTabPageName_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.AppWorkspace,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, DepartmentTabPageName.Width, DepartmentTabPageName.Height, 10);


        }

        private void TeacherTabPageName_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.AppWorkspace,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, DepartmentTabPageName.Width, DepartmentTabPageName.Height, 10);

        }

        private void CourseTabPageName_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.AppWorkspace,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, DepartmentTabPageName.Width, DepartmentTabPageName.Height, 10);

        }

        //department
        private void InsertDepartmentButtonName_MouseEnter(object sender, EventArgs e)
        {
            InsertDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void InsertDepartmentButtonName_MouseLeave(object sender, EventArgs e)
        {
            InsertDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void InsertDepartmentButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            InsertDepartmentButtonName.BackColor = Color.LightGray;
        }

        private void InsertDepartmentButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            InsertDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void UpdateDepartmentButtonName_MouseEnter(object sender, EventArgs e)
        {
            UpdateDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void UpdateDepartmentButtonName_MouseLeave(object sender, EventArgs e)
        {
            UpdateDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void UpdateDepartmentButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateDepartmentButtonName.BackColor = Color.LightGray;
        }

        private void UpdateDepartmentButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void DeleteDepartmentButtonName_MouseEnter(object sender, EventArgs e)
        {
            DeleteDepartmentButtonName.BackColor = Color.DarkCyan;
        }

        private void DeleteDepartmentButtonName_MouseLeave(object sender, EventArgs e)
        {
            DeleteDepartmentButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void DeleteDepartmentButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            DeleteDepartmentButtonName.BackColor = Color.LightGray;
        }

        private void DeleteDepartmentButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            DeleteDepartmentButtonName.BackColor = Color.DarkCyan;
        }


        //Course
        private void CourseInsertButtonName_MouseEnter(object sender, EventArgs e)
        {
            CourseInsertButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseInsertButtonName_MouseLeave(object sender, EventArgs e)
        {
            CourseInsertButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void CourseInsertButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            CourseInsertButtonName.BackColor = Color.LightGray;
        }

        private void CourseInsertButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            CourseInsertButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseUpdateButtonName_MouseEnter(object sender, EventArgs e)
        {
            CourseUpdateButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseUpdateButtonName_MouseLeave(object sender, EventArgs e)
        {
            CourseUpdateButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void CourseUpdateButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            CourseUpdateButtonName.BackColor = Color.LightGray;
        }

        private void CourseUpdateButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            CourseUpdateButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseDeleteButtonName_MouseEnter(object sender, EventArgs e)
        {
            CourseDeleteButtonName.BackColor = Color.DarkCyan;
        }

        private void CourseDeleteButtonName_MouseLeave(object sender, EventArgs e)
        {
            CourseDeleteButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void CourseDeleteButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            CourseDeleteButtonName.BackColor = Color.LightGray;
        }

        private void CourseDeleteButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            CourseDeleteButtonName.BackColor = Color.DarkCyan;
        }


        //teacher
        private void TeacherInsertButtonName_MouseEnter(object sender, EventArgs e)
        {
            TeacherInsertButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherInsertButtonName_MouseLeave(object sender, EventArgs e)
        {
            TeacherInsertButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void TeacherInsertButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            TeacherInsertButtonName.BackColor = Color.LightGray;
        }

        private void TeacherInsertButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            TeacherInsertButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherUpdateButtonName_MouseEnter(object sender, EventArgs e)
        {
            TeacherUpdateButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherUpdateButtonName_MouseLeave(object sender, EventArgs e)
        {
            TeacherUpdateButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void TeacherUpdateButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            TeacherUpdateButtonName.BackColor = Color.LightGray;
        }

        private void TeacherUpdateButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            TeacherUpdateButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherDeleteButtonName_MouseEnter(object sender, EventArgs e)
        {
            TeacherDeleteButtonName.BackColor = Color.DarkCyan;
        }

        private void TeacherDeleteButtonName_MouseLeave(object sender, EventArgs e)
        {
            TeacherDeleteButtonName.BackColor = Color.FromArgb(0, 200, 200);
        }

        private void TeacherDeleteButtonName_MouseDown(object sender, MouseEventArgs e)
        {
            TeacherDeleteButtonName.BackColor = Color.LightGray;
        }

        private void TeacherDeleteButtonName_MouseUp(object sender, MouseEventArgs e)
        {
            TeacherDeleteButtonName.BackColor = Color.DarkCyan;
        }
    

        //department
        private void DepartmentDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            try
            {
                int columnIndex = columnIndex = DepartmentDataGridView1.CurrentCell.ColumnIndex;
                int rowIndex = DepartmentDataGridView1.CurrentCell.RowIndex;

                string columnNameHere = DepartmentDataGridView1.Columns[columnIndex].HeaderText.ToString();
                string cellValue = DepartmentDataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int idHere = Int32.Parse(DepartmentDataGridView1.Rows[rowIndex].Cells[3].Value.ToString());

                departmentName= DepartmentDataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

                //ManageDataHeaderLabelName.Text = "ri=" + rowIndex + " / ci=" + columnIndex + " / cn=" + columnNameHere + " / id=" + idHere + " / cv=" + cellValue;

                departmentTableName = "Department Table";
                departmentColumnName = columnNameHere;
                departmentOldValue = cellValue;
                departmentIdPrimaryKey = idHere;
                

            }
            catch (Exception ex) { }

            //int promptValue = Prompt.ShowDialog("Test", "123");
        }

        //teacher
        private void TeacherDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            try
            {
                int columnIndex = columnIndex = TeacherDataGridView1.CurrentCell.ColumnIndex;
                int rowIndex = TeacherDataGridView1.CurrentCell.RowIndex;

                string columnNameHere = TeacherDataGridView1.Columns[columnIndex].HeaderText.ToString();
                string cellValue = TeacherDataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int idHere = Int32.Parse(TeacherDataGridView1.Rows[rowIndex].Cells[2].Value.ToString());

                teacherName = TeacherDataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

                //ManageDataHeaderLabelName.Text = "ri=" + rowIndex + " / ci=" + columnIndex + " / cn=" + columnNameHere + " / id=" + idHere + " / cv=" + cellValue;

                teacherTableName = "Teacher Table";
                teacherColumnName = columnNameHere;
                teacherOldValue = cellValue;
                teacherIdPrimaryKey = idHere;


            }
            catch (Exception ex) { }
        }

        //Course
        private void CourseDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            try
            {
                int columnIndex = columnIndex = CourseDataGridView1.CurrentCell.ColumnIndex;
                int rowIndex = CourseDataGridView1.CurrentCell.RowIndex;

                string columnNameHere = CourseDataGridView1.Columns[columnIndex].HeaderText.ToString();
                string cellValue = CourseDataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int idHere = Int32.Parse(CourseDataGridView1.Rows[rowIndex].Cells[3].Value.ToString());

                courseName = CourseDataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

                //ManageDataHeaderLabelName.Text = "ri=" + rowIndex + " / ci=" + columnIndex + " / cn=" + columnNameHere + " / id=" + idHere + " / cv=" + cellValue;

                courseTableName = "Course Table";
                courseColumnName = columnNameHere;
                courseOldValue = cellValue;
                courseIdPrimaryKey = idHere;


            }
            catch (Exception ex) { }
        }

        private void UpdateDepartmentButtonName_Click(object sender, EventArgs e)
        {
            if (lastSelectedGridView == 1)
            {
                UpdateDataForm u = new UpdateDataForm(departmentTableName, departmentColumnName, departmentOldValue, departmentIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
            else if (lastSelectedGridView == 2)
            {
                UpdateDataForm u = new UpdateDataForm(teacherTableName, teacherColumnName, teacherOldValue, teacherIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
            else if (lastSelectedGridView == 3)
            {
                UpdateDataForm u = new UpdateDataForm(courseTableName, courseColumnName, courseOldValue, courseIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //department
        private void InsertDepartmentButtonName_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentFullName = DepartmentFullNameTextBoxName.Text;
                string departmentShortName = DepartmentShortNameTextBoxName.Text;
                string departmentCode = DepartmentCodeTextBoxName.Text;

                if (!String.IsNullOrEmpty(departmentFullName.Trim()) &&
                    !String.IsNullOrEmpty(departmentShortName.Trim()) &&
                    !String.IsNullOrEmpty(departmentCode.Trim()))
                {
                    manageDataDatabaseControlClass.InsertIntoDepartment( departmentFullName,
                                                               departmentShortName,
                                                               departmentCode
                                                             );

                    refreshGridView();

                    DepartmentFullNameTextBoxName.Text=null;
                    DepartmentShortNameTextBoxName.Text=null;
                    DepartmentCodeTextBoxName.Text = null;
                }
                else MessageBox.Show("Fill up all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Fill up all the fields carefully");
            }
        }

        private void DeleteDepartmentButtonName_Click(object sender, EventArgs e)
        {
            if (lastSelectedGridView == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure to Delete Department '" + departmentName + "' ?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (departmentIdPrimaryKey > 0 && !String.IsNullOrEmpty(departmentColumnName.Trim()))
                        {
                            manageDataDatabaseControlClass.DeleteDepartment(departmentIdPrimaryKey);

                            refreshGridView();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception : " + ex);
                    }
                }
                else if (result == DialogResult.No)
                {

                }
            }
            else if (lastSelectedGridView == 2)
            {
                DialogResult result = MessageBox.Show("Are you sure to Delete Teacher '" + teacherName + "' ?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (teacherIdPrimaryKey > 0 && !String.IsNullOrEmpty(teacherColumnName.Trim()))
                        {
                            manageDataDatabaseControlClass.DeleteTeacher(teacherIdPrimaryKey);

                            refreshGridView();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception : " + ex);
                    }
                }
                else if (result == DialogResult.No)
                {

                }
            }
            else if (lastSelectedGridView == 3)
            {
                DialogResult result = MessageBox.Show("Are you sure to Delete Course '" + courseName + "' ?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (courseIdPrimaryKey > 0 && !String.IsNullOrEmpty(courseColumnName.Trim()))
                        {
                            manageDataDatabaseControlClass.DeleteCourse(courseIdPrimaryKey);

                            refreshGridView();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception : " + ex);
                    }
                }
                else if (result == DialogResult.No)
                {

                }
            }
            
        }

        //teacher
        private void TeacherInsertButtonName_Click(object sender, EventArgs e)
        {
            try
            {
                string teacherName = TeacherNameTextBoxName.Text;
                string teacherDepartmentName = TeacherDepartmentComboBoxName.Text;
               

                if (!String.IsNullOrEmpty(teacherName.Trim()) &&
                    !String.IsNullOrEmpty(teacherDepartmentName.Trim()))
                {
                    manageDataDatabaseControlClass.InsertIntoTeacher(teacherName,teacherDepartmentName);

                    refreshGridView();

                    TeacherNameTextBoxName.Text = null;
                }
                else MessageBox.Show("Fill up all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Fill up all the fields carefully");
            }

        }

        private void TeacherUpdateButtonName_Click(object sender, EventArgs e)
        {
            if (lastSelectedGridView == 1)
            {
                UpdateDataForm u = new UpdateDataForm(departmentTableName, departmentColumnName, departmentOldValue, departmentIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
            else if (lastSelectedGridView == 2)
            {
                UpdateDataForm u = new UpdateDataForm(teacherTableName, teacherColumnName, teacherOldValue, teacherIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
            else if (lastSelectedGridView == 3)
            {
                UpdateDataForm u = new UpdateDataForm(courseTableName, courseColumnName, courseOldValue, courseIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
        }

        private void TeacherDeleteButtonName_Click(object sender, EventArgs e)
        {
            
        }

        //course
        private void CourseInsertButtonName_Click(object sender, EventArgs e)
        {
            try
            {
                string courseName = CourseNameTextBoxName.Text;
                string courseCode = CourseCodeTextBoxName.Text;
                string courseDepartmentName = CourseDepartmentComboBoxName.Text;

               // MessageBox.Show("Fil "+courseDepartmentName);

                if (!String.IsNullOrEmpty(courseName.Trim()) &&
                    !String.IsNullOrEmpty(courseCode.Trim()) &&
                    !String.IsNullOrEmpty(courseDepartmentName.Trim()))
                {
                    manageDataDatabaseControlClass.InsertIntoCourse(courseName,courseCode,courseDepartmentName);

                    refreshGridView();

                    CourseNameTextBoxName.Text = null;
                    CourseCodeTextBoxName.Text = null;
                }
                else MessageBox.Show("Fill up all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Fill up all the fields carefully");
            }

        }

        private void CourseUpdateButtonName_Click(object sender, EventArgs e)
        {
            if (lastSelectedGridView == 1)
            {
                UpdateDataForm u = new UpdateDataForm(departmentTableName, departmentColumnName, departmentOldValue, departmentIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
            else if (lastSelectedGridView == 2)
            {
                UpdateDataForm u = new UpdateDataForm(teacherTableName, teacherColumnName, teacherOldValue, teacherIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
            else if (lastSelectedGridView == 3)
            {
                UpdateDataForm u = new UpdateDataForm(courseTableName, courseColumnName, courseOldValue, courseIdPrimaryKey);
                u.ShowDialog();
                refreshGridView();
            }
        }

        private void CourseDeleteButtonName_Click(object sender, EventArgs e)
        {
           
            
        }

        private void DepartmentDataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            lastSelectedGridView = 1;
        }

        private void TeacherDataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* DepartmentDataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.InactiveBorder;
             TeacherDataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
             CourseDataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.InactiveBorder;
            // MessageBox.Show("gkghdghgj");
            */
            lastSelectedGridView = 2;
        }

        private void CourseDataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            lastSelectedGridView = 3;
        }

        private void InputRoutineButton_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentNameHere = DepartmentInputRoutineComboBox.Text;
                string yearHere = YearInputRoutineComboBox.SelectedItem.ToString();
                string semesterHere = SemesterInputRoutineComboBox.SelectedItem.ToString();
                string sectionHere = SectionInputRoutineComboBox.SelectedItem.ToString();

                if (!String.IsNullOrEmpty(departmentNameHere.Trim()) &&
                    !String.IsNullOrEmpty(yearHere.Trim()) &&
                    !String.IsNullOrEmpty(semesterHere.Trim()) &&
                    !String.IsNullOrEmpty(sectionHere.Trim()))
                {
                    InputRoutineForm inputRoutineForm = new InputRoutineForm(departmentNameHere, yearHere, semesterHere, sectionHere);
                    inputRoutineForm.ShowDialog();

                    int routineIdForeignKeyHere = routineManagementDatabaseControlClass.getRoutineId(departmentNameHere, yearHere, semesterHere, sectionHere);
                    //MessageBox.Show("rid = "+routineIdForeignKeyHere);
                    refreshListBoxes(routineIdForeignKeyHere);
                }
                else MessageBox.Show("Select all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }
        }


        public void refreshListBoxes(int routineIdHere)
        {
            string dayHere = null;
            string timeHere = null;

            count = 0;

            saturday800 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "8:00-8:50");
            saturday850 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "8:50-9:40");
            saturday940 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "9:40-10:30");
            saturday1030 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "10:30-11:20");
            saturday1120 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "11:20-12:10");
            saturday1210 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday", "12:10-1:00");
            saturday100 = routineManagementDatabaseControlClass.getAClassInfo(routineIdHere, "Saturday",  "1:00-1:50");
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

        public string getDay(int i)
        {
            string day = null;

            if (i == 0) day = "Saturday";
            else if (i == 1) day = "Sunday";
            else if (i == 2) day = "Monday";
            else if (i == 3) day = "Tuesday";
            else if (i == 4) day = "Wednesday";
            else if (i == 5) day = "Thursday";

            return day;
        }

        public string getTime(int i)
        {
            string time = null;

            if (i == 0) time = "8:00-8:50";
            else if (i == 1) time = "8:50-9:40";
            else if (i == 2) time = "9:40-10:30";
            else if (i == 3) time = "10:30-11:20";
            else if (i == 4) time = "11:20-12:10";
            else if (i == 5) time = "12:10-1:00";
            else if (i == 6) time = "1:00-1:50";
            else if (i == 7) time = "1:50-2:40";
            else if (i == 8) time = "2:40-3:30";
            else if (i == 9) time = "3:30-4:20";
            else if (i == 10) time = "4:20-5:10";

            return time;
        }

        public string[] getAClassInfo(int idHere, string dayHere, string Time )
        {
            string[] dayTimeOfClass = new string[3];
            count++;

            try
            {
                string courseCodeHere= "CSE11" + count;
                string roomNoHere = "7A0" + count;
                string teacherNameHere = "MAR"+count;

                try {
                    if (!string.IsNullOrEmpty(courseCodeHere.Trim())) dayTimeOfClass[0] = courseCodeHere;
                    else dayTimeOfClass[0] = "";
                }catch(NullReferenceException ex) { dayTimeOfClass[0] = ""; }

                try{
                    if (!string.IsNullOrEmpty(roomNoHere.Trim())) dayTimeOfClass[1] = roomNoHere;
                    else dayTimeOfClass[1] = "";
                }
                catch (NullReferenceException ex) { dayTimeOfClass[1] = ""; }

                try{
                    if (!string.IsNullOrEmpty(teacherNameHere.Trim())) dayTimeOfClass[2] = teacherNameHere;
                    else dayTimeOfClass[2] = "";
                }
                catch (NullReferenceException ex) { dayTimeOfClass[2] = ""; }

                return dayTimeOfClass;
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                MessageBox.Show("Exception : "+ex);
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

        private void ShowRoutineInputRoutineButton_Click(object sender, EventArgs e)
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
                    
                    routineIdForeignKeyHere =routineManagementDatabaseControlClass.getRoutineId(departmentNameHere, yearHere, semesterHere, sectionHere);

                    if(routineIdForeignKeyHere>0)refreshListBoxes(routineIdForeignKeyHere);
                    else MessageBox.Show("Routine does not exist");
                }
                else MessageBox.Show("Select all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }

            //refreshListBoxes(routineIdForeignKeyHere);
        }

        private void Sunday800ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            string str = Sunday800ListBox.Items[e.Index].ToString();

            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(str, Sunday800ListBox.Font);

            PointF pos = new PointF((e.Bounds.Width / 2) - (stringSize.Width / 2), e.Bounds.Y);

            e.Graphics.DrawString(str, Sunday800ListBox.Font, Brushes.Black, pos);

            if (e.State == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }



        public string makeAcronym(string str)
        {
            return new string(str.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]).ToArray());
        }

        private void DeleteRoutineInputRoutineButton_Click(object sender, EventArgs e)
        {
            //routineManagementDatabaseControlClass.getNumberOfRows("DepartmentTable1");
            DialogResult result = MessageBox.Show("Are you sure to Delete Routine ?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {

                try
                {
                    string departmentNameHere = DepartmentInputRoutineComboBox.Text;
                    string yearHere = YearInputRoutineComboBox.SelectedItem.ToString();
                    string semesterHere = SemesterInputRoutineComboBox.SelectedItem.ToString();
                    string sectionHere = SectionInputRoutineComboBox.SelectedItem.ToString();

                    if (!String.IsNullOrEmpty(departmentNameHere.Trim()) &&
                        !String.IsNullOrEmpty(yearHere.Trim()) &&
                        !String.IsNullOrEmpty(semesterHere.Trim()) &&
                        !String.IsNullOrEmpty(sectionHere.Trim()))
                    {

                        int routineIdForeignKeyHere = routineManagementDatabaseControlClass.getRoutineId(departmentNameHere, yearHere, semesterHere, sectionHere);
                        //MessageBox.Show("rid = "+routineIdForeignKeyHere);

                        routineManagementDatabaseControlClass.DeleteRoutine(routineIdForeignKeyHere);

                        refreshListBoxes(routineIdForeignKeyHere);
                    }
                    else MessageBox.Show("Select all the fields");

                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Select all the fields");
                }

               
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void UpdateRoutineButtonName_Click(object sender, EventArgs e)
        {
            int routineIdForeignKeyHere = 0; 

            try
            {
                string departmentNameHere = DepartmentUpdateRoutineComboBox.Text;
                string yearHere = YearUpdateRoutineComboBox.SelectedItem.ToString();
                string semesterHere = SemesterUpdateRoutineComboBox.SelectedItem.ToString();
                string sectionHere = SectionUpdateRoutineComboBox.SelectedItem.ToString();

                if (!String.IsNullOrEmpty(departmentNameHere.Trim()) &&
                    !String.IsNullOrEmpty(yearHere.Trim()) &&
                    !String.IsNullOrEmpty(semesterHere.Trim()) &&
                    !String.IsNullOrEmpty(sectionHere.Trim())
                   )
                {
                    
                    routineIdForeignKeyHere =routineManagementDatabaseControlClass.getRoutineId(departmentNameHere, yearHere, semesterHere, sectionHere);

                    if (routineIdForeignKeyHere > 0)
                    {
                        UpdateDataForm u = new UpdateDataForm(classTableName, classColumnName, classOldValue, classIdPrimaryKey);
                        u.ShowDialog();

                        routineManagementDatabaseControlClass.ManageDataRefreshGridView(RoutineInfoDataGridView, ClassInfoDataGridView, routineIdForeignKeyHere);
                    }

                    else MessageBox.Show("Routine does not exist");



                }
                else MessageBox.Show("Select all the fields");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }
        }

        private void ClassInfoDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //CourseCode,Teacher,Teacher2,Time,RoomNo,Day,Id

            try
            {
                int columnIndex = ClassInfoDataGridView.CurrentCell.ColumnIndex;
                int rowIndex = ClassInfoDataGridView.CurrentCell.RowIndex;

                string columnNameHere = ClassInfoDataGridView.Columns[columnIndex].HeaderText.ToString();
                string cellValue = ClassInfoDataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                int idHere = Int32.Parse(ClassInfoDataGridView.Rows[rowIndex].Cells[7].Value.ToString());

                className = ClassInfoDataGridView.Rows[rowIndex].Cells[0].Value.ToString();

                //ManageDataHeaderLabelName.Text = "ri=" + rowIndex + " / ci=" + columnIndex + " / cn=" + columnNameHere + " / id=" + idHere + " / cv=" + cellValue;

                classTableName = "ClassInfo Table";
                classColumnName = columnNameHere;
                classOldValue = cellValue;
                classIdPrimaryKey = idHere;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception :" +ex);
            }

        }

        private void ShowRoutineButtonName_Click(object sender, EventArgs e)
        {
            int routineIdForeignKeyHere = 0;

            ClassInfoDataGridView.Show();
            RoutineInfoDataGridView.Show();

            try
            {
                string departmentNameHere = DepartmentUpdateRoutineComboBox.Text;
                string yearHere = YearUpdateRoutineComboBox.SelectedItem.ToString();
                string semesterHere = SemesterUpdateRoutineComboBox.SelectedItem.ToString();
                string sectionHere = SectionUpdateRoutineComboBox.SelectedItem.ToString();

                if (!String.IsNullOrEmpty(departmentNameHere.Trim()) &&
                    !String.IsNullOrEmpty(yearHere.Trim()) &&
                    !String.IsNullOrEmpty(semesterHere.Trim()) &&
                    !String.IsNullOrEmpty(sectionHere.Trim())
                   )
                {

                    routineIdForeignKeyHere = routineManagementDatabaseControlClass.getRoutineId(departmentNameHere, yearHere, semesterHere, sectionHere);

                    if (routineIdForeignKeyHere > 0)
                        routineManagementDatabaseControlClass.ManageDataRefreshGridView(RoutineInfoDataGridView, ClassInfoDataGridView, routineIdForeignKeyHere);

                    else MessageBox.Show("Routine does not exist");



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




   
    


