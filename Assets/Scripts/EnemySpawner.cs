using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float xLimit;
    [SerializeField] private float[] xPositions;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Wave[] wave;
    [SerializeField]private PlayerController _player;
    [SerializeField]private float currentTime;

    private List<float> remainingPositions = new List<float>();
    private int waveIndex;
    private float xPos = 0f;
    private int rand;

    private void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xPositions);
    }

    private void Update()
    {
        if (_player != null && _player.startGame)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                SelectWave();
            }
        }
    }

    public void SpawnEnemy(float xPos)
    {
        GameObject enemyObj = Instantiate(enemyPrefab, new Vector3(xPos, transform.position.y, 0), Quaternion.identity); 
    }

    public void SelectWave()
    {
        // Reinicia la lista de posiciones disponibles
        remainingPositions.Clear();
        remainingPositions.AddRange(xPositions);

        // Selecciona una ola aleatoria
        waveIndex = Random.Range(0, wave.Length);
        currentTime = wave[waveIndex].delayTime;

        for (int i = 0; i < wave[waveIndex].spawnAmount; i++)
        {
            if (remainingPositions.Count > 0)
            {
                int rand = Random.Range(0, remainingPositions.Count);
                float xPos = remainingPositions[rand];
                remainingPositions.RemoveAt(rand);

                SpawnEnemy(xPos);
            }
            else
            {
                Debug.LogWarning("No hay suficientes posiciones de spawn disponibles.");
                break;
            }
        }
    }
}

