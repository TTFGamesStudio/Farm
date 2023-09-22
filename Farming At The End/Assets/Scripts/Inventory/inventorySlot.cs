using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct inventorySlot
{
    public slotType type;
    public item i;
}

public enum slotType
{
    item,
    tool
}
