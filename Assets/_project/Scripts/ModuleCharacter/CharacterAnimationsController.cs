using UnityEngine;

namespace _project.Scripts.ModuleCharacter
{
    public class CharacterAnimationsController : MonoBehaviour
    {
        private enum CharacterMove
        {
            Forward,
            Backward,
            Left,
            Right,
            Jump,
            RunJump,
            Shoot
        }

        [SerializeField] private Animator _animator;
        
        private PlayerInputTransmitter _inputTransmitter;
        private Vector3 _moveDirection;

        private void Start()
        {
            _inputTransmitter = PlayerInputTransmitter.Instance;
            _moveDirection = new Vector3();
        }

        private void Update()
        {
            _moveDirection.x = _inputTransmitter.GetAxis(PlayerInputAxisName.MovementHorizontal);
            _moveDirection.z = _inputTransmitter.GetAxis(PlayerInputAxisName.MovementVertical);

            _animator.SetFloat(_animator.parameters[(int) CharacterMove.Forward].nameHash, _moveDirection.z);
            _animator.SetFloat(_animator.parameters[(int) CharacterMove.Backward].nameHash, _moveDirection.z);
            _animator.SetFloat(_animator.parameters[(int) CharacterMove.Left].nameHash, _moveDirection.x);
            _animator.SetFloat(_animator.parameters[(int) CharacterMove.Right].nameHash, _moveDirection.x);
            
            _animator.SetFloat(_animator.parameters[(int) CharacterMove.Shoot].nameHash, 
                _inputTransmitter.GetAxis(PlayerInputAxisName.Fire));
        }

        public void PlayJump()
        {
            if (_moveDirection.z <= 0)
            {
                _animator.SetTrigger(_animator.parameters[(int) CharacterMove.Jump].nameHash);
            }
            else
            {
                _animator.SetTrigger(_animator.parameters[(int) CharacterMove.RunJump].nameHash);
            }
        }
    }
}