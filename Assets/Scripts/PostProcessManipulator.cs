using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using Kino.PostProcessing;
public class PostProcessManipulator : MonoBehaviour
{

    private float jitterAmount;

    public float JitterAmount { get => jitterAmount; set => jitterAmount = value; }

    private float driftAmount;
    public float DriftAmount { get => driftAmount; set => driftAmount = value; }

    private Volume postprocess;
    private Glitch glitch;
    private Recolor recolor;

    // Start is called before the first frame update
    void Start()
    {
        postprocess = GetComponent<Volume>();
        Glitch g;
        if(postprocess.profile.TryGet<Glitch>(out g) ) {
            glitch = g;
        }

        Recolor r;
        if(postprocess.profile.TryGet<Recolor>(out r) ) {
            recolor = r;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        glitch.jitter.value = jitterAmount;
        glitch.drift.value = driftAmount;
    }
}
