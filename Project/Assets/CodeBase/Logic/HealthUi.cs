using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Logic
{
    public class HealthUi : MonoBehaviour
    {
        public HpBar hpBar;
        private IHealth _health;

        private void Construct(IHealth health)
        {
            _health = health;
            _health.HealthChanged += UpdateHpBar;
        }

        private void Start()
        {
            IHealth health = GetComponent<IHealth>();
            if (health != null)
            {
                Construct(health);
                hpBar.SetValue(_health.Current, _health.Max);
            }
        }

        private void UpdateHpBar()
        {
            hpBar.SetValue(_health.Current, _health.Max);
        }

        private void OnDestroy()
        {
            if (_health != null)
                _health.HealthChanged -= UpdateHpBar;
        }
    }
}