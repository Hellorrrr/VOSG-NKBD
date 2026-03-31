namespace VOSG_NKBD.Data
{
    internal class Payment
    {
        public object PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public object VOSG_NKBDId { get; internal set; }
    }
}