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
    public class Mission
    {
        public class Vector3D
        {
            public double X = 0;
            public double Y = 0;
            public double Z = 0;

            public static readonly Vector3D Zero = new Vector3D();

            public static bool TryParse(string value, out Vector3D vec)
            {
                vec = new Vector3D();

                if (value == null || value == string.Empty)
                    return false;

                string[] parts = value.Split(" ".ToCharArray(), 3);
                if (parts.Length != 3)
                    return false;

                return double.TryParse(parts[0], out vec.X) && double.TryParse(parts[1], out vec.Z) && double.TryParse(parts[2], out vec.Z);
            }

            public override string ToString()
            {
                return X.ToString() + " " + Y.ToString() + " " + Z.ToString();
            }
        }
        public string name = string.Empty;
        public string authors = string.Empty;
        public enum Modes
        {
            Cooperative,
            Deathmatch,
        }
        public Modes mode = Modes.Cooperative;

        public string date = string.Empty;
        public int difficulty = -1;

        public class TimerClass : IXmlSerializable
        {
            public int max = -1;
            public int warn = 0;

            public XmlSchema GetSchema()
            {
                return null;
            }

            public void ReadXml(XmlReader reader)
            {
                int.TryParse(reader.GetAttribute("max"), out max);
                int.TryParse(reader.GetAttribute("warn"), out warn);
            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteAttributeString("max", max.ToString());
                writer.WriteAttributeString("warn", warn.ToString());
            }
        }
        public TimerClass timer = new TimerClass();

        public int duration = -1;

        public string galaxy = string.Empty;

        public string description = string.Empty;
        public string briefing = string.Empty;

        public List<string> options = new List<string>();

        public class Player
        {
            public string name = string.Empty;
            public string designation = string.Empty;
            public string vesselclass = string.Empty;
            public string faction = string.Empty;
            public string spawn = string.Empty;
        }

        public class PlayerList : IXmlSerializable
        {
            public int min = -1;
            public int max = -1;

            public List<Player> players = new List<Player>();

            public XmlSchema GetSchema()
            {
                return null;
            }

            public void ReadXml(XmlReader reader)
            {
                string v = reader.GetAttribute("min");
                if (v !=null && v != string.Empty)
                    int.TryParse(v, out min);

                v = reader.GetAttribute("max");
                if (v != null && v != string.Empty)
                    int.TryParse(v, out max);

                players.Clear();
                while (reader.Read() && reader.Name == "player")
                {
                    Player p = new Player();
                    p.name = reader.GetAttribute("name") ?? string.Empty;
                    p.designation = reader.GetAttribute("designation") ?? string.Empty;
                    p.vesselclass = reader.GetAttribute("vesselclass") ?? string.Empty;
                    p.faction = reader.GetAttribute("faction") ?? string.Empty;
                    p.spawn = reader.GetAttribute("spawn") ?? string.Empty;

                    players.Add(p);
                }

                reader.ReadEndElement();
            }

            public void WriteXml(XmlWriter writer)
            {

            }
        }

        public PlayerList players = new PlayerList();


        public class SpawnPointsList : IXmlSerializable
        {
            public List<Spawn> items = new List<Spawn>();

            public XmlSchema GetSchema()
            {
                return null;
            }

            public void ReadXml(XmlReader reader)
            {
                items.Clear();
                while (reader.Read() && reader.Name == "spawn")
                {
                    Spawn s = new Spawn();

                    s.id = reader.GetAttribute("id") ?? string.Empty;
                    s.galaxy = reader.GetAttribute("galaxy") ?? string.Empty;
                    s.system = reader.GetAttribute("system") ?? string.Empty;
                    s.planet = reader.GetAttribute("planet") ?? string.Empty;
                    Vector3D.TryParse(reader.GetAttribute("position"), out s.postion);
                    Vector3D.TryParse(reader.GetAttribute("orientation"), out s.orientation);
                    s.docked = reader.GetAttribute("docked") ?? string.Empty;
                    s.dock = reader.GetAttribute("dock") ?? string.Empty;
                    s.maneuver = reader.GetAttribute("maneuver") ?? string.Empty;

                    items.Add(s);
                }
                reader.ReadEndElement();
            }

            public void WriteXml(XmlWriter writer)
            {

            }
        }

        public class Spawn
        {
            public string id = string.Empty;
            public string galaxy = string.Empty;
            public string system = string.Empty;
            public string planet = string.Empty;
            public Vector3D postion = Vector3D.Zero;
            public Vector3D orientation = Vector3D.Zero;
            public string docked = string.Empty;
            public string dock = string.Empty;
            public string maneuver = string.Empty;
        }

        public SpawnPointsList spawnpoints = new SpawnPointsList();

    }
}
