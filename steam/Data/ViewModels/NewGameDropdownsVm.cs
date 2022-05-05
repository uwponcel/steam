using steam.Models;
using System.Collections.Generic;

namespace steam.Data.ViewModels
{
    public class NewGameDropdownsVm
    {
        public NewGameDropdownsVm()
        {
            Developpers = new List<Developper>();
            Publishers = new List<Publisher>();
        }

        public List<Developper> Developpers { get; set; }
        public List<Publisher> Publishers { get; set; } 
    }
}
