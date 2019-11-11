using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject obstacles;
    public Transform target;

    public float XSize = 8.8f;
    public float ZSize = 8.8f;

    public Vector3 curPos;
    public Vector3 origin;

    public int noOfTrees;

    private float planetSize = 9.5f;

    private float lamda;
    private float phi;
    private Vector3 delta;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= noOfTrees; i++)
        {
            AddTree();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RandomPos()
    {
        lamda = Random.Range(0f, 6.283f);
        phi = Random.Range(0f, 6.283f);
        float x = planetSize * Mathf.Cos(lamda) * Mathf.Cos(phi);
        float y = planetSize * Mathf.Cos(lamda) * Mathf.Sin(phi);
        float z = planetSize * Mathf.Sin(lamda);
        curPos = new Vector3(x, y, z);
    }
    void AddTree()
    {
        
        RandomPos();
        delta = target.position - curPos;
        rotation = Quaternion.LookRotation(delta);
        obstacles = GameObject.Instantiate(obstacles, curPos, Quaternion.Slerp(transform.rotation, rotation, 1)) as GameObject;
       
    }
}
