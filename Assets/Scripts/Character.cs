using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;

    public Character()
    {
        Reset();
    }

    public Character(string name)
    {
        Reset();
        this.name = name;
    }

    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Hero: {0} - EXP: {1}", this.name, this.exp);
    }

    private void Reset()
    {
        this.name = "Not assigned";
        this.exp = 0;
    }
}
