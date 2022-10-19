using LINQ.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5(); 
           //Exercise6();
            //Exercise7();
            //Exercise8(); 
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13(); 
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
          // Exercise21();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            Exercise30(); 
            //Exercise31(); 
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();
            var outOfStock = products.Where(oos => oos.UnitsInStock == 0);
            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();
            var inStockMorethanThree = products.Where(ismtt => (ismtt.UnitsInStock > 0)&&(ismtt.UnitPrice > 3.00M));
            PrintProductInformation(inStockMorethanThree);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customers = DataLoader.LoadCustomers();

            var WACust = customers.Where(wc => wc.Region == "WA");
            PrintCustomerInformation(WACust);

        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var products = DataLoader.LoadProducts();

            var anonProd = from p in products
                           select new 
                           { prodName = p.ProductName };
            foreach(var row in anonProd)
            {
                Console.WriteLine(row.prodName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var products = DataLoader.LoadProducts();

            var allProd = from p in products
                          select new
                          {
                              prodID = p.ProductID,
                              prodName = p.ProductName,
                              prodCat = p.Category,
                              prodPrice = Math.Round(p.UnitPrice * 1.25M,2),
                              prodOnHand = p.UnitsInStock
                          };
            foreach(var row in allProd)
            {
                Console.WriteLine(row.prodID + " " + row.prodName + " " + 
                    row.prodCat + " " + row.prodPrice+ " " + row.prodOnHand);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var products = DataLoader.LoadProducts();

            var nameAndCat = from p in products
                             select new
                             {
                                 prodName = p.ProductName.ToUpper(),
                                 prodCat = p.Category.ToUpper()

                             };
            foreach(var row in nameAndCat)
            {
                Console.WriteLine(row.prodName + " " + row.prodCat);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var products = DataLoader.LoadProducts();

            var allProd = from p in products
                          select

                          new
                          {
                              prodId = p.ProductID,
                              prodName = p.ProductName,
                              prodCat = p.Category,
                              prodPrice = p.UnitPrice,
                              prodStock = p.UnitsInStock,
                              reOrder = (p.UnitsInStock < 3) ? true : false
                          };
            foreach(var row in allProd)
            {
                Console.WriteLine("{0,-10},{1,-10},{2}",row.prodName, row.prodStock, row.reOrder);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var products = DataLoader.LoadProducts();

            var allProd = from p in products
                          select

                          new
                          {
                              prodId = p.ProductID,
                              prodName = p.ProductName,
                              prodCat = p.Category,
                              prodPrice = Math.Round(p.UnitPrice,2),
                              prodStock = p.UnitsInStock,
                              stockValue = Math.Round(p.UnitsInStock *p.UnitPrice,2)
                          };
            foreach(var row in allProd)
            {
                Console.WriteLine(row.prodId + " " + row.prodCat + " "
                    + row.prodPrice + " " + row.prodStock
                    + " " + row.stockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var numbersA = DataLoader.NumbersA;

            var evenA = from n in numbersA
                        where (n % 2 == 0)
                        select n;
            foreach(var row in evenA)
            {
                Console.WriteLine(row);
            }
                        
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500x   
        /// </summary>
        static void Exercise10()
        {
            var customers = DataLoader.LoadCustomers();

            var custOrd = from c in customers
                          where (c.Orders.Any(l => l.Total < 500))
                          select new
                          {
                              cName = c.CompanyName
                              
                              
                          };
            foreach(var row in custOrd)
            {
                Console.WriteLine(row.cName);
            }
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var numbersC = DataLoader.NumbersC;

            var oddC = from n in numbersC
                       where (n % 2 == 1)
                       select n;
            var first3Odd = oddC.Take(3);

            foreach(var row in first3Odd)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var numbersB = DataLoader.NumbersB;

            var allNumbersB = from n in numbersB
                                 select n;
            var SkipFirst3 = allNumbersB.Skip(3);

            foreach(var row in SkipFirst3)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var customers = DataLoader.LoadCustomers();
            
            var justWA = customers.Where(r => r.Region == "WA");

            var ordOnly = from c in justWA
                          //orderby c.Orders.Max(o => o.OrderDate)
                          select new
                          {
                              name = c.CompanyName,
                              ord = c.Orders.Max(o => o.OrderID)
                          };
            foreach(var row in ordOnly)
            {
                Console.WriteLine(row.name + " " + row.ord);
            }

            
            
            

            
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var numbersC = DataLoader.NumbersC;

            var doUntil6 = numbersC.TakeWhile(num => num < 6);

            foreach(var row in doUntil6)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var numbersC = DataLoader.NumbersC;

            var divBy3 = numbersC.SkipWhile(num => num % 3 != 0);
            var divBy3Skip1 = divBy3.Skip(1);
            
            foreach(var row in divBy3Skip1)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();

            var prodAlpha = products.OrderBy(p => p.ProductName);

            PrintProductInformation(prodAlpha);

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            var prodByStockDesc = products.OrderByDescending(p => p.UnitsInStock);

            PrintProductInformation(prodByStockDesc);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();

            var prodCat = products.OrderBy(p => (p.Category)).ThenByDescending(c =>(c.UnitPrice));

            PrintProductInformation(prodCat);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var numbersB = DataLoader.NumbersB;

            

            var reverseB = numbersB.Reverse();

            foreach(var row in reverseB)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();

            var groupCat = products.GroupBy(p => p.Category);

            
            foreach (var row in groupCat)
            {
                Console.WriteLine(row.Key);
                
                foreach(var prod in row)
                {
                    Console.WriteLine("   " + prod.ProductName);
                }
                
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {

            var customers = DataLoader.LoadCustomers();

            var orders = from c in customers
                         select new
                         {
                             name = c.CompanyName,
                             ordYr = from ord in c.Orders
                                     group ord by ord.OrderDate.Year into yr
                                     select new
                                     {
                                         year = yr.Key,
                                         ordMnth = from m in yr
                                                   group m by m.OrderDate.Month into mnth
                                                   select new
                                                   {
                                                       months = mnth.Key,
                                                       ordTot = mnth.Sum(a => a.Total)

                                                   }

                                     }
                         };
            foreach (var company in orders)
                {
                Console.WriteLine(company.name);
                foreach(var coYear in company.ordYr)
                {
                    Console.WriteLine("        " + coYear.year);
                    foreach(var ordMonth in coYear.ordMnth)
                    {
                        Console.WriteLine("         " + ordMonth.months + " -" + ordMonth.ordTot);
                    }

                }
                Console.WriteLine("________________________________");
                }
        }
        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var products = DataLoader.LoadProducts();

            var prodCat = from c in products
                          select c.Category;
            var prodCatDistinct = prodCat.Distinct();

            foreach(var row in prodCatDistinct)
            {
                Console.WriteLine(row);
            }    
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var products = DataLoader.LoadProducts();

            var prod789 = products.Any(p => (p.ProductID == 789));

            Console.WriteLine("Product 789 exists :{0}", prod789);
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var products = DataLoader.LoadProducts();

            var outOfStock = from p in products
                             where p.UnitsInStock == 0
                             select p.Category;
            var outOfStockDistinct = outOfStock.Distinct();
            Console.WriteLine("The categories with at least one product OOS are: ");
            foreach(var row in outOfStockDistinct)
            {
                Console.WriteLine(row);
            }    
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var products = DataLoader.LoadProducts();

            var inStock = from p in products
                             where p.UnitsInStock == 0
                             select p.Category;
            var inStockDistinct = (from p in products
                                  select p.Category).Except(inStock);
            Console.WriteLine("The categories which do not have any OOS are: ");
            foreach (var row in inStockDistinct)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var numbersA = DataLoader.NumbersA;

            var oddsOnly = from n in numbersA
                           where (n % 2 == 1)
                           select n;
            var oddsCount = oddsOnly.Count();
            Console.WriteLine(oddsCount);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = DataLoader.LoadCustomers();

            var ordByID = from c in customers
                          select new
                          {
                              cID = c.CustomerID,
                              ordCt = c.Orders.Count()
                          };
            foreach(var row in ordByID)
            {
                Console.WriteLine(row.cID + " " + row.ordCt);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var products = DataLoader.LoadProducts();

            var catProdCount = from p in products
                               group p by p.Category into cat
                               select new
                               {
                                   cat = cat.Key,
                                   prdCt = cat.Count()
                               };
            foreach(var row in catProdCount)
            {
                Console.WriteLine(row.cat + " " + row.prdCt);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var products = DataLoader.LoadProducts();

            var unitSumCat = from p in products
                             group p by p.Category into cat
                             select new
                             {
                                 cat = cat.Key,
                                 unitSum = cat.Sum(s => (s.UnitsInStock))
                             };
            foreach(var row in unitSumCat)
            {
                Console.WriteLine(row.cat + " " + row.unitSum);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var products = DataLoader.LoadProducts();

            decimal min = products.Min(p => p.UnitPrice);
            var lowestProd = from p in products

                                 //orderby p.UnitPrice
                             group p by p.Category into groups
                             
                             select groups.OrderBy(p => (p.UnitPrice)).First();
            
            



            foreach(var group in lowestProd)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine(group.Category +" " +group.ProductName +" "+ Math.Round(group.UnitPrice*1.0M,2));
                Console.WriteLine("*********************************");
                /*foreach(var prod in group)
                {
                    Console.WriteLine(prod.ProductName + " " + prod.UnitPrice);
                }*/

            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var products = DataLoader.LoadProducts();

            var avgPrice = from p in products
                           group p by p.Category into avgCat
                           select new
                           {
                               avgCat = avgCat.Key,
                               avgPrice = Math.Round(avgCat.Average(a => a.UnitPrice),2)
                           };
            var top3Price = avgPrice.OrderByDescending(a => a.avgPrice).Take(3);

            foreach (var row in top3Price)
            {
                Console.WriteLine(row.avgCat + " " + row.avgPrice);
            }
            /*
            foreach(var row in avgPrice)
            {
                Console.WriteLine(row.avgCat + " " + row.avgPrice);
            }
            */
        }
    }
}
