using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Ludiq;

public class DictionaryBolt : MonoBehaviour
{
    public Dictionary<string, int> myDictionary;
    public AotDictionary aotDictionary;
    int minimumValue = 100;
    public void AddToDictionary(string key,int value)
    {
        myDictionary.Add(key, value);
    }

    public int GetDictionaryBoltMinimumValue(AotDictionary dictionary)
    {
        foreach(int value in dictionary.Values)
        {
            if(minimumValue > value)
            {
                minimumValue = value;
            }
        }
        return minimumValue;
    }



}