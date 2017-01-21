using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ReportToken : MonoBehaviour {
    
    public EffectType type;

    public Dictionary<EffectScale, string> texts = new Dictionary<EffectScale, string>();

    public void Start() {
        //XDocument xmlDoc = XDocument.Load("XML/Data.xml");
        //IEnumerable<XElement> elements = from element in xmlDoc.Descendants() select element;
    }
    
}
