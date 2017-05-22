using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models;
namespace SportClubUkolova.Core
{
    public interface IClientRepository
    {
        List<Client> AllClients { get; }

        bool ClientRegistration(Client client);
        bool EditClientInfo(Client client);
        bool DeleteClient(int? clientId);
        Client GetClientById(int? clientId);
        long CheckBalance(Client client);

    }
}