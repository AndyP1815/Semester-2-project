using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace classes
{
   
    public class Poster : Product
    {
        private bool frame;
        private string size;
        private string posterDirection;
      
        // Retrieving 
        public Poster(string id, string productName, string description, decimal price, string url, string posterDirection)
            : base(id, productName, description, price, url)
        {
            frame = false;
            size = "S";
            this.posterDirection = posterDirection;
        }

        //Creating 
        public Poster(string productName, string description, decimal price, string url,List<Catogories> catogories ,string posterDirection) :
            base(productName, description, price, url,catogories)
        {
            this.posterDirection = posterDirection;
            frame = false;
            size = "S";
        }
        //new
        public Poster(Poster p, bool frame, string size):
            base(p.ID,p.ProductName,p.Description,p.Price,p.Url)
        {
            this.posterDirection = p.posterDirection;
            this.size = size;
            this.frame = frame; 
        }


        public override decimal CalculatePrice()
        {
            if (frame)
            {
                return base.CalculatePrice() + SizePrice() + 20;
            }
            else { return base.CalculatePrice() + SizePrice(); }

        }
        public decimal SizePrice()
        {
            if (size == "S")
            {
                return 0;
            }
            else if (size == "M")
            {
                return 10;
            }
            else if (size == "L")
            {
                return 20;
            }
            return 0;
        }
        public void ChangeSize(string s)
        {
            if(s == null)
            {
                this.size = "S";
            }
            else
            {
                if (s.ToUpper() == "S" ^ s.ToUpper() == "M" ^ s.ToUpper() == "L")
                {
                    this.size = s;
                }
                else
                {

                }
            }
           
            
        }
        public void ChangeFrame(bool b)
        {
            if (b)
            {
                frame = true;
            }
            else
            {
                frame = false;
            }
        }

        public override string ExtraProductInfo()
        {
            string Frame = frame ? "Yes" : "No";

			return $"Size: {size}\n " +
                $"With Frame {Frame} ";
        }

        public override string GetOption()
        {
            return "Frame";
        }

        public override string Getsize()
        {
            return size;
        }

        public override int GetBool()
        {
            return frame ? 1 : 0;
        }

        public string Size { get { return size; } }
        public bool Frame { get { return frame; } }
        public string PosterDirection { get { return posterDirection; } }

    }
}
