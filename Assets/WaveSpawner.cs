using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<Wave> waves;

    int currentWaveIdx = 0;
    int nextSpawnIdx = 0;
    float timeSinceSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        Wave currentWave = waves[currentWaveIdx];
        if (nextSpawnIdx < currentWave.enemies.Count) {
            if (timeSinceSpawn > currentWave.delayBetweenSpawns) {
                // spawn enemy
                Instantiate(currentWave.enemies[nextSpawnIdx], transform.position, Quaternion.identity);
                nextSpawnIdx++;
                timeSinceSpawn = 0.0f;
            }
        } else if (GameObject.FindGameObjectsWithTag("enemy").Length == 0) {
            if (currentWaveIdx < waves.Count-1) {
                currentWaveIdx++;
                nextSpawnIdx = 0;
            } else {
                // all waves completed
                gameObject.SetActive(false);;
            }
        }
    }
}
