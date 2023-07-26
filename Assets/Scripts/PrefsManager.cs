using UnityEngine;

public class PrefsManager
{
    private readonly char[] _temp;
    
    private const string BOUGHT_HEROES = "BoughtHeroes";
    private const string SELECTED_HERO = "SelectedHero";
    private const string MONEY = "Money";
    private const string GEMS = "Gems";
    
    private string _boughtHeroes;

    public PrefsManager(int heroesCount)
    {
        _temp = new char[heroesCount];
    }
    
    public void SaveBoughtHero(int heroIndex)
    {
        if (heroIndex >= 0 && heroIndex < _temp.Length)
        {
            _temp[heroIndex] = '1';
        }

        _boughtHeroes = string.Concat(_temp);
        PlayerPrefs.SetString(BOUGHT_HEROES, _boughtHeroes);
        PlayerPrefs.Save();
    }

    public void UpdateBoughtHeroes(HeroSettings[] heroes)
    {
        if (!PlayerPrefs.HasKey(BOUGHT_HEROES))
        {
            return;
        }
        
        _boughtHeroes = PlayerPrefs.GetString(BOUGHT_HEROES);

        for (var i = 0; i < _boughtHeroes.Length; i++)
        {
            if (_boughtHeroes[i] == '1')
            {
                heroes[i].MarkAsAvailable();
            }
        }
    }

    public void SaveSelectedHeroIndex(int heroIndex)
    {
        PlayerPrefs.SetInt(SELECTED_HERO, heroIndex);
        PlayerPrefs.Save();
    }

    public int GetSelectedHeroIndex()
    {
        return PlayerPrefs.HasKey(SELECTED_HERO) ? PlayerPrefs.GetInt(SELECTED_HERO) : 0;
    }

    public bool HasKeyMoney()
    {
        return PlayerPrefs.HasKey(MONEY);
    }
    
    public bool HasKeyGems()
    {
        return PlayerPrefs.HasKey(GEMS);
    }
    
    public void SaveMoney(int money)
    {
        PlayerPrefs.SetInt(MONEY, money);
        PlayerPrefs.Save();
    }
    
    public void SaveGems(int gems)
    {
        PlayerPrefs.SetInt(GEMS, gems);
        PlayerPrefs.Save();
    }

    public int GetMoney()
    {
        return PlayerPrefs.GetInt(MONEY);
    }
    
    public int GetGems()
    {
        return PlayerPrefs.GetInt(GEMS);
    }
}