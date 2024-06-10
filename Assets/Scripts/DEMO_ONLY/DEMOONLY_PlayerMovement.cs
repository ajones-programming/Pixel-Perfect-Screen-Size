using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DEMOONLY
{
    public class DEMOONLY_PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed;
        // Update is called once per frame
        void Update()
        {
            Vector3 newPos = transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * speed;
            newPos.z = newPos.y * 0.01f;
            transform.position = newPos;
        }
    }

}
