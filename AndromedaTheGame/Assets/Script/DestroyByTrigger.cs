using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTrigger : MonoBehaviour {

    public GameObject explosion;
    public GameObject explosionPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Limit")) return;
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
