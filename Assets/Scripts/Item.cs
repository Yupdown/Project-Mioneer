using System.Xml.Serialization;
using UnityEngine;

namespace Merle.Mioneer
{
    public class Item
    {
        private int id;
        private string name;

        private Sprite iconGraphics;

        private int value;

        private int maxStackAmount;

        public void Deserialize(string fileName)
        {

        }

        public struct Serialized
        {
            [XmlElement(ElementName = "TemplateID")]
            public int id;

            [XmlElement(ElementName = "Name")]
            public string name;

            [XmlElement(ElementName = "SpritePath")]
            public string spritePath;

            [XmlElement(ElementName = "Price")]
            public int price;

            [XmlElement(ElementName = "MaxCount")]
            public int maxCount;
        }
    }
}
