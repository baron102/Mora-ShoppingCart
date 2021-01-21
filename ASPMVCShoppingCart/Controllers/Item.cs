using ASPMVCShoppingCart.Models;

namespace ASPMVCShoppingCart.Controllers
{
    public class Item
    {

        private tblProduct product = new tblProduct(); // Instantiate tblProduct class object 

        #region Properties
        public tblProduct Product
        {
            get { return product; }
            set { product = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors
        // Default constructor
        public Item()
        {

        }

        // Parameterised constructor
        public Item(tblProduct product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
        #endregion

    }
}