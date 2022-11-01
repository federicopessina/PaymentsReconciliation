using System;

namespace PaymentsReconciliation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();

            PrintWait();
        }

        private static void PrintWait()
        {
            Console.ReadLine();
        }

        private static void PrintWelcomeMessage()
        {
            string welcomeMessage = "Welcome to PaymentsReconciliation App";
            System.Console.WriteLine(welcomeMessage);
        }
    }
}
