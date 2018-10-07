using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limit
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {
    public float speed = 2f;
    public Limit limite;
    private Rigidbody rgbd;
    // Use this for initialization

    private void Awake()
    {
        rgbd=GetComponent<Rigidbody>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical"); 

        Vector3 Movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rgbd.velocity = Movement * speed ;
        //el mathf. clamp evalua un valor float entregado y ese valor va a ser cambiado entre el minimo y maximo
        rgbd.position = new Vector3(Mathf.Clamp(rgbd.position.x, limite.xMin, limite.xMax),0f, 
            Mathf.Clamp(rgbd.position.z, limite.zMin, limite.zMax));
    }
    
}
