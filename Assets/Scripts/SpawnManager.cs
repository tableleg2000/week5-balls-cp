using UnityEngine;
using System.Collections.Generic;
using System.Collections;

#
public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public GameObject[] enemyPrefabToSpawn;
    private float spawnRange = 50;
    public int enemyCount;
    public int waveNumber = 1;
    public int maxEnemies = 100;       //max number of enemies on screen
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
          
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 5; i <enemiesToSpawn; i++)
        {
            int index = Random.Range(0, enemyPrefab.Count);
            Instantiate(enemyPrefab[index], GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    public void SpawnArray()
    {
        for ( int i = 0; i <enemyPrefabToSpawn.Length; i++)
        {

        }
    } 

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<EnemyController>(FindObjectsSortMode.None).Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    
}
