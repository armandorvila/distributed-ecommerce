using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using ArmandoShop.Model;

namespace ArmandoShop.DataAccess.Mapping
{
    class ContractMapper : IRowMapper<Contract>
    {
        public Contract MapRow(DbDataReader reader)
        {
            Contract contract = new Contract();
            contract.Id = reader.GetInt64(0);
            contract.Stock = reader.GetInt32(1);
            contract.Charged = reader.GetBoolean(2);
            contract.Date = reader.GetDateTime(3);
            /*2 statefull calss*/
            contract.Product = this.GetProduct(reader);
            contract.Provider = this.GetProvider(reader);
            return contract;
        }

        private Product GetProduct(DbDataReader reader)
        {
            Product product = new Product();
            product.Id = reader.GetInt64(4);
            product.Name = reader.GetString(5);
            product.Stock = reader.GetInt32(6);
            product.Price = reader.GetDecimal(7);
            product.Description = reader.GetString(8);
            
            Category category = new Category();

            category.Id = reader.GetInt64(9);
            category.Name = reader.GetString(10);
            category.Description = reader.GetString(11);

            product.Category = category;

            return product;
        }

        private Provider GetProvider(DbDataReader reader)
        {
            Provider provider = new Provider();
            provider.Id = reader.GetInt64(12);
            provider.Name = reader.GetString(13);
            provider.Surname = reader.GetString(14);
            provider.Address = reader.GetString(15);
            provider.Phone = reader.GetString(16);
            provider.Mail = reader.GetString(17);
            return provider;
        }
    }
}
