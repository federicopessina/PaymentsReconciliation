using System;

namespace PaymentsReconciliation.Models
{
    [Serializable]
    internal class Payment
    {
        public string Customer { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }

    }
}
