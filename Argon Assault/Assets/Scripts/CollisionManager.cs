using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CollisionManager : MonoBehaviour{

  [SerializeField] float levelLoadDelay = 1;
  [SerializeField] GameObject Explosion;
  [SerializeField] GameObject[] guns;

  bool debugMode = false;

  void Update(){
    Debug();
    ProcessFiring();
  }

  void Debug(){
    if (Input.GetKey(KeyCode.L)){
      debugMode = true;
    if ((Input.GetKey(KeyCode.E)) & (debugMode)){
      Application.Quit();
    }
    }
  } 

    void OnTriggerEnter(Collider other){
      if (debugMode){
        return;
      }
      SendMessage("TakeDamage");
      switch (other.gameObject.tag){
        case "Enemy":
          print("Hit a tagged enemy");
          break;
        case "Environment":
          print("Hit the environment");
          break;
      }
    }

    void ProcessFiring(){
      if (Input.GetButton("Fire")){
        GunsActive(true);
      } else {
        GunsActive(false);
      }

    }

    void GunsActive(bool isActive){
      foreach (GameObject gun in guns) {
        var emissionModule = gun.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
      }
    }

    void StartDeathSequence(){
      Explosion.SetActive(true);
      Invoke("ReloadScene", 1.5f);
    } 

    void ReloadScene(){
      SceneManager.LoadScene(1);
    }
}
