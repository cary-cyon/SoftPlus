
using System.Collections.Generic;


namespace SoftPlus.Model
{
    internal class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Client> Clients { get; set; }
    }
}
