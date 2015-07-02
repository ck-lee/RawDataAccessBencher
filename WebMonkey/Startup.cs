using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using EF6.Bencher.EntityClasses;
using Microsoft.OData.Edm;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Owin;

[assembly: OwinStartup(typeof(WebMonkey.Startup))]

namespace WebMonkey
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            var products = builder.EntitySet<Product>("Products");
            products.EntityType.Ignore(p => p.BillOfMaterials);
            products.EntityType.Ignore(p => p.BillOfMaterials_);

            products.EntityType.Ignore(p => p.ProductCostHistories);
            products.EntityType.Ignore(p => p.ProductDocuments);
            products.EntityType.Ignore(p => p.ProductInventories);
            products.EntityType.Ignore(p => p.ProductListPriceHistories);
            products.EntityType.Ignore(p => p.ProductModel);
            products.EntityType.Ignore(p => p.ProductProductPhotos);
            products.EntityType.Ignore(p => p.ProductReviews);
            products.EntityType.Ignore(p => p.ProductSubcategory);
            products.EntityType.Ignore(p => p.ProductVendors);
            products.EntityType.Ignore(p => p.PurchaseOrderDetails);
            products.EntityType.Ignore(p => p.ShoppingCartItems);
            products.EntityType.Ignore(p => p.SpecialOfferProducts);
            products.EntityType.Ignore(p => p.TransactionHistories);
            products.EntityType.Ignore(p => p.UnitMeasure);
            products.EntityType.Ignore(p => p.UnitMeasure_);
            products.EntityType.Ignore(p => p.WorkOrders);

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
            config.EnsureInitialized();
        }

        
    }
}
