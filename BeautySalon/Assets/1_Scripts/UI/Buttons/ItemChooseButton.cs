using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObjectsOnScene;
using Data;

namespace UI
{
    public class ItemChooseButton : MyButton
    {
        private StorageWindow storageWindow;
        private Image imageItem;
        private TypeItem typeItem;

        protected override void OnClickButton()
        {
            storageWindow.OnClickButtonItem(typeItem);
        }

        protected override void AfterAwake()
        {
            imageItem = GetComponent<Image>();
        }

        public void SetDataItemUI(StorageWindow storageWindow, TypeItem typeItem, Sprite sprite)
        {
            this.storageWindow = storageWindow;
            this.typeItem = typeItem;
            imageItem.sprite = sprite;
        }
    }
}
