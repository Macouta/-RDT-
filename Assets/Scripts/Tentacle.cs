using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tentacle : MonoBehaviour
{
    public Transform targetDir;
    public int resolution = 10;
    public float length = 3f;
    public float smoothSpeed = 0.02f;
    public float trailSpeed = 350;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;


    private float dist;
    private Vector3[] segmentPoses;
    private Vector3[] segmentV;
    private LineRenderer lineRend;


    
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = resolution;
        segmentPoses = new Vector3[resolution];
        segmentV = new Vector3[resolution];

        dist = length / resolution;

        ResetPos();
    }

    // Update is called once per frame
    void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude, 0);


        segmentPoses[0] = targetDir.position;
        
        for(int i = 1; i < segmentPoses.Length; i++) {
            // Vector3 targetPos = segmentPoses[i - 1] + targetDir.right * dist;
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * dist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed + i / trailSpeed);
        }

        lineRend.SetPositions(segmentPoses);
    }

    private void ResetPos() {
        segmentPoses[0] = targetDir.position;
        for(int i = 1; i < resolution; i++) {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right * dist;
        }
        lineRend.SetPositions(segmentPoses);
    }
}
