using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;
using classes.classes;
using classes.Interfaces;


namespace classes.Managers
{
    public class CartManager
    {
        private ICartRepository cartRepository; 
        private IProductRepo productRepo;
        private ProductReworker productReworker = new ProductReworker();
        public CartManager(ICartRepository cartRepository,IProductRepo productRepo) 
        {
            this.cartRepository = cartRepository;
            this.productRepo = productRepo;
        }
        public void CreateCart(int id)
        {
            try
            {
                cartRepository.CreateCart(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void UpdateCart(int id, int quantity)
        {
            try {
                cartRepository.UpdateCart(id, quantity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
       

        public Cart GetCartByUserId(int user_id)
        {
            try
            {
                var products = new List<Product>();
                var ids = cartRepository.GetProductIdsInCart(user_id);
                foreach (string id in ids)
                {
                    products.Add(productRepo.GetProductByInt(id));
                }

                var Cart_Items = cartRepository.GetProductsInCart(products, user_id);


                var Cart_Return_Items = new List<Cart_Item>();
                foreach (var item in Cart_Items)
                {
                    Product ReturnProduct = productReworker.MakeProduct(item.Product, cartRepository.GetProductBool(item.Id), cartRepository.GetProductSize(item.Id));


                    Cart_Return_Items.Add(new Cart_Item(ReturnProduct, item.Quantity, item.Id));
                }
                return new Cart(cartRepository.GetCartIdByUserId(user_id), Cart_Return_Items);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void DeleteCart(int id)
        {
            try
            {
                cartRepository.DeleteCart(id);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        
        public void AddProductToCart(Cart_Item product,int User_id)
        {
            try
            {
                cartRepository.AddProductToCart(product, User_id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        
        public void RemoveProductToCart(int cart_Item_id)
        {
            try
            {
                cartRepository.RemoveProductFromCart(cart_Item_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void ProductIsRemoved(string product_id)
        {
            try
            {
                cartRepository.ProductIsRemoved(product_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public void AddOrUpdateProductToCart(User user, Product product, bool isBool, string size, ProductReworker productReworker)
        {
            try
            {
                if(size == null)
                {
                    size = "No size";
                }
                Cart_Item existingCartItem = user.Cart.CartProducts.FirstOrDefault(item =>
                    Convert.ToBoolean(item.Product.GetBool()) == isBool && item.Product.Getsize() == size && item.Product.ID == product.ID);

                if (existingCartItem != null)
                {

                    existingCartItem.QuantityUp(1);
                    UpdateCart(existingCartItem.Id,existingCartItem.Quantity);
                }
                else
                {

                    Product returnProduct = productReworker.MakeProduct(product, isBool, size);
                    Cart_Item cartItem = new Cart_Item(returnProduct, 1);
                    AddProductToCart(cartItem, user.ID);
                    user.AddProductToCart(cartItem);
                }
            }catch (NullReferenceException ex)
            {
                throw new NullReferenceException( "A error occurd when adding or updating the cart:" + ex.Message + ex.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception("A error occurd when adding or updating the cart:"+ ex.Message + ex.StackTrace);
            }
            
        }

    }
}
