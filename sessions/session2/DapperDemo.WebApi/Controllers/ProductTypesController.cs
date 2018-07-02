
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
        private readonly SqlConnection connection;
        string GetConnectionString() => ConfigurationManager.ConnectionStrings["ProductsDb"].ConnectionString;

        public ProductTypesController()
        {
            connection = new SqlConnection(GetConnectionString());
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAllProductTypes()
        {
            var query = "select * from ProductTypes";
            var productTypes = connection.Query<ProductType>(query).ToList();
            return Ok(productTypes);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetAllProductTypeDetails(int id)
        {
            var query = "select top(1) * from ProductTypes as pt where pt.Id = @ID";
            var productType = connection.QueryFirst<ProductType>(query, new { ID = id });
            return Ok(productType);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateProductType(ProductType p)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = @"
begin transaction
insert into ProductTypes
(Name)
Values
(@productTypeName);
declare @ID as int = Scope_identity();
select * from ProductTypes as pt where pt.Id = @ID;
commit";

            var productType = connection.Query<ProductType>(query, new { productTypeName = p.Name });
            return Ok(productType);
        }

        protected override void Dispose(bool disposing)
        {
            connection.Close();
            connection.Dispose();
            base.Dispose(disposing);
        }
    }
}