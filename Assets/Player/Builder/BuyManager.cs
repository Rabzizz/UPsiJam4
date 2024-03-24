using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BuyManager : MonoBehaviour
{
    public InputActionReference inputBuild;

    public int startMoney = 300;

    public int priceCCTV = 2;
    public int priceTrap = 5;
    public int priceDoor = 8;

    int currentMoney;

    public UnityEvent<int> OnMoneyUpdated;

    ItemTypes selectedItem = ItemTypes.CCTV;

    public BuilderController builder;

    private void Start()
    {
        inputBuild.action.canceled += (e) => BuyItem();

        ResetMoney();
    }

    public void Update()
    {
        selectedItem = (ItemTypes) builder.selectedItem;
    }

    public void ResetMoney()
    {
        currentMoney = startMoney;

        OnMoneyUpdated?.Invoke(currentMoney);
    }

    // --------------- Select Item --------------- //

    public void SelectItem(ItemTypes selectedItem)
    {
        this.selectedItem = selectedItem;
    }

    public void BuyItem()
    {
        switch(selectedItem)
        {
            case ItemTypes.CCTV:
                BuyCCTV();
                break;
            case ItemTypes.Trap:
                BuyTrap();
                break;
        }
    }

    // --------------- Buy Sell --------------- //

    public void BuyCCTV()
    {
        if (currentMoney - priceCCTV > 0)
            currentMoney -= priceCCTV;
        else
            Debug.Log("CCTV too expensive");


        OnMoneyUpdated?.Invoke(currentMoney);
    }

    public void SellCCTV()
    {
        currentMoney += priceCCTV;

        OnMoneyUpdated?.Invoke(currentMoney);
    }

    public void BuyTrap()
    {
        if (currentMoney - priceTrap > 0)
            currentMoney -= priceTrap;
        else
            Debug.Log("Trap too expensive");

        OnMoneyUpdated?.Invoke(currentMoney);
    }

    public void SellTrap()
    {
        currentMoney += priceTrap;

        OnMoneyUpdated?.Invoke(currentMoney);
    }

    public void BuyDoor()
    {
        if (currentMoney - priceDoor > 0)
            currentMoney -= priceDoor;
        else
            Debug.Log("Door too expensive");

        OnMoneyUpdated?.Invoke(currentMoney);
    }

    public void SellDoor()
    {
        currentMoney += priceDoor;

        OnMoneyUpdated?.Invoke(currentMoney);
    }
}
