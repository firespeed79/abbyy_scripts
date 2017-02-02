string protcl = Context.Text;

if(protcl.Length == 2 && protcl != "10")
{
    
    protcl = protcl.Substring(1,1);  
}
else if (protcl.Length< 1)
{
    FCTools.ShowMessage("Could not Validate Protcl");
}

Context.Text = protcl;