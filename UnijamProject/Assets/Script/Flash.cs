using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float flashLength =  0.2f;
    [SerializeField] private float cooldownLength = 1f;
    [SerializeField] private Collider2D collider ;
    [SerializeField] private Image reloadImage;

    private float flashTimer = 0;
    private bool cooldownTimer =true;

    void Start()
    {
        collider.enabled = false;
        reloadImage.fillAmount = 0;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (cooldownTimer )
            {
                StartCoroutine(Reload());
                StartCoroutine(FlashBang());
                cooldownTimer = false;
            }
        }
    }

    IEnumerator FlashBang()
    {
        collider.enabled = true;
        while (flashTimer <= flashLength)
        {
            light.intensity = curve.Evaluate(flashTimer/flashLength);
            flashTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            if (flashTimer >= flashLength / 5 && collider.enabled)
            {
                collider.enabled = false;
            }
        }
        light.intensity = 0;
        flashTimer = 0;
        
    }

    IEnumerator Reload()
    {
        float timing = 0;
        while (timing < cooldownLength)
        {
            timing += Time.deltaTime;
            
            reloadImage.fillAmount = 1-(timing / cooldownLength);
            yield return new WaitForEndOfFrame();
        }
        cooldownTimer = true;
        
    }
}
