using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Enemy : MonoBehaviour{

  Scoreboard scoreBoard;


  void Start(){
    AddNonTriggerMeshCollider();
    scoreBoard = FindObjectOfType<Scoreboard>();
  
  }

  void AddNonTriggerMeshCollider(){
    Collider meshCollider = gameObject.AddComponent<MeshCollider>();
    meshCollider.enabled = true;
    meshCollider.isTrigger = false;
  }


  void OnParticleCollision(GameObject other){
    print($"Particles collided with enemy {gameObject.name}");
    SendMessage("EnemyTakeDamage");
    scoreBoard.ScoreHit();
  }



}

