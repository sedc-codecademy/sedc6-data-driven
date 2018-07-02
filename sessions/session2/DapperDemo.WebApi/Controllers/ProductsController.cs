using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DapperDemo.WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        string GetConnectionString() => ConfigurationManager.ConnectionStrings["ProductsDb"].ConnectionString;

        public async Task<IHttpActionResult> GetAllProducts()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {

            }
        }
    }
}