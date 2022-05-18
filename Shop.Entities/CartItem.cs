namespace Shop.Entities
{
    public class CartItem
    {
        public CartItem(string sku,int quantity)
        {
            SKU = sku;
            Quantity = quantity;
        }
        public string SKU { get;private set; }
        public int Quantity { get; set; }
    }
}