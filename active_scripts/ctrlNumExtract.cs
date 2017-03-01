using System;

if(Context.Field("ctrlNum").Text == "")
{
    string ctrlNum = Context.Field("subjLine").Text;
 
    int openBracket = ctrlNum.IndexOf('[');
    int closeBracket = ctrlNum.IndexOf(']');
    try
    {
          ctrlNum = ctrlNum.Substring(openBracket + 1, (closeBracket - openBracket) - 1); 
          Context.Field("ctrlNum").Value = ctrlNum;
    }
    catch (ArgumentOutOfRangeException)
    {
        Context.Field("ctrlNum").Value = "";
    }
}