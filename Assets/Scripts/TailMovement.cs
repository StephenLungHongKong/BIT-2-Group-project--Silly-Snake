using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TailMovement : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    public Vector3 tailTarget;
    public GameObject tailTargetObj;
    public PlayerMovementScript mainSnake;
    public float stoppingDistance = 0.5f;

    void Start()
    {
        //mainSnake = GameObject.FindGameObjectWithTag(snake).GetComponent<PlayerMovementScript>();
        Speed = mainSnake.moveSpeed;
        tailTargetObj = mainSnake.tailObjects[mainSnake.tailObjects.Count - 2];
    }

    void Update()
    {
        tailTarget = tailTargetObj.transform.position;
        float dist = Vector3.Distance(transform.position, tailTarget);
        if (dist > stoppingDistance)
        {
            transform.LookAt(tailTarget);
            transform.Translate(0, 0, Speed * Time.deltaTime);
        }
    }


}
