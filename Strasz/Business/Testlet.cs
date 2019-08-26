using TDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD.Business {
    public class Testlet {
        private string _testletId { get; set; }
        private readonly List<Item> _items;

        public Testlet(string testLetId)
        {
            _testletId = testLetId;
            _items = new List<Item>();
        }

        /// <summary>
        /// Items private collection has 6 operational and 4 pretest items. This funciton randomizes the order of itmes per TDD.
        /// </summary>
        /// <param name="operationals"></param>
        /// <param name="presets"></param>
        /// <returns></returns>
        public List<Item> Randomize(int operationals = 0, int prestests = 0)
        {
            var orderedList = new List<Item>();
            // first two items are always pretest items
            for (int i = 0; i < prestests; i++)
            {
                if (i < 2)
                {
                    _items.Add(
                        new Item
                        {
                            ItemId = Guid.NewGuid(),
                            ItemType = ItemTypeEnum.Prestest
                        }
                    );
                }
                else
                {
                    orderedList.Add(
                        new Item
                        {
                            ItemId = Guid.NewGuid(),
                            ItemType = ItemTypeEnum.Prestest
                        }
                    );
                }
            }

            for (int i = 0; i < operationals; i++)
            {
                orderedList.Add(
                    new Item
                    {
                        ItemId = Guid.NewGuid(),
                        ItemType = ItemTypeEnum.Opertational
                    }
                );
            }

            var total = operationals + prestests;
            // add random list to items list
            _items.AddRange(ShuffleList(orderedList, 0, total));

            // return new list
            return _items;
        }

        public List<Item> ShuffleList(List<Item> testList, int minVal, int maxVal)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            var newRandList = testList.OrderBy(item => rand.Next(minVal, maxVal)).ToList();

            // random list
            return newRandList;
        }
    }
}
