﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace FIXED
{
    internal class MainClass
    {

        public static readonly string con_string = "Server=JENNNN\\SQLEXPRESS;Database=RM;Integrated Security=True;";

        public static SqlConnection con = new SqlConnection(con_string);

        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;

            string qry = @"Select * from users where username = '" + user + "' and upass ='" + pass + "' ";
            SqlCommand cmd = new SqlCommand(qry, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            if(dt.Rows.Count > 0 )
            {
                isValid= true;
                USER = dt.Rows[0]["uName"].ToString();
            }

            return isValid;
        }

       

        public static string user;

        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }
    }
}
