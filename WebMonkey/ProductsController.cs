using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using EF6.Bencher;
using EF6.Bencher.EntityClasses;

namespace WebMonkey
{
    public class ProductsController : ODataController
    {
        AWDataContext db = new AWDataContext();

        // GET api/<controller>
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return db.Products;
        }

    }
}