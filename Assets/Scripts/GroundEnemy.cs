using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour {
    public  Renderer rend;
    // Use this for initialization
    void Start () {
         rend = this.gameObject.GetComponent<Renderer>();
        havematerial();

    }

    // Update is called once per frame
    void Update () {
      
        
    }
    void havematerial()


    {
        int i = Random.Range(0, 3);

        switch (i)
        {
            
            case 0: { rend.material.color= new Color32(5, 89, 16,1); break; }
            case 1: { rend.material.color = new Color32(224, 53, 53, 1); break; }
            case 2: { rend.material.color=new Color32(51, 15, 81,1); break; }
        }
    
    }
}
