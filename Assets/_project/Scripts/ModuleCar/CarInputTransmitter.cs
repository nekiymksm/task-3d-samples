using _project.Scripts.Main.Ui.Items;
using UnityEngine;

namespace _project.Scripts.ModuleCar
{
    public enum CarInputAxisName
    {
        Vertical,
        Horizontal
    }
    
    public class CarInputTransmitter
    {
        public static CarInputTransmitter Instance;
        
        private CarInput _carInput;
        private bool _isMobile;
        
        private float _horizontalValue;
        private float _verticalValue;

        private CarInputTransmitter(CarInput carInput, bool isMobile)
        {
            _carInput = carInput;
            _isMobile = isMobile;
        }
 
        public static void Init(CarInput carInput, bool isMobile)
        {
            if (Instance == null)
            {
                Instance = new CarInputTransmitter(carInput, isMobile);
            }
        }

        public float GetAxis(CarInputAxisName inputAxisName)
        {
            switch (inputAxisName)
            {
                case CarInputAxisName.Horizontal:
                    return _isMobile ? _carInput.Horizontal : Input.GetAxis("Horizontal");
                
                case CarInputAxisName.Vertical:
                    return _isMobile ? _carInput.Vertical : Input.GetAxis("Vertical");
            }

            return 0;
        }
    }
}