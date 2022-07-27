using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourcesData", menuName = "ScriptableObjects/Create Resources Data")]
public class ResourceData : ScriptableObject
{
    [Serializable]
    public struct WeaponConfig
    {
        public string Name;
        public int Cost;
    }

    public WeaponConfig[] WeaponCosts;
}
