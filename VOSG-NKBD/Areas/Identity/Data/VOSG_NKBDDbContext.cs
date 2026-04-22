namespace VOSG_NKBD.Data
{
    internal class VOSG_NKBDDbContext
    {
        public object Confirmation { get; internal set; }
        public object Database { get; internal set; }
        public object Locations { get; internal set; }
        public object Activites { get; internal set; }
        public object Place { get; internal set; }
        public object Payments { get; internal set; }
        public object Payment { get; internal set; }
        public object Bookings { get; internal set; }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}