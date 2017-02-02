string emailSubject = Context.Field("CtrlNum").Text;
FCTools.ShowMessage(emailSubject);  

int openBracket = emailSubject.IndexOf('[');
int closeBracket = emailSubject.IndexOf(']');

if (emailSubject == null)
{
  FCTools.ShowMessage("Subject length = 0 chars!");  
}
else
{
  string ctrlNum = emailSubject.Substring(openBracket + 1, (closeBracket - openBracket) - 1); 
    Context.Field("CtrlNum").Value = ctrlNum;
}