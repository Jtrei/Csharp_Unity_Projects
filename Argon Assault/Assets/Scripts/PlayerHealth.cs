using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour{

  int health = 3;
  float timeAtHit = 0;
  float timeSinceLastHit;

    private void TakeDamage(){
      timeSinceLastHit = Time.time - timeAtHit;
      if (timeSinceLastHit > 3){ 
        health = health - 1;
        timeAtHit = Time.time;
      }
      Debug.Log("Damage taken, health: " + health);

      if (health == 0){
        SendMessage("StartDeathSequence");
        Debug.Log("Starting Death Sequence");
      }
    }
}
