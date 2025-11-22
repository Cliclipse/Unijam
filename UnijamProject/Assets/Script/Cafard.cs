using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafard : MonoBehaviour
{
    private bool enVie = true;
    public float speed = 5f;
    private Transform target; // Déplacement vers lequel on essaie d'aller à chaque tour. 
    private Vector3 cible;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    void Update()
    {
       cible = target.position;
       cible.y = transform.position.y;
       transform.position = Vector3.MoveTowards(this.transform.position, cible, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Mort");
    }
}
