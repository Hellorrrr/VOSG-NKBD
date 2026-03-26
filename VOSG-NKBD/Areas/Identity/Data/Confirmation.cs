namespace VOSG_NKBD.Data
{
    internal class Confirmation
    {
        public object VOSG_NKBDId { get; set; }
        public object PlaceID { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public object TotalPrice { get; set; }
    }
}