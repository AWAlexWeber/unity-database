using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Database {
    
    // This function is the function that will load all of our static data from the jsons files in the Database folder
    public class DatabaseLoad : MonoBehaviour
    {
        public string typeIDMapTypeID = "1";
        public string databasePath = "/Database/";
        public string bootstrapName = "bootstrap.json";

        public void Start() {
            // Loading our database json
            Dictionary<string, DatabaseEntry> persistData = this.loadStart();
        
            // Completed loading, creating our PersistDatabase and loading to the menu screen
            this.buildPersistDatabase(persistData);

            // Transitioning to main menu screen
            this.loadEnd();
            
        }

        private string readFromFile(string path) {
            string fullPath = "Assets" + path;

            StreamReader reader = new StreamReader(fullPath);
            string output = reader.ReadToEnd();
            reader.Close();
            return output;
        }

        // Function that starts the loading process, returning a dictionary where the key is the string/integer of the typeID.
        private Dictionary<string, DatabaseEntry> loadStart() {
            // Building a new container dictionary
            Dictionary<string, DatabaseEntry> outputDictionary = new Dictionary<string, DatabaseEntry>();

            // Loading the bootstrap list
            BootstrapLoadData bootstrapList = new BootstrapLoadData();
            try {
                bootstrapList = JsonUtility.FromJson<BootstrapLoadData>(this.readFromFile(databasePath + bootstrapName));

                // Building database entry
                DatabaseEntry bootstrapListEntry = new DatabaseEntry(bootstrapList, bootstrapList.GetType());
                outputDictionary.Add(bootstrapList.getTypeID().ToString(), bootstrapListEntry);
            }
            catch (UnityException e) {
                Debug.LogError("Error loading database bootstrap! Failing...");
                Debug.LogError(e);
                return null;
            }

            // Bootstrap has been loaded, proceeding with the loading of all other data
            //int count = 0;
            foreach (string path in bootstrapList.databaseList) {
                //Debug.Log("Loading " + count.ToString() + " of " + bootstrapList.databaseList.Count.ToString() + ": " + path);

                // Loading the ship JSON
                if (path.Equals("ship.json")) {
                    StaticShipLoadData shipData = JsonUtility.FromJson<StaticShipLoadData>(this.readFromFile(databasePath + path));
                    DatabaseEntry shipDataEntry = new DatabaseEntry(shipData, shipData.GetType());
                    outputDictionary.Add(shipData.getTypeID().ToString(), shipDataEntry);
                    
                    foreach (StaticShipData std in shipData.ships) {
                        DatabaseEntry localShipData = new DatabaseEntry(std, std.GetType());
                        outputDictionary.Add(std.getTypeID().ToString(), localShipData);
                    }
                }

                if (path.Equals("typeID.json")) {
                    StaticTypeIDMap typeData = JsonUtility.FromJson<StaticTypeIDMap>(this.readFromFile(databasePath + path));
                    DatabaseEntry typeDataEntry = new DatabaseEntry(typeData, typeData.GetType());
                    outputDictionary.Add(typeData.getTypeID().ToString(), typeDataEntry);
                }
            }

            return outputDictionary;
        }

        private void buildPersistDatabase(Dictionary<string, DatabaseEntry> inputDictionary) {
            PersistDatabase database = new PersistDatabase(inputDictionary, (Database.StaticTypeIDMap)inputDictionary[typeIDMapTypeID].getObject());
        }

        private System.Type getTypeFromString(string input) {
            // Not using built-in JSON loading, instead doing this manually
            // Replace this ASAP
            int typeNameStart = input.IndexOf("\"typeName\":") + 13;
            int typeNameEnd = input.IndexOf("\"", typeNameStart);

            // Loading type in
            string classType = input.Substring(typeNameStart, typeNameEnd - typeNameStart);
            classType = "Database."+classType;
            System.Type returnType = System.Type.GetType(classType, true);
            return null;
        }

        private void loadEnd() {
            Destroy(this);
        }
    }
}