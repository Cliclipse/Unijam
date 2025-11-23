using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;

public class Moustique : MonoBehaviour
{
    private Vector3 pos_origin;
    private Vector3 posTargetHaut;
    private Vector3 posTargetCote;
    private Vector3 posTargetBas;
    public float speed = 5.0f ;
    public float hauteur= 3.0f;
    public float largeur = 10.0f;
    private bool enVie = true;
    [SerializeField] private AudioSource mosquitoSound;





    // Start is called before the first frame update
    void Start()
    {
        //recupere la position de notre moustique a l'origine.
        pos_origin = transform.position;
        posTargetHaut = pos_origin;
        posTargetHaut[1] += hauteur;
        posTargetCote = posTargetHaut;
        posTargetCote[0] -= largeur;
        posTargetBas = posTargetCote;
        posTargetBas[1] -= hauteur;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(move());
        enVie = true;

    }
    void Update()
    {
       son_distance();
    }
    void son_distance()
    {
        float distance= Vector3.Distance(Move.Instance.transform.position, this.transform.position);
        Debug.Log(distance);
        mosquitoSound.volume = 1 / (distance/3);       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DeathManager.Instance.ResetScene(false);
        }
    }

    IEnumerator move()
    {
        while (enVie)
        {
            while (this.transform.position != posTargetHaut)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, posTargetHaut, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            GetComponent<Rigidbody2D>().gravityScale = 0;
            //Debug.Log("C'est fini");
            while (this.transform.position != posTargetCote)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, posTargetCote, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            //Debug.Log("Oh nice");
            transform.position = Vector3.MoveTowards(transform.position, posTargetBas, speed * Time.deltaTime);
            while (this.transform.position != posTargetBas)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, posTargetBas, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            //Debug.Log("Oh no");
            while (this.transform.position != posTargetCote)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, posTargetCote, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            //Debug.Log("Let me out");

            while (this.transform.position != posTargetHaut)
            {
                transform.position = Vector3.MoveTowards(transform.position, posTargetHaut, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            //Debug.Log("pleure");
            while (this.transform.position != pos_origin)
            {
                transform.position = Vector3.MoveTowards(transform.position, pos_origin, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            //Debug.Log("c'est fini2");
        }
        
        
    }
}
