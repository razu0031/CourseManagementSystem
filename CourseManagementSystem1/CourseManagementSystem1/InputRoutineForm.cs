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
    public partial class InputRoutineForm : Form
    {
        ManageDataDatabaseControlClass manageDataDatabaseControlClass = new ManageDataDatabaseControlClass();
        RoutineManagementDatabaseControlClass routineManagementDatabaseControlClass = new RoutineManagementDatabaseControlClass();

        string[] dayArray = new string[] { "Saturday",    "Sunday",     "Monday",
                                            "Tuesday",    "Wednesday",  "Thursday"
                                          };

        string[] timeArray = new string[] { "8:00-8:50",    "8:50-9:40",    "9:40-10:30",
                                            "10:30-11:20",  "11:20-12:10",  "12:10-1:00",
                                            "1:00-1:50",    "1:50-2:40",    "2:40-3:30",
                                            "3:30-4:20",    "4:20-5:10"
                                          };

        string[] roomArray = new string[] { "1A01",    "1A02",   "1A03",    "1A04",    "1A05",   "1A06",
                                            "1A07",    "1A08",   "1B01",    "1B02",    "1B03",   "1B04",
                                            "1B05",    "1B06",   "1B07",    "1B08",    "1C01",   "1C02",
                                            "1C03",    "1C04",   "1C05",    "1C06",    "1C07",   "1C08",
                                            "2A01",    "2A02",   "2A03",    "2A04",    "2A05",   "2A06",
                                            "2A07",    "2A08",   "2B01",    "2B02",    "2B03",   "2B04",
                                            "2B05",    "2B06",   "2B07",    "2B08",    "2C01",   "2C02",
                                            "2C03",    "2C04",   "2C05",    "2C06",    "2C07",   "2C08",
                                            "3A01",    "3A02",   "3A03",    "3A04",    "3A05",   "3A06",
                                            "3A03",    "3A08",   "3B01",    "3B02",    "3B03",   "3B04",
                                            "3B05",    "3B06",   "3B07",    "3B08",    "3C01",   "3C02",
                                            "3C03",    "3C04",   "3C05",    "3C06",    "3C07",   "3C08",
                                            "4A01",    "4A02",   "4A03",    "4A04",    "4A05",   "4A06",
                                            "4A07",    "4A08",   "4B01",    "4B02",    "4B03",   "4B04",
                                            "4B05",    "4B06",   "4B07",    "4B08",    "4C01",   "4C02",
                                            "4C03",    "4C04",   "4C05",    "4C06",    "4C07",   "4C08",
                                            "5A01",    "5A02",   "5A03",    "5A04",    "5A05",   "5A06",
                                            "5A07",    "5A08",   "5B01",    "5B02",    "5B03",   "5B04",
                                            "5B05",    "5B06",   "5B07",    "5B08",    "5C01",   "5C02",
                                            "5C03",    "5C04",   "5C05",    "5C06",    "5C07",   "5C08",
                                            "6A01",    "6A02",   "6A03",    "6A04",    "6A05",   "6A06",
                                            "6A07",    "6A08",   "6B01",    "6B02",    "6B03",   "6B04",
                                            "6B05",    "6B06",   "6B07",    "6B08",    "6C01",   "6C02",
                                            "6C03",    "6C04",   "6C05",    "6C06",    "6C07",   "6C08",
                                            "7A01",    "7A02",   "7A03",    "7A04",    "7A05",   "7A06",
                                            "7A07",    "7A08",   "7B01",    "7B02",    "7B03",   "7B04",
                                            "7B05",    "7B06",   "7B07",    "7B08",    "7C01",   "7C02",
                                            "7C03",    "7C04",   "7C05",    "7C06",    "7C07",   "7C08",
                                            "8A01",    "8A02",   "8A03",    "8A04",    "8A05",   "8A06",
                                            "8A07",    "8A08",   "8B01",    "8B02",    "8B03",   "8B04",
                                            "8B05",    "8B06",   "8B07",    "8B08",    "8C01",   "8C02",
                                            "8C03",    "8C04",   "8C05",    "8C06",    "8C07",   "8C08"
                                          };

        string[] groupArray = new string[] { "Group1",    "Group2",     "Group1+2",
                                            "Group1/2"
                                          };

        string departmentShortName;
        string year;
        string semester;
        string section;


        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);


        public InputRoutineForm()
        {
            customInitializeComponent();
        }

        public InputRoutineForm(string departmentNameHere, string yearHere, string semesterHere, string sectionHere)
        {
            customInitializeComponent();

            UpdateFormHeaderLabelName.Text = departmentNameHere +"  "+yearHere+" year  "+semesterHere+" semester  "+sectionHere+" section  Routine Input";

            departmentShortName=departmentNameHere;
            year=yearHere;
            semester=semesterHere;
            section=sectionHere;


        }

        public void customInitializeComponent()
        {
            InitializeComponent();
            refreshComboBox();
            TimeInputRoutineComboBox.Items.AddRange(timeArray);
            RoomNumberInputRoutineComboBox.Items.AddRange(roomArray);
            DayInputRoutineComboBox.Items.AddRange(dayArray);
            GroupInputRoutineComboBox.Items.AddRange(groupArray);

            Teacher1NameInputRoutineComboBox.AutoSize = false;
            Teacher2NameInputRoutineComboBox.AutoSize = false;
            CourseCodeInputRoutineComboBox.AutoSize = false;
            TimeInputRoutineComboBox.AutoSize = false;
            RoomNumberInputRoutineComboBox.AutoSize = false;
            GroupInputRoutineComboBox.AutoSize = false;

            Teacher1NameInputRoutineComboBox.Font = new Font("Cambria", 12);
            Teacher2NameInputRoutineComboBox.Font = new Font("Cambria", 11);
            CourseCodeInputRoutineComboBox.Font = new Font("Cambria", 12);
            TimeInputRoutineComboBox.Font = new Font("Cambria", 12);
            RoomNumberInputRoutineComboBox.Font = new Font("Cambria", 12);
            DayInputRoutineComboBox.Font = new Font("Cambria", 12);
            GroupInputRoutineComboBox.Font = new Font("Cambria", 12);

            CancelButton.Font = new Font("Cambria", 12);
            InputButton.Font = new Font("Cambria", 12);

            SendMessage(TimeInputRoutineComboBox.Handle, EM_SETCUEBANNER, 1, "Time");
            SendMessage(RoomNumberInputRoutineComboBox.Handle, EM_SETCUEBANNER, 1, "Room No.");
        }

        public void refreshComboBox()
        {
            manageDataDatabaseControlClass.ManageDataRefreshInputRoutineComboBox(CourseCodeInputRoutineComboBox, Teacher1NameInputRoutineComboBox, Teacher2NameInputRoutineComboBox);
        }

        


        private void InputButton_Click(object sender, EventArgs e)
        {
            int routineIdForeignKeyHere = 0;

            try
            {
                string courseCodeHere = CourseCodeInputRoutineComboBox.Text;
                string teacher1NameHere = Teacher1NameInputRoutineComboBox.Text;
                string teacher2NameHere = Teacher2NameInputRoutineComboBox.SelectedItem.ToString();
                string dayHere = DayInputRoutineComboBox.SelectedItem.ToString();
                string timeHere = TimeInputRoutineComboBox.SelectedItem.ToString();
                string roomNoHere = RoomNumberInputRoutineComboBox.SelectedItem.ToString();
                string groupHere = GroupInputRoutineComboBox.SelectedItem.ToString();


                if (!String.IsNullOrEmpty(courseCodeHere.Trim()) &&
                    !String.IsNullOrEmpty(teacher1NameHere.Trim()) &&
                    !String.IsNullOrEmpty(groupHere.Trim()) &&
                    !String.IsNullOrEmpty(dayHere.Trim()) &&
                    !String.IsNullOrEmpty(timeHere.Trim()) &&
                    !String.IsNullOrEmpty(roomNoHere.Trim())
                   )
                {
                    routineIdForeignKeyHere = routineManagementDatabaseControlClass.getRoutineId(departmentShortName,
                                                                                                 year, 
                                                                                                 semester, 
                                                                                                 section
                                                                                                );

                    if (routineIdForeignKeyHere > 0)
                    {
                        routineManagementDatabaseControlClass.InsertIntoClassInfoTable(routineIdForeignKeyHere,
                                                                                       dayHere,
                                                                                       timeHere,
                                                                                       roomNoHere,
                                                                                       courseCodeHere,
                                                                                       teacher1NameHere,
                                                                                       teacher2NameHere,
                                                                                       groupHere
                                                                                      );
                    }
                    else if(routineIdForeignKeyHere==0)
                    {
                        MessageBox.Show("Routine does not exist.\nCreating new one");

                        routineManagementDatabaseControlClass.InsertIntoRoutineInfoTable(departmentShortName,
                                                                                         year,
                                                                                         semester,
                                                                                         section
                                                                                        );

                        routineIdForeignKeyHere = routineManagementDatabaseControlClass.getRoutineId(departmentShortName,
                                                                                                 year,
                                                                                                 semester,
                                                                                                 section
                                                                                                );

                        routineManagementDatabaseControlClass.InsertIntoClassInfoTable(routineIdForeignKeyHere,
                                                                                       dayHere,
                                                                                       timeHere,
                                                                                       roomNoHere,
                                                                                       courseCodeHere,
                                                                                       teacher1NameHere,
                                                                                       teacher2NameHere,
                                                                                       groupHere
                                                                                      );
                    }
                   

                }
                else MessageBox.Show("Select all the fields");

            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Select all the fields");
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputRoutineForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courseManagementDatabase1DataSet2.TeacherTable1' table. You can move, or remove it, as needed.
            this.teacherTable1TableAdapter.Fill(this.courseManagementDatabase1DataSet2.TeacherTable1);
            // TODO: This line of code loads data into the 'courseManagementDatabase1DataSet1.CourseTable1' table. You can move, or remove it, as needed.
            this.courseTable1TableAdapter.Fill(this.courseManagementDatabase1DataSet1.CourseTable1);

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
    
    }
}
