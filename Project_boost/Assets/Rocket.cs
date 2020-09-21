using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f; // Adds to inspector
    [SerializeField] float mainThrust = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;
    // Start is called before the first frame update

    enum State {Alive, Dead, Transcending,}
    State state = State.Alive;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive){
        Rotate();
        Thrust();
        }
    }

    private void Rotate (){

        rigidBody.freezeRotation = true; // halt physical control, allow manual control
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        } 

        rigidBody.freezeRotation = false; // resume physics control
    }

    void OnCollisionEnter(Collision collision){
        if (state != State.Alive) {return;}
        switch (collision.gameObject.tag){
            case "Friendly":
                break;
            case "Finish":
                print("Hit Finish");
                state = State.Transcending;
                Invoke("LoadNextScene", 1f); // parameterize time
                break;
            default:
                print("Hit Dead");
                state = State.Dead;
                Invoke("LoadNextScene", 1f); // parameterize time
                break;
        }
    }

    private void LoadNextScene(){

        if (state == State.Transcending) {
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(0);
        }
    }

    private void Thrust(){
        float thrustThisFrame = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
            if (!audioSource.isPlaying) {
                audioSource.Play(); 
            }
        } else {
            audioSource.Stop();
        }
    }
}

