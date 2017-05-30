using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace zadanieKwalifikacyjne
{
    public static class DbOperations
    {
        public static bool InsertRecordsToDB(string date, string city, string tempAvg, string tempMin, string tempMax, string windAvg, string humidAvg)
        {
            string connString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string queryToSql = "INSERT INTO tblWeather (WeatherDate, WeatherCity, WeatherTempAvg, WeatherTempMin, WeatherTempMax, WeatherWindAvg, WeatherHumidAvg) values (@date, @city, @tempAvg,@tempMin,@tempMax,@windAvg,@humidAvg)";
                    SqlCommand cmd = new SqlCommand(queryToSql, conn);
                    DateTime dateDateTime = Convert.ToDateTime(date).Date;
                    cmd.Parameters.AddWithValue("@date", dateDateTime);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@tempAvg", tempAvg);
                    cmd.Parameters.AddWithValue("@tempMin", tempMin);
                    cmd.Parameters.AddWithValue("@tempMax", tempMax);
                    cmd.Parameters.AddWithValue("@windAvg", windAvg);
                    cmd.Parameters.AddWithValue("@humidAvg", humidAvg);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static DataTable GetRecordsFromDB(string date, string city, out bool result)
        {
            string connString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        
            try
            {
                DataTable dt = new DataTable();
                string queryToSql = "SELECT * FROM tblWeather WHERE (WeatherDate=@date AND WeatherCity=@city)";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(queryToSql, conn);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@city", city);
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Columns.Add("WeatherID");
                        dt.Columns.Add("WeatherCity");
                        dt.Columns.Add("WeatherTempAvg");
                        dt.Columns.Add("WeatherTempMin");
                        dt.Columns.Add("WeatherTempMax");
                        dt.Columns.Add("WeatherWindAvg");
                        dt.Columns.Add("WeatherHumidAvg");

                        while(rdr.Read())
                        {
                            DataRow dr = dt.NewRow();

                            dr["WeatherTempAvg"] = rdr["WeatherTempAvg"];
                            dr["WeatherTempMin"] = rdr["WeatherTempMin"];
                            dr["WeatherTempMax"] = rdr["WeatherTempMax"];
                            dr["WeatherWindAvg"] = rdr["WeatherWindAvg"];
                            dr["WeatherHumidAvg"] = rdr["WeatherHumidAvg"];
                            dt.Rows.Add(dr);

                        }
                        result = true;
                        return dt;
                        
                    }
                    
                }

            }
            catch (Exception)
            {
                result = false;
                return null;
                

            }
        }

    }
}