using NUnit.Framework;
using TDD.Business;
using TDD.Models;
using System;
using System.Collections.Generic;

namespace TDD {

    [TestFixture]
    public class TestletTest {
        private List<Item> _ItemsListFixed { get; set; }
        private List<Item> _ItemsListRand { get; set; }
        private Testlet _Testlet { get; set; }

        [SetUp]
        public void Setup()
        {
            _Testlet = new Testlet("Test Testlet");

            _ItemsListFixed = new List<Item>
            {
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Pretest
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Pretest
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Pretest
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Pretest
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Opertational
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Opertational
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Opertational
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Opertational
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Opertational
                },
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemType = ItemTypeEnum.Opertational
                }
            };
        }

        [Test]
        public void RandomizeTest()
        {
            var randTestsActual = _Testlet.Randomize(6, 4);

            CollectionAssert.AreNotEqual(_ItemsListFixed, randTestsActual);
        }

        [Test]
        public void FirstTwoPresetsTest()
        {
            var randList = _Testlet.Randomize(6, 4);

            if (randList.Count > 0)
            {
                Assert.IsTrue(randList[0].ItemType == ItemTypeEnum.Pretest && randList[1].ItemType == ItemTypeEnum.Pretest);
            }
            else
            {
                Assert.Fail();
            }
        }


        [Test]
        public void ShuffleListTest()
        {
            var shuffleList = _Testlet.ShuffleList(_ItemsListFixed, 0, 10);

            if (shuffleList.Count == 10)
            {
                CollectionAssert.AreNotEqual(_ItemsListFixed, shuffleList);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}