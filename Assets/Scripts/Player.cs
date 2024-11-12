using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]

    public float speed = 20.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        var input = new Vector3();
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        transform.position += input * speed * Time.deltaTime;

        if(input != Vector3.zero) 
            transform.forward = input;
    }
}