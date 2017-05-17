using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class follow : MonoBehaviour {

    public Transform player;
    Animator anim;
    bool move;
    bool hit;
    public Slider hp;
    GameObject npc;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Moove", move);
        anim.SetBool("Hit", hit);

        if (hp.value <= 0) return;

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.position, this.transform.position) < 15 && angle < 30 )
        {
            this.transform.Translate(0, 0, 0);
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.16f);
                move = true;
                hit = false;
            }
            else
            {
                hit = true;
                move = false;

            }

        }
        else { move = false;
            hit = false;
        }

    }
}
