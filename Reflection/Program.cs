using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            //foreach (var item in assembly.GetTypes())
            //{
            //    Console.WriteLine($"{item.Namespace}.{item.Name}");
            //    foreach (var property in item.GetProperties())
            //    {
            //    Console.WriteLine($"{property.PropertyType}/ {property.Name}");
            //    }

            //}

            var userType = Type.GetType("Reflection.User");
            var userProperties = userType.GetProperties();
            var userName = userType.GetProperty("Name");
            var userLastName = userType.GetProperty("LastName");
            var user = (User)Activator.CreateInstance(userType);

            var welcome = userType.GetMethod("Welcome");
            var getFullName = userType.GetMethod("GetFullName");
            welcome.Invoke(user, null);
            userName.SetValue(user, "Damla");
            userLastName.SetValue(user, "Türker");

            var returnFullName = getFullName.Invoke(user, null).ToString();
            Console.WriteLine(returnFullName);
            Console.ReadLine();

        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void Welcome()
        {
            Console.WriteLine("Hoşgeldiniz");
        }
        public string GetFullName()
        {
            return $"Adınız : {Name} - Soyadınız: {LastName}";
        }
    }

}
