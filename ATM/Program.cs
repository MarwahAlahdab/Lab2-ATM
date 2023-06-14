using System;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Transactions;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{


    public static decimal Balance = 0; //


    private static void Main(string[] args)
    {
        try
        {
            UserInterface();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Something went wrong!, Please try again .. " + ex.Message +" \n");

        }
        finally
        {
            UserInterface();
        }
    }





    public static void UserInterface()
    {
        string transaction;

        do
        {
            Console.WriteLine("Choose a transaction by number: \n" +
                "1. View Balance \n" +
                "2. Withdraw \n" +
                "3. Deposit \n" +
                "4. Exit  \n");

            transaction = Console.ReadLine();

            switch (transaction)
            {
                case "1":
                    Console.WriteLine("Your balance now is: " + ViewBalance());
                    break;
                case "2":
                    Console.WriteLine("Enter the amount to Withdraw:");
                    decimal withdraw_amount = Convert.ToDecimal(Console.ReadLine());
                    Withdraw(withdraw_amount);
                    break;
                case "3":
                    Console.WriteLine("Enter the amount to Deposit:");
                    decimal deposit_amount = Convert.ToDecimal(Console.ReadLine());
                    Deposit(deposit_amount);
                    break;
                case "4":
                    Console.WriteLine("Exiting the application...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid transaction.");
                    break;
            }

            Console.WriteLine();
        } while (transaction != "4");


    }






   


    public static decimal ViewBalance()
    {
        return Balance;
    }

    public static decimal Withdraw(decimal number)
    {
        if(Balance == 0) {
            throw new Exception("Your balance is Zero ! so you can't withdraw");
           
        }
           

        if (number >= Balance)
            throw new Exception("You don't have this amount!");
    
        else if (number <= 0)
            throw new Exception("Try a valid value!");

        return Balance -= number;
    }






    public static decimal Deposit(decimal number)
    {
        if(number < 0)
            throw new Exception("Try a valid value!");
        

        return Balance += number; ;
    }














}