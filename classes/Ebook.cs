using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public  class Ebook: Books
    {
        private string downloadLink;


        public Ebook(Books b,string downloadLink,decimal price) 
            : base(b.ID,b.ProductName,b.Description,price,b.Url,b.Pages,b.Ebook)
        {
            this.downloadLink = downloadLink;
        }
        public Ebook(Books b, string downloadLink)
           : base(b.ID, b.ProductName, b.Description, b.Price, b.Url, b.Pages, b.Ebook)
        {
            this.downloadLink = downloadLink;
        }
        public Ebook(string id,string name,string descritpion,decimal price,string url,int pages,bool ebook,string link) : base(id, name, descritpion, price, url, pages, ebook)
        {
            this.downloadLink = link;
        }

        public string DownloadLink { get { return downloadLink; } }
    }
}
