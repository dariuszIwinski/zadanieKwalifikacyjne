using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zadanieKwalifikacyjne
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rowInforForUserUser.Visible = false;
        }


        protected void btnUserGetData_Click(object sender, EventArgs e)
        {
            bool result;
            string date = txtUserDay.Text;
            string city = ddlUserCity.SelectedValue;
            DataTable dt = new DataTable();
            try
            {
                dt = DbOperations.GetRecordsFromDB(date, city, out result);
                DataRow dr = dt.Rows[0];
                string tempAvg = dr["WeatherTempAvg"].ToString();
                string tempMin = dr["WeatherTempMin"].ToString();
                string tempMax = dr["WeatherTempMax"].ToString();
                string windAvg = dr["WeatherWindAvg"].ToString();
                string humidAvg = dr["WeatherHumidAvg"].ToString();
                dataInTable.InnerHtml = "<table class=\"table text-center table-bordered table-hover table-responsive\">" +
                    "<tr>" +
                    "<th class=\"text-center\">Miasto</th>" +
                     "<th class=\"text-center\">Data</th>" +
                      "<th class=\"text-center\">Temp śr.</th>" +
                       "<th class=\"text-center\">Temp min.</th>" +
                        "<th class=\"text-center\">Temp max.</th>" +
                         "<th class=\"text-center\">Pred wiatru</th>" +
                          "<th class=\"text-center\">Wilgotność pow.</th>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>" +
                    city +
                    "</td>" +
                    "<td>" +
                    date +
                    "</td>" +
                    "<td>" +
                    tempAvg +
                    "</td>" +
                    "<td>" +
                    tempMin +
                    "</td>" +
                    "<td>" +
                    tempMax +
                    "</td>" +
                    "<td>" +
                    windAvg +
                    "</td>" +
                         "<td>" +
                    humidAvg +
                    "</td>" +
                    "</tr>" +
                    "</table>";

                if (dt!=null)
                {
                    rowInforForUserUser.Visible = true;
                    InfoForUserUser.InnerText = "Dane pozyskane!";
                }
                else
                {
                    rowInforForUserUser.Visible = true;
                    InfoForUserUser.InnerText = "Niestety nie udało się połączyć z bazą danych. Spróbuj ponownie później lub poproś admina o aktualizację tego dnia.";
                }
              
            }
            catch (Exception ex)
            {
                rowInforForUserUser.Visible = true;
                InfoForUserUser.InnerText = "Nie udało się pozyskać danych z powodu błędu: " + ex.ToString();
            }
        }
    }
}


