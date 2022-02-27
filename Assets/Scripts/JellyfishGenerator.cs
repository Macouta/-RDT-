using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Motion;
using System.Linq;

public class JellyfishGenerator : MonoBehaviour
{

    public Transform notesParent;
    public Transform jellyfishesParent;
    public Transform jellyfishesTarget;

    public GameObject jellyfishPrefab;
    List<Transform> notes;
    List<GameObject> jellyfishes;
    // Start is called before the first frame update
    void Start()
    {
        jellyfishes = new List<GameObject>();
        notes = new List<Transform>(notesParent.gameObject.GetComponentsInChildren<Transform>().Where(go => go.transform != notesParent.transform));
        foreach(Transform n in notes) {
            Debug.Log(n.name);
            Debug.Log(n.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNote(Vector2 note) {
        if(note.y == 127) {
            int n = (int)note.x % 12;
            GameObject jellyfish = Instantiate(jellyfishPrefab, notes[n].position, Quaternion.identity, jellyfishesParent);
            jellyfish.GetComponent<Jellyfish>().target = jellyfishesTarget;
            jellyfishes.Add(jellyfish);
        }
            
    }
}
