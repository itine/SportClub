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
        //bool ClientRegistration(Client client);
        //bool EditClientInfo(Client client);
        //bool DeleteClient(int? clientId);
        //Client GetClientById(int? clientId);
        //long CheckBalance(Client client);

    }
}