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

        public IList<ProductData> GetAll()
        {
            var result = HttpContext.Current.Session["Products"] as IList<ProductData>;

            if (result == null || UpdateDatabase)
            {
                using (var db = new _Databse._DatabseContextShop())
                {
                    result = db.Products.Select(product => new ProductData
                    {
                        ProductID = product.Id,
                        ProductName = product.ProductName,
                        UnitPrice = product.UnitPrice.HasValue ? product.UnitPrice.Value : default(decimal),
                        UnitsInStock = product.UnitsInStock.HasValue ? product.UnitsInStock.Value : default(short),
                        //  QuantityPerUnit = product.QuantityPerUnit,
                        Discontinued = product.Discontinued,
                        UnitsOnOrder = product.UnitsOnOrder.HasValue ? (int)product.UnitsOnOrder.Value : default(int),
                        //CategoryID = product.CategoryID,
                        //Category = new CategoryViewModel()
                        //{
                        //    CategoryID = product.Category.CategoryID,
                        //    CategoryName = product.Category.CategoryName
                        //},
                        LastSupply = DateTime.Today
                    }).ToList();
                }

                HttpContext.Current.Session["Products"] = result;
            }

            return result;
        }

        public IEnumerable<ProductData> Read()
        {
            return GetAll();
        }

        public void Create(ProductData product)
        {
            if (!UpdateDatabase)
            {
                var first = GetAll().OrderByDescending(e => e.ProductID).FirstOrDefault();
                var id = (first != null) ? first.ProductID : 0;

                product.ProductID = id + 1;

                //if (product.CategoryID == null)
                //{
                //    product.CategoryID = 1;
                //}

                //if (product.Category == null)
                //{
                //    product.Category = new CategoryViewModel() { CategoryID = 1, CategoryName = "Beverages" };
                //}

                GetAll().Insert(0, product);
            }
            else
            {
                using (var db = new _Databse._DatabseContextShop())
                {
                    var entity = new ProductTable();

                    entity.ProductName = product.ProductName;
                    entity.UnitPrice = product.UnitPrice;
                    entity.UnitsInStock = (short)product.UnitsInStock;
                    entity.Discontinued = product.Discontinued;
                    //entity.CategoryID = product.CategoryID;

                    //if (entity.CategoryID == null)
                    //{
                    //    entity.CategoryID = 1;
                    //}

                    //if (product.Category != null)
                    //{
                    //    entity.CategoryID = product.Category.CategoryID;
                    //}

                    db.Products.Add(entity);
                    db.SaveChanges();

                    product.ProductID = entity.Id;

                }                
            }
        }

        //public void Update(ProductData product)
        //{
        //    if (!UpdateDatabase)
        //    {
        //        var target = One(e => e.ProductID == product.ProductID);

        //        if (target != null)
        //        {
        //            target.ProductName = product.ProductName;
        //            target.UnitPrice = product.UnitPrice;
        //            target.UnitsInStock = product.UnitsInStock;
        //            target.Discontinued = product.Discontinued;

        //            //if (product.CategoryID == null)
        //            //{
        //            //    product.CategoryID = 1;
        //            //}

        //            //if (product.Category != null)
        //            //{
        //            //    product.CategoryID = product.Category.CategoryID;
        //            //}
        //            //else
        //            //{
        //            //    product.Category = new CategoryViewModel()
        //            //    {
        //            //        CategoryID = (int)product.CategoryID,
        //            //        CategoryName = entities.Categories.Where(s => s.CategoryID == product.CategoryID).Select(s => s.CategoryName).First()
        //            //    };
        //            //}

        //            //target.CategoryID = product.CategoryID;
        //            //target.Category = product.Category;
        //        }
        //    }
        //    else
        //    {
        //        using (var db = new _Databse._DatabseContextShop())
        //        {
        //            var entity = new ProductTable();

        //            entity.Id = product.ProductID;
        //            entity.ProductName = product.ProductName;
        //            entity.UnitPrice = product.UnitPrice;
        //            entity.UnitsInStock = (short)product.UnitsInStock;
        //            entity.Discontinued = product.Discontinued;
        //            //entity.CategoryID = product.CategoryID;

        //            //if (product.Category != null)
        //            //{
        //            //    entity.CategoryID = product.Category.CategoryID;
        //            //}

        //            db.Products.Attach(entity);
        //            //db.Entry(entity).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
                   
        //    }
        //}

        //public void Destroy(ProductData product)
        //{
        //    if (!UpdateDatabase)
        //    {
        //        var target = GetAll().FirstOrDefault(p => p.ProductID == product.ProductID);
        //        if (target != null)
        //        {
        //            GetAll().Remove(target);
        //        }
        //    }
        //    else
        //    {
        //        var entity = new Product();

        //        entity.ProductID = product.ProductID;

        //        entities.Products.Attach(entity);

        //        entities.Products.Remove(entity);

        //        var orderDetails = entities.Order_Details.Where(pd => pd.ProductID == entity.ProductID);

        //        foreach (var orderDetail in orderDetails)
        //        {
        //            entities.Order_Details.Remove(orderDetail);
        //        }

        //        entities.SaveChanges();
        //    }
        //}

        public ProductTable GetOneProduct(int id)
        {
            using (var db = new _DatabseContextShop())
            {
                ProductTable result = db.Products.FirstOrDefault(x => x.Id == id);
                return result;
            }
            
        }

        public static ProductData GetOneProductModel(int id, _DatabseContextShop db)
        {
            //using (var db = new _DatabseContextShop())
            //{
                var result = db.Products.Where(x => x.Id == id)
                    .Select(x => new ProductData
                    {
                        Discontinued = x.Discontinued,
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


        //public void Dispose()
        //{
        //    db.Dispose();
        //}


    }
}