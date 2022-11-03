using System;
using System.Collections.Generic;

namespace PaymentsReconciliation.Model
{
    internal class Purchase
    {
        public string Cust { get; set; }
        public DateTime Date { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public List<string> Item { get; set; }

        public decimal Amount { get; set; } = 0;
        public Purchase()
        {
            Item = new List<string>();
        }
        public Purchase(string cust)
        {
            Cust = cust;
            Item = new List<string>();
        }

        public Purchase(string cust, DateTime date)
        {
            Cust = cust;
            Date = date;
            Item = new List<string>();
        }

        public Purchase(string cust, DateTime date, List<string> item)
        {
            Cust = cust;
            Date = date;
            Item = item;
        }
    }
}
