
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// 1. Mettre en évidence le choix à poser
// 2. indiquer les prix
public class UIController : MonoBehaviour
{
    public InputActionReference inputSelectCCTV;
    public InputActionReference inputSelectTrap;

    public TextMeshProUGUI MoneyLabel;

    public Image toolbar;

    public List<Sprite> sprites = new List<Sprite>();

    public event Action<ItemTypes> OnElementSelected;

    public TextMeshProUGUI timerLabel;
    public TextMeshProUGUI daysLabel;
    

    private void Start()
    {
        inputSelectCCTV.action.started += (e) => SelectElement(ItemTypes.CCTV); // TODO enum
        inputSelectTrap.action.started += (e) => SelectElement(ItemTypes.Trap);
        GameManager.Instance.gameObject.GetComponent<BuyManager>().OnMoneyUpdated.AddListener(UpdateMoney);
    }

    public void SelectElement(ItemTypes selectedItem)
    {
        if (sprites.Count > (int)selectedItem)
        {
            toolbar.sprite = sprites[(int)selectedItem];

            OnElementSelected.Invoke(selectedItem);
        }
    }

    public void UpdateMoney(int money)
    {
        MoneyLabel.text = "*" +money;
    }

    public void UpdateDays(int days)
    {
        daysLabel.text = "Days" + days;
    }

    public void UpdateTimer(float timeInSecond)
    {
        int minutes = (int)timeInSecond/60;
        int seconds = (int)(((timeInSecond / 60) - (int)minutes)*60);
        timerLabel.text = $"{minutes}:{seconds}";
    }
}
