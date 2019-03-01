using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipControl : MonoBehaviour {
    public GameInput gameInput;
    public GameObject rotationObject;
    private float distance;

	// Update is called once per frame
	void Update () {
        distance = gameInput.mDistance;
        if (gameInput.mSwipLeft)
        {
            rotationObject.transform.Rotate(Vector3.up * distance * Time.deltaTime);
        }
        else if (gameInput.mSwipRight)
        {
            rotationObject.transform.Rotate(Vector3.up * distance * Time.deltaTime);
        }
    }
}
