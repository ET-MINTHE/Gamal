using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Web.UI;
using Newtonsoft.Json;
using Nancy.Json;

namespace Gamal.Controllers
{
    public class SearchRequestHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string term = context.Request.Query["term"];
            string cs = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            List<string> courses = new List<string>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("searchCourseByDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@term",
                    Value = term
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@department",
                    Value = "GINF"
                });
                con.Open();
               // IAsyncResult result = cmd.BeginExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    courses.Add(rdr["CourseName"].ToString());
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.WriteAsync(js.Serialize(courses));
        }

        public bool IsReusable { get { return false; } }
    }
}
