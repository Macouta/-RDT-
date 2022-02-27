using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteInEditMode]
public class TubeGenerator : MonoBehaviour
{
    private bool mooving = true;
    public bool Mooving { get => mooving; set => mooving = value; }
    [Button("Moove")]
    private void DefaultSizedButton() { this.Mooving = !this.Mooving; }

    public static TubeGenerator instance;
    public Camera mainCamera;
    public Transform startPoint; //Point from where ground tiles will start
    public TubeTile tilePrefab;
    public float movingSpeed = 12;
    public int tilesToPreSpawn = 15; //How many tiles should be pre-spawned

    List<TubeTile> spawnedTiles = new List<TubeTile>();


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        Vector3 spawnPosition = startPoint.position;

        UOUtility.DestroyChildren(transform.gameObject);
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            TubeTile spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity) as TubeTile;
            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            spawnedTiles.Add(spawnedTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mooving)
        {
            foreach (TubeTile t in spawnedTiles)
            {
                t.transform.Translate(-t.transform.forward * Time.deltaTime * movingSpeed, Space.World);
            }
            if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).z < 0)
            {
                //Move the tile to the front if it's behind the Camera
                TubeTile tileTmp = spawnedTiles[0];
                spawnedTiles.RemoveAt(0);
                tileTmp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTmp.startPoint.localPosition;
                spawnedTiles.Add(tileTmp);
            }
        }

    }
}
