using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Database {
    [System.Serializable]
    public class DatabaseItem
    {
        public int typeID;
        public string typeName;

        public int getTypeID() {
            return this.typeID;
        }
    }
}