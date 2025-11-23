using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;

namespace Script
{
    public class Moustique_rond : MonoBehaviour
    {
        public float angularSpeed = 5f;
        public float circleRad = 6f;
        private Vector2 fixedPoint;
        private float currentAngle;
        private bool enVie;
        [SerializeField] private AudioSource mosquitoSound;
        void Start()
        {
            //recupere la position de notre moustique a l'origine.
            GetComponent<Rigidbody2D>().gravityScale = 0;
            fixedPoint = transform.position;
            enVie = true;

        }
         void son_distance()
    {
        float distance= Vector3.Distance(Move.Instance.transform.position, this.transform.position);
        Debug.Log(distance);
        mosquitoSound.volume = 1 / (distance/5);       
    }

        void Update()
        {
            currentAngle += angularSpeed * Time.deltaTime;
            Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;
            transform.position = fixedPoint + offset;
            son_distance();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                DeathManager.Instance.ResetScene();
            }
        }
    }
}