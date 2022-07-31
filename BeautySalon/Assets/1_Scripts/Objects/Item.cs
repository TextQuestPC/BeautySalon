using UnityEngine;

namespace ObjectsOnScene
{
    public class Item : ObjectScene
    {
        [SerializeField] private TypeItem typeItem;

        public TypeItem GetTypeItem { get => typeItem; }
    }
}