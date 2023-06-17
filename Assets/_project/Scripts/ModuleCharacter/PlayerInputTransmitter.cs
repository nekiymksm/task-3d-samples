using _project.Scripts.Main.Ui.Items;
using UnityEngine;

namespace _project.Scripts.ModuleCharacter
{
    public enum PlayerInputAxisName
    {
        MovementHorizontal,
        MovementVertical,
        ViewHorizontal,
        ViewVertical,
        Jump,
        Fire
    }
    
    public class PlayerInputTransmitter
    {
        public static PlayerInputTransmitter Instance;
        
        private PlayerInput _playerInput;
        private bool _isMobile;
        
        private float _movementHorizontal;
        private float _movementVertical;
        private float _viewHorizontal;
        private float _viewVertical;

        private PlayerInputTransmitter(PlayerInput playerInput, bool isMobile)
        {
            _playerInput = playerInput;
            _isMobile = isMobile;
        }

        public static void Init(PlayerInput playerInput, bool isMobile)
        {
            if (Instance == null)
            {
                Instance = new PlayerInputTransmitter(playerInput, isMobile);
            }
        }

        public float GetAxis(PlayerInputAxisName inputAxisName)
        {
            switch (inputAxisName)
            {
                case PlayerInputAxisName.MovementHorizontal:
                    return _isMobile ? _playerInput.MovementHorizontal : Input.GetAxis("Horizontal");
                
                case PlayerInputAxisName.MovementVertical:
                    return _isMobile ? _playerInput.MovementVertical : Input.GetAxis("Vertical");
                
                case PlayerInputAxisName.ViewHorizontal:
                    return _isMobile ? _playerInput.ViewHorizontal : Input.GetAxis("Mouse X");
                
                case PlayerInputAxisName.ViewVertical:
                    return _isMobile ? _playerInput.ViewVertical : Input.GetAxis("Mouse Y");
                
                case PlayerInputAxisName.Fire:
                    return _isMobile ? _playerInput.Fire : Input.GetAxis("Fire1");
                
                case PlayerInputAxisName.Jump:
                    return _isMobile ? _playerInput.Jump : Input.GetAxis("Jump");
            }

            return 0;
        }
    }
}