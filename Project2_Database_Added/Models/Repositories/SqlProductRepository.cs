﻿using Microsoft.EntityFrameworkCore;
using Project2_Database_Added.Models.Data;

namespace Project2_Database_Added.Models.Repositories
{
    public class SqlProductRepository : IRepository<Product>
    {
        private readonly AppDbContext context;
        public SqlProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Product Add(Product P)
        {
            context.Products.Add(P);
            context.SaveChanges();
            return P;
        }
        public Product Delete(int Id)
        {
            Product P = context.Products.Find(Id);
            if (P != null)
            {
                context.Products.Remove(P);
                context.SaveChanges();
            }
            return P;
        }
        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Product Get(int Id)

        {
            return context.Products.Find(Id);
        }
        public Product Update(Product P)
        {
            var Product = context.Products.Attach(P);
            Product.State = EntityState.Modified;
            context.SaveChanges();
            return P;
        }
    }

}
