using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limit
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour
{   
    [Header ("Movimiento")]
    public float speed = 2f;
    public Limit limite;
    private Rigidbody rgbd;

    [Header ("Disparo")]
    public GameObject Bala;
    public Transform BalaSpawn;
    public float fireRate;
    private float nextFire;
    // Use this for initialization

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time> nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Bala, BalaSpawn.position, Quaternion.identity);
            
        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rgbd.velocity = Movement * speed;
        //el mathf. clamp evalua un valor float entregado y ese valor va a ser cambiado entre el minimo y maximo
        rgbd.position = new Vector3(Mathf.Clamp(rgbd.position.x, limite.xMin, limite.xMax), 0f,
            Mathf.Clamp(rgbd.position.z, limite.zMin, limite.zMax));

        rgbd.rotation = Quaternion.Euler(0f, 0f, rgbd.velocity.x * -4.5f);
    }
}