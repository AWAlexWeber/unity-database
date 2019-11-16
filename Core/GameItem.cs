using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// GameItem is just a core item that all 'items' must have
// The entry and entry type are duplicated across DatabaseItem
namespace GameEngine {
    public class GameItem : MonoBehaviour 
    {
        public int typeID;
        public string typeName;
    }
}