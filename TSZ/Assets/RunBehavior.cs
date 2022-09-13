using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBehavior : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("début du state run");
        
        animator.gameObject.GetComponent<eightDir>().controllable = true;
        animator.gameObject.GetComponent<eightDir>().currentSpeed = animator.gameObject.GetComponent<eightDir>().runSpeed;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        /*
         * Attention ! Ici les lignes suivantes ne posent pas de soucis parce que la transition engendrée par le trigger
         * est instantannée !
         * 
         * Si la transition devait durer, ce state ne finirait qu'à la fin de la transition, et donc ...
         * Le trigger se réactiverait ! Car il aura été consommé une première fois pour lancer la transition
         * Et donc réactivé à la frame suivante ...
         * 
         * Certaines personnes diront que c'est ici plus pratique d'utiliser des booléens.
         * 
         * Une règle ? Il faut faire gaffe aux inputs et aux triggers.
         * 
         */

        if (Input.GetButton("Fire1"))
        {
            //On veut faire un roll
            animator.SetTrigger("Roll");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
