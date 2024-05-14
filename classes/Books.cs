using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace classes
{
    public class Books : Product
    {
        private bool ebook;
        private int pages;
        //Retrieving
        public Books(string id, string productName, string description, decimal price, string url, int pages, bool Has_Option)
    : base(id, productName, description, price, url)
        {
            ebook =Has_Option;
            this.pages = pages;
        }
        //creating
        public Books(string productName, string description, decimal price, string url, List<Catogories> catogories, int pages,bool Has_Option) :
            base(productName, description, price, url, catogories)
        {
            this.ebook = Has_Option;
            this.pages = pages;
        }
      
        public override string SeeInfo()
        {
            return base.SeeInfo() + $"Number of pages = {pages.ToString()}";
        }

        public void ChangeEbook(bool b)
        {
            if (b)
            {
                ebook = true;
            }
            else
            {
                ebook = false;
            }
        }

        public override string ExtraProductInfo()
        {
            return $"Amount of pages: {this.pages.ToString()}";
        }

      

        public bool Ebook { get { return ebook; } }
        public int Pages { get { return pages; } }
    }
}
