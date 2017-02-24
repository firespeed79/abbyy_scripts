using System;

namespace test.ScriptTests
{
    class substring
    {
        public static string getBldgNums(string address)
        {
            int space, dash, number;
            bool isNumber;
            string bldgNums, testCase, final;

            space = address.IndexOf(" ");
            dash = address.IndexOf('-');

            bldgNums = address.Substring(0, space);

            try
            {
                testCase = bldgNums.Substring(0, dash);
                isNumber = Int32.TryParse(testCase, out number);

                if (isNumber)
                {
                    final = bldgNums;
                }
                else
                {
                    final = "";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                if (dash == -1)
                {
                    final = bldgNums;
                }
                else
                {
                    final = "";
                }
            }
 
            return final;
        }
    }
}
