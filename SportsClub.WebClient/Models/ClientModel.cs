using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsClub.WebClient.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }

        public string ClientName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public long Cash { get; set; }
    }
}