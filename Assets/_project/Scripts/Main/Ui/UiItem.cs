using UnityEngine;

namespace _project.Scripts.Main.Ui
{
    public abstract class UiItem : MonoBehaviour
    {
        protected UiRoot UiRoot;
        
        public void Init(UiRoot uiRoot)
        {
            UiRoot = uiRoot;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            OnHide();
            gameObject.SetActive(false);
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }
    }
}