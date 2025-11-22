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
    private float speed = 5.0f ;
    private bool enVie = false;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //recupere la position de notre moustique a l'origine.
        pos_origin = transform.position;
        posTargetHaut = pos_origin;
        posTargetHaut[1] += 3;
        posTargetCote = posTargetHaut;
        posTargetCote[0] -= 10;
        posTargetBas = posTargetCote;
        posTargetBas[1] -= 3;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(move());
        enVie = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator move()
    {
        
        while (this.transform.position != posTargetHaut)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, posTargetHaut, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Debug.Log("C'est fini");
        while (this.transform.position != posTargetCote)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, posTargetCote, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Oh nice");
        transform.position = Vector3.MoveTowards(transform.position, posTargetBas, speed * Time.deltaTime);
        while (this.transform.position != posTargetBas)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, posTargetBas, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = Vector3.MoveTowards(transform.position, posTargetCote, speed * Time.deltaTime);
        yield return null;
        transform.position = Vector3.MoveTowards(transform.position, posTargetHaut, speed * Time.deltaTime);
        yield return null;
        transform.position = Vector3.MoveTowards(transform.position, pos_origin, speed * Time.deltaTime);

        
    }
}
