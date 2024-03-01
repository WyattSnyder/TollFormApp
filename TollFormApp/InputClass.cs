using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace TollFormApp
{
    class InputClass
    {
        private int driver_id;
        private DateTime minDate;
        private DateTime maxDate;
        private string driverName;
        private SqlConnection trollsDb;
        private List<string[]> driverRoads;
        private List<string[]> tollRoads;
        

        public InputClass(int login_id)
        {
            driverRoads = new List<string[]>();
            tollRoads = new List<string[]>();
            // TO DO validate login_id before setting it as driver_id
            driver_id = login_id;
            driverName = null;
            minDate = DateTime.Parse("01/01/1900");
            maxDate = DateTime.Now;
            setDriverName();
            setDefaultDates();
            setTollRoads();
            setDriverRoads();
        }
        public string getDriverName()
        {
            return driverName;
        }

        public DateTime getMinDate()
        {
            return minDate;
        }

        public DateTime getMaxDate()
        {
            return maxDate;
        }

        public int getDayOfWeekNumber()
        {
            int dayNum = 9;
            dayNum = (int)maxDate.DayOfWeek;
            return dayNum;
        }

        public List<string[]> getDriverRoads()
        {
            return driverRoads;
        }

        public List<string[]> getTollRoads()
        {
            return tollRoads;
        }

        private void setTollRoads()
        {
            openDb();
            string queryScript = "SELECT toll_location, toll_amount FROM TROLLS_Toll GROUP BY toll_location, toll_amount ORDER BY toll_amount";
            string[] fieldList = { "toll_location", "toll_amount" };
            try
            {
                SqlCommand command = new SqlCommand(queryScript, trollsDb);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] row = new string[fieldList.Length];
                        for (int col = 0; col < fieldList.Length; col++)
                        {
                            row[col] = reader[fieldList[col]].ToString();
                        }
                        tollRoads.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Boo! This did not work");
            }
            closeDb();
        }

        private void setDriverRoads()
        {
            openDb();
            string queryScript = "SELECT toll_location, toll_amount FROM TROLLS_Toll WHERE driver_id = @driver_id GROUP BY toll_location, toll_amount ORDER BY toll_amount";
            string[] fieldList = { "toll_location", "toll_amount" };
            try
            {
                SqlCommand command = new SqlCommand(queryScript, trollsDb);
                command.Parameters.AddWithValue("@driver_id", driver_id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] row = new string[fieldList.Length];
                        for (int col = 0; col < fieldList.Length; col++)
                        {
                            row[col] = reader[fieldList[col]].ToString();
                        }
                        driverRoads.Add(row);
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Boo! This did not work");
            }
            closeDb();
        }

        private void setDefaultDates()
        {
            openDb();
            string minScript = "SELECT MIN(trip_date) FROM TROLLS_Toll WHERE driver_id = @driver_id";
            string maxScript = "SELECT MAX(trip_date) FROM TROLLS_Toll WHERE driver_id = @driver_id";
            try
            {
                SqlCommand minCommand = new SqlCommand(minScript, trollsDb);
                minCommand.Parameters.AddWithValue("@driver_id", driver_id);
                minDate = (DateTime)minCommand.ExecuteScalar();
                SqlCommand maxCommand = new SqlCommand(maxScript, trollsDb);
                maxCommand.Parameters.AddWithValue("@driver_id", driver_id);
                maxDate = (DateTime)maxCommand.ExecuteScalar();
            }
            catch
            {
                maxDate = DateTime.Parse("12/31/2099");
            }
            closeDb();
        }

        private void setDriverName()
        {
            openDb();
            string queryScript = "SELECT CONCAT(first_name, ' ', last_name) FROM TROLLS_Driver WHERE driver_id = @driver_id";
            try
            {
                SqlCommand command = new SqlCommand(queryScript, trollsDb);
                command.Parameters.AddWithValue("@driver_id", driver_id);
                driverName = (string)command.ExecuteScalar();
            }
            catch
            {
                driverName = "boo";
            }
            closeDb();
        }


        // Utility method openDb tries to open the database
        // using the programmed connection string
        // and will update sqlError string if fails
        // as well as capture, but not return the exception
        private void openDb()
        {
            string connectionString = "Data Source=cisdbss.pcc.edu;"
                                        + "Initial Catalog=233N_Mostafavi_Teams;"
                                        + "User ID=233N_Mostafavi_Teams;"
                                        + "Password=ILoveCSharp@2";
            try
            {
                trollsDb = new SqlConnection(connectionString);
                trollsDb.Open(); 
            }
            catch (Exception ex)
            {
                //sqlError = "ERROR SQL failure!";
                //connectionException = ex;
                //MessageBox.Show(ex.ToString());
            }
        }

        // Utility method closeDb closes the database connection
        private void closeDb()
        {
            trollsDb.Close();
        }

    }
}
