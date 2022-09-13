using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothValue;
    public float yOffset;
    public float xVelocity = 0.0f;
    public float yVelocity = 0.0f;

    // Après Update, après les mouvements de la cible
    void LateUpdate()
    {
        //Partir de la position actuelle, pour aller à la position target, avec
        float newX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref xVelocity, smoothValue);
        float newY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothValue);



        //sans smooth effect
        //transform.position = new Vector3 (target.position.x, target.position.y + yOffset,-10);

        transform.position = new Vector3(newX, newY, -10);
    }
}
