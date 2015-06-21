using System;
using System.Collections.Generic;
using System.Linq;
using DomainEntitites;



namespace EcommerceDAL
{
    public static class DAL
    {

        private static EcommerceDAL.EcommerceEntity _entities = new EcommerceEntity();
        
        public static List<User> GetUsers()
        {

            return _entities.Users.ToList();

        }

        public  static User GetUser(string username)
        {

            var user= _entities.Users.FirstOrDefault(m => m.UserName == username);

            return user;
        }

        public static void AddUser(User user)
        {
            
            _entities.Users.Add(user);
            _entities.SaveChanges();
        }


        public static List<Product> GetProducts()
        {

            return _entities.Products.ToList();

        }

        public static Product GetProduct(string productName)
        {

            
           return _entities.Products.FirstOrDefault(m => m.Name == productName);
        }


        public static void AddProduct(Product product)
        {
            
            _entities.Products.Add(product);
        }

        public static void AddOrder(Order order)
        {

            _entities.Orders.Add(order);
            _entities.SaveChanges();

        }

        public static Order  GetOrder(int id)
        {

            return _entities.Orders.FirstOrDefault(m => m.UserId == id);

        }
    }
}
