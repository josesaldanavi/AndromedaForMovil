using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody rgbd;
    public float speedBullet;

    public void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        rgbd.velocity = transform.forward * speedBullet ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
