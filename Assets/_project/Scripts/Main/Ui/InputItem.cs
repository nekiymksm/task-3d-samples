using UnityEngine;
using UnityEngine.EventSystems;

namespace _project.Scripts.Main.Ui
{
    public class InputItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public float Value { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            Value = 1;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Value = 0;
        }
    }
}