using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;
namespace VBRedisCacheSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(
               "rediscache coonection string from azure portal");


           IDatabase cache = connection.GetDatabase();

            Person per = new Person();
            per.Age = 52;
            per.Name = "John";
            var serializedPerson = JsonConvert.SerializeObject(per);
            cache.StringSet("Raj", serializedPerson);


            var perCopy = JsonConvert.DeserializeObject<Person>(cache.StringGet("Raj"));
            Console.WriteLine(perCopy.Age+"  "+perCopy.Name);

        }
    }
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
