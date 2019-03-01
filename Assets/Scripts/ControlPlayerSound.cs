using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayerSound : MonoBehaviour {
    public AudioSource player;
    public Button sound;
    private bool soundTrue=true;
	// Use this for initialization
	void Start () {
      
        Button isSound = sound.GetComponent<Button>();
        isSound.onClick.AddListener(checkSound);
	}
	void checkSound()
    {
        if (soundTrue)
        {
            soundTrue = false;
            player.enabled = false;
        }
        else
        {
            soundTrue = true;
            player.enabled = true;
        }
        
    }
	// Update is called once per frame
	void Update () {
        
		
	}
}
