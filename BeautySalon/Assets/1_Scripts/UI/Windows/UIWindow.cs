using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIWindow : Window
    {
        [SerializeField] private Text moneyText;

        public void ChangeMoneyText(int newValue)
        {
            moneyText.text = newValue.ToString();
        }
    }
}