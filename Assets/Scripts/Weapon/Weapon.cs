using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

namespace Dmpk_TPS
{
    //[RequireComponent(typeof(CinemachineImpulseSource))]

    public abstract class Weapon : MonoBehaviour
    {
        public static event Action<Transform, Transform, Transform> SetIKEvent;
        public static event Action<string, Sprite, int, int> WeaponSelectedEvent;
        public static event Action<int> WeaponFireEvent;

        [Header("Info")]
        [SerializeField] private string weaponName;
        public string WeaponName { get => weaponName;}

        [SerializeField] private Sprite weaponSprite;
        public Sprite WeaponSprite { get => weaponSprite;}

        [Header("Audio")]
        [SerializeField] private protected AudioClip gunShotClip;
        [SerializeField] private protected AudioClip reloadClip;
        [SerializeField] private protected AudioClip emptyClip;

        [Header("IK")]
        [SerializeField] private protected Transform rightHand;
        [SerializeField] private protected Transform leftHand;
        [SerializeField] private protected Transform muzzle;

        [Header("Stats")]
        [SerializeField] private protected int clipSize;
        [SerializeField] private protected float fireRate;

        private protected CinemachineImpulseSource cameraRecoil;
        private protected int currentAmmo;
        private protected float nextTimeToFire = 0;
        private protected AudioSource source;


        private void Awake()
        {
            muzzle = transform.Find("MuzzlePosition");
            source = muzzle.GetComponent<AudioSource>();
            cameraRecoil = GetComponent<CinemachineImpulseSource>();
        }

        public virtual void Start()
        {
            source.clip = gunShotClip;
            currentAmmo = UnityEngine.Random.Range(1, clipSize);

            WeaponSelectedEvent?.Invoke(WeaponName, WeaponSprite, clipSize, currentAmmo);
        }

        public void WeaponSelected() => WeaponSelectedEvent?.Invoke(WeaponName, WeaponSprite, clipSize, currentAmmo);

        public void SendAmmo() => WeaponFireEvent?.Invoke(currentAmmo);

        public void SetIk() => SetIKEvent?.Invoke(rightHand, leftHand, muzzle);

        public bool CanReload() => currentAmmo != clipSize;

        public void ReloadStart() => PlayAudio(reloadClip);

        public void ReloadEnd()
        {
            currentAmmo += clipSize - currentAmmo;
            SendAmmo();
        }

        private void PlayAudio(AudioClip audioClip)
        {
            source.clip = audioClip;
            source.Play();
        }

        public void FireWeapon()
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;

                if (currentAmmo > 0)
                {
                    currentAmmo --;
                    SendAmmo();

                    PlayAudio(gunShotClip);     //todo move audio and recoil to separate managers activated on weaponfire event
                    cameraRecoil.GenerateImpulse(Camera.main.transform.forward);
                    
                    Fire();
                }
                else PlayAudio(emptyClip);
            }
        }

        public abstract void Fire();

    }

}
