using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
   
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        transform.localScale = new Vector2(2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = Character.healthAmount;
        transform.localScale = localScale;

    }
}
