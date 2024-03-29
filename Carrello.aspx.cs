﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using E_commerce;

namespace E_commerce
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }

        private void LoadCartItems()
        {
            List<int> product = (List<int>)Session["ProductID"];
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Prezzo", typeof(double));

            if (product != null)
            {
                foreach (int id in product)
                {
                    try
                    {
                        DBconn.conn.Open();
                        SqlCommand cmd = new SqlCommand($"SELECT * FROM Products WHERE ID='{id}'", DBconn.conn);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();
                            dt.Rows.Add(dataReader["ID"], dataReader["Nome"], dataReader["Prezzo"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                    finally
                    {
                        if (DBconn.conn.State == ConnectionState.Open)
                        {
                            DBconn.conn.Close();
                        }
                    }
                }
            }

            rptCartItems.DataSource = dt;
            rptCartItems.DataBind();

            double totCart = GetTotalCartAmount(product);
            contentTot.InnerHtml = $"<h2>Totale: {totCart}€</h2>";
        }

        private double GetTotalCartAmount(List<int> productIds)
        {
            double totalAmount = 0;

            if (productIds != null)
            {
                foreach (int id in productIds)
                {
                    try
                    {
                        DBconn.conn.Open();
                        SqlCommand cmd = new SqlCommand($"SELECT Prezzo FROM Products WHERE ID='{id}'", DBconn.conn);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            totalAmount += Convert.ToDouble(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }
                    finally
                    {
                        if (DBconn.conn.State == ConnectionState.Open)
                        {
                            DBconn.conn.Close();
                        }
                    }
                }
            }

            return totalAmount;
        }

        protected void rptCartItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                List<int> product = (List<int>)Session["ProductID"];

                if (product != null)
                {
                    product.Remove(productId);
                    Session["ProductID"] = product;
                    LoadCartItems(); // Ricarica gli elementi del carrello dopo l'eliminazione
                }
            }
        }
        protected void btnClearSession_Click(object sender, EventArgs e)
        {

            Session.Clear();
            LoadCartItems();
        }
    }
}