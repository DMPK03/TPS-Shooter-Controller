using System;
using UnityEngine;

namespace Dmpk_TPS
{
    public class AnimationControl : MonoBehaviour
    {        
        private IKcontroller ik;
        private Animator animator;

        private int crouch, sideways, forward, freeFall, jump, grounded, sprint, speedMulti, reload, swap;
        private bool sprinting, canIk = true;

        private void Awake()
        {
            HashAnim();
            SubEvents();
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
            ik = GetComponent<IKcontroller>();
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
                ik.SpineWeight = !sprinting && canIk? 1 : 0;   
                ik.HandWeight = canIk? 1 : 0;
            }
        }

#endregion
#region Combat

        private void ReloadWeapon(bool r)
        {
            animator.SetBool(reload, r);
            canIk = !r;
            SetSpineIk();
        }

        private void SwitchWeapon(bool s)
        {
            animator.SetBool(swap, s);
            canIk = !s;
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
            Movement.moveEvent += SetMoving;
            Movement.Grounded += g => animator.SetBool(grounded, g);
            Movement.Jump += j => animator.SetBool(jump, j);
            Movement.FreeFall += ff => animator.SetBool(freeFall, ff);
            Movement.Crouch += c => animator.SetBool(crouch, c);
            WeaponManager.ReloadWeapon += ReloadWeapon;
            WeaponManager.SwitchWeapon += SwitchWeapon;
        }
        
    }
}