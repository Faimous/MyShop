using MyShop.Models._Databse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShop.Models.Products
{
    public class Product
    {
        private static bool UpdateDatabase = false;
        // private SampleEntities entities;

        public Product()
        {
        }



        public static void Add(ProductData product, _DatabseContextShop db)
        {
            var entity = new ProductTable();

            entity.ProductName = product.ProductName;
            entity.UnitPrice = product.UnitPrice;
            entity.Description = product.Description;
            entity.UnitsInStock = (short)product.UnitsInStock;
            entity.Discontinued = product.Discontinued;
            entity.Id = product.ProductID;
            entity.LastSupply = DateTime.Now;
            entity.UnitsOnOrder = product.UnitsOnOrder;



            db.Products.Add(entity);
            db.SaveChanges();
        }


        public ProductTable GetOneProduct(int id, _DatabseContextShop db)
        {

            ProductTable result = db.Products.FirstOrDefault(x => x.Id == id);
            return result;


        }

        public static ProductData GetOneProductModel(int id, _DatabseContextShop db)
        {
            //using (var db = new _DatabseContextShop())
            //{
            var result = db.Products.Where(x => x.Id == id)
                .Select(x => new ProductData
                {
                    Discontinued = x.Discontinued,
                    Description = x.Description,
                    LastSupply = x.LastSupply,
                    ProductID = x.Id,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    UnitsOnOrder = x.UnitsOnOrder
                })
                    .FirstOrDefault();

            return result;

            //}

        }


        public static List<ProductData> GetProducts(_DatabseContextShop db)
        {
            List<ProductData> result;
            {
                result = db.Products
                    .Where(product => product.Discontinued != true
                    && product.UnitsInStock > 0
                    )
                    .Select(product => new ProductData
                    {
                        ProductID = product.Id,
                        ProductName = product.ProductName,
                        Description = product.Description,
                        UnitPrice = product.UnitPrice ?? 0,
                        UnitsInStock = product.UnitsInStock ?? 0,
                        UnitsOnOrder = product.UnitsOnOrder ?? 0,
                        Discontinued = product.Discontinued,
                        LastSupply = product.LastSupply
                    }).ToList();
                return result;
            }
        }

        public static IQueryable<ProductTable> GetAdminProducts(_DatabseContextShop db)
        {
            IQueryable<ProductTable> result;
            {
                result = db.Products

                    .Select(product => new ProductTable
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        UnitPrice = product.UnitPrice ?? 0,
                        UnitsInStock = product.UnitsInStock ?? 0,
                        UnitsOnOrder = product.UnitsOnOrder ?? 0,
                        Discontinued = product.Discontinued,
                        LastSupply = product.LastSupply,
                        Description = product.Description
                    });
                return result;
            }
        }
    }
}