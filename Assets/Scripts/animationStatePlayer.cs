using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStatePlayer : MonoBehaviour
{
    //Variables
    Animator animator;
    int isRunningHash;
    int isAttackingHash;

    // Start is called before the first frame update
    void Start()
    {
        //Get the type animator in our scene
        animator = GetComponent<Animator>();

        //Get the variable in the animator
        isRunningHash = Animator.StringToHash("isRunning");
        isAttackingHash = Animator.StringToHash("isAttacking");
    }

    // Update is called once per frame
    void Update()
    {
        // Help us to know if the player is idle or running
        bool isRunning = animator.GetBool(isRunningHash);
        bool isRunPressed = Input.GetKeyDown(KeyCode.W);

        // Help to know if the player is attacking
        bool isAttacking = animator.GetBool(isAttackingHash);
        bool attackedPressed = Input.GetKeyDown(KeyCode.Space);

        //Changing the bool if he is or not running
        if (!isRunning && isRunPressed)
            animator.SetBool(isRunningHash, true);

        if (isRunning && !isRunPressed)
            animator.SetBool(isRunningHash, false);

        //Changing the bool if he is attacking and running
        if (!isAttacking && (isRunPressed && attackedPressed))
            animator.SetBool(isAttackingHash, true);

        if (isAttacking && (!isRunPressed || !attackedPressed))
            animator.SetBool(isAttackingHash, false);
    }
}
