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

        [HttpGet]
        [Route("{id:min(1)}")]
        public async Task<IHttpActionResult> GetProductDetails(int id)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var query = @"select 
p.Id,
p.Name,
p.Description,
p.Quantity,
p.ProductTypeId,
pt.Name as ProductTypeName
from products as p
inner join ProductTypes as pt 
	on p.ProductTypeId = pt.Id
where p.Id = @Id
";
                var products = connection.Query<ProductFull>(query,new { Id = id}).ToList();
                return Ok(products);
            }
        }

    }
}