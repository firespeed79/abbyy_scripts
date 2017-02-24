using System;
using System.Net;
using System.IO;
using System.Xml;

namespace test.ScriptTests
{
    class addressParseUsingSubstring
    {
        public static void ParseWithSubstring()
        {
            string address, requestUri, formattedAddress, street, town, state, zip;
            int endOfOpenTag, startOfCloseTag, comma, space;

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

                    System.Xml.XmlNodeList formattedXML = googXMLDoc.GetElementsByTagName("formatted_address");

                    if (formattedXML[0].InnerXml != null)
                    {
                        // We have to be able to use the address as a string instead of an xml object
                        formattedAddress = formattedXML[0].InnerXml.ToString();

                        // Extract the address from between the traditional XML tags
                        endOfOpenTag = formattedAddress.IndexOf(">");
                        startOfCloseTag = formattedAddress.LastIndexOf("<");
                        formattedAddress = formattedAddress.Substring(endOfOpenTag + 1, ((startOfCloseTag + 1) - endOfOpenTag - 2));

                        // Next step: extract parts of address from new string
                        comma = formattedAddress.IndexOf(","); // Find the first comma
                        street = formattedAddress.Substring(0, comma); // Slice out the street info
                        formattedAddress = formattedAddress.Substring(comma + 2); // Assign remaining address to formattedAddress to continue slicing

                        comma = formattedAddress.IndexOf(","); // Find the new first comma
                        town = formattedAddress.Substring(0, comma); // etc...
                        formattedAddress = formattedAddress.Substring(comma + 2); // etc...

                        comma = formattedAddress.IndexOf(",");
                        state = formattedAddress.Substring(0, comma);
                        space = state.IndexOf(' '); // The space between the state and the zip code
                        zip = state.Substring(space + 1);
                        state = state.Substring(0, space);
                        formattedAddress = null; // Null out the address

                        Console.WriteLine(street);
                        Console.WriteLine(town);
                        Console.WriteLine(state);
                        Console.WriteLine(zip);
                        Console.WriteLine();
                        Console.WriteLine(street + " " + town + " " + " " + state + " " + zip);

                    }
                    else
                    {
                        Console.WriteLine("Error! Nothing was receieved from Google geocode!");
                    }


                }
}
