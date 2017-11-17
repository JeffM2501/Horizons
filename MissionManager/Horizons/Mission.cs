using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public class Player : XmlAttributedListItem
        {
            public string name = string.Empty;
            public string designation = string.Empty;
            public string vesselclass = string.Empty;
            public string faction = string.Empty;
            public string spawn = string.Empty;

            public override void ReadXml(XmlReader reader)
            {
                name = reader.GetAttribute("name") ?? string.Empty;
                designation = reader.GetAttribute("designation") ?? string.Empty;
                vesselclass = reader.GetAttribute("vesselclass") ?? string.Empty;
                faction = reader.GetAttribute("faction") ?? string.Empty;
                spawn = reader.GetAttribute("spawn") ?? string.Empty;
            }
        }

        public class PlayerList : XmlAttributedList<Player>
        {
            public int min = -1;
            public int max = -1;

            public override void ReadXml(XmlReader reader)
            {
                if (!int.TryParse(reader.GetAttribute("min") ?? string.Empty, out min))
                    min = 1;

                if (!int.TryParse(reader.GetAttribute("max") ?? string.Empty, out max))
                    max = 1;

                base.ReadXml(reader);
            }
        }
        public PlayerList players = new PlayerList();


        public class Spawn : XmlAttributedListItem
        {
            public string id = string.Empty;
            public string galaxy = string.Empty;
            public string system = string.Empty;
            public string planet = string.Empty;
            public Vector3D postion = Vector3D.Zero;
            public Vector3D orientation = Vector3D.Zero;
            public string docked = string.Empty;
            public string dock = string.Empty;

            public enum Maneuver
            {
                Cruise,
                Follow,
                Orbit,
                Docking,
                Docked,
                Departing,
                Burst,
                FTL
            }
            public Maneuver maneuver = Maneuver.Cruise;

            public Spawn(){ }

            public override void ReadXml(XmlReader reader)
            {
                id = reader.GetAttribute("id") ?? string.Empty;
                galaxy = reader.GetAttribute("galaxy") ?? string.Empty;
                system = reader.GetAttribute("system") ?? string.Empty;
                planet = reader.GetAttribute("planet") ?? string.Empty;
                Vector3D.TryParse(reader.GetAttribute("position"), out postion);
                Vector3D.TryParse(reader.GetAttribute("orientation"), out orientation);
                docked = reader.GetAttribute("docked") ?? string.Empty;
                dock = reader.GetAttribute("dock") ?? string.Empty;
                if (!Enum.TryParse<Spawn.Maneuver>(reader.GetAttribute("maneuver") ?? string.Empty, out maneuver))
                    maneuver = Spawn.Maneuver.Cruise;
            }
        }
        public XmlAttributedList<Spawn> spawnpoints = new XmlAttributedList<Spawn>();

       public class Objective : XmlAttributedListItem
        {
            public enum ObjectiveRank
            {
                Primary,
                Secondary,
                Opertunity
            }
            public ObjectiveRank rank = ObjectiveRank.Opertunity;

            public enum ObjectiveType
            {
                None,
                Open,
                Deploy,
                Aquire_Commodity,
                Enemies_Remaining,
                Enemies_Destroyed,
                Objects_Hailed,
                Objects_Scanned,
                Objects_Survived,
                Object_Survived,
                Objects_Destroyed,
                LocalThreats,
                Timed,
                Waypoints_Reached,
                Docked
            }
            public ObjectiveType type = ObjectiveType.None;

            public string value = string.Empty;
            public string title = string.Empty;
            public string triggerEvent = string.Empty;
            public bool visible = true;
            public List<string> tags = new List<string>();

            public override void ReadXml(XmlReader reader)
            {
                if (!Enum.TryParse<ObjectiveRank>(reader.GetAttribute("rank") ?? string.Empty, out rank))
                    rank = ObjectiveRank.Opertunity;

                if (!Enum.TryParse<ObjectiveType>(reader.GetAttribute("type") ?? string.Empty, out type))
                    type = ObjectiveType.None;

                value = reader.GetAttribute("value") ?? string.Empty;
                title = reader.GetAttribute("title") ?? string.Empty;
                triggerEvent = reader.GetAttribute("event") ?? string.Empty;
                visible = (reader.GetAttribute("visible") ?? string.Empty).ToUpper() != "FALSE";
                tags.AddRange((reader.GetAttribute("tags") ?? string.Empty).Split(",".ToCharArray()).ToArray());
            }
        }

        public XmlAttributedList<Objective> objectives = new XmlAttributedList<Objective>();


        public class Variable : XmlAttributedListItem
        {
            public string name = string.Empty;
            public enum VariableTypes
            {
                Unknown,
                Int32,
                Float,
                Boolean,
            }

            public VariableTypes type = VariableTypes.Unknown;

            public string value = string.Empty;

            public override void ReadXml(XmlReader reader)
            {
                if (!Enum.TryParse<VariableTypes>(reader.GetAttribute("type") ?? string.Empty, out type))
                    type = VariableTypes.Unknown;


                name = reader.GetAttribute("name") ?? string.Empty;
                value = reader.GetAttribute("value") ?? string.Empty;
            }
        }

        public XmlAttributedList<Variable> variables = new XmlAttributedList<Variable>();

        public class Vessel : XmlAttributedListItem
        {
            public string name = string.Empty;
            public string className = string.Empty;
            public string faction = string.Empty;
            public List<string> tags = new List<string>();
            public Vector3D position = Vector3D.Zero;
            public Vector3D orientation = Vector3D.Zero;
            public string planet = string.Empty;
            public double speed;

            public bool sentient = false;

            public enum Behavior
            {
                Idle,
                Defend,
                Escort,
                Flee,
                Intercept,
                Patrol,
                Follow,
                GoToWaypoint,
                Hold,
                PlayerHold,
                Surrendered
            }
            public Behavior corebehavior = Behavior.Idle;
            public Behavior behavior = Behavior.Idle;

            public int crewSize = 0;
            public bool debug = false;
            public string broadcastingKey;
        }
    }
}
