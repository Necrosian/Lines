
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

    public float inpd = 0.1f;
    public float speed = 12.0f;
    public float rotation = 100;
    bool moove;
    Quaternion targetRot;
    Rigidbody rb;
    float  forwardimp, sideimp;
    Animator anim;
    bool hit;
    
    
    public Quaternion TargetRotatiion{
        get { return targetRot; }
    }


    // Use this for initialization
    void Start () {
        targetRot = transform.rotation;
        if (GetComponent<Rigidbody>())
        {
            rb = GetComponent<Rigidbody>();
        }
        forwardimp = sideimp = 0;
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;

	}

    void GetInput() {
        forwardimp = Input.GetAxis("Vertical");
        sideimp = Input.GetAxis("Horizontal");
        
    }

	// Update is called once per frame
	void Update () {
        GetInput();
        anim.SetBool("Moove", moove);
        anim.SetBool("Hit", hit);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            hit = true;

        }
        else hit = false;

    }


   void FixedUpdate() {
        Run();
        RunSide();
    }

    void Run()
    {
        
        if (Mathf.Abs(forwardimp) > inpd)
        {
            rb.velocity = transform.forward * forwardimp * speed;
            moove = true;           
        }
        else
        {
            rb.velocity = Vector3.zero;
            moove = false;
        }


    }

    void RunSide()
    {
        if (Mathf.Abs(sideimp) > inpd)
        {
            rb.velocity = transform.right * sideimp * speed;
            moove = true;
            }
    }
}
