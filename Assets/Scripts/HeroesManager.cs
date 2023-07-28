using System;
using UnityEngine;

[Serializable]
public class HeroesManager : MonoBehaviour
{
    [field:SerializeField]
    public HeroSettings[] Heroes { get; private set; }
    
    private char[] _boughtHeroesArray;

    private void Awake()
    {
        _boughtHeroesArray = new char[Heroes.Length];
    }

    public void UpdateBoughtHeroes()
    {
        for (var i = 1; i < Heroes.Length; i++)
        {
            Heroes[i].ChangeAvailability(false);
        }

        var boughtHeroes = PrefsManager.GetBoughtHeroes();

        if (string.IsNullOrEmpty(boughtHeroes))
        {
            return;
        }
        
        for (var i = 0; i < Heroes.Length; i++)
        {
            Heroes[i].ChangeAvailability(boughtHeroes[i] == '1');
        }
    }

    public void SaveBoughtHeroes()
    {
        for (var i = 0; i < Heroes.Length; i++)
        {
            if (Heroes[i].IsAvailable)
            {
                _boughtHeroesArray[i] = '1';
            }
            else
            {
                _boughtHeroesArray[i] = '0';
            }
        }

        var boughtHeroes = string.Concat(_boughtHeroesArray);
        PrefsManager.SaveBoughtHeroes(boughtHeroes);
    }
}