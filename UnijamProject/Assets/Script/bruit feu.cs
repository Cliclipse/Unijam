using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bruitfeu : MonoBehaviour
{ [SerializeField] private AudioSource fireSound;
    // Start is called before the first frame update
    void Start()
    { 
        fireSound.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        son_distance();
    }
        void son_distance()
        {
            float distance= Vector3.Distance(Move.Instance.transform.position, this.transform.position);
            Debug.Log(distance);
            fireSound.volume = 1 / (distance/5);       
        }
}
