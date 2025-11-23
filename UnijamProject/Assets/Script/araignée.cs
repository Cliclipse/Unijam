using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araignée : MonoBehaviour
{
    private Vector3 posOrigin;
    private Vector3 posTarget;
    public float speed = 5f;
    public float largeur = 10.0f;

    private bool enVie = true;
    [SerializeField] private AudioSource spiderSound;

    // Start is called before the first frame update
    void Start()
    {
        posOrigin = transform.position;
        posTarget = transform.position;
        posTarget[0] += largeur;
        StartCoroutine(move());
    }
    void Update()
    {
        son_distance();
    }
    void son_distance()
    {
        float distance= Vector3.Distance(Move.Instance.transform.position, this.transform.position);
        Debug.Log(distance);
        spiderSound.volume = 1 / (distance/5);       
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DeathManager.Instance.ResetScene(false);
        }
    }
    
    // Update is called once per frame
    IEnumerator move()
    {
        while (enVie)
        {
            while (transform.position != posTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, posTarget, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            Debug.Log("Mehh");

            while (transform.position != posOrigin)
            {
                transform.position = Vector3.MoveTowards(transform.position, posOrigin, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }

    }
}

