using CareConnect.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareConnect.Core.Models
{
    public class ClientWrapper
    {
        public Client ClientDetail { get; set; } = new Client();
        public EntityAddress Address { get; set; } = new EntityAddress();
    }
}
