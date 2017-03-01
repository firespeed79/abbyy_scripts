using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.IO;

string address, requestUri, geoCheck, bldgNum, street1, street2, city, county, state, zip, errorMsg;
List<string> longName = new List<string>();
List<string> type = new List<string>();

if (Context.Field("zip").Text == "")
{
    address = Context.Text; // Get the address from the field
}
else
{
    address = Context.Text + " " + Context.Field("zip").Text; // Results are better with a zip code and the address field is just the street
}
requestUri = "https://maps.googleapis.com/maps/api/geocode/xml?sensor=false&address=" + address; // Build the API url

if (Context.Text == "" || Context.Text == null)
{
    FCTools.ShowMessage("The address is invalid! It is either blank, incomplete, or was not read properly by ABBYY.");
}
else
{
    WebRequest googReq = WebRequest.Create(requestUri);
    using (WebResponse googResp = googReq.GetResponse())
    {    
        using (Stream xmlStream = googResp.GetResponseStream())
        {
            XmlDocument googXMLDoc = new XmlDocument();
            googXMLDoc.Load(new StreamReader(xmlStream));
            XmlNodeList formattedXML = googXMLDoc.GetElementsByTagName("address_component"); 
            XmlNodeList geoRespXML = googXMLDoc.GetElementsByTagName("GeocodeResponse");
            XmlNode resp = geoRespXML[0];
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
                                city = longName[3];
                                county = longName[4];
                                state = longName[5];
                                zip = longName[7];
                                
                                Context.Field("singleBldg").Text = bldgNum;
                                Context.Field("st1").Text = street1;
                                Context.Field("st2").Text = street2;
                                Context.Field("city").Text = city;
                                Context.Field("county").Text = county;
                                Context.Field("state").Text = state;
                                Context.Field("zip").Text = zip;
                            }
                            else 
                            {
                                street2 = longName[0];
                                bldgNum = longName[1];
                                street1 = longName[2];
                                city = longName[3];
                                county = longName[5];
                                state = longName[6];
                                zip = longName[8];

                                Context.Field("singleBldg").Text = bldgNum;
                                Context.Field("st1").Text = street1;
                                Context.Field("st2").Text = street2;
                                Context.Field("city").Text = city;
                                Context.Field("county").Text = county;
                                Context.Field("state").Text = state;
                                Context.Field("zip").Text = zip;
                            }
                           
                            break;
                        case 8:
                            if (type[7].Contains("postal_code_suffix"))
                            {
                                street2 = "";
                                bldgNum = longName[0];
                                street1 = longName[1];
                                city = longName[2];
                                county = longName[3];
                                state = longName[4];
                                zip = longName[6];

                                Context.Field("singleBldg").Text = bldgNum;
                                Context.Field("st1").Text = street1;
                                Context.Field("st2").Text = street2;
                                Context.Field("city").Text = city;
                                Context.Field("county").Text = county;
                                Context.Field("state").Text = state;
                                Context.Field("zip").Text = zip;
                            }
                            else
                            {
                                street2 = "";
                                bldgNum = longName[0];
                                street1 = longName[1];
                                city = longName[2];
                                county = longName[4];
                                state = longName[5];
                                zip = longName[7];

                                Context.Field("singleBldg").Text = bldgNum;
                                Context.Field("st1").Text = street1;
                                Context.Field("st2").Text = street2;
                                Context.Field("city").Text = city;
                                Context.Field("county").Text = county;
                                Context.Field("state").Text = state;
                                Context.Field("zip").Text = zip;
                            }
                            break;
                        case 7:
                            street2 = "";
                            bldgNum = longName[0];
                            street1 = longName[1];
                            city = longName[2];
                            county = longName[3];
                            state = longName[4];
                            zip = longName[6];

                            Context.Field("singleBldg").Text = bldgNum;
                            Context.Field("st1").Text = street1;
                            Context.Field("st2").Text = street2;
                            Context.Field("city").Text = city;
                            Context.Field("county").Text = county;
                            Context.Field("state").Text = state;
                            Context.Field("zip").Text = zip;
                            break;
                        case 6:
                            street1 = longName[0];
                            city = longName[1];
                            county = longName[2];
                            state = longName[3];
                            zip = longName[5];
                            street2 = "";
                            bldgNum = "";

                            Context.Field("singleBldg").Text = bldgNum;
                            Context.Field("st1").Text = street1;
                            Context.Field("st2").Text = street2;
                            Context.Field("city").Text = city;
                            Context.Field("county").Text = county;
                            Context.Field("state").Text = state;
                            Context.Field("zip").Text = zip;
                            break;
                        case 5:
                            street1 = longName[0];
                            city = longName[1];
                            state = longName[2];
                            zip = longName[4];
                            street2 = "";
                            county = "";
                            bldgNum = "";
                            
                            Context.Field("singleBldg").Text = bldgNum;
                            Context.Field("st1").Text = street1;
                            Context.Field("st2").Text = street2;
                            Context.Field("city").Text = city;
                            Context.Field("county").Text = county;
                            Context.Field("state").Text = state;
                            Context.Field("zip").Text = zip;
                            break;
                        default:
                            street2 = "";
                            bldgNum = longName[0];
                            street1 = longName[1];
                            city = longName[2];
                            county = longName[3];
                            state = longName[4];
                            zip = longName[6];

                            Context.Field("singleBldg").Text = bldgNum;
                            Context.Field("st1").Text = street1;
                            Context.Field("st2").Text = street2;
                            Context.Field("city").Text = city;
                            Context.Field("county").Text = county;
                            Context.Field("state").Text = state;
                            Context.Field("zip").Text = zip;
                            break;
                    }    
                }
                catch (ArgumentOutOfRangeException)
                {
                    FCTools.ShowMessage("Location already geocoded!");
                }          
            }
            else
            {
                errorMsg = "Error! Google geocode response status: " + geoCheck + 
                "\n\n 'ZERO_RESULTS' indicates that the parse was successful but returned no results.\n" + 
                "This may occur if Google's geocoder was passed a non-existent address.\n\n" +
                "'OVER_QUERY_LIMIT' indicates that the script is over its verification quota.\n\n" +
                "'REQUEST_DENIED' indicates that your address parse request was denied.\n" +
                "Please report this as soon as possible\n\n" +
                "'INVALID_REQUEST' generally indicates that critical components of the address are missing.\n\n" +
                "'UNKNOWN_ERROR' indicates that the request could not be processed due to a server error.\n" +
                "The request may succeed if you try again.";
                errorMsg = errorMsg.Replace("\n", System.Environment.NewLine);
                FCTools.ShowMessage(errorMsg);
            }
        }
    }
}