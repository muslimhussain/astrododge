using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoroid : MonoBehaviour
{
    [SerializeField] private float travelSpeedIncrement = 0.1f;
    [SerializeField] private float travelSpeed = 5f;
    [SerializeField] private float lifeTime = 5f;
    
    void Start()
    {
        Invoke(nameof(DestroySelf), lifeTime);
    }

    void Update()
    {
        transform.Translate(-travelSpeed * Time.deltaTime, 0, 0);

        travelSpeed += travelSpeedIncrement * Time.deltaTime;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
