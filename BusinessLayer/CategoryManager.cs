using DataAccessLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryManager
    {
        Repository<Category> caterepo = new Repository<Category>();
        public List<Category> GetAll()
        {
            return caterepo.List();
        }

        public int BLAdd(Category p) //BL=Business Layer
        {
            if(p.CategoryName.Length<=3)
            {
                return -1;
            }
            return caterepo.Insert(p);
        }
        public int BLDelete(int p)
        {
            if (p != 0)
            {
                Category c = caterepo.Find(x => x.CategoryID == p);
                return caterepo.Delete(c);
            }
            else
            {
                return -1;
            }
        }
        public int BLUpdate(Category p)
        {
            if(p.CategoryName == "" || p.CategoryName.Length<=3 || p.CategoryName.Length>= 30)
            {
                return -1;
            }
            Category ct = caterepo.Find(x=>x.CategoryID == p.CategoryID);
            ct.CategoryName = p.CategoryName;
            return caterepo.Update(ct);
        }
    }
}
