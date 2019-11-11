using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    public Light light;
    public float waitingTime = 0.05f;
    IEnumerator Start()
    {
        while (true)
        {
            light.enabled = !(light.enabled); //toggle on/off the enabled property
            yield return new WaitForSeconds(waitingTime);
        }
    }
}
