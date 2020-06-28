using UnityEngine;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Merle.Mioneer
{
    public class Block
    {
        private static Block[] registry;

        private int id;
        private string name;

        private int blockHP;
        private int blockDurability;

        private DropItemProperties[] dropItems;

        private Sprite graphics;

        public static void Register(string csvText)
        {
            using (var stringReader = new StringReader(csvText))
            {
                using (var csvReader = new CsvReader(stringReader, CultureInfo.InvariantCulture))
                {
                    List<Block> blockList = new List<Block>();
                    IEnumerable<Serialized> serializedData = csvReader.GetRecords<Serialized>();

                    foreach (Serialized data in serializedData)
                    {
                        Block block = new Block();

                        block.id = data.id;
                        block.name = data.name;
                        block.graphics = Resources.Load<Sprite>(data.spritePath);

                        blockList.Add(block);
                    }

                    registry = blockList.ToArray();
                }
            }
        }

        public static Block GetBlockByKey(string key)
        {
            return Array.Find<Block>(registry, (block) => block.name == key);
        }

        public struct Serialized
        {
            [Name("BlockID")]
            public int id;

            [Name("BlockName")]
            public string name;
            [Name("SpritePath")]
            public string spritePath;

            [Name("BlockHp")]
            public int hp;
            [Name("BlockDurability")]
            public int durability;

            [Name("DropItem1")]
            public int dropItemID;
            [Name("DropItem1_Probability")]
            public int dropItemProbability;
            [Name("DropItem1_Count")]
            public int dropItemCount;
        }

        private struct DropItemProperties
        {
            public int itemID;

            public double probability;

            public int dropCount;
        }
    }
}
