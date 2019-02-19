using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothBazar.Entities;
using ClothBazar.Database;

namespace ClothBazar.Service
{
    public class CategoryService
    {
        public void SaveCategory(Category dtoObject)
        {
            using (var context = new CBContext())
            {
                dtoObject.CreatedOn = DateTime.Now.ToLongDateString();

                context.Categories.Add(dtoObject);

                context.SaveChanges();

            }
        }

        public List<Category> GetCategory()
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetSingleCategory(int id)
        {
            using (var context = new CBContext())
            {
                return context.Categories.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void UpdateCategory(Category dtoObject)
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

        public void DeleteCategory(Category dtoObject)
        {
            using (var context = new CBContext())
            {
                
                context.Entry(dtoObject).State = System.Data.Entity.EntityState.Deleted;

                context.Categories.Remove(dtoObject);

                context.SaveChanges();
            }
        }
    }
}
