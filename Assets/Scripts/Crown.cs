using UnityEngine;
using System.Collections;
using DG.Tweening;

[ExecuteInEditMode]
public class Crown : MonoBehaviour
{
    public float thetaScale = 0.01f;        //Set lower to add more points
    [SerializeField] float radius = 3f;
    public float Radius { get => radius; set => radius = value; }
    public float max_radius = 1.0f;
    public float width = 0.1f;
    public Material tentacle_mat;

    private int size; //Total number of points in circle
    private LineRenderer lineRenderer;


    void Start()
    {
        float sizeValue = (2.0f * Mathf.PI) / thetaScale;
        size = (int)sizeValue;
        size++;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.positionCount = size;
    }

    void Update()
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.positionCount = size;
        Vector3 pos;
        float theta = 0f;
        for (int i = 0; i < size; i++)
        {
            theta += (2.0f * Mathf.PI * thetaScale);
            float x = Radius * Mathf.Cos(theta);
            float z = Radius * Mathf.Sin(theta);
            x += this.transform.parent.position.x;
            z += this.transform.parent.position.z;
            pos = new Vector3(x, this.transform.parent.position.y, z);
            lineRenderer.SetPosition(i, pos);
        }
    }

    public void AnimRadius(float duration)
    {
        Debug.Log("anim");
        DOTween.To(() => Radius, x => {
            Radius = x;
            tentacle_mat.SetFloat("_radius", 5.9f + x);
            }, 1f, duration).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutBounce).OnComplete(() => Debug.Log("anim end"));

    }
}