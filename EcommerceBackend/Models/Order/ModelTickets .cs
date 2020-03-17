using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestSharp.models.Order
{
    public class ModelTickets
    {
        public int theaterId { get; set; }
        public string ticketCode { get; set; }
        public string seatCode { get; set; }
        public string theaterName { get; set; }
        public string seatName { get; set; }
        public string quantity { get; set; }
        public string seatType { get; set; }
        public string movieName { get; set; }
        public string sessionDateTime { get; set; }
        public string sessionDateTimeString { get; set; }
        public string roomNumber { get; set; }
        public string status { get; set; }
        public string integrationCode { get; set; }
        public int unitPrice { get; set; }
        public string theaterAddress { get; set; }
        public string localizationType { get; set; }
        public string rating { get; set; }



    }
}
