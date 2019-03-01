using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {
    private Vector3 startPosWhenCollision;
    public Rigidbody player;
    public float speed = 250;
    public static float GlobalGravity = -9.8f;
    public float gravityScale = 1.0f;
    private bool isForce = false;
    public AudioSource audioSource;
    public GameObject gameManger;
	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody>();
        player.useGravity = false;
        audioSource = GetComponent<AudioSource>();
       

    }
    private void FixedUpdate()
    {
        
            Vector3 gravity = GlobalGravity * gravityScale * Vector3.up;
            player.AddForce(gravity, ForceMode.Acceleration);
        
        
    }
    void force()
    {
        isForce = false;
        player.AddForce(Vector3.up * speed, ForceMode.Impulse);

    }
    // Update is called once per frame
    void Update () {
        if (isForce)  {  force(); }
        playerRotation();
        
	}
    private void OnCollisionEnter(Collision collision)
    {
        isForce = true;
        if (collision.collider.tag == "end" || collision.collider.tag == "enemy")
        {
            speed = 0;
            gravityScale = 0;
            gameManger.gameObject.SetActive(false);
        }
   
        audioSource.Play();
        audioSource.PlayDelayed(200);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end" || other.tag == "enemy")
        {
            speed = 0;
            gravityScale = 0;
            gameManger.gameObject.SetActive(false);
        }
      
    }
    private void playerRotation()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
        transform.Rotate(Vector3.right * 10 * Time.deltaTime);

    }
}
