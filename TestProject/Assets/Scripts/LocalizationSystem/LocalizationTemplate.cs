using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocalizationTemplate 
{
    // to show at Labelled object
    public string label { get; set; }
    // Labels text
    public string text { get; set; }
    // to detect if its Right to Left
    public string RTL { get; set; }

}
