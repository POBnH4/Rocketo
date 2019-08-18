using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Osilliator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementFactor;
    [SerializeField] float period = 2f;

    Vector3 startingPositon;

    // Start is called before the first frame update
    void Start()
    {
        this.startingPositon = transform.position;
    }

    // Update is called once per frame  
    void Update()
    {
        if (period <= Mathf.Epsilon) return;

        const float tau = Mathf.PI * 2f;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);
        print(cycles + " | " + rawSinWave);
        movementFactor = (rawSinWave / 2f) + 0.5f;
        
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPositon + offset;
        
    }
}
