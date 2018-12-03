using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {

    public Chunk[] chunks;
    public float spawnNextChunk = 12f;
    public int numberOfChunks = 0;

    Ball ball;
	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

        if (numberOfChunks < 2 && ball.isPlaying)
        {
            spawnNextChunk += 10f;
            Vector2 newChunkPos = new Vector2(0f, spawnNextChunk);

            int randomChunk = Random.Range(0, chunks.Length);
           // print(randomChunk);
            Instantiate(chunks[randomChunk], newChunkPos, Quaternion.identity);
            numberOfChunks += 1;
        }
    }
}
