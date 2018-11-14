using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [Header("Canvas_Life")]
    public Canvas canvas_life;
    public Text life_text;
    public Animator heard_anim;
    private PlayerController vidaREf;

    [Header("CanvasController")]
    public Canvas over_Canvas;
    public Animator canvas_over;
    public Text puntos;
    public GameObject restar_GameObject;
    public GameObject hazard;
    public Vector3 spawnValues;
    public int indexHazard;
    private int score;
    private int indice;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;
    public bool gameOver = false;
    public static bool restart =false;

    // Use this for initialization
    private void Awake()
    {
        vidaREf = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Start () {
        //se ejecutara cuando se activa el juego
        over_Canvas.enabled = false;
        restar_GameObject.gameObject.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnHazard());

    }
	
	// Update is called once per frame
	void Update () {
        LifeScore();
        GameOver();
        if (vidaREf.vida <= 25)
        {
            heard_anim.SetBool("latiendo",false);
        }
        if (restart == true && Input.GetKeyDown(KeyCode.R))
        {
            canvas_over.SetBool("gameOver", false);
            indice = 0;
            Restar();
        }
	}
    public void Restar()
    {
        SceneManager.LoadScene(0);
        canvas_over.SetBool("gameOver", false);
        heard_anim.SetBool("latiendo", true);
        indice = 0;
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
            if (gameOver == true)
            {
                restar_GameObject.gameObject.SetActive(true);
                indice = 1;
                restart = true;
                break;

            }

        }
    }
    public void GameOver()
    {
        if (DestroyByTrigger.dead == true)
        {
            gameOver = true;
            over_Canvas.enabled = true;
            canvas_over.SetBool("gameOver", true);
            canvas_over.SetInteger("Reinicio", indice);
        }

    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void UpdateScore()
    {
        puntos.text = "Puntuación: " + score;
    }

    public void LifeScore()
    {
        life_text.text = vidaREf.vida + "%";

    }
  
}
