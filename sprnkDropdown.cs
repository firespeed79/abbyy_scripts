string context = Context.Text; //get the fields new value
int end = context.Length - 1; //reference place value of the fields last character
int sprnk; //this will hold the output of our string to int conversion
string[] sprnkType = new string[4];
sprnkType[0] = "None";
sprnkType[1] = "Less Than";
sprnkType[2] = "Greater Than";
sprnkType[3] = "100";
for(int i = 0 ; i < sprnkType.Length; i++)
{
    if(Context.Field(sprnkType[i]).Value != (object)0)
        Context.Field(sprnkType[i]).Value = 0;
}
//This Script runs everytime the field value changes. if any dropdown value is active we must
//deactive it to prevent multiple selections and to allow a new value to be set
if(context == "")
{
   FCTools.ShowMessage("Warning: Sprinkler not verified");
    Context.NeedVerification = true;  
   Context.Field(sprnkType[0]).Value = 1;
}else if(int.TryParse(context, out sprnk))
{
    if(sprnk <= 0)
    {
        Context.Field(sprnkType[0]).Value = 1;
        Context.Field(sprnkType[1]).Value = 0;
        Context.Field(sprnkType[2]).Value = 0;
        Context.Field(sprnkType[3]).Value = 0;
    }
    else if(sprnk <= 50)
        Context.Field(sprnkType[1]).Value = 1;
    else if (sprnk >= 100)
        Context.Field(sprnkType[3]).Value = 1;
    else if(sprnk > 50)
        Context.Field(sprnkType[2]).Value = 1;
}
else if(context[end] == '%')
{
    Context.Field("Sprnk").Value = context.Substring(0,context.Length - 1);
    if(int.TryParse(context.Substring(0,context.Length - 1), out sprnk))
    {
        if(sprnk <= 0)
        {
            Context.Field(sprnkType[0]).Value = 1;
            Context.Field(sprnkType[1]).Value = 0;
            Context.Field(sprnkType[2]).Value = 0;
            Context.Field(sprnkType[3]).Value = 0;
        }
        else if(sprnk <= 50)
            Context.Field(sprnkType[1]).Value = 1;
        else if (sprnk >= 100)
            Context.Field(sprnkType[3]).Value = 1;
        else if(sprnk > 50)
            Context.Field(sprnkType[2]).Value = 1;
    }
    else
    {
        Context.Field(sprnkType[0]).Value = 1;
       FCTools.ShowMessage("Warning: Sprinkler Not Recognized");
        Context.NeedVerification = true;
     
    }
    
}
else
{
   
    Context.Field(sprnkType[0]).Value = 1;
    FCTools.ShowMessage("Warning: Sprinkler Not Recognized");
    Context.NeedVerification = true;
     
}
