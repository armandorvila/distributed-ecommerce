using System.Collections.Generic;
using System.ServiceModel;
using ArmandoShop.Model;

namespace ArmandoShop.Services.Contracts
{
   
    [ServiceContract(Namespace ="http://ArmandoShop.categoryService")]
    public  interface ICategoryService
    {
        [OperationContract]
        IList<Category> ListCategories();

        [OperationContract]
        IList<Category> GetCategoriesByProvider(long idProvider);

        [OperationContract]
        IList<Category> GetCategoriesNotInProvider(long idProvider);

        [OperationContract]
        void AddProviderToCategory(long idProvider, long idCategory);

        [OperationContract]
        void RemoveProviderOfCategory(long idProvider, long idCategory);

        [OperationContract]
        Category GetCategory(long id);

        [OperationContract]
        long NewCategory(Category category);

        [OperationContract]
        void DeleteCategory(long id);

        [OperationContract]
        void ModifyCategory(Category category);

    }
}
