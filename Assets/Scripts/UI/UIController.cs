using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Dmpk_TPS
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Image weaponImage;
        [SerializeField] private TextMeshProUGUI weaponNameText;
        [SerializeField] private TextMeshProUGUI ammoText;

        private string totalAmmo;

        private void Awake() {
            Weapon.WeaponSelectedEvent += OnNewWeapon;
            Weapon.WeaponFireEvent += OnWeaponFire;
        }

        private void OnWeaponFire(int curent)
        {
            ammoText.text = $"{curent} / " + totalAmmo;
        }

        private void OnNewWeapon(string name, Sprite sprite, int total, int curent)
        {
            weaponNameText.text = name;
            weaponImage.sprite = sprite;
            totalAmmo = total.ToString();

            ammoText.text = $"{curent} / " + totalAmmo; 

        }
    }
}

