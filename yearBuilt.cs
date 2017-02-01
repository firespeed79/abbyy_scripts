using System;
using System.Collections;
using System.Collections.Generic;

string yearBuilt = Context.Text;
List<string> cachedWords = new List<string>();
if(cachedWords == null)
{
    cachedWords.Add("00");
    cachedWords.Add("01");
    cachedWords.Add("02");
    cachedWords.Add("03");
    cachedWords.Add("04");
    cachedWords.Add("05");
    cachedWords.Add("06");
    cachedWords.Add("07");
    cachedWords.Add("08");
    cachedWords.Add("09");
    cachedWords.Add("10");
    cachedWords.Add("11");
    cachedWords.Add("12");
    cachedWords.Add("13");
    cachedWords.Add("14");
    cachedWords.Add("15");
    cachedWords.Add("16");
    cachedWords.Add("17");
}

for(int i = 0; i<cachedWords.Count; i++)
{
    
    if(cachedWords[i] == yearBuilt)
    {
        yearBuilt = "20"+yearBuilt;
        break;
    }
    else if(i >= cachedWords.Count)
    {
        if(yearBuilt.Length >= 4)
        {
            FCTools.ShowMessage("Could not verify Year Built");
            break;
        }
        else
        {
            yearBuilt = "19"+yearBuilt;
            break;
        }
    }
}
Context.Text = yearBuilt;