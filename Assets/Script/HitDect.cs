using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDect : MonoBehaviour {

    public bool dead;
    public Slider hp;
    Animator anim;
    public string Opponent;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Dead", dead);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != Opponent) {
            Debug.Log("Hit");
            return;
        }
        else { 
        hp.value -= 20;
        if (hp.value <= 0) dead = true;
    }
        
       
    }
}   
