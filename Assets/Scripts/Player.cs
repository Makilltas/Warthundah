using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public AudioClip shot;

    public bool isPlayer1 = true;

    [Header("Movement")]

    public float speed = 20.0f;

    private AudioSource audioSource;

    [Header("Shooting")]

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float fireRate = 0.5f;
    
    void Start()
    {
        InvokeRepeating("Shoot", 0.0f, fireRate);
        audioSource = GetComponent<AudioSource>();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        audioSource.pitch = Random.Range(0.5f, 1.6f);
        audioSource.PlayOneShot(shot);
    }

    
    void Update()
    {
        var input = new Vector3();
        if(isPlayer1)
        {
            input.x = Input.GetAxis("HorizontalKeys");
            input.z = Input.GetAxis("VerticalKeys");
           
        }
        else
        {
            input.x = Input.GetAxis("HorizontalArrows");
            input.z = Input.GetAxis("VerticalArrows");
        }
        

        transform.position += input * speed * Time.deltaTime;

        if(input != Vector3.zero) 
            transform.forward = input;
    }
}
