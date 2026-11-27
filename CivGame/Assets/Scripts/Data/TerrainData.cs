using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Civ/Terrain")]
public class TerrainData : ScriptableObject
{
    public string displayName = "Terrain Name";
    public Color color = Color.green;

    public ResourceQuantity[] resources;

    public float maxHeight = 0.5f;
    public bool canBuildCity;
}

[Serializable]
public class ResourceQuantity
{
    public ResourceData resource;
    public int Quantity;
}
