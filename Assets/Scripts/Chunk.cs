using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

    ChunkManager chunkManager;

    private void Start()
    {
        chunkManager = GameObject.FindObjectOfType<ChunkManager>();

    }

    private void Update()
    {
        if (chunkManager.transform.position.y >= this.transform.position.y)
        {
            Destroy(this.gameObject);
            chunkManager.numberOfChunks -= 1;
        }
    }
}
