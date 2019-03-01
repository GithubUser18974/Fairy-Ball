using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToX : MonoBehaviour {

    private Vector3 startPos;
    public float distanceScale = 1;
    public float speed = 2;
    private bool above = false;

    // Use this for initialization
    void Start()
    {
        mRandomSpeed();
        startPos = this.gameObject.transform.position;
        above = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (above)
        {

            this.gameObject.transform.position += new Vector3(-0.01f, 0.0f, 0.0f) * Time.deltaTime * speed;
        }
        else
        {
            this.gameObject.transform.position += new Vector3(0.01f, 0.0f, 0.0f) * Time.deltaTime * speed;
        }
        float distance = startPos.x - this.gameObject.transform.position.x;
        if (distance > distanceScale)
        {
            above = false;
        }
        else if (distance < -1 * distanceScale)
        {
            above = true;
        }


    }
    void mRandomSpeed()
    {
        int ind = Random.Range(0, 3);
        switch (ind)
        {
            case 0: { speed = 7; break; }
            case 1: { speed = 10; break; }
            case 2: { speed = 12; break; }
        }
    }
}
