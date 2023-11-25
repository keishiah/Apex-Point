using CodeBase.Services.GameOver;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Tank
{
    public class TankDeath : MonoBehaviour
    {
        private TankHealth _health;
        private IGameOver _gameOver;

        [Inject]
        void Construct(IGameOver gameOver)
        {
            _gameOver = gameOver;
        }

        private void Start()
        {
            _health = GetComponent<TankHealth>();
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_health.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _gameOver.OnTankDestroyed();
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= OnHealthChanged;
        }
    }
}