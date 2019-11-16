using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Base class for representing a database entry
public class DatabaseEntry
{
    private object entry;
    private Type entryType;

    // Constructor uses an object and type to declare the database entry
    // This will help anyone accessing this database entry infer what is happenin
    public DatabaseEntry (object entry, Type entryType) {
        this.entryType = entryType;
        this.entry = entry;
    }

    public Type getEntryType() {
        return this.entryType;
    }

    public bool isEquals(Type compareType) {
        return compareType == this.entryType;
    }

    public object getObject() {
        return this.entry;
    }
}
