using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DEMOONLY
{
    public class DEMOONLY_CameraFollowPlayer : MonoBehaviour
    {

        [SerializeField] private Camera _camera;
        [SerializeField] Transform player;

        // Update is called once per frame
        void LateUpdate()
        {
            _camera.transform.position = new Vector3(player.position.x, player.position.y, -10);
        }
    }
}

