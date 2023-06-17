using System;
using UnityEngine;

namespace _project.Scripts.ModuleCar
{
    public class CarMovement : MonoBehaviour
    {
        [SerializeField] private float _maxMotorTorque;
        [SerializeField] private float _maxSteeringAngle;
        [SerializeField] private float _brakeForce;
        [SerializeField] private float _centerOfMassValue;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private AxleInfo[] _axleInfos;

        private CarInputTransmitter _carInputTransmitter;
        private float _motorValue;
        private float _steeringValue;

        private void Start()
        {
            _rigidbody.centerOfMass = new Vector3(0, _centerOfMassValue, 0);
            _carInputTransmitter = CarInputTransmitter.Instance;
        }

        public void FixedUpdate()
        {
            _motorValue = _maxMotorTorque * _carInputTransmitter.GetAxis(CarInputAxisName.Vertical);
            _steeringValue = _maxSteeringAngle * _carInputTransmitter.GetAxis(CarInputAxisName.Horizontal);

            _rigidbody.AddForce(transform.forward * _motorValue);
            
            foreach (AxleInfo axleInfo in _axleInfos) 
            {
                if (axleInfo.IsSteering) 
                {
                    axleInfo.LeftWheel.steerAngle = _steeringValue;
                    axleInfo.RightWheel.steerAngle = _steeringValue;
                }
                
                if (axleInfo.IsMotor) 
                {
                    axleInfo.LeftWheel.motorTorque = _motorValue;
                    axleInfo.RightWheel.motorTorque = _motorValue;
                }
                
                VisualizeRotation(axleInfo.LeftWheel);
                VisualizeRotation(axleInfo.RightWheel);
                
                var brakeForce = _motorValue == 0 ? _brakeForce : 0f;
                axleInfo.LeftWheel.brakeTorque = brakeForce;
                axleInfo.RightWheel.brakeTorque = brakeForce;
            }
        }

        private void VisualizeRotation(WheelCollider wheelCollider)
        {
            if (wheelCollider.transform.childCount == 0) 
            {
                return;
            }
     
            Transform visualWheel = wheelCollider.transform.GetChild(0);
     
            Vector3 position;
            Quaternion rotation;
            
            wheelCollider.GetWorldPose(out position, out rotation);
     
            visualWheel.position = position;
            visualWheel.rotation = rotation;
        }
    }
    
    [Serializable]
    public class AxleInfo 
    {
        public WheelCollider LeftWheel;
        public WheelCollider RightWheel;
        public bool IsMotor;
        public bool IsSteering;
    }
}