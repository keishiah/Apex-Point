using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using CodeBase.UI;
using CodeBase.UI.Factories;
using UnityEngine;

namespace CodeBase.Services.GameOver
{
    public class GameOver : IGameOver
    {
        private IUIFactory _uiFactory;
        private readonly IGameStateMachine _gameStateMachine;

        public GameOver(IUIFactory uiFactory, IGameStateMachine gameStateMachine)
        {
            _uiFactory = uiFactory;
            _gameStateMachine = gameStateMachine;
        }

        public void OnTankDestroyed()
        {
            Time.timeScale = 0;
            RestartButton restartButton = _uiFactory.CreateRestartButton().GetComponent<RestartButton>();
            restartButton.InitButton(RestartButtonClicked);
        }

        public void RestartButtonClicked()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(InfrastructureAssetPath.StartGameScene);
            Time.timeScale = 1;
        }
    }
}