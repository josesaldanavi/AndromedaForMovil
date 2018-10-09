using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdonRotation : MonoBehaviour {

    public float rotationVelocity;
    private Rigidbody rgdb;

    public void Awake()
    {
        rgdb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        //afecta solo la rotacion del objeto
        //Vector3 angularVelocity = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        //Ramdon.insideUnitSpher es lo mismo que la linea anterior
        rgdb.angularVelocity = Random.insideUnitSphere * rotationVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
