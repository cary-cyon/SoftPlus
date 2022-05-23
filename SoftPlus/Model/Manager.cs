
using SoftPlus.Command;
using SoftPlus.Data;
using System.Collections.Generic;


namespace SoftPlus.Model
{
    internal class Manager
    {
        private RelayCommand addCommand;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Client> Clients { get; set; }
        public RelayCommand AddComand
        {
            get { return addCommand ?? (addCommand = new RelayCommand(obj => DataManager.AddData<Manager>(obj))); }
        }
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
