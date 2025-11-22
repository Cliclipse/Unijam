using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araignée : MonoBehaviour
{
    private Vector3 posOrigin;
    private  Vector3 posTarget;
    public float speed = 5.0f ;
    public float largeur = 10.0f;
    private bool enVie = true;
    // Start is called before the first frame update
    void Start()
    {
        posOrigin = transform.position;
        posTarget = transform.position;
        posTarget[0] +=largeur;
        StartCoroutine(move());
    }

    // Update is called once per frame
    IEnumerator move()
    {
        while (transform.position != posTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, posTarget,speed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        while (transform.position != posOrigin)
        {
            transform.position = Vector3.MoveTowards(posOrigin, posTarget,speed*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
