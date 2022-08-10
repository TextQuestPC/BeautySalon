using Characters;
using Core;
using UnityEngine;

namespace ObjectsOnScene
{
    [RequireComponent(typeof(BoxCollider))]
    public class Storage : ObjectScene
    {
        [SerializeField] private TypeService typeService;
        [SerializeField] private TypeItem typeItem;

        private bool isFree;
        private Visitor myVisitor;

        public bool GetIsFree { get => isFree; }
        public TypeService GetTypeService { get => typeService; }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == NamesData.PLAYER_NAME)
            {
                BoxManager.GetManager<GameManager>().PlayerTryGetItem(typeItem);
            }
        }

        public void VisitorIsCame(Visitor visitor)
        {
            isFree = false;
            myVisitor = visitor;
        }
    }
}