using UnityEngine;

namespace _project.Scripts.ModuleCharacter
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private CharacterAnimationsController _animationsController;
        
        [SerializeField] private Footprint _footprintPrefab;
        [SerializeField] private Transform _stepPointTransform;
        [SerializeField] private Transform _footprintsContainerTransform;
        [SerializeField] private int _footprintCreatingPeriod;
        [SerializeField] private int _preloadFootprintsCount;
        
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _jumpForce;

        private FootprintsCreator _footprintsCreator;
        private PlayerInputTransmitter _inputTransmitter;
        private Vector3 _moveDirection;
        private Vector3 playerVelocity;
        private bool _canJump;
        private int _footprintPeriodCounter;

        private void Awake()
        {
            _footprintsCreator = new FootprintsCreator(_stepPointTransform, _footprintPrefab, _footprintsContainerTransform);
            _canJump = true;
            _footprintPeriodCounter = 0;
        }

        private void Start()
        {
            _inputTransmitter = PlayerInputTransmitter.Instance;
            _footprintsCreator.Init(_preloadFootprintsCount);
        }

        private void FixedUpdate()
        {
            if (_moveDirection != Vector3.zero)
            {
                _footprintPeriodCounter++;
            }
        }

        private void Update()
        {
            Move();
            Rotate();

            TryJump();
            SimulateGravity();
            
            TryCreateFootprint();
        }

        private void Move()
        {
            _moveDirection = transform
                .TransformDirection(_inputTransmitter.GetAxis(PlayerInputAxisName.MovementHorizontal), 0, 
                    _inputTransmitter.GetAxis(PlayerInputAxisName.MovementVertical));

            if (_moveDirection != Vector3.zero)
            {
                _characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);
            }
        }

        private void TryJump()
        {
            if (_characterController.isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            
            if (_canJump && _inputTransmitter.GetAxis(PlayerInputAxisName.Jump) > 0 && _characterController.isGrounded)
            {
                playerVelocity.y += Mathf.Sqrt(_jumpForce * -Physics.gravity.y);
                _animationsController.PlayJump();
                _canJump = false;
            }
        }
        
        private void Rotate()
        {
            float rotationValue = _inputTransmitter.GetAxis(PlayerInputAxisName.ViewHorizontal) * _rotateSpeed;
                
            if (rotationValue != 0)
            {
                transform.Rotate(0, rotationValue, 0);
            }
        }

        private void SimulateGravity()
        {
            if (_canJump == false && _inputTransmitter.GetAxis(PlayerInputAxisName.Jump) <= 0)
            {
                _canJump = true;
            }

            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
            _characterController.Move(playerVelocity * Time.deltaTime);
        }

        private void TryCreateFootprint()
        {
            if (_characterController.isGrounded && _footprintPeriodCounter >= _footprintCreatingPeriod)
            {
                _footprintPeriodCounter = 0;
                _footprintsCreator.Leave();
            }
        }
    }
}