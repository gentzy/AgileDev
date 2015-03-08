using System;
using System.IO;
using System.Text;
using System.Xml;

namespace InputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = new MemoryStream();
            Stream streamCopy = new FileStream("Sample.txt", FileMode.Create, FileAccess.ReadWrite);

            StreamWriter writer = new StreamWriter(stream);
            writer.Write("<Name>Gentiana</Name>");
            writer.Flush(); // Use flush to move the data from the reader to the stream

            stream.Seek(0, SeekOrigin.Begin); // Writing to the stream moved the current position to the end. We need to reset to the beginning

            stream.CopyTo(streamCopy);
            streamCopy.Position = 0; // Copying to the stream moved the current position to the end. We need to reset to the beginning

            XmlReader xmlReader = XmlReader.Create(streamCopy);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlReader); // Load the stream contents into an XML object

            writer.Close(); // This will close the underlying stream
            xmlReader.Close(); // What happened here? Did it close the underlying stream ?


            // XmlSettings
            XmlReaderSettings xmlSettings = new XmlReaderSettings();
            xmlSettings.CloseInput = true;
            XmlReader closingXmlReader = XmlReader.Create(streamCopy, xmlSettings);
            closingXmlReader.Close();


            // Using
            Stream binaryStream = new MemoryStream();
            binaryStream.WriteByte(1);
            binaryStream.WriteByte(0);
            binaryStream.WriteByte(1);
            binaryStream.Seek(0, SeekOrigin.Begin);            
            using (BinaryReader binaryReader = new BinaryReader(binaryStream))
            {
                double value = binaryReader.ReadDouble();
            }

            /*The using statement (not to be confused with the directive using System.Text;) defines a scope at the end of which an object will be disposed. */
        }
    }
}
