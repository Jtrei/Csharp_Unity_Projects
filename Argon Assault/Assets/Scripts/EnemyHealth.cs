using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EnemyHealth : MonoBehaviour{
  
  [SerializeField] GameObject deathFX;
  [SerializeField] int health = 15; 
  [SerializeField] Transform parent;


    private void EnemyTakeDamage(){
      health = health - 1;
      if (health == 0){
        VisualEffects();
        print("Enemy Destroyed!");
        Invoke("EnemyDestroyed", 1);
      }
    }

    private void VisualEffects(){
      GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
      fx.transform.parent = parent;
    }

    private void EnemyDestroyed(){
      Destroy(gameObject);
    }
}

