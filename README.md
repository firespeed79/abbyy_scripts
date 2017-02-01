# abbyy_scripts
Custom feature development in C# for the ABBYY Flexicapture software by [myself](https://github.com/jmarkman) and [Alfred Long](https://github.com/along88)

Scripts: 

addressParseWithSubpremise - Address Parsing functionality via Google Maps Geocoding API call

addressParseBySubstring - Precursor to above script

ctrlNumExtract - From the email subject gathered by ABBYY, get the company-specific control number within it

convert_constType_to_int - For database specific input, convert text from an ABBYY field to an integer using a dictionary

protection_class - Sometimes protection class input will come in as "0[x]" where x is any integer from 1 to 9; for clarity in the database, anything != 10 will be trimmed to its single-digit form

sprnkDropdown - A dropdown for input of sprinkler precentage coverage of a location was requested instead of validation of the broker's submission; take that input and jiggle the ethernet cord to make it function with ABBYY's dropdown function that only works with checkmarks

yearBuilt - We can understand years like '80 and '99 to mean 1980 and 1999 respectively, but these need to be expanded for the database