using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookShop
{
    public static class XMLutils
    {
        public static void Serialize<T>(T dataToSerialize, string path)
        {
            TextWriter writer = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(path);
                serializer.Serialize(writer, dataToSerialize);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static void Deserialize<T>(string path, ref T targetObject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            TextReader textReader = null;
            try
            {
                textReader = new StreamReader(path);
                targetObject = (T)serializer.Deserialize(textReader);
            }
            finally
            {
                textReader.Close();
            }
        }
    }
}
