using MyFYP.Core.Models;
using MyFYP.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyFYP.WebUI.Controllers
{
    public class ChartController : Controller
    {
        
        public ActionResult Index()
        {
            string query = "Select ProductName, COUNT(Quantity) TotalOrdered FROM OrderItem GROUP BY ProductName";
            string constr = ConfigurationManager.ConnectionStrings[@"Data Source=localhost\SQLEXPRESS;Initial Catalog=MyFYP;Integrated Security=True"].ConnectionString;
            List<OrderItem> chartData = new List<OrderItem>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new OrderItem
                            {
                                ProductName = sdr["ProductName"].ToString(),
                                Quantity = Convert.ToInt32(sdr["Quantity"])
                            });
                        }
                    }

                    con.Close();
                }
            }

            return View(chartData);
        }
    }
    }
