using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 grid_size = new Vector2(7, 8);
    public Vector2 margins = new Vector2(0.5f, 0.5f);
    private List<GameObject> generated = new List<GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {

        float size_x = grid_size.x + (margins.x * (grid_size.x - 2));
        float size_y = grid_size.y + (margins.y + (grid_size.y - 2));

        for(int i = 0; i < grid_size.x; i++) {
            for(int j = 0; j < grid_size.y; j++) {

                Vector3 pos = new Vector3(i + (margins.x * i) - (size_x/2) , 
                                            this.transform.position.y, 
                                            j  + (margins.y * j) - (size_y/2) );
                GameObject obj = Instantiate(prefab, pos, Quaternion.identity, this.transform);
                generated.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
