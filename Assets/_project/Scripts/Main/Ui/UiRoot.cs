using _project.Scripts.Main.Ui.Items;
using UnityEngine;

namespace _project.Scripts.Main.Ui
{
    public enum SceneName
    {
        MainMenu,
        Coin,
        Car,
        Character
    }
    
    public class UiRoot : MonoBehaviour
    {
        [SerializeField] private bool _isMobile;
        [SerializeField] private UiItem[] _uiItems;
        
        public bool IsMobile => _isMobile;
        public SceneName CurrentScene { get; private set; }
        
        private void Awake()
        {
            foreach (var item in _uiItems)
            {
                item.Init(this);
            }
        }

        public T GetItem<T>() where T : UiItem
        {
            for (int i = 0; i < _uiItems.Length; i++)
            {
                if (_uiItems[i].GetType() == typeof(T))
                {
                    return _uiItems[i] as T;
                }
            }
            
            return null;
        }
        
        public void SetCurrentSceneItems(SceneName currentScene, bool isHide)
        {
            CurrentScene = currentScene;
            
            switch (currentScene)
            {
                case SceneName.Car:
                    SetVision(GetItem<CarInput>(), isHide);
                    break;
                
                case SceneName.Character:
                    SetVision(GetItem<PlayerInput>(), isHide);
                    break;
            }
        }

        private void SetVision(UiItem item, bool isHide)
        {
            if (isHide)
            {
                item.Hide();
            }
            else
            {
                item.Show();
            }
        }
    }
}