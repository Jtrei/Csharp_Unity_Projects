using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    // Start is called before the first frame update

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput(){
        if (Input.GetKey(KeyCode.Space)) {
            print("Thrusting");
            rigidBody.AddRelativeForce(Vector3.up);
            audioSource.Play(); 
        } else {
            audioSource.Pause();
        }

        if (Input.GetKey(KeyCode.A)) {
            print("Rotating left");
            transform.Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)) {
            print("Rotating right");
            transform.Rotate(Vector3.back);
        } 
    }
}
