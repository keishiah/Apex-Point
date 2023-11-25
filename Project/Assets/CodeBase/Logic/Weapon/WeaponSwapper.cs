using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.Weapon
{
    public class WeaponSwapper : MonoBehaviour
    {
        public List<Weapon> weaponsList;
        private int _currentWeapon;

        private void Start()
        {
            _currentWeapon = 0;
            weaponsList[_currentWeapon].gameObject.SetActive(true);
        }

        private void Update()
        {
            HandleWeaponSwap(KeyCode.E, 1);
            HandleWeaponSwap(KeyCode.Q, -1);
        }

        public Weapon GetActiveWeapon()
        {
            return weaponsList[_currentWeapon];
        }

        private void HandleWeaponSwap(KeyCode key, int direction)
        {
            if (Input.GetKeyDown(key))
            {
                weaponsList[_currentWeapon].gameObject.SetActive(false);
                _currentWeapon = (_currentWeapon + direction + weaponsList.Count) % weaponsList.Count;
                weaponsList[_currentWeapon].gameObject.SetActive(true);
            }
        }

    }
}