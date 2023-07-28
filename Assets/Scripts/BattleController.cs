using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField]
    private Transform _heroRoot;

    private HeroLoader _heroLoader;

    private void Awake()
    {
        _heroLoader = FindObjectOfType<HeroLoader>();
        _heroLoader.SetHeroRoot(_heroRoot);
        _heroLoader.HeroCamera.SetActive(false);
        _heroLoader.HeroLight.SetActive(false);
    }
}