using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControllerByType : MonoBehaviour
{
    public Animator animator;
    public int isWalkingHash;
    public int isSittingHash;
    public int isRunningHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isSittingHash = Animator.StringToHash("isSit");
        isRunningHash = Animator.StringToHash("isRunning");
        


    }

    // Update is called once per frame
    void Update()
    {
        //bool isRunning = animator.GetBool(isRunningHash);
        //bool isWalking = animator.GetBool(isWalkingHash);
        //bool forwardPressed = false;
        //bool runPressed = Input.GetKey("left shift");
        //if (!isWalking && forwardPressed)
        //{
        //    animator.SetBool(isWalkingHash, true);
        //}
        //if (isWalking && !forwardPressed)
        //{
        //    animator.SetBool(isWalkingHash, false);
        //}
        //if (!isRunning && (forwardPressed && runPressed))
        //{
        //    animator.SetBool(isRunningHash, true);
        //}
        //if (isRunning && (!forwardPressed || !runPressed))
        //{
        //    animator.SetBool(isRunningHash, false);
        //}
    }
}
