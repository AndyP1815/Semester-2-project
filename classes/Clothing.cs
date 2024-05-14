using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes
{
    public class Clothing : Product
    {
        private string clothsize;
        public Clothing(string id, string productName, string description, decimal price,  string url)
          : base(id, productName, description, price, url)
        {
            this.clothsize = "S";
        }
        public Clothing(string productName, string description, decimal price, string url,List<Catogories> catogories)
        : base( productName, description,price,url,catogories)
        {
            this.clothsize = "S";
        }
        public Clothing(Clothing p,string size) :
           base(p.ID, p.ProductName, p.Description, p.Price, p.Url)
        {
            this.clothsize = size;
        }
        public override string SeeInfo()
        {
            return base.SeeInfo() + $"Size: {this.clothsize} ";
        }

        public override decimal CalculatePrice()
        {
            if (this.clothsize == "S")
            {
                return base.CalculatePrice();
            }
            else if (this.clothsize == "M")
            {
                return base.CalculatePrice() + 7;
            }
            else if (this.clothsize == "L")
            {
                return base.CalculatePrice() + 10;
            }
            return base.CalculatePrice();
        }

        public override string ExtraProductInfo()
        {
            return $"Size : {clothsize}";
        }
        public void ChangeClothingSize(string s)
        {
            if (s == null)
            {
                this.clothsize = "S";
            }
            else
            {
                if (s.ToUpper() == "S" ^ s.ToUpper() == "M" ^ s.ToUpper() == "L")
                {
                    this.clothsize = s;
                }
                else
                {

                }
            }
         
        }

        public override string Getsize()
        {
            return clothsize;
        }
 
       public string Clothsize { get { return clothsize; } }
    }
}
