﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_commerce
{
    public class DBconn
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DbShopConnectionString"].ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);

    }
}