using StraszTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StraszTest.Business {
    public class Testlet {
        private string _testletId { get; set; }
        private List<Item> _items;

        public Testlet(string testLetId, List<Item> items)
        {
            _testletId = testLetId;
            _items = items;
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
            var rand = new Random((int)DateTime.Now.Ticks);
            var newRandList = orderedList.OrderBy(item => rand.Next(2, total)).ToList();

            // add random list to items list
            _items.AddRange(newRandList);

            // return new list
            return _items;
        }
    }
}
