using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductManager
    {
        Repository<Product> repoproduct = new Repository<Product>();
        public List<Product> GetAll()
        {
            return repoproduct.List();
        }

        public List<Product> GetByName(string p)
        {
            return repoproduct.List(x => x.ProductName == p);
        }
    }
}
