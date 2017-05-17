using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraC : MonoBehaviour {

    Vector2 mouseL;
    Vector2 smoothV;

    public float sens = 5.0f;
    public float smooth = 2.0f;

    GameObject player;
	// Use this for initialization
	void Start () {
        player = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sens * smooth, sens * smooth));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smooth);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smooth);
        mouseL += smoothV;
        mouseL.y = Mathf.Clamp(mouseL.y, -42f, 63f);

        transform.localRotation = Quaternion.AngleAxis(-mouseL.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseL.x, Vector3.up);
    }
}
