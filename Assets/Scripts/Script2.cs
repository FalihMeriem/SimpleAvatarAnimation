using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2 : MonoBehaviour
{
    Animator animator;
    float VelicityX = 0.0f;
    float VelicityZ = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 4.0f;
    public float maxWalkVelocity = 0.5f;
    public float maxRunVelocity = 1.0f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      bool forwardPressed = Input.GetKey("w");
      bool leftPressed = Input.GetKey("a");
      bool rightPressed = Input.GetKey("d");
      bool runPressed = Input.GetKey("left shift");

      float maxCurrentVelocity = runPressed ? maxRunVelocity : maxWalkVelocity;
      
      if(forwardPressed && VelicityZ < maxCurrentVelocity)
      {
        VelicityZ += Time.deltaTime * acceleration;
      }
      if(leftPressed && VelicityX > -maxCurrentVelocity)
      {
        VelicityX -= Time.deltaTime * acceleration;
      }
      if(runPressed && VelicityZ > -maxCurrentVelocity)
      {
        VelicityZ -= Time.deltaTime * acceleration;
      }
      if(rightPressed && VelicityX < maxCurrentVelocity)
        {
            VelicityX +=Time.deltaTime * acceleration;
        }
      
        if (!forwardPressed && VelicityZ > 0.0f)
        {
            VelicityZ -= Time.deltaTime * deceleration;
            if (VelicityZ < 0.0f) VelicityZ = 0.0f;
        }
        if (!leftPressed && !rightPressed && Mathf.Abs(VelicityX) > 0.0f)
        {
            VelicityX -= Time.deltaTime * Mathf.Sign(VelicityX) * deceleration;
            if (Mathf.Abs(VelicityX) < 0.05f) VelicityX = 0.0f;
        }
        if (!runPressed && VelicityZ < 0.0f)
        {
            VelicityZ += Time.deltaTime * acceleration;
            if (VelicityZ > 0.0f) VelicityZ = 0.0f;
        }

      animator.SetFloat("VelicityX",VelicityX);
    animator.SetFloat("VelicityZ",VelicityZ);
    }
}
