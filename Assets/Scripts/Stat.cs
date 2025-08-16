using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField] private int baseValue;

    public List<int> modifiers;
    public int getValue()
    {
        int finalValue = baseValue;
        foreach (int modifier in modifiers)
        {
            finalValue += modifier;
        }
        return finalValue;
    } 
    public void addModifiers(int _modifier)
    {
        modifiers.Add( _modifier );
    }

    public void removeModifiers(int _modifier)
    {
        modifiers.RemoveAt(_modifier);
    }
}
