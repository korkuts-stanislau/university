using System;
using System.Xml;
using SubjectLib;

namespace XmlParserLib
{
    public class XmlParser
    {
        public XmlParser()
        {
            
        }
        public static void ReadFromXmlFile(Subjects subjects)
        {
            using (XmlReader xr = XmlReader.Create(@"C:\korkuts-itp21-oop\lab2\XMLParser\Subjects.xml"))
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
                    }
                    // reads the element value
                    else if (xr.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "SubjectName":
                                name = xr.Value;
                                break;
                            case "LectureHours":
                                lecHours = Convert.ToInt32(xr.Value);
                                break;
                            case "LabHours":
                                labHours = Convert.ToInt32(xr.Value);
                                break;
                            case "FirstName":
                                eduFirstName = xr.Value;
                                break;
                            case "LastName":
                                eduLastName = xr.Value;
                                break;
                            case "MiddleName":
                                eduMiddleName = xr.Value;
                                break;
                            case "ControlType":
                                cType = xr.Value;
                                break;
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
            using (XmlWriter xw = XmlWriter.Create(@"C:\korkuts-itp21-oop\lab2\XMLParser\Subjects.xml"))
            {
                xw.WriteStartDocument(); // the header
                xw.WriteStartElement("Дисциплины"); // opens the root users element

                for(int i = 0; i < subjects.Length; i++)
                {
                    xw.WriteStartElement("user");
                    xw.WriteAttributeString("age", u.Age.ToString());

                    xw.WriteElementString("name", u.Name);
                    xw.WriteElementString("registered", u.Registered.ToShortDateString());

                    xw.WriteEndElement();
                }

                xw.WriteEndElement(); // closes the root element
                xw.WriteEndDocument(); // closes the document
                xw.Flush();
            }
        }
    }
}
