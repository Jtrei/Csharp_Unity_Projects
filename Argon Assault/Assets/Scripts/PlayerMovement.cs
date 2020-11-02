using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerMovement : MonoBehaviour{

  [Header("General")]
  [Tooltip("ms^-1")][SerializeField] int xConstantTran = 15;
  [Tooltip("ms^-1")][SerializeField] int yConstantTran = 15;
  [Tooltip("m")][SerializeField] float xRangeTran = 20;
  [Tooltip("m")][SerializeField] float yRangeTran = 15;

  [Header("Screen-position based")]
  [SerializeField] float positionPitchFactor = -4;
  [SerializeField] float positionYawFactor = 2;

  [Header("Thrust based")]
  [SerializeField] float controlPitchFactor = -5;
  [SerializeField] float controlRollFactor = -20;
 
  public enum State {Alive, Dying, Dead};
  State status;

  float xThrow, yThrow;

    public void Start(){
      status = State.Alive;
    }

    void Update(){
      if (status == State.Alive){
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        TranslationalMovement();
        RotationalMovement();
      }
    }

    private void TranslationalMovement(){
      float xoffset = (xThrow * Time.deltaTime * xConstantTran);
      float rawNewXPos = transform.localPosition.x + xoffset;
      float xPos = Mathf.Clamp(rawNewXPos, -xRangeTran, xRangeTran);

      float yoffset = (yThrow * Time.deltaTime * yConstantTran);
      float rawNewYPos = transform.localPosition.y + yoffset;
      float yPos = Mathf.Clamp(rawNewYPos, -yRangeTran, yRangeTran); 
      
      transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z); 
    }

    private void RotationalMovement(){
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void StartDeathSequence(){
      status = State.Dying;
      Debug.Log("State set to" + status);
    }  
}


