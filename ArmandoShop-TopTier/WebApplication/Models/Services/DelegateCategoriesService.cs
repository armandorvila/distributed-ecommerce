using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArmandoShop.WebApplication.Models.Services
{
    public class DelegateCategoriesService
    {
        public List<Category> ListCategories()
        {
            List<Category> categories = new List<Category>();

            using (CategoryServiceClient client = new CategoryServiceClient()){
                categories = client.ListCategories();
            }

            return categories;
        }

        public Category GetCategory(long id)
        {
            Category category = null;
              using (CategoryServiceClient client = new CategoryServiceClient()){
                category = client.GetCategory(id);
            }
            return category;
        }

    }
}