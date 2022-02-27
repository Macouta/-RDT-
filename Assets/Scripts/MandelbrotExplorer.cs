using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandelbrotExplorer : MonoBehaviour
{
    public Material mandlebrot_mat;
    public Vector2 pos;
    public float scale = 4;
    public float angle = 0;

    private Vector2 smoothPos;
    private float smoothScale;
    private float smoothAngle;

    private void UpdateShader() {
        smoothPos = Vector2.Lerp(smoothPos, pos, .03f);
        smoothScale = Mathf.Lerp(smoothScale, scale, .03f);
        smoothAngle = Mathf.Lerp(smoothAngle, angle, .03f);
        float aspect = 4/4f;

        float scale_x = smoothScale;
        float scale_y = smoothScale;

        if(aspect > 1f) {
            scale_y /= aspect;
        } else {
            scale_x *= aspect;
        }
        mandlebrot_mat.SetVector("_Area", new Vector4(smoothPos.x, smoothPos.y, scale_x,scale_y));
        mandlebrot_mat.SetFloat("_Angle", smoothAngle);
    }

    private void HandleInputs() {
        if(Input.GetKey(KeyCode.KeypadPlus)) {
            scale *= 0.99f; 
        }
        if(Input.GetKey(KeyCode.KeypadMinus)) {
            scale *= 1.01f; 
        }

        if(Input.GetKey(KeyCode.A)) {
            angle += 0.01f; 
        }
        if(Input.GetKey(KeyCode.E)) {
            angle -= 0.01f; 
        }

        Vector2 dir = new Vector2(.01f*scale, 0);
        float s = Mathf.Sin(angle);
        float c = Mathf.Cos(angle);
        dir = new Vector2(dir.x*c-dir.y*s, dir.x*s+dir.y*c);
        
        if(Input.GetKey(KeyCode.Q))
            pos -= dir;
        if(Input.GetKey(KeyCode.D))
            pos += dir;
        // if(Input.GetKey(KeyCode.S))
        //     pos.y -= .01f*scale;
        // if(Input.GetKey(KeyCode.Z))
        //     pos.y += .01f*scale;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HandleInputs();
        UpdateShader();
    }
}
