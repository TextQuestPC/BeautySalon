using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIWindow : Window
    {
        [SerializeField] private Text moneyText;

        public void ChangeMoneyText(int newValue)
        {
            moneyText.GetComponent<Animator>().SetTrigger(TypeAnimation.Change.ToString());
            moneyText.text = newValue + "$";
        }
    }
}