using System.Collections.Generic;
using UnityEngine;

public class DecorController : MonoBehaviour
{
    public float ScrollSpeed;
    public List<GameObject> ChunksPrefab = new List<GameObject>();
    public List<GameObject> ChunksInstances = new List<GameObject>();
    
    private List<Transform> _chunksExemple = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _setPositionsTransforms();
    }   

    // Update is called once per frame
    void Update()
    {
        _moving();
    }

    private void _setPositionsTransforms(){
        foreach(GameObject chunks in ChunksInstances)
        {
            _chunksExemple.Add(chunks.transform);
            chunks.SetActive(false);
        }
        ChunksInstances.RemoveRange(0,ChunksInstances.Count);
        for(int i = 0; i < _chunksExemple.Count; i++){
            ChunksInstances.Add(Instantiate(ChunksPrefab[Random.Range(0,ChunksPrefab.Count)],_chunksExemple[i].position,_chunksExemple[i].rotation));
        }
    }

    private void _moving(){
        foreach(GameObject chunks in ChunksInstances){
            chunks.transform.position += new Vector3(-ScrollSpeed*Time.deltaTime, 0, 0);
        }
        if(Vector3.Distance(ChunksInstances[0].transform.position, _chunksExemple[0].position) < 1f){
            GameObject chunkToDestroy = ChunksInstances[0];
            ChunksInstances.RemoveAt(0);
            Destroy(chunkToDestroy);
            int indexPrefab = Random.Range(0,ChunksPrefab.Count);
            Transform chunkRight = _chunksExemple[_chunksExemple.Count-1].transform;
            ChunksInstances.Add(Instantiate(ChunksPrefab[indexPrefab], chunkRight.position, chunkRight.rotation));
        }
    }
}
