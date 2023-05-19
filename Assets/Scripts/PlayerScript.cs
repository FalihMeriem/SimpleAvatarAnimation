using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public float VelocityX;
    public float VelocityZ;
    public float acceleration = 4.0f;
    public float deceleration = 4.0f; //whats the point -_- whatever 

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
        
        float VelocityX = animator.GetFloat("VelocityX");
        float VelocityZ = animator.GetFloat("VelocityZ");



        bool forward = Input.GetKey("s");
        bool backward = Input.GetKey("x");
        bool left = Input.GetKey("w");
        bool right = Input.GetKey("c");
        bool run = Input.GetKey("r");

       float maxCurrentVelocity = run ? maxRunVelocity : maxWalkVelocity;
      
        //walks
        if(forward && VelocityZ<maxCurrentVelocity){
            VelocityZ += Time.deltaTime * acceleration;
        }
        if(backward && VelocityZ>-maxCurrentVelocity){
            VelocityZ -= Time.deltaTime * acceleration;
        }
        if(right && VelocityX <maxCurrentVelocity){
            VelocityX += Time.deltaTime * acceleration;
        }
        if(left && VelocityX>-maxCurrentVelocity){
            VelocityX -= Time.deltaTime * acceleration;
        }

       

        //runs
        if(forward && run && VelocityZ < maxCurrentVelocity){
            VelocityZ += Time.deltaTime * acceleration;
        }
        if(backward && run && VelocityZ>-maxCurrentVelocity){
            VelocityZ -= Time.deltaTime * acceleration;
        }

        if(right && run && VelocityX > -maxCurrentVelocity){
            
            VelocityX += Time.deltaTime * acceleration;
        }
        if(left && run &&  VelocityX>-maxCurrentVelocity){
            
            VelocityX -= Time.deltaTime * acceleration;
        }




//sabotage '-' stops

        if (!forward  && !backward  && Mathf.Abs(VelocityZ) > 0.0f)
        {
            VelocityZ -= Time.deltaTime * Mathf.Sign(VelocityZ) * deceleration;
            //if (VelocityZ < 0.0f) VelocityZ = 0.0f;
        }
        /*if (!backward  && VelocityZ < 0.0f)
        {
            VelocityZ += Time.deltaTime * deceleration;
            //if (VelocityZ < 0.0f) VelocityZ = 0.0f;
        }*/
        if (!left && !right && Mathf.Abs(VelocityX) > 0.0f)//Mathf.Abs = valeur absolue
        {
            VelocityX -= Time.deltaTime * Mathf.Sign(VelocityX) * deceleration;
            //if (Mathf.Abs(VelocityX) < 0.05f) VelocityX = 0.0f;
        }




        if (!run && Mathf.Abs(VelocityZ) > 0.5f)
        {
            VelocityZ -= Time.deltaTime * Mathf.Sign(VelocityZ)* acceleration;
           /* if (VelocityZ > 0.0f) VelocityZ = 0.0f;*/
        }

        if (!run && Mathf.Abs(VelocityX) > 0.5f)
        {
            VelocityX -= Time.deltaTime * Mathf.Sign(VelocityX) * acceleration;
           /* if (VelocityZ > 0.0f) VelocityZ = 0.0f;*/
        }


        //sabotage '-'
        /*
        
        if( !run && VelocityZ > maxCurrentVelocity ){
            VelocityZ -= Time.deltaTime * deceleration;
        }
        if( !forward &&  VelocityZ > maxCurrentVelocity){
            VelocityZ -= Time.deltaTime * deceleration;
            
        }
        if(!right && !left && !run && VelocityX < -maxCurrentVelocity){
            
            VelocityX -= Time.deltaTime * deceleration;
        }
       */


    //add backwards  DONE
    
    //run backwards DONE 

    //add deceleration DONE IG

    //add limits 3la mayfoutch 1 and 0 etc IDK ABOUT YALL BUT 3NDI MAKIFOUTCH LIMITS


        animator.SetFloat("VelocityX",VelocityX);
        animator.SetFloat("VelocityZ",VelocityZ);
      
    }
}
