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

        void Start()
        {
            //recupere la position de notre moustique a l'origine.
            GetComponent<Rigidbody2D>().gravityScale = 0;
            fixedPoint = transform.position;
            enVie = true;

        }

        void Update()
        {
            currentAngle += angularSpeed * Time.deltaTime;
            Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;
            transform.position = fixedPoint + offset;
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log(" mort ");
            }
        }
    }
}