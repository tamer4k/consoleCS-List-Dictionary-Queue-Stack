using System;
using System.Collections.Generic;
using System.Linq;

namespace SortRevers
{
    /*
     1. List  FIFO FindAll(); /FindLast(); /Find(); / TrueForAll(); /Complex type / Simple type/ Sort(); / Reverse(); / AsReadOnly(); / Count;
         Capacity / Insert();/ IndexOf(); / Contains(); / Exist(); StartWith(); / AddRange(); GetRange(); / RemoveRange(); InsertRange(); 
     2. Dictionary ContainsKey(); / KeyValuePair<T, T> / TryGetValue(); / Count(kvp => kvp.Value.Salary > 3000); / Remove() / Clear(); 
     3. Queue FIFO Enqueue(); fore add / Dequeue(); fore remove /  Peek() fore return  / Contains() fore check
     4. Stack LIFO Push();    fore add / Pop();     fore remove /  Peek() fore return  / Contains() fore check
    */
    public static class DoWhile
    {
        public static string dodo()
        {
            string result = "";

            do
            {
                Console.WriteLine("YES OR NO");
                result = Console.ReadLine().ToUpper();
            }
            while (result != "YES" && result != "NO");

            return result;
        }
    }
    public static class Addnummer
    {
        public static void addnumber(int x , int y, params object[] opsoinal)
        {
            int result = x + y;

                foreach (int item in opsoinal)
                {
                    result += item;
                }
         

            Console.WriteLine(result);
        }
    }
    public class Customer : IComparable<Customer>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public int CompareTo(Customer other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
    public class SortByName : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
    public class SortBySalary : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Capital { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            //var dowhile = DoWhile.dodo();
           Addnummer.addnumber(1, 1 , 10,5);
            

            Customer customer1 = new Customer() { ID = 1, Name = "C", Salary = 3000 };
            Customer customer2 = new Customer() { ID = 2, Name = "A", Salary = 2000 };
            Customer customer3 = new Customer() { ID = 3, Name = "D", Salary = 4000 };
            Customer customer4 = new Customer() { ID = 4, Name = "B", Salary = 5000 };
            Customer customer5 = new Customer() { ID = 5, Name = "E", Salary = 3500 };

            Stack<Customer> stackCustomers = new Stack<Customer>();
            Queue<Customer> queueCuctomer = new Queue<Customer>();
            List<Customer> listCustomers = new List<Customer>(100);
            Dictionary<int, Customer> dictionaryCuctomer = new Dictionary<int, Customer>();
            Customer[] ArryCustomers = new Customer[] { customer1, customer2, customer3, customer4, customer5 };


            stackCustomers.Push(customer1);
            stackCustomers.Push(customer2);
            stackCustomers.Push(customer3);
            stackCustomers.Push(customer4);
            stackCustomers.Push(customer5);
            stackCustomers.Pop();



            listCustomers.Add(customer1);
            listCustomers.Add(customer2);
            listCustomers.Add(customer3);
            listCustomers.Add(customer4);
            listCustomers.Add(customer5);

            listCustomers.Sort();
            listCustomers.Reverse();

                
            SortByName sortByName = new SortByName();
            SortBySalary sortBySalary = new SortBySalary();
            listCustomers.Sort(sortByName);
            listCustomers.AddRange(ArryCustomers);
            //listCustomers.Sort(delegate (Customer customer1, Customer customer2) { return customer1.Name.CompareTo(customer2.Name); });


            queueCuctomer.Enqueue(customer1);
            queueCuctomer.Enqueue(customer2);
            queueCuctomer.Enqueue(customer3);
            queueCuctomer.Enqueue(customer4);
            queueCuctomer.Enqueue(customer5);
            queueCuctomer.Dequeue();
            queueCuctomer.Peek();



            dictionaryCuctomer.Add(customer2.ID, customer2);
            dictionaryCuctomer.Add(customer3.ID, customer3);
            dictionaryCuctomer.Add(customer4.ID, customer4);
            dictionaryCuctomer.Add(customer5.ID, customer5);
            if (!dictionaryCuctomer.ContainsKey(customer1.ID))
            {
                dictionaryCuctomer.Add(customer1.ID, customer1);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n===================(List TrueForAll)===================\n");




            var item = listCustomers.TrueForAll(x => x.Salary > 1000);
            if (item == true)
            {
                Console.WriteLine("Iedereen kijken boven dan 1000");
                Console.WriteLine(item);

            }
            else
            {
                Console.WriteLine("Niet iedereen krijgen boven dan 1000");
                Console.WriteLine(item);
            }

            Console.WriteLine("\n===================(List Capacity and TrimExcess)===================\n");

            Console.WriteLine("Capacity before trimming: " + listCustomers.Capacity);
            listCustomers.TrimExcess();
            Console.WriteLine("Capacity after trimming: " + listCustomers.Capacity);

            Console.WriteLine("\n===================(List AsReadOnly)===================\n");

            IReadOnlyCollection<Customer> readOnlyCustomer = listCustomers.AsReadOnly();
            foreach (var l in listCustomers)
            {
                Console.WriteLine("ID: {0} , Name:{1} , Salary: {2} ", l.ID, l.Name, l.Salary);
            }

            Console.WriteLine("\n");

            Console.WriteLine("Salary boven dan 3000");
            List<Customer> findAll = listCustomers.FindAll(x => x.Salary > 3000);
            foreach (Customer f in findAll)
            {
                Console.WriteLine("ID: {0} , Name:{1} , Salary: {2} ", f.ID, f.Name, f.Salary);

            }



            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n===================(Queue FIFO)===================\n");

            foreach (Customer c in queueCuctomer)
            {
                Console.WriteLine("ID: {0} , Name:{1} , Salary: {2} ", c.ID, c.Name, c.Salary);
            }
            if (queueCuctomer.Contains(customer1))
            {
                Console.WriteLine("customer1 exist");
            }
            else
            {
                Console.WriteLine("customer1 not exist");
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===================(Stack LIFO)===================\n");

            foreach (Customer c in stackCustomers)
            {
                Console.WriteLine("ID: {0} , Name:{1} , Salary: {2} ", c.ID, c.Name, c.Salary);
            }
            Console.WriteLine("Count: {0}", stackCustomers.Count);
            if (stackCustomers.Contains(customer5))
            {
                Console.WriteLine("customer5 is exist");
            }
            else
            {
                Console.WriteLine("customer5 is not exist");
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n===================(Dictionary FIFO)===================\n");


            int countSalary = dictionaryCuctomer.Count(kvp => kvp.Value.Salary > 3000);
            Console.WriteLine("Customer die boven dan 2000 salary krijgen zijn : {0}", countSalary);

            foreach (KeyValuePair<int, Customer> d in dictionaryCuctomer)
            {
                Customer customer = d.Value;

                Console.WriteLine("ID: {0} , Name:{1} , Salary: {2} ", d.Key, customer.Name, customer.Salary);

            }
            Console.WriteLine("\n*************");
            Customer cust;
            if (dictionaryCuctomer.TryGetValue(9, out cust))
            {
                Console.WriteLine("ID: {0} , Name:{1} , Salary: {2} ", cust.ID, cust.Name, cust.Salary);
            }
            else
            {
                Console.WriteLine("dit cutomer is niet gevonden");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n===================(Array To Dictionary && List To Dictionary)===================\n");

            Dictionary<int, Customer> arrayToDictionary = ArryCustomers.ToDictionary(x => x.ID, x => x);

            foreach (KeyValuePair<int, Customer> kvp in arrayToDictionary)
            {
                Customer customer = kvp.Value;

                Console.WriteLine("ID: {0} , Name:{1} , Salary: {2} ", kvp.Key, customer.Name, customer.Salary);

            }

            Console.WriteLine("\n");

            //Dictionary<int, Customer> listToDictionary = listCustomers.ToDictionary(x => x.ID, x => x);

            //foreach (KeyValuePair<int, Customer> kvp in listToDictionary)
            //{
            //    Customer customer = kvp.Value;

            //    Console.WriteLine("ID: {0} , Name:{1} , Salary: {2} ", kvp.Key, customer.Name, customer.Salary);

            //}






            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n===================()===================\n");


            Country country1 = new Country() { Code = "NL", Name = "Netherlands", Capital = "Amsterdam" };
            Country country2 = new Country() { Code = "IT", Name = "Italië", Capital = "Rome" };
            Country country3 = new Country() { Code = "ES", Name = " Spanje", Capital = "Madrid" };
            Country country4 = new Country() { Code = "DE", Name = "Duitsland", Capital = "Berlijn" };
            Country country5 = new Country() { Code = "SE", Name = "Zweden", Capital = "Stockholm" };


            List<Country> countryList = new List<Country>();
            countryList.Add(country1);
            countryList.Add(country2);
            countryList.Add(country3);
            countryList.Add(country4);
            countryList.Add(country5);
            string strUserChoice = string.Empty;

            Dictionary<string, Country> countryDictionary = new Dictionary<string, Country>();
            countryDictionary.Add(country1.Code, country1);
            countryDictionary.Add(country2.Code, country2);
            countryDictionary.Add(country3.Code, country3);
            countryDictionary.Add(country4.Code, country4);
            countryDictionary.Add(country5.Code, country5);



            do
            {

                Console.WriteLine("Please enter country code");
                string strCountryCode = Console.ReadLine().ToUpper();

                Country resultCountry = countryList.Find(country => country.Code == strCountryCode);

                if (resultCountry == null)
                {
                    Console.WriteLine("not valid");
                }
                else
                {
                    Console.WriteLine("Name = {0}, Capital = {1} ", resultCountry.Name, resultCountry.Capital);
                }
                do
                {
                    Console.WriteLine("Do you want to continue? YES or NO");
                    strUserChoice = Console.ReadLine().ToUpper();


                }
                while (strUserChoice != "YES" && strUserChoice != "NO");

            } while (strUserChoice == "YES");





            do
            {

                Console.WriteLine("Please enter country code");
                string strCountryCode = Console.ReadLine().ToUpper();

                Country resultCountry = countryDictionary.ContainsKey(strCountryCode) ? countryDictionary[strCountryCode] : null;

                if (resultCountry == null)
                {
                    Console.WriteLine("not valid");
                }
                else
                {
                    Console.WriteLine("Name = {0}, Capital = {1} ", resultCountry.Name, resultCountry.Capital);
                }
                do
                {
                    Console.WriteLine("Do you want to continue? YES or NO");
                    strUserChoice = Console.ReadLine().ToUpper();


                }
                while (strUserChoice != "YES" && strUserChoice != "NO");

            } while (strUserChoice == "YES");









            Console.ReadKey();
        }
    }
}
