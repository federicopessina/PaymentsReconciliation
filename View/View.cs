using System;

namespace PaymentsReconciliation.View
{
    public static class View
    {
        /// <summary>
        /// Display a Welcome message on the Console Application.
        /// </summary>
        public static void PrintWelcomeMessage()
        {
            const string welcomeMessage = "Welcome to PaymentsReconciliation App";
            System.Console.WriteLine(welcomeMessage);
        }

        /// <summary>
        /// Pause the automatic closing of the Console Application.
        /// </summary>
        public static void PrintWait()
        {
            Console.ReadLine();
        }
    }
}
