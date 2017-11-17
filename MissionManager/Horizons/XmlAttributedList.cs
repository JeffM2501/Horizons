using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MissionManager.Horizons
{
    public class XmlAttributedListItem : IXmlSerializable
    {
        public XmlAttributedListItem() { }

        public virtual XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
        }

        public virtual void WriteXml(XmlWriter writer)
        {
        }
    }

    public class XmlAttributedList<T> : 
        IXmlSerializable
        where T : XmlAttributedListItem, new()
    {
        public List<T> items = new List<T>();

        public virtual XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
            string elementName = typeof(T).Name.ToLowerInvariant();

            items.Clear();
            while (reader.Read() && reader.Name == elementName)
            {
                T item = new T();
                item.ReadXml(reader);
                items.Add(item);
            }
  
            reader.ReadEndElement();
        }

        public virtual void WriteXml(XmlWriter writer)
        {
        }
    }
}
