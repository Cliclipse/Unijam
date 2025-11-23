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
    private Vector3 posOrigin;
    private Vector3 posTarget;
    [SerializeField] private float largeur = 10f;
    [SerializeField] private bool ciblant = false;
    [SerializeField] private AudioSource blatteSound;
    void Start()
    {
        posOrigin = transform.position;
        posTarget = transform.position;
        posTarget[0] += largeur;
        if (!ciblant)
        {
            StartCoroutine(move());
        }
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    void Update()
    {
        cible = target.position;
        cible.y = transform.position.y;
        if (ciblant)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, cible, speed * Time.deltaTime);
        }
        son_distance();
    }

    void son_distance()
    {
        float distance= Vector3.Distance(Move.Instance.transform.position, this.transform.position);
        blatteSound.volume = 1 / (distance/5);       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DeathManager.Instance.ResetScene(false);
        }
        else if (collision.gameObject.CompareTag("Flash"))
        {
            Debug.Log("cafard mort");
        }
    }
    
    IEnumerator move()
    {
        while (enVie)
        {
            while (transform.position != posTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, posTarget, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            transform.Rotate(0, 180, 0);
            while (transform.position != posOrigin)
            {
                transform.position = Vector3.MoveTowards(transform.position, posOrigin, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DeathManager.Instance.ResetScene(false);
        }
        else if (other.gameObject.CompareTag("Flash"))
        {
            Debug.Log("cafard mort");
            GetComponent<Collider2D>().enabled = false;
            speed = 0;
        }
    }
}
