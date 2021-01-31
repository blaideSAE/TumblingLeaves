using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLerpOverTime : MonoBehaviour
{
    public Vector3 endRotation;
    private Quaternion startRotation;
    public float period;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < period *60) 
        {
            timer += Time.deltaTime;

            transform.rotation = Quaternion.Lerp(startRotation,Quaternion.Euler(endRotation),timer/(period*60));


        }
        
    }


}
