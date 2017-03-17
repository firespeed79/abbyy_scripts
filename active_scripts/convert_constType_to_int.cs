using System.Collections.Generic;

// Create dictionary of as many known/seen construction type input values as possible
Dictionary<string, int> isoType = new Dictionary<string, int>();
/*
 * ISO Construction Type: Modified Fire Resistive
 * ISO Number: 5
 * IMS ID: 6
 */
    isoType.Add("mfr", 6);
    isoType.Add("modified fire resistive", 6);
/*
 * ISO Construction Type: Frame
 * ISO Number: 1
 * IMS ID: 5
 */  
    isoType.Add("brick frame", 5);
    isoType.Add("frame", 5);
    isoType.Add("brick veneer", 5);
    isoType.Add("frame block", 5);
    isoType.Add("heavy timber", 5);
    isoType.Add("masonry frame", 5);
    isoType.Add("masonry wood", 5);
    isoType.Add("metal building", 5);
    isoType.Add("sheet metal", 5);
    isoType.Add("wood", 5);
    isoType.Add("metal/aluminum", 5);
/*
 * ISO Construction Type: Joisted Masonry
 * ISO Number: 2
 * IMS ID: 4
 */
    isoType.Add("brick", 4);
    isoType.Add("brick steel", 4);
    isoType.Add("cd", 4);
    isoType.Add("cement", 4);
    isoType.Add("concrete" , 4);
    isoType.Add("masonry" , 4);
    isoType.Add("masonry timbre", 4);
    isoType.Add("stone", 4);
    isoType.Add("stucco", 4);
    isoType.Add("joist masonry", 4);
    isoType.Add("tilt-up", 4);
    isoType.Add("jm", 4);
    isoType.Add("joisted masonry", 4);
    isoType.Add("joisted mason", 4);
    isoType.Add("j/masonry", 4);
/*
 * ISO Construction Type: Non-Combustible
 * ISO Number: 3
 * IMS ID: 3
 */
    isoType.Add("cb", 3);
    isoType.Add("concrete block", 3);
    isoType.Add("icm", 3);
    isoType.Add("iron clad metal", 3);
    isoType.Add("steel concrete", 3);
    isoType.Add("steel cmu", 3);
    isoType.Add("non-comb.", 3);
    isoType.Add("non-comb", 3);
    isoType.Add("pole", 3);
    isoType.Add("non-combustible", 3);
    isoType.Add("non-combustib", 3);
/*
 * ISO Construction Type: Masonry Non-Combustible
 * ISO Number: 4
 * IMS ID: 2
 */
    isoType.Add("cement block", 2);
    isoType.Add("cbs", 2);
    isoType.Add("mnc", 2);
    isoType.Add("ctu", 2);
    isoType.Add("concrete tilt-up", 2);
    isoType.Add("pre-cast com", 2);
    isoType.Add("reinforced concrete", 2);
    isoType.Add("masonry nc", 2);
    isoType.Add("masonry non-c", 2);
    isoType.Add("masonry non-combustible", 2);
/*
 * ISO Construction Type: Fire Resistive
 * ISO Number: 6
 * IMS ID: 1
 */
    isoType.Add("aaa", 1);
    isoType.Add("fire resistive", 1);
    isoType.Add("cinder block", 1);
    isoType.Add("steel", 1);
    isoType.Add("steel frame", 1);
    isoType.Add("superior", 1);
    isoType.Add("w/r", 1);
    isoType.Add("fire resist", 1);
    isoType.Add("wind resistive", 1);
    isoType.Add("fire resistiv", 1);
Using     isoType.Add("fr", 1);
    
string co

nstType = Context.Text;
foreach (KeyValuePair<string, int> pair in isoType)
{
    if (constType.ToLower() == pair.Key)
    {  
       Context.Text = pair.Value.ToString();
    }
}
