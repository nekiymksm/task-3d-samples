using System.Collections.Generic;
using UnityEngine;

namespace _project.Scripts.ModuleCharacter
{
    public class FootprintsCreator
    {
        private Transform _stepPointTransform;
        private Transform _footprintsContainerTransform;
        private Footprint _footprintPrefab;
        private List<Footprint> _footprintsPool;

        private bool _isLeftLeg;
        
        public FootprintsCreator(Transform stepPointTransform, Footprint footprintPrefab, 
            Transform footprintsContainerTransform)
        {
            _stepPointTransform = stepPointTransform;
            _footprintsContainerTransform = footprintsContainerTransform;
            _footprintPrefab = footprintPrefab;
            _footprintsPool = new List<Footprint>();
        }

        public void Init(int preloadItemsCount)
        {
            for (int i = 0; i < preloadItemsCount; i++)
            {
                GetFootprint();
            }
        }

        public void Leave()
        {
            _isLeftLeg = !_isLeftLeg;
            
            for (int i = 0; i < _footprintsPool.Count; i++)
            {
                if (_footprintsPool[i].gameObject.activeSelf == false)
                {
                    _footprintsPool[i].Show(_stepPointTransform.position, _isLeftLeg);
                    return;
                }
            }
            
            GetFootprint().Show(_stepPointTransform.position, _isLeftLeg);
        }

        private Footprint GetFootprint()
        {
            var footprint = Object.Instantiate(_footprintPrefab);
                
            footprint.transform.SetParent(_footprintsContainerTransform);
            footprint.gameObject.SetActive(false);
            _footprintsPool.Add(footprint);

            return footprint;
        }
    }
}