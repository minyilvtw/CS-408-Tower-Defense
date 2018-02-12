using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public GameObject player;
    public float offset;

    void LateUpdate()
    {
        float newXPosition = player.transform.position.x;
        float newZPosition = player.transform.position.z - offset;
        transform.position = new Vector3(newXPosition, transform.position.y, newZPosition);
    }
}
