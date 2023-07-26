using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> _moneyValueChanged;
    [SerializeField]
    private UnityEvent<int> _gemsValueChanged;

    [SerializeField]
    private int _money;
    [SerializeField]
    private int _gems;

    private PrefsManager _prefsManager;

    public void Initialize(PrefsManager prefsManager)
    {
        _prefsManager = prefsManager;

        if (_prefsManager.HasKeyMoney())
        {
            _money = _prefsManager.GetMoney();        
        }
        
        if (_prefsManager.HasKeyGems())
        {
            _gems = _prefsManager.GetGems();        
        }
        
        SetMoney(_money);
        SetGems(_gems);
    }

    public bool BuyHero(int price)
    {
        if (_money < price)
        {
            return false;
        }

        _money -= price;
        SetMoney(_money);
        return true;
    }

    private void SetMoney(int value)
    {
        _money = value;
        _moneyValueChanged?.Invoke(_money);
        _prefsManager.SaveMoney(_money);
    }
    
    private void SetGems(int value)
    {
        _gems = value;
        _gemsValueChanged?.Invoke(_gems);
        _prefsManager.SaveGems(_gems);
    }
}