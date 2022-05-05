using steam.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace steam.Data.ViewModels
{
    public class ShoppingCartVm
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}