using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatabaseItem
{
    private int typeID;
    private string typeName;

    public int getTypeID() {
        return this.typeID;
    }
}
