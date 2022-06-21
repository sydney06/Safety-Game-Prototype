using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Controller : MonoBehaviour
{
    private Animator playerAnimator;



    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       //if(Input.get)
        
        
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerAnimator.SetBool("isUp", true);

            playerAnimator.SetBool("isDown", false);
            playerAnimator.SetBool("isLeft", false);
            playerAnimator.SetBool("isRight", false);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerAnimator.SetBool("isDown", true);

            playerAnimator.SetBool("isUp", false);
            playerAnimator.SetBool("isLeft", false);
            playerAnimator.SetBool("isRight", false);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnimator.SetBool("isLeft", true);

            playerAnimator.SetBool("isUp", false);
            playerAnimator.SetBool("isDown", false);
            playerAnimator.SetBool("isRight", false);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerAnimator.SetBool("isRight", true);

            playerAnimator.SetBool("isUp", false);
            playerAnimator.SetBool("isDown", false);
            playerAnimator.SetBool("isLeft", false);
        }
        else
        {
            playerAnimator.SetBool("isRight", false);
            playerAnimator.SetBool("isUp", false);
            playerAnimator.SetBool("isDown", false);
            playerAnimator.SetBool("isLeft", false);
        }





    }



}
