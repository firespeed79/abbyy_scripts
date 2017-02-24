using System;

int space, dash, number;
bool isNumber;
string address, bldgNums, testCase;

address = Context.Field("rawstreet").Text;
space = address.IndexOf(" ");

bldgNums = address.Substring(0, space);
dash = bldgNums.IndexOf('-');
try
{   
    testCase = bldgNums.Substring(0, dash);
    isNumber = Int32.TryParse(testCase, out number);
    
    if (isNumber)
    {
        Context.Field("physBldgNum").Text = bldgNums;
    }
    else
    {
        Context.Field("physBldgNum").Text = "";
    }
}
catch (ArgumentOutOfRangeException)
{
    if (dash == -1)
    {
        Context.Field("physBldgNum").Text = bldgNums;
    }
    else
    {
        Context.Field("physBldgNum").Text = "";
    }
}

