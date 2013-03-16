using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmandoShop.ManagementClient.Model.Services
{
    public class DelegateCategoryService
    {
        public List<Category> ListCategories()
        {
            List<Category> categories = new List<Category>();
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                categories = client.ListCategories();
            }
            return categories;
        }


        internal void ModifyCategory(Category onTable)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                client.ModifyCategory(onTable);
            }
        }

        internal long NewCategory(Category onTable)
        {
            long id = -1;
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                id = client.NewCategory(onTable);
            }
            return id;
        }

        internal void DeleteCategory(long id)
        {
            using (CategoryServiceClient client = new CategoryServiceClient())
            {
                client.DeleteCategory(id);
            }
        }
    }
}
