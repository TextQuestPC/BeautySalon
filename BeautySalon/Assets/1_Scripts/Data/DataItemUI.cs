using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectsOnScene;

namespace Data
{
    [CreateAssetMenu(fileName = "DataItemUI", menuName = "Data/DataItemUI")]
    public class DataItemUI : ScriptableObject
    {
        public TypeItem TypeItem;
        public Sprite SpriteItem;
    }
}