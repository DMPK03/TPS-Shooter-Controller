using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    public class Billboard : MonoBehaviour
    {
        private Transform cam;

        private void Start() {
            cam = Camera.main.transform;
        }

        void Update()
        {
            transform.LookAt(transform.position + cam.forward);      
        }
    }
}

