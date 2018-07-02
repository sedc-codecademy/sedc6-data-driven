
using Dapper;
using DapperDemo.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DapperDemo.WebApi.Controllers
{
    [RoutePrefix("producttypes")]
    public class ProductTypesController : ApiController
    {
        string GetConnectionString() => ConfigurationManager.ConnectionStrings["ProductsDb"].ConnectionString;

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAllProductTypes()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var query = "select * from ProductTypes";
                var productTypes = connection.Query<ProductType>(query).ToList();
                return Ok(productTypes);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetAllProductTypeDetails(int id)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var query = "select top(1) * from ProductTypes as pt where pt.Id = @ID";
                var productType = connection.QueryFirst<ProductType>(query, new { ID = id });
                return Ok(productType);
            }
        }
        /*
         * implement get Product details
         * implement get Product Type details
         */
    }
}