using MeenaBazar.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MeenaBazar.Repository
{
    public class SellerRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        public bool AddSeller(Seller obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("AddSeller", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sname", obj.SellerName);
            com.Parameters.AddWithValue("@oname", obj.OwnerName);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }

        public List<Seller> AllSeller()
        {
            Connection();
            List<Seller> sellers = new List<Seller>();


            SqlCommand com = new SqlCommand("Allseller", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                sellers.Add(

                    new Seller
                    {

                        SellerName = Convert.ToString(dr["Seller Name"]),
                        OwnerName = Convert.ToString(dr["Owner Name"]),

                    }
                    );
            }

            return sellers;
        }
        public bool UpdateSeller(Seller obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateSeller", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sid", obj.SellerId);
            com.Parameters.AddWithValue("@sname", obj.SellerName);
            com.Parameters.AddWithValue("@oname", obj.OwnerName);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSeller(int SellerId)
        {

            Connection();
            SqlCommand com = new SqlCommand("DeleteSeller", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sid", SellerId);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}