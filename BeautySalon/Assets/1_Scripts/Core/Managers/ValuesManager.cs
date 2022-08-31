using UI;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ValuesManager", menuName = "Managers/ValuesManager")]
    public class ValuesManager : BaseManager
    {
        private int money;

        public void AddMoney(int value)
        {
            money += value;

            UIManager.Instance.GetWindow<UIWindow>().ChangeMoneyText(money);
        }
    }
}