/*
strings: 
    Address - the address that was read by ABBYY
    requestUri - the Google API url that will utilize Google's geocoding tool
    formattedAddress - after acquiring the address from Google, it will be in XML format and will need to be extracted
    street - the variable that will store the extracted street (number and name)
    town - the variable to hold the extracted town
    state - the variable to hold the extracted state
    zip - the variable to hold the extracted zip code
    
ints:
    endOfOpenTag - the index of the ending bracket of the opening XML tag
    startOfCloseTag - the index of the starting bracket of the closing XML tag
    comma - the index of the comma in Google's formatted address
    space - the index of the rogue space between the state and the zip code in the formatted address
*/
string address, requestUri, formattedAddress, street, town, state, zip;
int endOfOpenTag, startOfCloseTag, comma, space;

address = Context.Text; // Get the address from the field
requestUri = "https://maps.googleapis.com/maps/api/geocode/xml?sensor=false&address=" + address; // Build the API url

/*
    If the field is blank, display a warning. Simplistic since so long as there's a best guess and a zip, Google will try to handle it.
*/
if (Context.Text == "" || Context.Text == null)
{
    FCTools.ShowMessage("The address is invalid! It is either blank, incomplete, or was not read properly by ABBYY.");
}
else
{
    // Create a new web request to the Google API
    System.Net.WebRequest googReq = System.Net.WebRequest.Create(requestUri);
    
    // Using the response from that request...
    using (System.Net.WebResponse googResp = googReq.GetResponse())
    {    
        // Get the information from it using a response stream
        using (System.IO.Stream xmlStream = googResp.GetResponseStream())
        {
            // Instantiate a new XmlDocument and load the data from the data stream using StreamReader
            System.Xml.XmlDocument googXMLDoc = new System.Xml.XmlDocument();
            googXMLDoc.Load(new System.IO.StreamReader(xmlStream));
            
            // There's no way to select a single XML node based on its tag name, so grab "everything" and just access element at index 0
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
                
                // Assign the extracted values to the verification fields
                Context.Field("(In Development) Extracted Street").Text = street;
                Context.Field("(In Development) Extracted Town").Text = town;
                Context.Field("(In Development) Extracted State").Text = state;
                Context.Field("(In Development) Extracted Zip").Text = zip;
            }
            else
            {
                FCTools.ShowMessage("Error! Nothing was receieved from Google geocode!");
            }
        }
    }
}