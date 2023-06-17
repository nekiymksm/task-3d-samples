using UnityEngine;

namespace _project.Scripts.ModuleCar
{
    public class CarTracker : MonoBehaviour
    {
        [SerializeField] private Transform _trackingTransform;

        private void Update()
        {
            transform.position = _trackingTransform.position;
            transform.rotation = _trackingTransform.rotation;
        }
    }
}