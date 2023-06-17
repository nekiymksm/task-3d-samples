using UnityEngine;

namespace _project.Scripts.ModuleCharacter
{
    public class PlayerCameraSight : MonoBehaviour
    {
        [SerializeField] private Transform _trackingTransform;
        [SerializeField] private float _verticalSightSpeed;
        [SerializeField] private float _horizontalSightSpeed;
        [SerializeField] private float _minVerticalValue;
        [SerializeField] private float _maxVerticalValue;

        private PlayerInputTransmitter _inputTransmitter;
        private float _horizontal;
        private float _vertical;
        
        private void Start()
        {
            _inputTransmitter = PlayerInputTransmitter.Instance;
        }
        
        private void Update()
        {
            transform.position = _trackingTransform.position;
            
            _vertical -= _inputTransmitter.GetAxis(PlayerInputAxisName.ViewVertical) * _verticalSightSpeed;
            _horizontal += _inputTransmitter.GetAxis(PlayerInputAxisName.ViewHorizontal) * _horizontalSightSpeed;
            
            _vertical = Mathf.Clamp(_vertical, _minVerticalValue, _maxVerticalValue);
            transform.rotation = Quaternion.Euler(_vertical, _horizontal, 0);
        }
    }
}