using UnityEngine;

[CreateAssetMenu(fileName = "HeroSettings", menuName = "ScriptableObject/HeroSettings", order = 50)]
public class HeroSettings : ScriptableObject
{
    [field:SerializeField]
    public string Name { get; private set; }
    [field:SerializeField]
    public Sprite Icon { get; private set; }
    [field:SerializeField]
    public string Level { get; private set; }
    [field:SerializeField]
    public int CurrentLevelPoints { get; private set; }
    [field:SerializeField]
    public int Health { get; private set; }
    [field:SerializeField]
    public int Attack { get; private set; }
    [field:SerializeField]
    public int Defense { get; private set; }
    [field:SerializeField]
    public int Speed { get; private set; }
    [field:SerializeField]
    public int Price { get; private set; }
    [field:SerializeField]
    public GameObject Prefab { get; private set; }
    [field:SerializeField]
    public bool IsAvailable { get; private set; }
    
    public bool IsLastSelected { get; private set; }

    public void ChangeAvailability(bool isAvailable)
    {
        IsAvailable = isAvailable;
    }
    
    public void ChangeLastSelectedState(bool isLastSelected)
    {
        IsLastSelected = isLastSelected;
    }
}