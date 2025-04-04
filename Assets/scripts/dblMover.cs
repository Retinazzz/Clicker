using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dblMover : MonoBehaviour

{
    [SerializeField] private Artifact _artifact;

public Vector3 pointA = new Vector3(-9, -2, 0);
public Vector3 pointB = new Vector3(9, -2, 0);
public float speed = 10.0f;

private Vector3 target;

void Start()
{
    target = pointB;
}

void Update()
{
    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    if (Vector3.Distance(transform.position, target) < 0.1f)
    {
        target = (target == pointA) ? pointB : pointA;  // Switch target
    }
}
public void OnTriggerEnter2D(Collider2D other)
{
    //_artifact.Addclicks(5);
    //Debug.Log("111");
}
}
