using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Dapper;
using DapperDemo.Entities;

namespace DapperDemo.WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        string GetConnectionString() => ConfigurationManager.ConnectionStrings["ProductsDb"].ConnectionString;

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var query = "select * from Products";
                var products = connection.Query<Product>(query).ToList();
                return Ok(products);
            }
        }
        
    }
}