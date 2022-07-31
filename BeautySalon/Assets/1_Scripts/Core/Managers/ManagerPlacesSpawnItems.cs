using ObjectsOnScene;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "ManagerPlacesSpawnItems", menuName = "Managers/ManagerPlacesSpawnItems")]
    public class ManagerPlacesSpawnItems : BaseManager
    {
        private List<PlaceSpawnItem> placesSpawn = new List<PlaceSpawnItem>();

        public override void OnInitialize()
        {
            placesSpawn.Add(BoxManager.GetManager<CreatorManager>().CreatePlaceSpawn(TypePlaceSpawnItem.Haircut));
        }
    }
}