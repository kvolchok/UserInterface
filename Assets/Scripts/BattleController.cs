using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField]
    private HeroLoader _heroLoader;
    [SerializeField]
    private HeroesManager _heroesManager;

    private void Awake()
    {
        var lastSelectedHeroIndex = PrefsManager.GetSelectedHeroIndex();
        var currentHero = _heroesManager.GetCurrentHero(lastSelectedHeroIndex);
        _heroLoader.ShowHero(currentHero);
    }
}