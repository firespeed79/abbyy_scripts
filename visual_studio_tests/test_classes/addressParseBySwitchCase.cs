using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace test
{
    class addressParseBySwitchCase
    {
        public static void ParseSwitch()
        {
            string address, requestUri, geoCheck, bldgNum, street1, street2, town, county, state, zip;
            List<string> longName = new List<string>();
            List<string> type = new List<string>();

            Console.Write("Enter address: ");
            address = Console.ReadLine();
            requestUri = $"https://maps.googleapis.com/maps/api/geocode/xml?sensor=false&address= {address}";

            WebRequest googReq = WebRequest.Create(requestUri);

            using (WebResponse googResp = googReq.GetResponse())
            {
                using (Stream xmlStream = googResp.GetResponseStream())
                {
                    XmlDocument googXMLDoc = new XmlDocument();
                    googXMLDoc.Load(new StreamReader(xmlStream));

                    XmlNodeList formattedXML = googXMLDoc.GetElementsByTagName("address_component");
                    XmlNodeList geoResp = googXMLDoc.GetElementsByTagName("GeocodeResponse");
                    XmlNode resp = geoResp[0];
                    geoCheck = resp["status"].InnerXml.ToString();

                    if (geoCheck.ToLower() == "ok")
                    {
                        foreach (XmlNode addressNode in formattedXML)
                        {
                            longName.Add(addressNode["long_name"].InnerXml.ToString());
                            type.Add(addressNode["type"].InnerXml.ToString());
                        }


                        try
                        {
                            int count = type.Count;
                            switch (count)
                            {
                                case 9:
                                    if (type[8].Contains("postal_code_suffix"))
                                    {
                                        street2 = "";
                                        bldgNum = longName[0];
                                        street1 = longName[1];
                                        town = longName[3];
                                        county = longName[4];
                                        state = longName[5];
                                        zip = longName[7];

                                        Console.WriteLine(bldgNum + "\n" + street1 + "\n#" + street2 + "\n" + town + "\n" + county + "\n" + state + "\n" + zip);
                                    }
                                    else
                                    {
                                        street2 = longName[0];
                                        bldgNum = longName[1];
                                        street1 = longName[2];
                                        town = longName[3];
                                        county = longName[5];
                                        state = longName[6];
                                        zip = longName[8];

                                        Console.WriteLine(bldgNum + "\n" + street1 + "\n#" + street2 + "\n" + town + "\n" + county + "\n" + state + "\n" + zip);
                                    }
                                    break;
                                case 8:
                                    if (type[7].Contains("postal_code_suffix"))
                                    {
                                        bldgNum = longName[0];
                                        street1 = longName[1];
                                        town = longName[2];
                                        county = longName[3];
                                        state = longName[4];
                                        zip = longName[6];

                                        Console.WriteLine(bldgNum + "\n" + street1 + "\n" + town + "\n" + county + "\n" + state + "\n" + zip);
                                    }
                                    else
                                    {
                                        bldgNum = longName[0];
                                        street1 = longName[1];
                                        town = longName[2];
                                        county = longName[4];
                                        state = longName[5];
                                        zip = longName[7];

                                        Console.WriteLine(bldgNum + "\n" + street1 + "\n" + town + "\n" + county + "\n" + state + "\n" + zip);
                                    }
                                    break;
                                case 7:
                                    bldgNum = longName[0];
                                    street1 = longName[1];
                                    town = longName[2];
                                    county = longName[3];
                                    state = longName[4];
                                    zip = longName[6];

                                    Console.WriteLine(bldgNum + "\n" + street1 + "\n" + town + "\n" + county + "\n" + state + "\n" + zip);
                                    break;
                                case 6:
                                    street1 = longName[0];
                                    town = longName[1];
                                    county = longName[2];
                                    state = longName[3];
                                    zip = longName[5];
                                    street2 = "";
                                    bldgNum = "";

                                    Console.WriteLine(street1 + "\n" + town + "\n" + county + "\n" + state + "\n" + zip);
                                    break;
                                case 5:
                                    street1 = longName[0];
                                    town = longName[1];
                                    state = longName[2];
                                    zip = longName[4];

                                    Console.WriteLine(street1 + "\n" + town + "\n" + state + "\n" + zip);
                                    break;
                                default:
                                    bldgNum = longName[0];
                                    street1 = longName[1];
                                    town = longName[2];
                                    county = longName[3];
                                    state = longName[4];
                                    zip = longName[6];

                                    Console.WriteLine(bldgNum + "\n" + street1 + "\n" + town + "\n" + county + "\n" + state + "\n" + zip);
                                    break;
                            }

                            Console.WriteLine();
                            foreach (string str in type)
                            {
                                Console.WriteLine(str);
                            }
                            Console.WriteLine();
                            foreach (string str in longName)
                            {
                                Console.WriteLine(str);
                            }
                            Console.WriteLine();
                            Console.WriteLine(type.Count);
                            Console.ReadKey();

                        }
                        catch (ArgumentOutOfRangeException index)
                        {
                            Console.WriteLine(index);
                            Console.WriteLine($"Length of type is {type.Count}");
                            Console.WriteLine();
                            foreach (string str in type)
                            {
                                Console.WriteLine(str);
                            }
                            Console.WriteLine();
                            foreach (string str in longName)
                            {
                                Console.WriteLine(str);
                            }
                            Console.WriteLine();
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Write("Error! Google geocode response status: " + geoCheck);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
