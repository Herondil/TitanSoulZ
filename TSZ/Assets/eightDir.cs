using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eightDir : MonoBehaviour
{
    private Rigidbody2D _rgbd;
    
    public float speed;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction =  new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        _rgbd.velocity = direction.normalized*speed;
    }
}
