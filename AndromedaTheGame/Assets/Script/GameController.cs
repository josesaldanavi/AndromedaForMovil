using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text puntos;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int indexHazard;
    private int score;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;

	// Use this for initialization
	void Start () {
        //se ejecutara cuando se activa el juego
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnHazard());
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator SpawnHazard()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {
            for (int i = 0; i < indexHazard; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            //detener la ejecucion de la corrutina
            yield return new WaitForSeconds(waveWait);
        }

        
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        puntos.text = "Puntuación: " + score;
    }

  
}
