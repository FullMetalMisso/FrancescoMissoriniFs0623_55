using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace E_commerce
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DBconn.conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", DBconn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                string content = "";

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        content += $@"<div class=""card col-6 col-sm-4 col-md-3 mb-3 mx-3"">
                        <img src=""{dataReader["Image"]}"" class=""h-100 card-img-top img-fluid"" alt=""{dataReader["Nome"]}"">
                        <div class=""card-body"">
                        <h5 class=""card-title"">{dataReader["Nome"]}</h5>
                        <p class=""card-text"">{dataReader["Descrizione"]}</p>
                        <p class=""card-text"">{dataReader["Prezzo"]}€</p>
                        <a href=""Dettaglio.aspx?product={dataReader["ID"]}"" class=""btn btn-primary"">Dettaglio</a>
                        </div>
                        </div>";


                    }
                }
                contentHtml.InnerHtml = content;
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if (DBconn.conn.State == System.Data.ConnectionState.Open)
                {
                    DBconn.conn.Close();
                }
            }
        }
    }
}
