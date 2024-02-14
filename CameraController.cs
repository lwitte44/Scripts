using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //creates "player" from object type GameObject and it will be told what "player" is on the UnityEngine
    public GameObject player;
    //this give the camera the 3D movement it need to keep the same offset from the player
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }


}
