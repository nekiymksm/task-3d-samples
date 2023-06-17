using UnityEngine;
using Random = UnityEngine.Random;

namespace _project.Scripts.ModuleCoin
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material[] _materials;

        private int _currentMaterialIndex;

        private void Start()
        {
            _currentMaterialIndex = 0;
        }

        private void Update()
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        }

        private void OnMouseDown()
        {
            _meshRenderer.material = _materials[GetMaterialIndex()];
        }

        private int GetMaterialIndex()
        {
            int materialIndex = 0;

            do
            {
                materialIndex = Random.Range(0, _materials.Length);
            } 
            while (materialIndex == _currentMaterialIndex);

            _currentMaterialIndex = materialIndex;
            return materialIndex;
        }
    }
}