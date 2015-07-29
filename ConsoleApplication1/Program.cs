using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //abstarctFactory abs = new factoery1();
            //factoery1 objfact = new factoery1();
           
         
            //clientProd objclient = new clientProd(abs);
            //objclient.RunPro();
            //Console.ReadKey();
            //Console.WriteLine(objfact.objecttype());
            //Console.ReadKey();
              string[] a = { "a", "b", "c", "d" };
         string[] b = { "d","e","f","g"};
 
         var UnResult = a.Union(b);
         Console.WriteLine("Union Result");
         foreach (string s in UnResult)
         {
             Console.WriteLine(s);          
         }
 
         var ExResult = a.Except(b);
         Console.WriteLine("Except Result");
         foreach (string s in ExResult)
         {
             Console.WriteLine(s);
         }
 
         var InResult = a.Intersect(b);
         Console.WriteLine("Intersect Result");
         foreach (string s in InResult)
         {
             Console.WriteLine(s);
         }
         Console.ReadLine();
         
     
        }
    }

    abstract class abstarctFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB(); 
    }
    abstract class AbstractProductA
    {
        public AbstractProductA()
        {

           // RestClient abc = new RestClient();
            Task t = new Task(DownloadPageAsync);
            t.Start();
            Console.WriteLine("Downloading page...");
            //WebClient client = new WebClient();
            //if (client.IsBusy == false)
            //{
            //    var data = client.DownloadString("http://localhost:62992/naasservices/v1.0/datacenters");
            //    var list = data.ToList();
            //}

            

            Console.WriteLine("abstract constructor");
        }

        static async void DownloadPageAsync()
        {
            // ... Target page.
            string page = "http://localhost:62992/naasservices/v1.0/datacenters";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null &&
                result.Length >= 50)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    class ProductA1 : AbstractProductA
    {
    }
    class ProductB : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interact with " + a.GetType().Name);
        }
    }

    class factoery1 : abstarctFactory
    {
        public override AbstractProductA CreateProductA()
        {
            
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB();
        }
        public string objecttype()
        {
            return this.GetType().FullName;
        }
    }

    class clientProd
    {
        private AbstractProductA _abstarctprodA;
        private AbstractProductB _abstarctProdB;

        public clientProd(abstarctFactory abs)
        {
            _abstarctprodA=abs.CreateProductA();
            _abstarctProdB = abs.CreateProductB();

        }

        public void RunPro()
        {
            _abstarctProdB.Interact(_abstarctprodA);
        }
    }
}
