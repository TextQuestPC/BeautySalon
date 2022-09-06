using UnityEngine;
using UnityEngine.UI;
using ObjectsOnScene;
using Data;
using Core;

namespace UI
{
    public class StorageWindow : Window
    {
        [HideInInspector]
        public delegate void ChooseItem();
        public event ChooseItem AfterChooseItem;

        [SerializeField] private GameObject substrateObject;
        [SerializeField] private ItemChooseButton[] itemButtons;

        public void ShowButtons(TypeItem[] typeItems)
        {
            substrateObject.SetActive(true);

            for (int i = 0; i < typeItems.Length; i++)
            {
                DataItemUI data = BoxManager.GetManager<DataManager>().GetDataItemUI(typeItems[i]);

                itemButtons[i].gameObject.SetActive(true);
                itemButtons[i].SetDataItemUI(this, typeItems[i], data.SpriteItem);
            }
        }

        public void OnClickButtonItem(TypeItem typeItem)
        {
            BoxManager.GetManager<GameManager>().PlayerTryGetItem(typeItem);

            Hide();
        }

        protected override void AfterHide()
        {
            substrateObject.SetActive(false);

            foreach (var button in itemButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}