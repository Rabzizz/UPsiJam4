
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

    public UnityEvent<ItemTypes> OnElementSelected; //ugly but well...

    private void Start()
    {
        inputSelectCCTV.action.started += (e) => SelectElement(ItemTypes.CCTV); // TODO enum
        inputSelectTrap.action.started += (e) => SelectElement(ItemTypes.Trap);
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
        MoneyLabel.text = money + "CHF";
    }
}
