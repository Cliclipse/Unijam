using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float flashLength =  0.2f;
    [SerializeField] private float cooldownLength = 1f;

    private float flashTimer = 0;
    private float cooldownTimer = 0;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (cooldownTimer < 0)
            {
                cooldownTimer = cooldownLength;
                StartCoroutine(FlashBang());
            }
        }
        cooldownTimer -= Time.deltaTime;
    }

    IEnumerator FlashBang()
    {
        while (flashTimer <= flashLength)
        {
            light.intensity = curve.Evaluate(flashTimer/flashLength);
            flashTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        light.intensity = 0;
        flashTimer = 0;
    }
}
