using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredBusinessModel.Domain
{
    public class Cart
    {
        private List<CartItem> beers;

        public Cart()
        {
            beers = new List<CartItem>();
        }

        public void addCartItem(CartItem item)
        {
            beers.Add(item);
        }

    }
}
