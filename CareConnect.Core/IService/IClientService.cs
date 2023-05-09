using CareConnect.Core.Models;
using CareConnect.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareConnect.Core.IService
{
    public interface IClientService
    {
        Task<List<Client>> GetClients();
        Task<bool> CreateorUpdateClient(ClientWrapper objClient);
        Task<ClientWrapper> GetClientById(long ClientId);
    }
}
