using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CollisionManager : MonoBehaviour{

  [SerializeField] float levelLoadDelay = 1;
  [SerializeField] GameObject Explosion;

  bool debugMode = false;

  void Update(){
    Debug();
  }

  void Debug(){
    if (Input.GetKey(KeyCode.L)){
      debugMode = true;
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

    void StartDeathSequence(){
      Explosion.SetActive(true);
      Invoke("ReloadScene", 1.5f);
    } 

    void ReloadScene(){
      SceneManager.LoadScene(1);
    }
}
