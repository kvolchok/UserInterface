using UnityEngine;

public class LobbyScreen : MonoBehaviour
{
    [SerializeField]
    private HeroStatsView _heroStatsView;
    
    private HeroLoader _heroLoader;

    public void Initialize(HeroLoader heroLoader)
    {
        _heroLoader = heroLoader;
    }
    
    public void ShowScreen(HeroSettings[] heroes, int heroIndex)
    {
        var currentHero = heroes[heroIndex];
        _heroStatsView.ShowHeroStats(currentHero);
        _heroLoader.ShowHero(currentHero);
    }
}