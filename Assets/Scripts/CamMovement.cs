using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {
    public Transform player;
    void Update () {
        if (transform.position.y-player.position.y >=0.7f)
        {
            transform.position = new Vector3(transform.position.x, player.position.y+0.7f, transform.position.z);
        }
	}
}
