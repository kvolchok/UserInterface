using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [field:SerializeField]
    public HeroSettings[] Heroes { get; private set; }
}