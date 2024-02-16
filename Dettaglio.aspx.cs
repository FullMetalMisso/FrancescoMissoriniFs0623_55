using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class Dettaglio : System.Web.UI.Page
    {
        private string ProductID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["product"] == null)
            {
                Response.Redirect("Home.aspx");
            }
           ProductID = Request.QueryString["product"].ToString();

            try
            {
                DBconn.conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Products WHERE id={ProductID}", DBconn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if(dataReader.HasRows)
                {
                    dataReader.Read();
                    ttlProduct.InnerText = dataReader["Nome"].ToString();
                    img.Src = dataReader["Image"].ToString();
                    txtDescription.InnerText = dataReader["Descrizione"].ToString();
                    txtPrice.InnerText = $"{dataReader["prezzo"]}€";
                }



            }catch(Exception ex)
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

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            int prodId = int.Parse(ProductID);
            List<int> products;
            if (Session["ProductID"]==null)
            {
                products = new List<int>();
            }    
            else
            {
                products = (List<int>)Session["ProductID"];
            }

            products.Add(prodId);

            Session["ProductID"] = products;
        }
    }
}