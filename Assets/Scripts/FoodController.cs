using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public GameObject foodPrefab;

    public float XSize = 8.8f;
    public float ZSize = 8.8f;

    public Vector3 curPos;
    public GameObject curFood;
    public Transform target;
    public float crashDistance = 1.0f;

    private float planetSize = 9.5f;

    private float lamda;
    private float phi;
    private Vector3 delta;
    private Quaternion rotation;
    private bool crashed;

    GameObject[] gameObjects;
    private void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    void AddNewFood()
    {
        RandomPos();
        if (crashed) RandomPos();
        delta = target.position - curPos;
        rotation = Quaternion.LookRotation(delta);
        curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.Slerp(transform.rotation, rotation, 1)) as GameObject;
    }

    void RandomPos()
    {
        lamda = Random.Range(0f, 6.283f);
        phi = Random.Range(0f, 6.283f);

        float x = planetSize * Mathf.Cos(lamda) * Mathf.Cos(phi);
        float y = planetSize * Mathf.Cos(lamda) * Mathf.Sin(phi);
        float z = planetSize * Mathf.Sin(lamda);
        curPos = new Vector3(x, y, z);
        foreach (GameObject obstacle in gameObjects)
        {
            if (Vector3.Distance(curPos, obstacle.transform.position) < crashDistance)
            {
                crashed = false;
            }
            else
            {
                crashed = true;
                Debug.Log("Food crashed Obstacle");
            }
        }
    }

    void Update()
    {
        if (!curFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }

}
