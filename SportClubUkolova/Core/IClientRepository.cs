using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models;
using SportClubUkolova.Models;

namespace SportClubUkolova.Core
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