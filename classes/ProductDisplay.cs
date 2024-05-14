using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class ProductDisplay
    {
        public ProductDisplay()
        {

        }
     
        public List<List<Product>> ProductDTOs(List<Product> products, List<int> numberList)
        {
            if (products.Count == 0 || numberList.Count == 0 || products.Count < numberList.Count)
            {
                throw new IndexOutOfRangeException();
            }
            try
            {
                return numberList
        .Select((n, i) => new { Index = i, Product = products[n] })
        .GroupBy(p => p.Index % 3)
        .Select(g => g.Select(p => new Product((p.Product))).ToList())
        .ToList();
            }
            catch (Exception ex) { throw new Exception(); }
        }

        public List<int> GetNumber(int MaxNumber)
        {

            if(MaxNumber <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            try
            {
                List<int> ReturnNumber = new List<int>();
                Random random = new Random();
                List<int> numberslist = Enumerable.Range(0, MaxNumber).OrderBy(n => random.Next()).ToList();
                int i = 0;

                if (MaxNumber < 24)
                {
                    while (ReturnNumber.Count < MaxNumber)
                    {
                        ReturnNumber.Add(numberslist[i]);
                        i++;
                    }
                }
                else
                {


                    while (ReturnNumber.Count < 24)
                    {
                        ReturnNumber.Add(numberslist[i]);
                        i++;
                    }
                }
                return ReturnNumber;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
