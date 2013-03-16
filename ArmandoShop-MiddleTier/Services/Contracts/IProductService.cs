using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArmandoShop.Model;
using System.ServiceModel;

namespace ArmandoShop.Services.Contracts
{  
    [ServiceContract (Namespace="http://ArmandoShop.ProductsService")]
    public interface IProductsService
    {
        [OperationContract]
        Product GetProduct(long id);
        
        [OperationContract]
        IList<Product> ListProducts();

        [OperationContract]
        IList<Product> GetProductsByCategory(long idCategory);


        [OperationContract]
        long NewProduct(Product product);

        [OperationContract]
        void ModifyProduct(Product product);

        [OperationContract]
        void DeleteProduct(long id);
    }
}
