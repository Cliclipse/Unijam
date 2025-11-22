using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float distanceDeChamp;
    [SerializeField] private GameObject player; 
    [SerializeField] private float hauteur; 

    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3( player.transform.position.x , hauteur, -distanceDeChamp);
    }
}
