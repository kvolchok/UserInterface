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

    private void Awake()
    {
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
    }
    
    private void SetGems(int value)
    {
        _gems = value;
        _gemsValueChanged?.Invoke(_gems);
    }
}