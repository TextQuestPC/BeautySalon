using ObjectsOnScene;
using System.Collections;
using System.Collections.Generic;
using SystemMove;
using UnityEngine;

namespace Characters
{
    public class Visitor : ObjectScene, IInitialize
    {
        [SerializeField] private TypeService typeNeedServices;
        [SerializeField] private TypeItem typeNeedItem;

        private MoveVisitorComponent moveComponent;

        public override void OnInitialize()
        {
            moveComponent = new MoveVisitorComponent();
        }
    }
}