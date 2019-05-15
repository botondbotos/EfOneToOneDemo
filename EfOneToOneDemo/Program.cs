using EfOneToOneDemo.Data;
using EfOneToOneDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfOneToOneDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new ApplicationContext())
            {
                var address = new Address { City = "New York" };
                context.Address.Add(address);
                context.Employees.Add(new Employee { Name = "John Doe", Address = address });
                context.Employees.Add(new Employee { Name = "Jane Doe", Address = address });

                context.SaveChanges();
            }
        }
    }
}