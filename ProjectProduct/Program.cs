using BusinessLayer;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ProjectProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryManager cm = new CategoryManager();
            ProductManager pm = new ProductManager();

            foreach (var item in pm.GetAll())
            {
                Console.WriteLine("ID: " + item.ProductID + " Ürün Adı: " + item.ProductName + " Stok: " + item.Stock);
            }

            Console.WriteLine();
            Console.WriteLine("-------------");
            Console.WriteLine();

            string proname = "Fırın";
            foreach (var item in pm.GetByName(proname))
            {
                Console.WriteLine("ID: " + item.ProductID + " Ürün Adı: " + item.ProductName + " Stok: " + item.Stock);
            }
            Console.WriteLine();

            Category c = new Category();
            c.CategoryName = "KategoriKategoriKategoriKategoriKategori";
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);
            if (results.IsValid)
            {
                cm.BLAdd(c);
                Console.WriteLine("Kategori eklendi");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }

            //Category c = new Category();
            //c.CategoryID = 3;
            //c.CategoryName = "Mobilya ve Oturma Grubu";
            //cm.BLUpdate(c);

            //foreach (var item in cm.GetAll())
            //{
            //    Console.WriteLine("ID: "+item.CategoryID+" - Kategori Adı: "+item.CategoryName);
            //}

            //Category ct = new Category();
            //ct.CategoryName = "Halılar";
            //cm.BLAdd(ct);
            //cm.BLDelete(5);
            Console.ReadLine();
        }
    }
}
