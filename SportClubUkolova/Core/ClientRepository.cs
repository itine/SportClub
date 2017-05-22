using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models;

namespace SportClubUkolova.Core
{
    public class ClientRepository : IClientRepository
    {
        private SportsClubEntities context = new SportsClubEntities();

        public List<Client> AllClients
        {
            get { return context.Client.ToList(); } 
        }

        public bool ClientRegistration(Client client)
        {
            if (context.Client.Find(client) != null)
                return false;
            context.Client.Add(client);
            context.SaveChanges();
            return true;
        }

        public bool EditClientInfo(Client client)
        {
            if (context.Client.Find(client) == null)
                return false;
            DeleteClient(client.ClientId);
            Client newClient = new Client()
            {
                Address = client.Address,
                ClientCash = client.ClientCash,
                ClientFIO = client.ClientFIO,
                ClientId = client.ClientId,
                PhoneNumber = client.PhoneNumber,
                Training = client.Training
            };
            context.Client.Add(newClient);
            context.SaveChanges();
            return true;
        }

        public bool DeleteClient(int? clientId)
        {
            if (clientId != null)
            {
                var client = context.Client.Where(x => x.ClientId == clientId).FirstOrDefault();
                if (client != null)
                {
                    context.Client.Remove(client);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Client GetClientById(int? clientId)
        {
            if (clientId != null)
            {
                return context.Client.Where(x => x.ClientId == clientId).FirstOrDefault();
            }
            return null;
        }

        public long CheckBalance(Client client)
        {
            return client.ClientCash;
        }
    }
}