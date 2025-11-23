using System.Collections;
using UnityEngine;

public class SexManager : MonoBehaviour
{
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private float much=.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(QTECorrection());
        }
    }

    

    IEnumerator QTECorrection()
    {
        leftHand.transform.position+= new Vector3(much*40,0,0);
        rightHand.transform.position-= new Vector3(much*40,0,0);
        yield return new WaitForSeconds(0.1f);
        leftHand.transform.position-= new Vector3(much*20,0,0);
        rightHand.transform.position+= new Vector3(much*20,0,0);
        yield return new WaitForSeconds(0.1f);
        leftHand.transform.position+= new Vector3(much*10,0,0);
        rightHand.transform.position-= new Vector3(much*10,0,0);
        yield return new WaitForSeconds(0.1f);
        checkDistance();
    }

    void checkDistance()
    {
        if (Vector2.Distance(leftHand.transform.position, rightHand.transform.position) <= .5f)
        {
            
        }
    }
}
