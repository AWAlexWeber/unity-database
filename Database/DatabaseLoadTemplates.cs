using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Set of database entries containing the base amount of information required to function
namespace Database {
    
    // Serializable object that will contain the list of all database files to load
    [System.Serializable]
    class BootstrapLoadData : DatabaseItem {
        public List<string> databaseList;
    }

    [System.Serializable]
    class ShipLoadData : DatabaseItem {
        public List<ShipData> ships;
    }

    [System.Serializable]
    public class ShipData : DatabaseItem {
        public string shipName;
        public int numRooms;
        public List<ShipRooms> rooms;
    }

    [System.Serializable]
    public class ShipRooms : DatabaseItem {
        List<RoomDimension> roomDims;
    }

    [System.Serializable]
    public class RoomDimension : DatabaseItem {
        int width;
        int height;
    }
}