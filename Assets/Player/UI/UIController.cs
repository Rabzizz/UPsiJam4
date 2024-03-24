
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

    public UnityEvent<int> OnElementSelected; //ugly but well...

    private void Start()
    {
        inputSelectCCTV.action.started += (e) => SelectElement(1); // TODO enum
        inputSelectTrap.action.started += (e) => SelectElement(2);
    }

    public void SelectElement(int index)
    {
        if (sprites.Count > index - 1)
        {
            toolbar.sprite = sprites[index - 1];

            OnElementSelected.Invoke(index);
        }
    }

    public void UpdateMoney(int money)
    {
        MoneyLabel.text = money + "CHF";
    }
}
