using UnityEngine;

public class PrefsManager
{
    private const string BOUGHT_HEROES = "BoughtHeroes";
    private const string SELECTED_HERO = "SelectedHero";
    private const string MONEY = "Money";
    private const string GEMS = "Gems";
    
    private char[] _temp;
    private string _boughtHeroes;

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
        for (var i = 1; i < heroes.Length; i++)
        {
            heroes[i].ChangeAvailability(false);
        }
        
        
        _temp = new char[heroes.Length];
        for (var i = 0; i < heroes.Length; i++)
        {
            if (heroes[i].IsAvailable)
            {
                _temp[i] = '1';
            }
            else
            {
                _temp[i] = '0';   
            }
        }

        if (!PlayerPrefs.HasKey(BOUGHT_HEROES))
        {
            return;
        }

        _boughtHeroes = PlayerPrefs.GetString(BOUGHT_HEROES);

        for (var i = 0; i < _boughtHeroes.Length; i++)
        {
            heroes[i].ChangeAvailability(_boughtHeroes[i] == '1');
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