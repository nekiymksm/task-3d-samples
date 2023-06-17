using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _project.Scripts.Main.Ui.Items
{
    public class PauseMenu : UiItem
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Transform _menuViewTransform;

        private void Start()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
            _resumeButton.onClick.AddListener(OnResumeButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
            
            _menuViewTransform.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
            _resumeButton.onClick.RemoveListener(OnResumeButtonClick);
            _exitButton.onClick.RemoveListener(OnExitButtonClick);
        }

        private void OnPauseButtonClick()
        {
            _menuViewTransform.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
            
            UiRoot.SetCurrentSceneItems(UiRoot.CurrentScene, true);
            
            Time.timeScale = 0;
        }
        
        private void OnResumeButtonClick()
        {
            _menuViewTransform.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(true);
            
            UiRoot.SetCurrentSceneItems(UiRoot.CurrentScene, false);
            
            Time.timeScale = 1;
        }

        private void OnExitButtonClick()
        {
            SceneManager.UnloadSceneAsync((int) UiRoot.CurrentScene);
            
            OnResumeButtonClick();
            
            Hide();
            UiRoot.GetItem<MainMenu>().Show();
            UiRoot.SetCurrentSceneItems(UiRoot.CurrentScene, true);
        }
    }
}