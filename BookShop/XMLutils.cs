using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
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
        public static void ExtractSchema<T>(string path, T schemaGenerateForObject)
        {
            //SoapReflectionImporter soapReflectionImporter = new SoapReflectionImporter();
            //XmlTypeMapping xmlTypeMapping = soapReflectionImporter.ImportTypeMapping(typeof(T));
            //XmlSchemas xmlSchemas = new XmlSchemas();
            //XmlSchema xmlSchema = new XmlSchema();
            //xmlSchemas.Add(xmlSchema);
            //StreamWriter writer = new StreamWriter(path);
            //xmlSchema.Write(writer);
            //XmlSchemaExporter xmlSchemaExporter = new XmlSchemaExporter(xmlSchemas);
            //xmlSchemaExporter.ExportTypeMapping(xmlTypeMapping);
            XmlSchemas schemas = new XmlSchemas();
            XmlSchemaExporter exporter = new XmlSchemaExporter(schemas);
            XmlTypeMapping mapping = new XmlReflectionImporter().ImportTypeMapping(typeof(T));
            exporter.ExportTypeMapping(mapping);
            StreamWriter schemaWriter = new StreamWriter(path);
            foreach (XmlSchema schema in schemas)
            {
                schema.Write(schemaWriter);
            }
        }
    }
}
