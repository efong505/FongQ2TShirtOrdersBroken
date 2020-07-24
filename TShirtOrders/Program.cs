// Edward Fong
// efong@cnm.edu
// Program.cs
// Quiz 2
// All corrections are under TODO: Comments with intitials EF
using System;
using System.Collections.Generic;

//TODO:  Good work!  You got them all!  100/100

namespace TShirtOrders
{
    class Program
    {
        private const string COMPANYNAME = "Super Shirt Ordermatic 3000";
        private const string COMPANYSLOGAN = "The best shirt ordering system in the multiverse!";

        static void Main(string[] args)
        {
            Header();
            char option;
            List<TShirtOrder> orders = new List<TShirtOrder>();
            do
            {
                DisplayShirtOrders(orders);
                option = GetStringFromUser("(A)dd shirt (R)emove shirt (T)otal (E)xit: ").Trim().ToUpper()[0];
                switch(option)
                {
                    case 'A':
                        AddShirtOrder(orders);
                        break;
                    case 'R':
                        RemoveShirtOrder(orders);
                        break;
                    case 'T':
                        DisplayTotal(orders);
                        break;

                }                
            } while (option!='E');
            Console.WriteLine("Thank you for using "+ COMPANYNAME);
        }
        private static void DisplayTotal(List<TShirtOrder> orders)
        {
            decimal total = 0;
            foreach (var order in orders) // TODO: EF changed string type for order to var
            {
                total += order.Price;
            }
            Console.WriteLine("Total price of order is: " + total);
        }

        private static void RemoveShirtOrder(List<TShirtOrder> orders)
        {
            int index = GetIntFromUser("Enter index of shirt order to remove: ");
            if (GetBoolFromUser("Are you sure you want to delete this order"))
            {
                index -= 1; // TODO: EF zero indexed. Have to subtract 1 to remove correct item
                orders.Remove(orders[index]);//TODO: EF Added order with referenced index of TShirt Order in List.
            }
        }
        private static void AddShirtOrder(List<TShirtOrder> orders)
        {
            TShirtOrder order = new TShirtOrder();
            order.FirstName = GetStringFromUser("Please enter your first name: ");
            order.LastName = GetStringFromUser("Please enter your last name: ");
            order.IsLocalPickup = GetBoolFromUser("Local pickup");
            if (!order.IsLocalPickup)
            {
                order.Address = GetStringFromUser("Address: ");
            }
            order.OrderDate = DateTime.Now;
            order.PrintAreaInSqIn = GetDoubleFromUser("Please enter are of your design in square inches: ");
            order.NumColors = GetIntFromUser("Please enter number of colors: ");
            order.NumShirts = GetIntFromUser("Please enter the number of shirts: ");
            Console.WriteLine(order.ToString());
            orders.Add(order);
        }
        private static void DisplayShirtOrders(List<TShirtOrder> orders)
        {
            Console.WriteLine();
            Console.WriteLine("Current shirts orders:");
            if (orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; ++i) //TODO: EF removed closing parenthesis () because Count is not a method
                {
                    Console.WriteLine((i + 1) + ": " + orders[i]);
                }
            }
            else
            {
                Console.WriteLine("No shirts in order.");
            }
            Console.WriteLine();
        }
        private static void Header()
        {
            Console.WriteLine("Welcome to "+ COMPANYNAME+"!");
            Console.WriteLine(COMPANYSLOGAN);
            Console.WriteLine();
        }
        private static bool GetBoolFromUser(string prompt)
        {
            Console.Write(prompt + " (y/n)? ");
            return Console.ReadLine().ToLower()[0] == 'y';
        }
        private static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }
        private static double GetDoubleFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private static string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
