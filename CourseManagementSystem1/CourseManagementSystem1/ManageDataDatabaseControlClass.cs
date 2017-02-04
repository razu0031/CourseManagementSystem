using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CourseManagementSystem1
{
    class ManageDataDatabaseControlClass 
    {
        SqlConnectionClass sqlConnectionClass = new SqlConnectionClass();
        RoutineManagementDatabaseControlClass routineManagementDatabaseControlClass = new RoutineManagementDatabaseControlClass();

        public string connectionString;// = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\My_Apps\\C#Corner\\CourseManagementSystem1\\CourseManagementSystem1\\CourseManagementDatabase1.mdf;Integrated Security=True";
        public string departmentTableName;
        public string teacherTableName;
        public string courseTableName;

        public ManageDataDatabaseControlClass()
        {
            connectionString = sqlConnectionClass.connectionString;
            departmentTableName = "DepartmentTable1";
            teacherTableName = "TeacherTable1";
            courseTableName = "CourseTable1";
        }


        //department
        public void InsertIntoDepartment(string departmentFullNameHere,string departmentShortNameHere, string departmentCodeHere)
        {
            try
            {
                 SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string insertQuery = "insert into "+departmentTableName+" (DepartmentFullName,DepartmentShortName,DepartmentCode)"
                                                    + "VALUES('" + departmentFullNameHere +
                                                            "','" + departmentShortNameHere +
                                                            "','" + departmentCodeHere +
                                                            "')";

                SqlCommand mSqlCommand = new SqlCommand(insertQuery, mSqlConnection);
                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Department,  " + departmentFullNameHere + " has been added succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : "+ex);
            }
        }

        public void UpdateDepartment(int idPrimaryKeyHere, string columnNameHere, string newValueHere, string oldValueHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "update "+departmentTableName+" set " + columnNameHere + "='" + newValueHere + "' where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                sqlConnectionClass.closeConnection(mSqlConnection);

                MessageBox.Show("Department has updated succesfully from\n" + oldValueHere + "  to  " + newValueHere);
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error in Updating\n\nError Deatails : " + exception);
            }
        }

        public void DeleteDepartment(int idPrimaryKeyHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string query = "Delete from "+departmentTableName+" where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Department has been Deleted succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : "+ex);
            }
        }


        //teacher
        public void InsertIntoTeacher(string teacherNameHere, string teacherDepartmentNameHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string insertQuery = "insert into " + teacherTableName + " (TeacherName,DepartmentName)"
                                                    + "VALUES('" + teacherNameHere +
                                                            "','" + teacherDepartmentNameHere +
                                                            "')";

                SqlCommand mSqlCommand = new SqlCommand(insertQuery, mSqlConnection);
                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Teacher,  " + teacherNameHere + " has been added succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : "+ex);
            }
        }

        public void UpdateTeacher(int idPrimaryKeyHere, string columnNameHere, string newValueHere, string oldValueHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "update " + teacherTableName + " set " + columnNameHere + "='" + newValueHere + "' where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                sqlConnectionClass.closeConnection(mSqlConnection);

                MessageBox.Show("Teacher has updated succesfully from\n" + oldValueHere + "  to  " + newValueHere);

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error in Updating\n\nError Deatails : " + exception);
            }
        }

        public void DeleteTeacher(int idPrimaryKeyHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string query = "Delete from " + teacherTableName + " where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Teacher has been Deleted succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }


        //course
        public void InsertIntoCourse(string courseNameHere, string courseCodeHere, string courseDepartmentNameHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string insertQuery = "insert into " + courseTableName + " (CourseName,CourseCode,DepartmentName)"
                                                    + "VALUES('" + courseNameHere +
                                                            "','" + courseCodeHere +
                                                            "','" + courseDepartmentNameHere +
                                                            "')";

                SqlCommand mSqlCommand = new SqlCommand(insertQuery, mSqlConnection);
                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Course,  " + courseNameHere + " has been added succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }

        public void UpdateCourse(int idPrimaryKeyHere, string columnNameHere, string newValueHere, string oldValueHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "update " + courseTableName + " set " + columnNameHere + "='" + newValueHere + "' where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                sqlConnectionClass.closeConnection(mSqlConnection);

                MessageBox.Show("Course has updated succesfully from\n" + oldValueHere + "  to  " + newValueHere);

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error in Updating\n\nError Deatails : " + exception);
            }
        }

        public void DeleteCourse(int idPrimaryKeyHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string query = "Delete from " + courseTableName + " where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Course has been Deleted succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }


        public string[] getAllTeacherName()
        {
            int n = routineManagementDatabaseControlClass.getNumberOfRows(teacherTableName);
            string[] teacherNameArrayHere = new string[n+1];
            int count = 1;

            teacherNameArrayHere[0] = "";

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "select TeacherName from " + teacherTableName;

                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                SqlDataReader reader = mSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    teacherNameArrayHere[count] = reader["TeacherName"].ToString();
                    count++;
                }

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }

            return teacherNameArrayHere;
        }


        //refresh gridviews
        public void ManageDataRefreshGridView(DataGridView departmentDataGridView, DataGridView teacherDataGridView, DataGridView courseDataGridView, ComboBox teacherDepartmentComboBox, ComboBox courseDepartmentComboBox, ComboBox departmentInputRoutineComboBox, ComboBox departmentUpdateRoutineComboBox)
        {
            SqlConnection mSqlConnection = sqlConnectionClass.openConnection();
            DataTable mDataTable = new DataTable();
            DataTable mDataTable2 = new DataTable();
            DataTable mDataTable3 = new DataTable();
            DataTable mDataTable4 = new DataTable();

            //department
            string query = "select DepartmentFullName,DepartmentShortName,DepartmentCode,Id from DepartmentTable1";
            SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(mSqlCommand);

            mSqlDataAdapter.Fill(mDataTable);
            departmentDataGridView.DataSource = mDataTable;

            //teacher
            string query2 = "select TeacherName,DepartmentName,Id from TeacherTable1";
            SqlCommand mSqlCommand2 = new SqlCommand(query2, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter2 = new SqlDataAdapter(mSqlCommand2);

            mSqlDataAdapter2.Fill(mDataTable2);
            teacherDataGridView.DataSource = mDataTable2;

            //course
            string query3 = "select CourseName,CourseCode,DepartmentName,Id from CourseTable1";
            SqlCommand mSqlCommand3 = new SqlCommand(query3, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter3 = new SqlDataAdapter(mSqlCommand3);

            mSqlDataAdapter3.Fill(mDataTable3);
            courseDataGridView.DataSource = mDataTable3;

            teacherDepartmentComboBox.DataSource = mDataTable;
            teacherDepartmentComboBox.DisplayMember = "DepartmentShortName";

            courseDepartmentComboBox.DataSource = mDataTable;
            courseDepartmentComboBox.DisplayMember = "DepartmentShortName";

            departmentInputRoutineComboBox.DataSource = mDataTable;
            departmentInputRoutineComboBox.DisplayMember = "DepartmentShortName";

            departmentUpdateRoutineComboBox.DataSource = mDataTable;
            departmentUpdateRoutineComboBox.DisplayMember = "DepartmentShortName";

            sqlConnectionClass.closeConnection(mSqlConnection);
        }

        public void ManageDataRefreshInputRoutineComboBox(ComboBox courseCodeComboBoxHere, ComboBox teacher1NameComboBoxHere, ComboBox teacher2NameComboBoxHere)
        {
            SqlConnection mSqlConnection = sqlConnectionClass.openConnection();
            DataTable mDataTable = new DataTable();
            DataTable mDataTable2 = new DataTable();

            //course
            string query = "select * from CourseTable1";
            SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(mSqlCommand);

            mSqlDataAdapter.Fill(mDataTable);

            //teacher
            string query2 = "select * from TeacherTable1";
            SqlCommand mSqlCommand2 = new SqlCommand(query2, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter2 = new SqlDataAdapter(mSqlCommand2);
            
            mSqlDataAdapter2.Fill(mDataTable2);

            courseCodeComboBoxHere.DataSource = mDataTable;
            courseCodeComboBoxHere.DisplayMember = "CourseCode";

            teacher1NameComboBoxHere.DataSource = mDataTable2;
            teacher1NameComboBoxHere.DisplayMember = "TeacherName";

            //teacher2NameComboBoxHere.DataSource = mDataTable2;
            //teacher2NameComboBoxHere.DisplayMember = "TeacherName";
            string[] teacherNameArrayHere = getAllTeacherName();
            teacher2NameComboBoxHere.Items.AddRange(teacherNameArrayHere);

            sqlConnectionClass.closeConnection(mSqlConnection);
        }


        public void StudentPanelRefreshDepartmentCombobox(ComboBox departmentInputRoutineComboBox)
        {
            SqlConnection mSqlConnection = sqlConnectionClass.openConnection();
            DataTable mDataTable = new DataTable();

            //department
            string query = "select DepartmentFullName,DepartmentShortName,DepartmentCode,Id from DepartmentTable1";
            SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(mSqlCommand);

            mSqlDataAdapter.Fill(mDataTable);

            departmentInputRoutineComboBox.DataSource = mDataTable;
            departmentInputRoutineComboBox.DisplayMember = "DepartmentShortName";
        }

        }
}
