using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EnemyDeathFxDestroyer : MonoBehaviour{

  void Start(){
    Destroy(gameObject, 5);
  }

}

