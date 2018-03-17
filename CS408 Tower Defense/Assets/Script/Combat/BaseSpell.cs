using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpell : MonoBehaviour {

    protected float cooldown;
    protected float lastCast;

    public virtual void Cast()
    {
        if (!Requirement())
        {
            return;
        }

        Action();
        lastCast = Time.time;
    }

    public float GetRemainingCD()
    {
        float remaining = cooldown - (Time.time - lastCast);
        if((int)remaining <= 0)
        {
            remaining = 0;
        }
        return (int)remaining;
    }

    public string GetRemainingCDText()
    {
        string text = GetRemainingCD().ToString();
        if(GetRemainingCD() == 0)
        {
            text = "OK";
        }
        return text;
    }

    public virtual bool Requirement()
    {
        if (Time.time - lastCast <= cooldown)
        {
            return false;
        }
        return true;
    }
    
    public virtual void Action()
    {
        Debug.Log("Casting " + this.ToString());
    }
}
