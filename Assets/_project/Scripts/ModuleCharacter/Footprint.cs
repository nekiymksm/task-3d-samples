using System.Threading.Tasks;
using UnityEngine;

namespace _project.Scripts.ModuleCharacter
{
    public class Footprint : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _view;
        [SerializeField] private int _showingDurations;
        [SerializeField] private float _startingAlphaValue;
        [SerializeField] private float _fadePerFrameValue;
        [SerializeField] private float _distanceBetweenLegs;

        private bool _isLeft;

        public void Show(Vector3 position, bool isLeftLeg)
        {
            gameObject.SetActive(true);

            position.x += isLeftLeg ? -_distanceBetweenLegs : _distanceBetweenLegs;
            transform.position = position;

            LostAsync();
        }

        private async void LostAsync()
        {
            var tempColor = _view.color;

            await Task.Delay(_showingDurations);

            while (_view.color.a > 0)
            {
                tempColor.a -= _fadePerFrameValue * Time.deltaTime;
                _view.color = tempColor;

                await Task.Yield();
            }
            
            tempColor.a = _startingAlphaValue;
            _view.color = tempColor;
            
            gameObject.SetActive(false);
        }
    }
}