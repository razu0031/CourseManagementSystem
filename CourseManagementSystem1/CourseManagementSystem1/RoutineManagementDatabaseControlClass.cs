using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementSystem1
{
    class RoutineManagementDatabaseControlClass
    {
        SqlConnectionClass sqlConnectionClass = new SqlConnectionClass();
        public string connectionString;
        public string departmentTableName;
        public string teacherTableName;
        public string courseTableName;

        public string routineInfoTableName;
        public string classInfoTableName;

        public RoutineManagementDatabaseControlClass()
        {
            connectionString = sqlConnectionClass.connectionString;
            departmentTableName = "DepartmentTable1";
            teacherTableName = "TeacherTable1";
            courseTableName = "CourseTable1";

            routineInfoTableName = "RoutineInfoTable1";
            classInfoTableName = "ClassInfoTable1";
        }


        //department
        public void InsertIntoRoutineInfoTable(string departmentShortNameHere, string yearHere, string semesterHere, string sectionHere)
        {
            int departmentIdForeignKeyHere = getDepartmentIdByDepartmentShortName(departmentShortNameHere);

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string insertQuery = "insert into " + routineInfoTableName + " (DepartmentId,DepartmentShortName,Year,Semester,Section)"
                                                    + "VALUES(" + departmentIdForeignKeyHere +
                                                            ",'" + departmentShortNameHere +
                                                            "','" + yearHere +
                                                            "','" + semesterHere +
                                                            "','" + sectionHere +
                                                            "')";

                SqlCommand mSqlCommand = new SqlCommand(insertQuery, mSqlConnection);
                mSqlCommand.ExecuteNonQuery();

                //MessageBox.Show("Department,  " + departmentFullNameHere + " has been added succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }
        }

        public int getRoutineId(string departmentShortNameHere, string yearHere, string semesterHere, string sectionHere)
        {
            int routineIdHere = 0;

            //MessageBox.Show("In control" + departmentShortNameHere + " / " + yearHere + " / " + semesterHere + " / " + sectionHere);

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "select * from "+routineInfoTableName
                              +" where DepartmentShortName='" + departmentShortNameHere
                              +"' and Year='"+yearHere
                              +"' and Semester='"+semesterHere
                              +"' and Section='"+sectionHere+"'";

                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                SqlDataReader reader = mSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    routineIdHere = (int)reader["Id"];
                   // MessageBox.Show("In con id " +routineIdHere); 
                }

                sqlConnectionClass.closeConnection(mSqlConnection);

                return routineIdHere;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }

            return routineIdHere;
        }

        public string getRoutineSection(int routineIdHere)
        {
            string sectionHere ="";

            //MessageBox.Show("In control" + departmentShortNameHere + " / " + yearHere + " / " + semesterHere + " / " + sectionHere);

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "select * from " + routineInfoTableName
                              + " where Id=" + routineIdHere;

                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                SqlDataReader reader = mSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    sectionHere = reader["Section"].ToString();
                }

                sqlConnectionClass.closeConnection(mSqlConnection);

                return sectionHere;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }

            return sectionHere;
        }


        public void InsertIntoClassInfoTable(int routineIdForeignkeyHere, string dayHere, string timeHere, string roomNoHere, string courseCodeHere, string teacher1NameHere, string teacher2NameHere, string groupHere)
        {
            int courseIdForeignKeyHere=getCourseIdByCourseCode(courseCodeHere);
            int teacherIdForeignKeyHere=getTeacherIdByTeacherName(teacher1NameHere);

             ///MessageBox.Show(" " + groupHere);

            //try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                /*string insertQuery = "insert into " + classInfoTableName + " (RoutineId,Day,Time,RoomNo,CourseCode,Teacher,CourseId,TeacherId,Teacher2,Group)"
                                                    + " VALUES(" + routineIdForeignkeyHere +
                                                            ",'" + dayHere +
                                                            "','" + timeHere +
                                                            "','" + roomNoHere +
                                                            "','" + courseCodeHere +
                                                            "','" + teacher1NameHere +
                                                            "'," + courseIdForeignKeyHere +
                                                            "," + teacherIdForeignKeyHere +
                                                            ",'" + teacher2NameHere +
                                                            "','" + groupHere +
                                                            "')";
                                                            */

                string insertQuery = "insert into ClassInfoTable1 (RoutineId,Day,GroupName,Time,RoomNo,CourseCode,Teacher,CourseId,TeacherId,Teacher2)"
                                                    + "VALUES(" + routineIdForeignkeyHere +
                                                            ",'" + dayHere +
                                                            "','" + groupHere +
                                                            "','" + timeHere +
                                                            "','" + roomNoHere +
                                                            "','" + courseCodeHere +
                                                            "','" + teacher1NameHere +
                                                            "'," + courseIdForeignKeyHere +
                                                            "," + teacherIdForeignKeyHere +
                                                            ",'" + teacher2NameHere +
                                                            "')";

                SqlCommand mSqlCommand = new SqlCommand(insertQuery, mSqlConnection);
                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Class,  " + dayHere +" in "+ timeHere+ " has been added succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);

            }
          //  catch (Exception ex)
            {
          //      MessageBox.Show("Exception : " + ex);
            }
        }

        public void UpdateClassInfo(int idPrimaryKeyHere, string columnNameHere, string newValueHere, string oldValueHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "update " + classInfoTableName + " set " + columnNameHere + "='" + newValueHere + "' where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                sqlConnectionClass.closeConnection(mSqlConnection);

                MessageBox.Show("Class has updated succesfully from\n" + oldValueHere + "  to  " + newValueHere);

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error in Updating\n\nError Deatails : " + exception);
            }
        }

        public void DeleteClass(int idPrimaryKeyHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string query = "Delete from " + classInfoTableName + " where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Class has been Deleted succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }


        public string[] getAClassInfo(int routineIdForeignKeyHere, string dayHere, string timeHere)
        {
            string[] classInfoHere = new string[3];
            string courseCodeHere = null;
            string roomNoHere=null;
            string teacherNameHere=null;
            string teacher1NameHere = null;
            string teacher2NameHere = null;
            string groupHere = null;
            string sectionHere = getRoutineSection(routineIdForeignKeyHere);

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "select * from "+classInfoTableName
                              +" where RoutineId=" + routineIdForeignKeyHere
                              +" and Day='"+dayHere
                              +"' and Time='"+timeHere+"'";

                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                SqlDataReader reader = mSqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    courseCodeHere = reader["CourseCode"].ToString();
                    roomNoHere = reader["RoomNo"].ToString();
                    teacher1NameHere = reader["Teacher"].ToString();
                    teacher2NameHere = reader["Teacher2"].ToString();
                    groupHere = reader["GroupName"].ToString();

                    //dateString = reader["ResignationDate"].ToString();
                    //if (!String.IsNullOrEmpty(dateString)) employee.resignationDate = Convert.ToDateTime(dateString);                  
                }

                sqlConnectionClass.closeConnection(mSqlConnection);

                try
                {
                    if (!string.IsNullOrEmpty(courseCodeHere.Trim())) classInfoHere[0] = courseCodeHere;
                    else classInfoHere[0] = "";
                }
                catch (NullReferenceException ex) { classInfoHere[0] = ""; }


                try
                {
                    if (!string.IsNullOrEmpty(roomNoHere.Trim())) classInfoHere[1] = roomNoHere;
                    else classInfoHere[1] = "";
                }
                catch (NullReferenceException ex) { classInfoHere[1] = ""; }


                try
                {
                    if (!string.IsNullOrEmpty(teacher1NameHere.Trim()))
                    {
                        teacher1NameHere = makeAcronym(teacher1NameHere);//teacherNameHere;
                    }
                    else teacher1NameHere = "";
                }
                catch (NullReferenceException ex) { teacher1NameHere = ""; }


                try
                {
                    if (!string.IsNullOrEmpty(teacher2NameHere.Trim()))
                    {
                        teacher2NameHere = makeAcronym(teacher2NameHere);//teacherNameHere;
                    }
                    else teacher2NameHere = "";
                }
                catch (NullReferenceException ex) { teacher2NameHere = ""; }


                try
                {
                    if (string.IsNullOrEmpty(groupHere.Trim())) groupHere = "";
                }
                catch (NullReferenceException ex) { groupHere = ""; }


                if (teacher2NameHere.Equals("")) classInfoHere[2] = teacher1NameHere;
                else classInfoHere[2] = teacher1NameHere + " , " + teacher2NameHere;

                //
                groupHere = getGroup(groupHere, sectionHere);
                if (!groupHere.Equals("")) classInfoHere[1] = classInfoHere[1] + " , " + groupHere;

                return classInfoHere;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
                //dayTimeOfClass = "";
            }

            return classInfoHere;
        }

        public string getGroup(string groupHere, string sectionHere)
        {
            string customedGroupHere = "";

            if (groupHere.Equals("Group1"))
            {
                customedGroupHere = sectionHere + "1";
            }
            else if (groupHere.Equals("Group2"))
            {
                customedGroupHere = sectionHere + "2";
            }
            else if (groupHere.Equals("Group1+2")) 
            {
                customedGroupHere = "";
            }
            else if (groupHere.Equals("Group1/2"))
            {
                customedGroupHere = sectionHere + "1/"+sectionHere+"2";
            }

            return customedGroupHere;
        }

        public string makeAcronym(string str)
        {
            return new string(str.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]).ToArray());
        }


        public int getDepartmentIdByDepartmentShortName(string departmentShortNameHere)
        {
            int departmentIdForeignKeyHere = 0;

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "select * from " + departmentTableName
                              + " where DepartmentShortName='" + departmentShortNameHere+"'";

                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                SqlDataReader reader = mSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    departmentIdForeignKeyHere = (int)reader["Id"];
                }

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }

            return departmentIdForeignKeyHere;

        }

        public int getTeacherIdByTeacherName(string teacherNameHere)
        {
            int teacherIdForeignKeyHere = 0;

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "select * from " + teacherTableName
                              + " where TeacherName='" + teacherNameHere + "'";

                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                SqlDataReader reader = mSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    teacherIdForeignKeyHere = (int)reader["Id"];
                }

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }

            return teacherIdForeignKeyHere;

        }

        public int getCourseIdByCourseCode(string courseCodeHere)
        {
            int courseIdForeignKeyHere = 0;

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "select * from " + courseTableName
                              + " where CourseCode='" + courseCodeHere + "'";

                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                SqlDataReader reader = mSqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    courseIdForeignKeyHere = (int)reader["Id"];
                }

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex);
            }

            return courseIdForeignKeyHere;

        }

        public int getNumberOfRows(string tableNameHere)
        {
            int numberOfRow = 0;

            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                string query = "select count(*) from "+tableNameHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                //mSqlCommand.ExecuteNonQuery();

                numberOfRow = Convert.ToInt16(mSqlCommand.ExecuteScalar());

                sqlConnectionClass.closeConnection(mSqlConnection);

               // MessageBox.Show("Row numbers in "+tableNameHere+" = "+numberOfRow);

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error in Updating\n\nError Deatails : " + exception);
            }

            return numberOfRow;
        }

        

        //refresh gridviews
        public void ManageDataRefreshGridView(DataGridView rotineInfoDataGridView, DataGridView classInfoDataGridView, int routineIdForeignKeyHere)
        {
            SqlConnection mSqlConnection = sqlConnectionClass.openConnection();
            DataTable mDataTable = new DataTable();
            DataTable mDataTable2 = new DataTable();
            DataTable mDataTable3 = new DataTable();
            DataTable mDataTable4 = new DataTable();

            //routine info
            string query2 = "select Section,Semester,Year,DepartmentShortName,Id from " + routineInfoTableName;
            SqlCommand mSqlCommand2 = new SqlCommand(query2, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter2 = new SqlDataAdapter(mSqlCommand2);

            mSqlDataAdapter2.Fill(mDataTable2);
            rotineInfoDataGridView.DataSource = mDataTable2;

            //class info
            string query = "select CourseCode,Teacher,Teacher2,Time,RoomNo,Day,GroupName,Id from "+classInfoTableName+" where RoutineId = "+routineIdForeignKeyHere;
            SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(mSqlCommand);

            mSqlDataAdapter.Fill(mDataTable);
            classInfoDataGridView.DataSource = mDataTable;      

            sqlConnectionClass.closeConnection(mSqlConnection);
        }


        public void SearchTheDayOfTeacher(string dayHere, DataGridView teacherClassDataGridViewHere, string teacherNameHere)
        {
            SqlConnection mSqlConnection = sqlConnectionClass.openConnection();
            DataTable mDataTable = new DataTable();
            

            //class info
            string query = "select Teacher,CourseCode,Time,RoomNo,Teacher2,Day,GroupName,Id from " + classInfoTableName + " where Day = '" + dayHere+"' and (Teacher = '" + teacherNameHere + "' or Teacher2='" + teacherNameHere + "')";
            SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(mSqlCommand);

            mSqlDataAdapter.Fill(mDataTable);
            teacherClassDataGridViewHere.DataSource = mDataTable;

            sqlConnectionClass.closeConnection(mSqlConnection);
        }

        public void SearchTheWeekOfTeacher(DataGridView teacherClassDataGridViewHere, string teacherNameHere)
        {
            SqlConnection mSqlConnection = sqlConnectionClass.openConnection();
            DataTable mDataTable = new DataTable();


            //class info
            string query = "select Teacher,CourseCode,Time,RoomNo,Teacher2,Day,GroupName,Id from " + classInfoTableName + " where Teacher = '" + teacherNameHere+"' or Teacher2='"+teacherNameHere+"'";
            SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(mSqlCommand);

            mSqlDataAdapter.Fill(mDataTable);
            teacherClassDataGridViewHere.DataSource = mDataTable;

            sqlConnectionClass.closeConnection(mSqlConnection);
        }


        public void ExtendedSearch(DataGridView teacherClassDataGridViewHere, string searchNameHere, string searchByHere)
        {
            string columnName="";

            if (searchByHere.Equals("by Teacher")) columnName = "Teacher";
            else if (searchByHere.Equals("by Room")) columnName = "RoomNo";
            else if (searchByHere.Equals("by Time")) columnName = "Time";
            else if (searchByHere.Equals("by Day")) columnName = "Day";


            SqlConnection mSqlConnection = sqlConnectionClass.openConnection();
            DataTable mDataTable = new DataTable();


            //class info
            string query = "select Teacher,CourseCode,Time,RoomNo,Teacher2,Day,GroupName,Id from " + classInfoTableName + " where "+columnName+" = '" + searchNameHere + "' or Teacher2='" + searchNameHere + "'";
            SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);
            SqlDataAdapter mSqlDataAdapter = new SqlDataAdapter(mSqlCommand);

            mSqlDataAdapter.Fill(mDataTable);
            teacherClassDataGridViewHere.DataSource = mDataTable;

            sqlConnectionClass.closeConnection(mSqlConnection);
        }



        public void DeleteRoutine(int idPrimaryKeyHere)
        {
            try
            {
                SqlConnection mSqlConnection = sqlConnectionClass.openConnection();

                //FIRING A COMMAND
                string query = "Delete * from " + classInfoTableName + " where Id=" + idPrimaryKeyHere;
                SqlCommand mSqlCommand = new SqlCommand(query, mSqlConnection);

                mSqlCommand.ExecuteNonQuery();

                MessageBox.Show("Routine has been Deleted succesfully");

                sqlConnectionClass.closeConnection(mSqlConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }


    }
}
