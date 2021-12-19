using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager 
{

    public static OwnedItem OnOwnedItem = new OwnedItem();
    
    /// <summary>
    ///  Event based on owned item type
    ///  to inform subscribed scripts
    ///  FinancialType is coin or gem
    ///  GameObject is clicked button
    /// </summary>
    public class OwnedItem : UnityEvent<PublicHardCodeds.FinancialTypes,GameObject>
    { 
    
    }
}
