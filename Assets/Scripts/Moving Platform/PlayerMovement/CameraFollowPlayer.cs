using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Camera.main.transform.position = 
            new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
    }
}
