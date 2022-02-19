using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Dmpk_TPS
{    
    public class CameraControl : MonoBehaviour
    {		
		[SerializeField]private CinemachineFreeLook cmFreeLook;
		private float sensitivity = .3f;
		private float zoomSpeed = 5f;
		private float rotateSpeed = 50;

        private Camera mainCamera;
		private float m0_radius, m0_height, m1_radius;
		private bool isMoving;
		private Vector2 mousePos;

        private void Awake() 
        {
			InputManager.Move += move => isMoving = move != Vector2.zero;
			InputManager.Mouse += m => mousePos = m;
			InputManager.Zoom += CameraZoom;
        }

        private void Start() {
			mainCamera = Camera.main;
			m0_radius = cmFreeLook.m_Orbits[0].m_Radius;
			m0_height = cmFreeLook.m_Orbits[0].m_Height;	
			m1_radius = cmFreeLook.m_Orbits[1].m_Radius;
        }

        private void Update()
		{
			CameraFreeLook();
			SetCameraZoom();			
		}

		public void CameraZoom(float index)
		{
			m0_radius = cmFreeLook.m_Orbits[0].m_Radius - index;
			m0_height = cmFreeLook.m_Orbits[0].m_Height - index;	
			m1_radius = cmFreeLook.m_Orbits[1].m_Radius - index;
		}

		private void SetCameraZoom()
		{
			if (cmFreeLook.m_Orbits[0].m_Radius == m0_radius) return;
			else 
			{
				float step = zoomSpeed * Time.deltaTime;
				cmFreeLook.m_Orbits[0].m_Radius = Mathf.MoveTowards(cmFreeLook.m_Orbits[0].m_Radius, m0_radius,step);
				cmFreeLook.m_Orbits[0].m_Height = Mathf.MoveTowards(cmFreeLook.m_Orbits[0].m_Height, m0_height, step);
				cmFreeLook.m_Orbits[1].m_Radius = Mathf.MoveTowards(cmFreeLook.m_Orbits[1].m_Radius, m1_radius, step);
			}
		}

		private void CameraFreeLook()
		{
			cmFreeLook.m_XAxis.Value += mousePos.x * sensitivity * 60 * Time.deltaTime;
			cmFreeLook.m_YAxis.Value += mousePos.y * sensitivity * Time.deltaTime;
			
			if (isMoving)
			{
				float step = rotateSpeed * 20 * Time.deltaTime;
				float cameraYaw =  mainCamera.transform.rotation.eulerAngles.y;
            	transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, cameraYaw, 0), step);
			}
		}

    }
}