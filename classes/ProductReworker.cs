using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes
{
    public class ProductReworker
    {
        public Product ChangeBool(Product product, bool myboolean)
        {
            try
            {
                if (product is Poster)
                {
                    ((Poster)(product)).ChangeFrame(myboolean);
                    return product;
                }
                if (product is Figures)
                {
                    ((Figures)(product)).ChangeCollored(myboolean);
                    return product;
                }
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public Product ChangeSize(Product product, string size)
        {
            try
            {
                if (product is Poster && size != string.Empty)
                {

                    ((Poster)product).ChangeSize(size);
                    return product;
                }
                if (product is Clothing && size != string.Empty)
                {
                    ((Clothing)product).ChangeClothingSize(size);
                    return product;

                }
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }
        public Product MakeProduct(Product product,bool Bool,string size)
        {
            try
            {
                Product returnProduct;
                if (product is Poster)
                {
                    returnProduct = new Poster((Poster)product, Bool, size);
                    return returnProduct;
                }
                if (product is Books)
                {
                    return product;
                }
                if (product is Figures)
                {
                    returnProduct = new Figures((Figures)product, Bool);
                    return returnProduct;
                }
                if (product is Clothing)
                {
                    returnProduct = new Clothing((Clothing)product, size);
                    return returnProduct;
                }
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }

    }
}
