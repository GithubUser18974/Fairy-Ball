﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlower : MonoBehaviour {
    public float speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);

    }
}
