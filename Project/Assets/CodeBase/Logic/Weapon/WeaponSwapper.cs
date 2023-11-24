using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.Weapon
{
    public class WeaponSwapper : MonoBehaviour
    {
        public List<Weapon> weaponsList;
        private int currentWeapon;

        private void Start()
        {
            currentWeapon = 0;
            weaponsList[currentWeapon].gameObject.SetActive(true);
        }

        private void Update()
        {
            HandleWeaponSwap(KeyCode.E, 1);
            HandleWeaponSwap(KeyCode.Q, -1);
        }

        public Weapon GetActiveWeapon()
        {
            return weaponsList[currentWeapon];
        }

        private void HandleWeaponSwap(KeyCode key, int direction)
        {
            if (Input.GetKeyDown(key))
            {
                weaponsList[currentWeapon].gameObject.SetActive(false);
                currentWeapon = (currentWeapon + direction + weaponsList.Count) % weaponsList.Count;
                weaponsList[currentWeapon].gameObject.SetActive(true);
            }
        }

    }
}