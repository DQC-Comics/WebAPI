namespace DQC.Comics.WebAPI.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class BookingsHub : Hub
    {
        public void BookingStatus(int bookingId, string status)
        {
            this.Clients.Others.bookingStatus(bookingId, status);
        }
    }
}
