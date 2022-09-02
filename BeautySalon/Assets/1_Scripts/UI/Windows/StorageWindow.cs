using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObjectsOnScene;

namespace UI
{
    public class StorageWindow : Window
    {
        [HideInInspector]
        public delegate void ChooseItem();
        public event ChooseItem AfterChooseItem;

        [SerializeField] private Button[] itemButtons;

        public void ShowButtons(TypeItem[] typeItems)
        {
            foreach (var typeItem in typeItems)
            {

            }
        }
    }
}