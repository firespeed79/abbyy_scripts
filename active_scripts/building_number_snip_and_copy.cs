using System;

int space, dash, number;
bool isNumber;
string address, bldgNums, testCase;

address = Context.Field("rawStreet").Text;
space = address.IndexOf(" ");

if (Context.Field("rawStreet").Text == "")
    return;
else
{
    bldgNums = address.Substring(0, space);
    dash = bldgNums.IndexOf('-');
    try
    {   
        testCase = bldgNums.Substring(0, dash);
        isNumber = Int32.TryParse(testCase, out number);
        
        if (isNumber)
        {
            Context.Field("physBldg").Text = bldgNums;
        }
        else
        {
            Context.Field("physBldg").Text = "";
        }
    }
    catch (ArgumentOutOfRangeException)
    {
        if (dash == -1)
        {
            Context.Field("physBldg").Text = bldgNums;
        }
        else
        {
            Context.Field("physBldg").Text = "";
        }
    }
}