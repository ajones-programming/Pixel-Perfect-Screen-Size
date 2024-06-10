using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DEMOONLY
{
    
    public class DEMOONLY_RotateCube : MonoBehaviour
    {
        [SerializeField] float speed = 5;
        // Update is called once per frame
        void Update()
        {
            float rotateBy = Time.deltaTime * speed;
            transform.Rotate(Vector3.one * rotateBy);
        }
    }

}
