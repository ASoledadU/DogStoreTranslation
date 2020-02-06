using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace VSC
{
    class Program
    {
        static DogSpa LoadDogSpa()
        {
            string jsonable = File.ReadAllText(@"services.json");
            var wholeThing = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Service>>>(jsonable);
            Dictionary<string, Service> dictionaryOfServices = wholeThing["services"];
            List<Service> listOfServices = dictionaryOfServices.Values.ToList();
            return new DogSpa(listOfServices);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dog Spa!");
            DogSpa dogSpa = LoadDogSpa();
            foreach (var service in dogSpa.Services.Values)
            {
                Console.WriteLine(service.Name + "...................$" + service.Price);
            }
            Console.WriteLine("Which service would you like to order today?: ");
            string ask = Console.ReadLine();
            if (dogSpa.ProvidesService(ask))
            {
                Service service = dogSpa.FindService(ask);
                RecordTransaction(ask);
                Console.WriteLine("What a great choice!");
                Console.WriteLine("Your total is: " + service.Price);
                Console.WriteLine("Have a great day!");
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }

        public static void RecordTransaction(string serviceName)
        {
            DateTime localDate = DateTime.Now;
            StreamWriter w = File.AppendText("transactions.txt");
            w.WriteLine(localDate + ", " + serviceName);
            w.Flush();
        }
    }
}
