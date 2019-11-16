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
    class StaticShipLoadData : DatabaseItem {
        public List<StaticShipData> ships;
    }

    [System.Serializable]
    public class StaticShipData : DatabaseItem {
        public string shipName;
        public int numRooms;
        public List<StaticShipRooms> rooms;
        public StaticShipLayout shipLayout;
    }

    [System.Serializable]
    public class StaticShipRooms : DatabaseItem {
        List<StaticRoomDimension> roomDims;
    }

    [System.Serializable]
    public class StaticRoomDimension : DatabaseItem {
        int width;
        int height;
    }

    [System.Serializable]
    public class StaticShipLayout : DatabaseItem {
        int scienceModules;
        int weaponModules;
        int engineerModules;
    }

    [System.Serializable]
    public class StaticTypeIDMap : DatabaseItem {
        public Dictionary<string, int> typeIDMap;

        public int getTypeIDFromString(string typeName) {
            return this.typeIDMap[typeName];
        }
    }
}