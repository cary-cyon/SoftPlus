using System.Collections.Generic;



namespace SoftPlus.Model
{
    internal class ClientStatus 
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public  List<Client> Clients { get; set; }

    }
}
