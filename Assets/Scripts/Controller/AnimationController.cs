using System;
using UnityEngine;

namespace Dmpk_TPS
{
    public class AnimationController : MonoBehaviour
    {        
        private IkController ik;
        private Animator animator;

        private int crouch, sideways, forward, freeFall, jump, grounded, sprint, speedMulti, reload, swap;
        private bool sprinting, canIkSpine, canIkHands = true;

        private void Awake()
        {
            HashAnim();
            SubEvents();
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
            ik = GetComponent<IkController>();
        }

#region Movement

        public void SetMoving(float x, float z, float s)
        {
            animator.SetFloat(forward, x);
			animator.SetFloat(sideways, z);
            animator.SetFloat(sprint, s);
            
            sprinting = s != 1;
            SetSpineIk();
        }
        
        private void SetSpineIk()
        {
            if(ik != null)
            {
                ik.SpineWeight = !sprinting && canIkHands && canIkSpine? 1 : 0;   
                ik.HandWeight = canIkHands? 1 : 0;
            }
        }

#endregion
#region Combat

        private void ReloadWeapon(bool r)
        {
            animator.SetBool(reload, r);
            canIkHands = !r;
            SetSpineIk();
        }

        private void SwitchWeapon(bool s)
        {
            animator.SetBool(swap, s);
            canIkHands = !s;
            SetSpineIk();
        }

#endregion

        private void HashAnim()
        {
            sprint = Animator.StringToHash("Sprint");
            grounded = Animator.StringToHash("Grounded");
            jump = Animator.StringToHash("Jump");
            freeFall = Animator.StringToHash("FreeFall");
            forward = Animator.StringToHash("Forward");
            sideways = Animator.StringToHash("Sideways");
            crouch = Animator.StringToHash("Crouch");
            speedMulti = Animator.StringToHash("SpeedMulti");
            reload = Animator.StringToHash("Reload");
            swap = Animator.StringToHash("Switch");
        }

        private void SubEvents()
        {
            MovementController.moveEvent += SetMoving;
            MovementController.Grounded += g => animator.SetBool(grounded, g);
            MovementController.Jump += j => animator.SetBool(jump, j);
            MovementController.FreeFall += ff => animator.SetBool(freeFall, ff);
            MovementController.Crouch += c => animator.SetBool(crouch, c);
            InputManager.Aiming += () => canIkSpine = !canIkSpine;
            WeaponController.ReloadWeapon += ReloadWeapon;
            WeaponController.SwitchWeapon += SwitchWeapon;
        }
        
    }
}