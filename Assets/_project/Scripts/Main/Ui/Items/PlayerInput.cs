using _project.Scripts.ModuleCharacter;
using UnityEngine;

namespace _project.Scripts.Main.Ui.Items
{
    public class PlayerInput : UiItem
    {
        [SerializeField] private Joystick _movementJoystick;
        [SerializeField] private Joystick _viewJoystick;
        [SerializeField] private InputItem _fireInput;
        [SerializeField] private InputItem _jumpInput;
        
        public float MovementHorizontal => _movementJoystick.Horizontal;
        public float MovementVertical => _movementJoystick.Vertical;
        public float ViewHorizontal => _viewJoystick.Horizontal;
        public float ViewVertical => _viewJoystick.Vertical;
        public float Fire => _fireInput.Value;
        public float Jump => _jumpInput.Value;

        private void Awake()
        {
            PlayerInputTransmitter.Init(this, UiRoot.IsMobile);
        }

        private void Start()
        {
            if (UiRoot.IsMobile == false)
            {
                Hide();
            }
        }
    }
}