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
    public class ProductRepository
    {

        private SqlConnection con;
        //To Handle connection related activities    
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        public bool AddProduct(Product obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("Product", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@pname", obj.ProductName);
            com.Parameters.AddWithValue("@bname", obj.BrandName);
            com.Parameters.AddWithValue("@price", obj.Price);

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

        public List<Product> AllProduct()
        {
            Connection();
            List<Product> products = new List<Product>();


            SqlCommand com = new SqlCommand("AllProduct", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                products.Add(

                    new Product
                    {

                        ProductId = Convert.ToInt32(dr["Product Id"]),
                        ProductName = Convert.ToString(dr["Product Name"]),
                        BrandName = Convert.ToString(dr["Brand Name"]),
                        Price = Convert.ToString(dr["Price"])

                    }
                    );
            }

            return products;
        }

        public bool UpdateProduct(Product obj)
        {

            Connection();
            SqlCommand com = new SqlCommand("UpdateProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@pid", obj.ProductId);
            com.Parameters.AddWithValue("@pname", obj.ProductName);
            com.Parameters.AddWithValue("@bname", obj.BrandName);
            com.Parameters.AddWithValue("@price", obj.Price);
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

        public bool DeleteProduct(int ProductId)
        {

            Connection();
            SqlCommand com = new SqlCommand("DeleteProduct", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@pid", ProductId);

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