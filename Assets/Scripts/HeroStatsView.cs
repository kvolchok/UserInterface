using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroStatsView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _descripton;
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private TextMeshProUGUI _level;
    [SerializeField]
    private TextMeshProUGUI _currentLevelPoints;
    [SerializeField]
    private Slider _levelPoints;
    [SerializeField]
    private Slider _health;
    [SerializeField]
    private Slider _attack;
    [SerializeField]
    private Slider _defense;
    [SerializeField]
    private Slider _speed;
    [SerializeField]
    private TextMeshProUGUI _price;
    
    public void ShowHeroStats(HeroSettings hero)
    {
        _name.text = hero.Name;
        _descripton.text = hero.Name;
        _icon.sprite = hero.Icon;
        _level.text = hero.Level;
        _currentLevelPoints.text = hero.CurrentLevelPoints.ToString();
        _levelPoints.value = hero.CurrentLevelPoints;
        _health.value = hero.Health;
        _attack.value = hero.Attack;
        _defense.value = hero.Defense;
        _speed.value = hero.Speed;
        _price.text = hero.Price.ToString();
    }
}