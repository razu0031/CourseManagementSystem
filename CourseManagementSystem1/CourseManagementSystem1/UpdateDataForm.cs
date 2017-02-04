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

namespace CourseManagementSystem1
{
    public partial class UpdateDataForm : Form
    {
        ManageDataDatabaseControlClass manageDataDatabaseControlClass = new ManageDataDatabaseControlClass();
        RoutineManagementDatabaseControlClass routineManagementDatabaseControlClass = new RoutineManagementDatabaseControlClass();

        string departmentTableName; 

        string tableName;
        string oldValue;
        string newValue;
        string columnName;
        int idPrimaryKey;

        public UpdateDataForm()
        {
            InitializeComponent();

            departmentTableName = manageDataDatabaseControlClass.departmentTableName;

            textBox1.AutoSize = false;
            textBox2.AutoSize = false;
            textBox1.Font = new Font("Cambria", 12);
            textBox2.Font = new Font("Cambria", 12);

            CancelButton.Font = new Font("Cambria", 12);
            UpdateButton.Font = new Font("Cambria", 12);
        }

        public UpdateDataForm(String tableNameHere, String columnNameHere, String oldValueHere, int idHere)
        {
            InitializeComponent();

            textBox1.AutoSize = false;
            textBox2.AutoSize = false;
            textBox1.Font = new Font("Cambria", 12);
            textBox2.Font = new Font("Cambria", 12);

            CancelButton.Font = new Font("Cambria", 12);
            UpdateButton.Font = new Font("Cambria", 12);

            UpdateFormHeaderLabelName.Text = tableNameHere + " Update";
            textBox1.Text = oldValueHere;

            tableName=tableNameHere;
            oldValue=oldValueHere;
            columnName=columnNameHere;
            idPrimaryKey=idHere;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, this.Height),
                SystemColors.AppWorkspace,
                ControlPaint.Dark(SystemColors.Menu, 0f)
                );
            g.FillRoundedRectangle(brush, 0, 0, panel2.Width, panel2.Height, 10);

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                newValue = textBox2.Text;
                
                if (!String.IsNullOrEmpty(newValue.Trim()))
                {
                    if(tableName.Equals("Department Table"))
                        manageDataDatabaseControlClass.UpdateDepartment(idPrimaryKey, columnName, newValue, oldValue);

                    else if (tableName.Equals("Teacher Table"))
                        manageDataDatabaseControlClass.UpdateTeacher(idPrimaryKey, columnName, newValue, oldValue);

                    else if (tableName.Equals("Course Table"))
                        manageDataDatabaseControlClass.UpdateCourse(idPrimaryKey, columnName, newValue, oldValue);

                    else if (tableName.Equals("ClassInfo Table"))
                        routineManagementDatabaseControlClass.UpdateClassInfo(idPrimaryKey, columnName, newValue, oldValue);

                    

                    this.Close();
                }
                else MessageBox.Show("Fill up the New Value Fields");

            }
            catch (Exception)
            {
                MessageBox.Show("Fill up the New Value Fields..");
            }

        }

        private void UpdateDataForm_Load(object sender, EventArgs e)
        {

        }
    }
    
}
