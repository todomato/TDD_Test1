using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Test
{
    public class Caculator<TSource>
    {
        private List<TSource> Source { get; set; }

        public Caculator(List<TSource> source)
        {
            this.Source = source;
        }

        public List<int> GetSumListByGroupingItems(int groupingNumber, Func<TSource, int> selector)
        {
            //分類群組
            var container = Grouping(groupingNumber);

            //群組相加
            var result = GetSum(container, selector);

            return result;
        }

        private static List<int> GetSum( List<List<TSource>> container, Func<TSource, int> selector)
        {
            var result = new List<int>();
            foreach (var item in container)
            {
                int sum = item.Sum(selector);
                result.Add(sum);
            }
            return result;
        }

        private List<List<TSource>> Grouping(int groupingNumber)
        {
            var container = new List<List<TSource>>();
            List<TSource> temp = null;
            for (int i = 0; i < this.Source.Count; i++)
            {
                if (i % groupingNumber == 0)
                {
                    temp = new List<TSource>();
                    temp.Add(this.Source[i]);
                    container.Add(temp);
                }
                else
                {
                    temp.Add(this.Source[i]);
                }
            }
            return container;
        }
    }
}
