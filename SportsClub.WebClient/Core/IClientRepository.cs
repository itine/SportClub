using SportsClub.WebClient.Models;
using System.Collections.Generic;

namespace SportsClub.WebClient.Core
{
    public interface IClientRepository
    {
        IEnumerable<ClientModel> GetAllClients();
        int ClientRegistration(ClientModel client);
        int EditClientInfo(ClientModel client);
        int DeleteClient(int clientId);
        ClientModel GetClientById(int clientId);
        long CheckBalance(ClientModel client);
    }
}