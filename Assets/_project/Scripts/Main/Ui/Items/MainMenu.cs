using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _project.Scripts.Main.Ui.Items
{
    public class MainMenu : UiItem
    {
        [SerializeField] private Button _coinButton;
        [SerializeField] private Button _carButton;
        [SerializeField] private Button _characterButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _coinButton.onClick.AddListener(() => OnSceneButtonClick(SceneName.Coin));
            _carButton.onClick.AddListener(() => OnSceneButtonClick(SceneName.Car));
            _characterButton.onClick.AddListener(() => OnSceneButtonClick(SceneName.Character));
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnDestroy()
        {
            _coinButton.onClick.RemoveListener(() => OnSceneButtonClick(SceneName.Coin));
            _carButton.onClick.RemoveListener(() => OnSceneButtonClick(SceneName.Car));
            _characterButton.onClick.RemoveListener(() => OnSceneButtonClick(SceneName.Character));
            _exitButton.onClick.RemoveListener(OnExitButtonClick);
        }

        private void OnSceneButtonClick(SceneName sceneName)
        {
            SceneManager.LoadSceneAsync((int) sceneName, LoadSceneMode.Additive);
            
            Hide();
            UiRoot.GetItem<PauseMenu>().Show();
            UiRoot.SetCurrentSceneItems(sceneName, false);
        }

        private void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}