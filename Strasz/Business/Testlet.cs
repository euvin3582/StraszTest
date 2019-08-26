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
        public List<Item> Randomize(int operationals = 0, int pretests = 0)
        {
            var totalList = new List<Item>();
            var pretestList = new List<Item>();

            // first two items are always pretest items
            for (int i = 0; i < pretests; i++)
            {
                pretestList.Add(
                    new Item {
                        ItemId = Guid.NewGuid(),
                        ItemType = ItemTypeEnum.Pretest
                    }
                );
            }

            // shuffle the list of pretest before inserting into final return list
            pretestList = ShuffleList(pretestList, 0, pretests);

            // get the first element and pop from the list
            for (int i = 0; i < 2; i++) {
                _items.Add(pretestList.ElementAt(0));
                pretestList.RemoveAt(0);
            }

            for (int i = 0; i < operationals; i++)
            {
                totalList.Add(
                    new Item
                    {
                        ItemId = Guid.NewGuid(),
                        ItemType = ItemTypeEnum.Opertational
                    }
                );
            }

            // include pretest list to total list
            totalList.AddRange(pretestList);

            var total = operationals + pretests;
            // add random list to items list
            _items.AddRange(ShuffleList(totalList, 0, totalList.Count));

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
