using UnityEngine;
using System;

public class ShopController : MonoBehaviour
{
    public const int One1000WaterPrice = 1;

    private EShowAdFor _showAdFor = EShowAdFor.key;



    public EShowAdFor ShowAdFor
    {
        get => _showAdFor;
        set => _showAdFor = value;
    }




    public event Action<int> OnBuyWater;
    public event Action<int, bool> OnBuyTimeEnergy;
    public event Action<bool> OnBuyX2Water;



    public void BuyWater(int count)
    {
        OnBuyWater.Invoke(count);
    }

    public void BuyTimeEnergy(EShopTimeEnergyPriceInCents count)
    {
        float price = (float)count / 100f;

#if UNITY_EDITOR
        bool succsesful = true;
#else
        bool succsesful = false;
#endif

        switch (count)
        {
            case EShopTimeEnergyPriceInCents.fifty:
                OnBuyTimeEnergy.Invoke(50, succsesful);
                break;

            case EShopTimeEnergyPriceInCents.two_hundred_fifty:
                OnBuyTimeEnergy.Invoke(250, succsesful);
                break;

            case EShopTimeEnergyPriceInCents.one_thousand:
                OnBuyTimeEnergy.Invoke(1000, succsesful);
                break;

            case EShopTimeEnergyPriceInCents.five_thousand:
                OnBuyTimeEnergy.Invoke(5000, succsesful);
                break;

            default:
                throw new NotImplementedException();
        }
    }

    public void BuyX2Water()
    {
#if UNITY_EDITOR
        bool succsesful = true;
#else
        bool succsesful = false;
#endif

        OnBuyX2Water(succsesful);
    }



    public enum EShopTimeEnergyPriceInCents
    {
        fifty = 49, two_hundred_fifty = 199, one_thousand = 699, five_thousand = 2999, 
    }



    public enum EShowAdFor
    {
        key, timeEnergy, fuel, toolBox, smallChest
    }
}