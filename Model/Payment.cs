namespace PaymentsReconciliation.Models
{
    internal class Payment
    {
        public string Customer { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public float Amount { get; set; }

    }
}
