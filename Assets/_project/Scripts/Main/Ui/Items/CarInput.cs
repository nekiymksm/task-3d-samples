using _project.Scripts.ModuleCar;
using UnityEngine;

namespace _project.Scripts.Main.Ui.Items
{
    public class CarInput : UiItem
    {
        [SerializeField] private InputItem _rideInput;
        [SerializeField] private InputItem _breakInput;
        [SerializeField] private InputItem _rightInput;
        [SerializeField] private InputItem _leftInput;

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private void Awake()
        {
            CarInputTransmitter.Init(this, UiRoot.IsMobile);
        }
        
        private void Start()
        {
            if (UiRoot.IsMobile == false)
            {
                Hide();
            }
        }

        private void Update()
        {
            if (_rideInput.Value > 0)
            {
                Vertical = 1;
            }
            else if (_breakInput.Value > 0)
            {
                Vertical = -1;
            }
            else
            {
                Vertical = 0;
            }
            
            if (_leftInput.Value > 0)
            {
                Horizontal = -1;
            }
            else if (_rightInput.Value > 0)
            {
                Horizontal = 1;
            }
            else
            {
                Horizontal = 0;
            }
        }
    }
}