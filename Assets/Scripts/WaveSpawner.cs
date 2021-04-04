using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;
    public Transform SpawnPoint;
    public Text WaveCountdownText;

    public float TimeBetweenWaves = 5.5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            countdown = TimeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        WaveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
