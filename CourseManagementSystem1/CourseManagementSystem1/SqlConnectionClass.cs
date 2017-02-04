using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseManagementSystem1
{
    class SqlConnectionClass
    {
        public string connectionString; //= "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\My_Apps\\C#Corner\\CourseManagementSystem1\\CourseManagementSystem1\\CourseManagementDatabase1.mdf;Integrated Security=True";

        public SqlConnectionClass()
        {
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\My_Apps\\C#Corner\\CourseManagementSystem1\\CourseManagementSystem1\\CourseManagementDatabase1.mdf;Integrated Security=True";
        }
                                //Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\My_Apps\C#Corner\CourseManagementSystem1\CourseManagementSystem1\CourseManagementDatabase1.mdf;Integrated Security=True

        public SqlConnection openConnection()
        {
            SqlConnection mSqlConnection = new SqlConnection(connectionString);
            mSqlConnection.Open();

            return mSqlConnection;
        }
        public void closeConnection(SqlConnection mSqlConnection)
        {
            mSqlConnection.Close();
        }
    }
}
