using System.IO;
using System.Xml.Serialization;
using TwentyFortyEight.Common;
using UnityEngine;

namespace TwentyFortyEight.Game
{
    public class ScoreSerializer : ISerializer<int>
    {
        private const string FileName = "BestScore.xml";
        
        public void Serialize(int value)
        {
            var serializer = new XmlSerializer(typeof(int));
            var writer = new StreamWriter(Application.persistentDataPath + FileName);
            serializer.Serialize(writer.BaseStream, value);
            writer.Close();
        }
        public int Deserialize()
        {
            var serializer = new XmlSerializer(typeof(int));
            if (File.Exists(Application.persistentDataPath + FileName))
            {
                var reader = new StreamReader(Application.persistentDataPath + FileName);
                int deserialized = (int) serializer.Deserialize(reader.BaseStream);
                reader.Close();
                return deserialized;
            }
            
            Serialize(0);
            return 0;
        }
    }
}