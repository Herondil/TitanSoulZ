using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnRoll : MonoBehaviour
{
    private AnimatorStateInfo   _state;
    private Animator _playerAnimator;
    private Animator _camAnimator;

    private void Awake()
    {
        _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        _camAnimator    = Camera.main.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //récupérer le state du joueur
        _state = _playerAnimator.GetCurrentAnimatorStateInfo(0);

        if (_state.IsName("Roll"))
        {
            //Debug.Log("Collision avec le joueur qui est en state roll");
            //tremblement de caméra
            _camAnimator.SetTrigger("Anim");
            _playerAnimator.SetBool("EndRoll", true);
            _playerAnimator.gameObject.GetComponent<eightDir>().controllable = false;
            _camAnimator.SetTrigger("Exit");
        }
    }
}
