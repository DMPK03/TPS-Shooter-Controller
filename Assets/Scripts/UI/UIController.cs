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
        [Header("Weapon")]
        [SerializeField] private Image weaponImage;
        [SerializeField] private TextMeshProUGUI weaponNameText;
        [SerializeField] private TextMeshProUGUI ammoText;

        [Header("Interact")]
        [SerializeField] private GameObject interactGO;
        [SerializeField] private Image interactImage;
        [SerializeField] private TextMeshProUGUI interactNameText;
        [SerializeField] private TextMeshProUGUI interactActionText;

        [Header("misc")]
        [SerializeField] private GameObject menu;
        [SerializeField] private TextMeshProUGUI warningText;

        private string totalAmmo;
        private Coroutine warningRoutine;

        private void Awake() {
            Weapon.WeaponSelectedEvent += OnNewWeapon;
            Weapon.WeaponFireEvent += OnWeaponFire;
            Interact.InteractableEvent += OnInteractable;
            InputManager.Esc += OnEscape;
            WeaponController.Warning += OnWarning;
        }

        private void Start() {
            Cursor.visible = false;
        }

        private void OnEscape(bool uiMode)
        {
            menu.gameObject.SetActive(uiMode);
            Cursor.visible = uiMode;
        }

        private void OnWarning(string txt)
        {
            if(warningRoutine == null) warningRoutine = StartCoroutine(Warning(txt));
        }

        private IEnumerator Warning(string txt)
        {
            warningText.text = txt;
            yield return new WaitForSeconds(2);
            warningText.text = "";
            warningRoutine = null;
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

        private void OnInteractable(IInteractable interactable, bool active)
        {
            if(active)
            {
                interactActionText.text = "Press \"E\" to " + interactable.ItemAction;
                interactNameText.text = interactable.ItemName;
                interactImage.sprite = interactable.ItemSprite;

                interactGO.SetActive(true);
            }
            else
            {
                interactGO.SetActive(false);
            }  
        }

        public void btnQuit() {
            Application.Quit();
        }
    }
}

