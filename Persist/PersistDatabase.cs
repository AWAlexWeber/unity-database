// PersistDatabase that will be a game object to reference the database from during gameplay
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Database {

    public class PersistDatabase {
        private Dictionary<string, DatabaseEntry> database;
        private StaticTypeIDMap typeIDMap;

        public PersistDatabase(Dictionary<string, DatabaseEntry> inputDatabase, StaticTypeIDMap typeIDMap) {
            this.database = inputDatabase;
            this.typeIDMap = typeIDMap;
        }

    }
}