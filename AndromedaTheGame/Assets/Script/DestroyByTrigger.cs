using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByTrigger : MonoBehaviour {

    public static bool dead = false;
    public GameObject explosion;
    public GameObject explosionPlayer;
    private GameController refScore;
    private PlayerController vidaREf;
    public int scoreValues;
    // Use this for initialization
    
    private void Awake()
    {
        
        //Referencia mediante tag
        vidaREf = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
        if (other.CompareTag("Player2"))
        {
            vidaREf.vida -= 5;
            if (vidaREf.vida <= 0)
            {
                Destroy(other.gameObject);
                Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
                dead = true;
            }
        }
        Destroy(gameObject);
        refScore.AddScore(scoreValues);
       
        
    }
}
