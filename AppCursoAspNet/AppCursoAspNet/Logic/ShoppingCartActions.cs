using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace Vista.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

/*
        public void AddToCart(int id)
        {
        
            ShoppingCartId = GetCartId();

            var cartItem = Datos.GetContext().ShoppingCartItems.SingleOrDefault(c => c.CartId == ShoppingCartId && c.Products_ProductID == id);
            if (cartItem == null)
            {             
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    Products_ProductID = id,
                    CartId = ShoppingCartId,
                    Product = Datos.GetContext().Products.SingleOrDefault(p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                Datos.GetContext().ShoppingCartItems.Add(cartItem);
            }
            else
            {               
                cartItem.Quantity++;
            }
            Datos.GetContext().SaveChanges();
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in Datos.GetContext().ShoppingCartItems
                               where cartItems.CartId == ShoppingCartId
                               select (int?)cartItems.Quantity *
                               cartItems.Product.UnitPrice).Sum();
            return total ?? decimal.Zero;
        }

        public ShoppingCartActions GetCart(HttpContext context)
        {
            using (var cart = new ShoppingCartActions())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return Datos.GetContext().ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {

                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<CartItem> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Product.ProductID == CartItemUpdates[i].ProductId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.Products_ProductID);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.Products_ProductID, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: " + exp.Message.ToString(), exp);
                }
            
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {

                try
                {
                    var myItem = (from c in Datos.GetContext().ShoppingCartItems where c.CartId == removeCartID && c.Product.ProductID == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        Datos.GetContext().ShoppingCartItems.Remove(myItem);
                        Datos.GetContext().SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR:" + exp.Message.ToString(), exp);
                }
            
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {

                try
                {
                    var myItem = (from c in Datos.GetContext().ShoppingCartItems where c.CartId == updateCartID && c.Product.ProductID == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantity = quantity;
                        Datos.GetContext().SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: " + exp.Message.ToString(), exp);
                }
           
        }
        */
        public void Dispose(){ }

    }
}
