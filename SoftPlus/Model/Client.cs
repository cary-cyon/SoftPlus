using System.Collections.Generic;

namespace SoftPlus.Model
{
    internal class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public int StatusId { get; set; }
        public ClientStatus Status { get; set; }
        public List<ClientProduct> ClientProducts { get; set; }
        public Client()
        {
            Name = "Новый Клиент";
            ManagerId = 2;
            StatusId = 2;
            Status = new ClientStatus();
            
        }

    }

}
