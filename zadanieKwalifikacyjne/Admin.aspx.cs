using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zadanieKwalifikacyjne
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rowInforForUserAdmin.Visible = false;
        }

        protected void btnAdminUpdateDatabase_Click(object sender, EventArgs e)
        {
            string city = ddlAdminCity.SelectedValue;
            string date = txtAdminDay.Text;
            Day day;
            try
            {
                day = Deserialization.ImportDeserializedDataFromAPI(city, date);
            }
            catch (Exception)
            {
                day = null;
                rowInforForUserAdmin.Visible = true;
                InfoForUserAdmin.InnerText = "Nie udało się dodać nowego rekordu do bazy. Spórbuj ponownie później.";
            }


            if (day != null)
            {
                bool result = DbOperations.InsertRecordsToDB(date, city, day.avgtemp_c.ToString(), day.mintemp_c.ToString(), day.maxtemp_c.ToString(), day.maxwind_mph.ToString(), day.avghumidity.ToString());

                if (result)
                {
                    rowInforForUserAdmin.Visible = true;
                    InfoForUserAdmin.InnerText = "Zaktualizowano.";

                }
                else
                {
                    rowInforForUserAdmin.Visible = true;
                    InfoForUserAdmin.InnerText = "Nie udało się dodać nowego rekordu do bazy. Spórbuj ponownie później.";
                }
            }
            else
            {
                rowInforForUserAdmin.Visible = true;
                InfoForUserAdmin.InnerText = "Nie udało się pobrać danych z API. Spórbuj ponownie później.";
            }
        }
    }
}