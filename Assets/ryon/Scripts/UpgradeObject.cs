using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Upgrades/Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string description;
    public int value;
}
