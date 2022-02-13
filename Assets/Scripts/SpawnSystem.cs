using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [System.Serializable]
    private class EnemySpawnType
    {
        public GameObject enemyPrefab;
        public float spawnInterval = 1f;
        public float spawnIntervalStep = 0.1f;
        public int countPerWave = 1;
        public int countPerWaveStep = 2;

        public bool WaveFinished { get; set; }
        public float CurrentInterval { get; set; }
        public int CurrentTotalCount { get; set; }
        public int CurrentCount { get; set; }
    }

    [SerializeField] private EnemySpawnType[] spawnTypes;
    [SerializeField] private int totalWaves = 5;
    [SerializeField] private float waveInterval = 3f;
    [SerializeField] private Transform spawnPoint;

    private int currWave = 0;

    public List<GameObject> SpawnedObjects { get; private set; }

    private void Awake()
    {
        SpawnedObjects = new List<GameObject>();
    }

    private void Start()
    {
        foreach (EnemySpawnType spawnType in spawnTypes)
        {
            spawnType.CurrentInterval = spawnType.spawnInterval;
            spawnType.CurrentTotalCount = spawnType.countPerWave;
        }
        StartCoroutine(WaveTimer());
    }

    private IEnumerator WaveTimer()
    {
        while (currWave < totalWaves)
        {
            Debug.Log("wave started");
            currWave++;
            foreach (EnemySpawnType spawnType in spawnTypes)
            {
                StartCoroutine(SpawnTimer(spawnType));
            }

            bool isWaveFinished = false;
            while (!isWaveFinished)
            {
                isWaveFinished = true;
                foreach (EnemySpawnType spawnType in spawnTypes)
                {
                    if (!spawnType.WaveFinished)
                    {
                        isWaveFinished = false;
                        break;
                    }
                }

                yield return null;
            }

            yield return new WaitForSeconds(waveInterval);

            foreach (EnemySpawnType spawnType in spawnTypes)
            {
                spawnType.CurrentInterval -= spawnType.spawnIntervalStep;
                spawnType.CurrentTotalCount += spawnType.countPerWaveStep;
            }
        }

        // win the game
        Time.timeScale = 0;
        HUD.WinPanel.ToggleVisible();
    }

    private IEnumerator SpawnTimer(EnemySpawnType spawnType)
    {
        spawnType.CurrentCount = 0;
        spawnType.WaveFinished = false;
        yield return new WaitForSeconds(spawnType.CurrentInterval);
        while (spawnType.CurrentCount < spawnType.CurrentTotalCount)
        {
            GameObject enemy = Instantiate(spawnType.enemyPrefab, spawnPoint.position, Quaternion.identity);
            SpawnedObjects.Add(enemy);
            spawnType.CurrentCount++;
            yield return new WaitForSeconds(spawnType.CurrentInterval);
        }
        spawnType.WaveFinished = true;
    }
}
