using System;
using UnityEngine;


namespace Dmpk_TPS
{
    [RequireComponent(typeof(Animator))]
    public class IkController : MonoBehaviour
    {
        [Range(0,1)]public float SpineWeight;
        
        [Range(0,1)]public float HandWeight;
        
        [SerializeField]private Transform target;
        [SerializeField]private Transform bone;
        
        private Transform rightHand;
        private Transform leftHand;
        private Transform muzzle;

        private Animator anim;
        private Vector2 screenCenterPoint;
        private Camera cam;

        
        private void Awake() {
            Weapon.SetIKEvent += SetIk;
            anim = GetComponent<Animator>();
            cam = Camera.main;
        }

        private void Start() {
            screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        }

        private void SetIk(Transform r, Transform l, Transform m)
        {
            rightHand = r;
            leftHand = l;
            muzzle = m;
        }

        public void LookDirection()
		{
        	Ray ray = cam.ScreenPointToRay(screenCenterPoint);
        	if (Physics.Raycast(ray, out RaycastHit raycastHit, 300)) {
            	target.position = raycastHit.point;
			}
		}
        

        void OnAnimatorIK()
        {

            if (rightHand != null)
            {
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
                anim.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, HandWeight);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, HandWeight);
            }
            if (leftHand != null)
            { 
                anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, HandWeight);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, HandWeight);
            }
        }

        
        void LateUpdate()
        {            
            if(SpineWeight != 0 && muzzle != null)
            {
                LookDirection();

                for (int i = 0; i < 3; i++)
                {
                    AimAtTarget(target.position);
                }
            }
        }

        public void AimAtTarget(Vector3 targetPosition)
        {
            Quaternion _aimTowards = Quaternion.FromToRotation(muzzle.forward, targetPosition - muzzle.position);
            Quaternion _blendRotation = Quaternion.Slerp(Quaternion.identity, _aimTowards, SpineWeight);
            bone.rotation = _blendRotation * bone.rotation;
        }
    }
}