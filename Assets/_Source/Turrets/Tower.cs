using System;
using UnityEngine;
[Serializable]
public class Tower
{
    public string Name;
    public int Cost;
    public GameObject Prefab;

    public Tower (string name, int cost, GameObject prefab)
    {
        Name = name;
        Cost = cost;
        Prefab = prefab;
    }
}
