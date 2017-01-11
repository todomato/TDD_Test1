using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExpectedObjects;

namespace TDD_Test.Tests
{
    [TestClass()]
    public class CaculatorTests
    {
        private List<Cargo> _cargos;
        
        [TestInitialize]
        public void TestInitialize()
        {
            // init
            _cargos = new List<Cargo>()
            {
                new Cargo(){ Id = 1, Cost =1, Revenue= 11, SellPrice = 21},
                new Cargo(){ Id = 2, Cost =2, Revenue= 12, SellPrice = 22},
                new Cargo(){ Id = 3, Cost =3, Revenue= 13, SellPrice = 23},
                new Cargo(){ Id = 4, Cost =4, Revenue= 14, SellPrice = 24},
                new Cargo(){ Id = 5, Cost =5, Revenue= 15, SellPrice = 25},
                new Cargo(){ Id = 6, Cost =6, Revenue= 16, SellPrice = 26},
                new Cargo(){ Id = 7, Cost =7, Revenue= 17, SellPrice = 27},
                new Cargo(){ Id = 8, Cost =8, Revenue= 18, SellPrice = 28},
                new Cargo(){ Id = 9, Cost =9, Revenue= 19, SellPrice = 29},
                new Cargo(){ Id = 10, Cost = 10, Revenue= 20, SellPrice = 30},
                new Cargo(){ Id = 11, Cost = 11, Revenue= 21, SellPrice = 31},
            };
        }

        [TestMethod()]
        public void 每三筆一組_取Cost總和()
        {
            //arrange
            var target = new Caculator<Cargo>(_cargos);
            var expected = new List<int>() { 6, 15, 24, 21 };

            //act
            List<int> actual = target.GetSumListByGroupingItems(3, c => c.Cost);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void 每四筆一組_取Revenue總和()
        {
            //arrange
            var target = new Caculator<Cargo>(_cargos);
            var expected = new List<int>() { 50, 66, 60 };

            //act
            List<int> actual = target.GetSumListByGroupingItems(4, c => c.Revenue);

            //assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}
