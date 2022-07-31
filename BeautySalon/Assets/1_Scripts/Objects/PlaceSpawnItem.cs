using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectsOnScene
{
    public class PlaceSpawnItem : ObjectScene
    {
        [SerializeField] private TypePlaceSpawnItem typePlace;

        public TypePlaceSpawnItem GetTypePlace { get => typePlace; }
    }
}