using CareConnect.Core.IService;
using CareConnect.Core.Models;
using CareConnect.Core.Service;

namespace CareConnectApp.Data
{
    public class ClientManager
    {
        private readonly IClientService _clientService;
        public ClientManager(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<bool> saveClient (ClientWrapper client)
        {
            return await _clientService.CreateorUpdateClient(client);

        }
        public async Task<ClientWrapper> GetClientById(int Id)
        {
            return await _clientService.GetClientById(Id);

        }
    }
}
