using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByTrigger : MonoBehaviour {

    public static bool dead = false;
    public GameObject explosion;
    public GameObject explosionPlayer;
    private GameController refScore;
    public int scoreValues;
    // Use this for initialization

    private void Awake()
    {

        //Referencia mediante tag
        refScore = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.restart == true)
        {
            dead = false;
        }
	}

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Limit")) return;
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            PlayerController.vida -= 5;
            if (PlayerController.vida == 0)
            {
                Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
                dead = true;
            }
        }
        refScore.AddScore(scoreValues);
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
