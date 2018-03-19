using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {

    /* Monosingleton is a class that creates a monostate 
     * to support n instanceswhere n is a fixed number
    */

    private static T instance = null;
    public static T Instance {
        get
        {
            if(instance == null)
            {
                instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                instance.Init();
            }

            return instance;
        }
    }

    public virtual void Init() { }

    private void Awake()
    {
        if (instance == null)
            instance = this as T;
        Init();
    }
}
