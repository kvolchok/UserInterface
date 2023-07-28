using UnityEngine;

public class LobbyScreen : MonoBehaviour
{
    [SerializeField]
    private HeroStatsView _heroStatsView;
    
    private HeroLoader _heroLoader;
    private HeroSettings _currentHero;

    public void Initialize(HeroLoader heroLoader)
    {
        _heroLoader = heroLoader;
    }
    
    public void ShowScreen(HeroSettings[] heroes, int heroIndex)
    {
        _currentHero = heroes[heroIndex];
        _heroStatsView.ShowHeroStats(_currentHero);
        _heroLoader.ShowHero(_currentHero);
    }
}