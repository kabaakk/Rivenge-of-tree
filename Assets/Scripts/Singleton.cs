using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The base abstract Singleton class.
/// </summary>
public abstract class Singleton<T>: MonoBehaviour where T: Singleton<T> {
		
    private static T sInstance = null;
		
    public static T instance {
        get {
            return sInstance;
        }
    }
		
    protected virtual void Awake() {
       
        sInstance = (T)this;
    }
}
