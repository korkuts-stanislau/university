using System;
using System.Xml;
using System.Xml.Schema;
using SubjectLib;

namespace XmlParserLib
{
    public class XmlParser
    {
        public XmlParser()
        {
            
        }
        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                throw new Exception("WARNING: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                throw new Exception("ERROR: " + e.Message);
            }
        }
        public static void ReadFromXmlFile(Subjects subjects)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add("", @"D:\korkuts-itp21-oop\lab2_dtd_notation\XMLParser\Subjects.xsd");
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);
            using (XmlReader xr = XmlReader.Create(@"D:\korkuts-itp21-oop\lab2_dtd_notation\XMLParser\Subjects.xml", settings))
            {
                string name = "";
                int lecHours = 0;
                int labHours = 0;
                string cType = "";
                string eduFirstName = "";
                string eduLastName = "";
                string eduMiddleName = "";
                string element = "";
                while (xr.Read())
                {
                    // reads the element
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        element = xr.Name; // the name of the current element
                        if(element == "Subject")
                        {
                            name = xr.GetAttribute("name");
                            lecHours = int.Parse(xr.GetAttribute("lecHours"));
                            labHours = int.Parse(xr.GetAttribute("labHours"));
                            cType = xr.GetAttribute("controlType");
                        }
                        if(element == "Educator")
                        {
                            eduFirstName = xr.GetAttribute("firstName");
                            eduLastName = xr.GetAttribute("lastName");
                            eduMiddleName = xr.GetAttribute("middleName");
                        }
                    }
                    // reads the closing element
                    else if ((xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "Subject"))
                        subjects.AddSubject(name, lecHours, labHours, cType, eduFirstName,
                            eduLastName, eduMiddleName);
                }
            }
        }
        public static void WriteToXmlFile(Subjects subjects)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "     ",
                NewLineOnAttributes = false,
                OmitXmlDeclaration = true
            };
            using (XmlWriter xw = XmlWriter.Create(@"D:\korkuts-itp21-oop\lab2_dtd_notation\XMLParser\Subjects.xml", settings))
            {
                xw.WriteStartDocument(); // the header
                xw.WriteStartElement("Subjects"); // opens the root users element

                for(int i = 0; i < subjects.Length; i++)
                {
                    string[] attributes = subjects[i];
                    xw.WriteStartElement("Subject");

                    xw.WriteAttributeString("name", attributes[0]);
                    xw.WriteAttributeString("lecHours", attributes[1]);
                    xw.WriteAttributeString("labHours", attributes[2]);
                    xw.WriteAttributeString("controlType", attributes[3]);

                    xw.WriteStartElement("Educator");
                    xw.WriteAttributeString("firstName", attributes[4]);
                    xw.WriteAttributeString("lastName", attributes[5]);
                    xw.WriteAttributeString("middleName", attributes[6]);
                    xw.WriteEndElement();

                    xw.WriteEndElement();
                }

                xw.WriteEndElement(); // closes the root element
                xw.WriteEndDocument(); // closes the document
                xw.Flush();
            }
        }
    }
}
