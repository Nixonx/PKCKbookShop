using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
        public static void SerializeWithXSLT<T> (T dataToSerialize, string path)
        {
        XmlSerializer s = new XmlSerializer(typeof(T));
            using (XmlWriter writer = XmlWriter.Create(path))
            {
             //   <? xml - stylesheet type = "text/xsl" href = "BookShopPDFTransform.xslt" ?>
                  writer.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"BookShopPDFTransform.xsl\"");
                s.Serialize(writer, dataToSerialize);
            }
        }
    public static BookShopMagazine Deserialize(string path)
        {
            BookShopMagazine targetObject = new BookShopMagazine();
            XmlSerializer serializer = new XmlSerializer(typeof(BookShopMagazine));

            TextReader textReader = null;
            try
            {
                textReader = new StreamReader(path);
                targetObject = (BookShopMagazine)serializer.Deserialize(textReader);
            }
            catch (Exception e)
            {
                Console.WriteLine("EXEPTION");
            }
            finally
            {
                textReader.Close();
            }
            return targetObject;
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
