using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models;
using SportClubUkolova.Models;

namespace SportClubUkolova.Core
{
    public class ClientRepository : IClientRepository
    {
        private SportsClubEntities1 edm = new SportsClubEntities1();

        public IEnumerable<ClientModel> GetAllClients() => (from client in edm.Clients
                                                            select new ClientModel
                                                            {
                                                                ClientId = client.ClientId,
                                                                ClientName = client.ClientFIO,
                                                                Address = client.Address,
                                                                Cash = client.ClientCash,
                                                                PhoneNumber = client.PhoneNumber
                                                            }).ToList();

        public int ClientRegistration(ClientModel client)
        {
            var clientEntity = new Client()
            {
                ClientFIO = client.ClientName,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                ClientCash = client.Cash
            };
            edm.Clients.Add(clientEntity);
            return clientEntity.ClientId;
        }


        public int EditClientInfo(ClientModel client)
        {
            var clientEntity = edm.Clients.FirstOrDefault(x => x.ClientId == client.ClientId);
            clientEntity.ClientFIO = client.ClientName;
            clientEntity.ClientCash = client.Cash;
            clientEntity.PhoneNumber = client.PhoneNumber;
            edm.Clients.Add(clientEntity);
            edm.SaveChanges();
            return clientEntity.ClientId;
        }

        public int DeleteClient(int clientId)
        {
            var clientEntity = edm.Clients.Where(x => x.ClientId == clientId).FirstOrDefault();
            edm.Clients.Remove(clientEntity);
            return clientEntity.ClientId;
        }

        public ClientModel GetClientById(int clientId) => (from client in edm.Clients
                                                           where client.ClientId == clientId
                                                           select new ClientModel
                                                           {
                                                               ClientId = client.ClientId,
                                                               ClientName = client.ClientFIO,
                                                               Address = client.Address,
                                                               Cash = client.ClientCash,
                                                               PhoneNumber = client.PhoneNumber
                                                           }).FirstOrDefault();



        public long CheckBalance(ClientModel client) => edm.Clients.FirstOrDefault(x => x.ClientId == client.ClientId).ClientCash;
       
    }
}