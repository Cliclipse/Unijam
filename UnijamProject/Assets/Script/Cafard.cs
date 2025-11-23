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
    [SerializeField] private AudioSource blatteSound;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    void Update()
    {
        cible = target.position;
        cible.y = transform.position.y;
        transform.position = Vector3.MoveTowards(this.transform.position, cible, speed * Time.deltaTime);
        son_distance();
    }

    void son_distance()
    {
        float distance= Vector3.Distance(Move.Instance.transform.position, this.transform.position);
        Debug.Log(distance);
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
}
