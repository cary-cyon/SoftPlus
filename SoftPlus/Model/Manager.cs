
using System.Collections.Generic;


namespace SoftPlus.Model
{
    internal class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Client> Clients { get; set; }
        public Manager()
        {
            Name = "Олег";
        }
        public override string ToString()
        {
            return Name;
        }
    }

}
