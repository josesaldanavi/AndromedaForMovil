using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private Rigidbody rgbd;
    public float speed;
    public void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        Vector3 vector3 = new Vector3(0f, 0f, 1);
        rgbd.velocity = vector3 * speed;
    }
}
