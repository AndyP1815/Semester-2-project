using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace classes
{
    public class Figures : Product
    {
        private string dimensions;
        private bool colored;

        //Retrieve
        public Figures(string id, string productName, string description, decimal price, string url, string dimensions)
           : base(id, productName, description, price, url)
        {
            this.dimensions = dimensions;
            this.colored = false;

        }

        //Create
        public Figures(string productName, string description, decimal price, string url, List<Catogories> catogories, string dimensions) :
            base(productName, description, price, url, catogories)
        {
            this.dimensions = dimensions;
        }
        public Figures(Figures p, bool collored) :
           base(p.ID, p.ProductName, p.Description, p.Price, p.Url)
        {
            this.dimensions=p.dimensions;
            this.colored = collored;
        }
        public override decimal CalculatePrice()
        {
            if (colored)
            {
               return base.CalculatePrice() + 20;
            }
            return base.CalculatePrice();
        }

        public override string SeeInfo()
        {
            string Colored = colored ? "Yes" : "No";
            return base.SeeInfo() +$"Dimension = {this.dimensions} Collored = {Colored}" ;
        }
        public void ChangeCollored(bool b)
        {
            if (b)
            {
                colored = true;
            }
            else
            {
                colored = false;
            }
        }

        public override string ExtraProductInfo()
        {
			string Colored = colored ? "Yes" : "No";
			return  $"Dimension = {this.dimensions} Collored = {Colored}";
		}

        public override string GetOption()
        {
            return "Collored";
        }


        public override int GetBool()
        {
            return colored ? 1 : 0;
        }

        public string Dimensions {get { return dimensions;} }
        public bool Colored { get { return colored;} }  
    }
}
