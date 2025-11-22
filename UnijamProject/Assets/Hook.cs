using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
    
    public Vector2 target;
    Vector2 direction;
    private bool _onTarget = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _onTarget = false;
        Vector2 direction = (new Vector2(transform.position.x, transform.position.y) - target).normalized;
    }

    //S'optimise en faisant pas la distance pour épargner la rac carrée
    private void Rush()
    {
        Vector3 delta = speed * Time.deltaTime * direction;
        if (Vector2.Distance(transform.position, target) < delta.magnitude)
        {
            transform.position = target;
            _onTarget = true;
        }
        else
        {
            transform.position += delta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_onTarget) Rush();
    }
}
