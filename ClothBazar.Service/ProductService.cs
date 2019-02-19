using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothBazar.Entities;
using ClothBazar.Database;

namespace ClothBazar.Service
{
    public class ProductService
    {
        public List<Product> GetProduct()
        {
            using (var context = new CBContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetSingleProduct(int id)
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void SaveProduct(Product dtoObject)
        {
            using (var context = new CBContext())
            {
                dtoObject.CreatedOn = DateTime.Now.ToLongDateString();

                context.Products.Add(dtoObject);

                context.SaveChanges();

            }
        }

        public void UpdateProduct(Product dtoObject)
        {
            using (var context = new CBContext())
            {
                //var catEntity = context.Categories.Where(x => x.Id == dtoObject.Id).FirstOrDefault();
                //catEntity.Name = dtoObject.Name;
                //catEntity.Description = dtoObject.Description;

                dtoObject.LastModifiedOn = DateTime.Now.ToLongDateString();

                context.Entry(dtoObject).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Product dtoObject)
        {
            using (var context = new CBContext())
            {
                
                context.Entry(dtoObject).State = System.Data.Entity.EntityState.Deleted;

                context.Products.Remove(dtoObject);

                context.SaveChanges();
            }
        }
    }
}
