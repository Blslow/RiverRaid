using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float spawningInterval = 1f;

    [SerializeField]
    private List<Transform> spawnPoints = new();

    [SerializeField]
    private List<GameObject> allEnemies = new();

    public static bool ShouldEnemiesSpawn = false;

    private void OnEnable()
    {
        Health.OnPlayerDeath += DestroyAllEnemies;
        Timer.OnTimerEnd += DestroyAllEnemies;
    }
    private void OnDisable()
    {
        Health.OnPlayerDeath -= DestroyAllEnemies;
        Timer.OnTimerEnd -= DestroyAllEnemies;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        if (ShouldEnemiesSpawn)
        {
            int numberOfEnemiesToSpawn = Random.Range(2, 5);
            foreach (Transform spawnPoint in GetUniqueRandomElements(spawnPoints, numberOfEnemiesToSpawn))
            {
                GameObject newEnemy = ObjectPooler.GetObject(enemyPrefab);
                newEnemy.transform.position = spawnPoint.position;
                newEnemy.name = "Enemy";
                if (!allEnemies.Contains(newEnemy))
                    allEnemies.Add(newEnemy);
            }
        }

        yield return new WaitForSeconds(spawningInterval);

        StartCoroutine(SpawnEnemies());
    }

    public void DestroyAllEnemies()
    {
        foreach (GameObject enemy in allEnemies)
        {
            ObjectPooler.ReturnGameObject(enemy);
        }
    }

    private List<T> GetUniqueRandomElements<T>(List<T> inputList, int count)
    {
        List<T> inputListClone = new List<T>(inputList);
        Shuffle(inputListClone);
        return inputListClone.GetRange(0, count);
    }

    private void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
}