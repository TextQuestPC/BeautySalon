using Characters;
using ObjectsOnScene;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "BalanceManager", menuName = "Managers/BalanceManager")]
    public class BalanceManager : BaseManager
    {
        private Dictionary<int, DataVisit[]> dataVisits;

        private int counterData = 0;

        public override void OnInitialize()
        {
            // TODO: Get data from file 

            dataVisits = new Dictionary<int, DataVisit[]>();
            dataVisits.Add(0, new DataVisit[]
            {
                new DataVisit(TypeService.Haircut, TypeItem.Scissors),
                //new DataVisit(TypeService.Nails, TypeItem.NailFile),
                //new DataVisit(TypeService.Brows, TypeItem.Ink)
            });
        }

        public DataVisit[] GetDataVisit()
        {
            if(counterData >= dataVisits.Count)
            {
                counterData = 0;
            }

            return dataVisits[counterData];
        }
    }
}