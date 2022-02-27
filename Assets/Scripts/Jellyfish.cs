using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Jellyfish : MonoBehaviour
{

    public Transform target;
    public float speed = 1f;
    private bool onDash = false;
    float rando;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        rando = Random.Range(0.5f, 1f);
        distance = Vector3.Distance(transform.position, target.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
            Destroy(this);
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * rando * Time.deltaTime);
    }
}
