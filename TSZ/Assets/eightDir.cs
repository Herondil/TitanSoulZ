using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eightDir : MonoBehaviour
{
    private Rigidbody2D _rgbd;
    private Animator _nmtr;
    
    public float runSpeed;
    public float sprintSpeed;
    public float rollSpeed;

    //speed currently effective
    public float currentSpeed;

    public bool controllable;

    private Vector2 direction;
    private Vector2 orientation;


    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
        _nmtr = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //booléen pour autorise ou non le mouvement
        if (controllable)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        //la direction est dépendante des inputs
        if (direction.magnitude > 0)
        {
            _nmtr.SetFloat("DirX", direction.x);
            _nmtr.SetFloat("DirY", direction.y);
            _nmtr.SetBool("isMoving", true);

            //clamp 
            //normaliser le vecteur orientation
            orientation = Vector2.ClampMagnitude(direction * 10000f, 1f);
        }
        else
        {
            _nmtr.SetFloat("DirX", orientation.x);
            _nmtr.SetFloat("DirY", orientation.y);
            _nmtr.SetBool("isMoving", false);
        }

        //controllable signifie qu'on ne peut plus faire d'action
        /*
        if (controllable)
        {
            if (Input.GetButton("Fire1"))
            {
                //On veut faire un roll
                _nmtr.SetTrigger("Roll");
            }
        }*/
        
    }

    private void FixedUpdate()
    {
        _rgbd.velocity = direction.normalized * currentSpeed;
    }
}
