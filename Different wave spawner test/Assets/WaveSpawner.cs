using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    public Wave[] waves;
    public int NextWave;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    //Timer
    private float searchCountdown = 1f;

    public SpawnState spawnState = SpawnState.COUNTING;
    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        //Making it fair
        if(spawnState == SpawnState.WAITING)
        {
            //Checks if enemies are still alive
            if(!EnemyIsAlive())
            {
                WaveCompleted();

            } else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if(spawnState != SpawnState.SPAWNING)
            {
                //Start Spawning wave
                StartCoroutine(SpawnWave(waves[NextWave]));
            }
        } else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void ClearClones()
    {
        //Clears GameObject clones to make program efficient
        var clones = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed");
        spawnState = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (NextWave + 1 > waves.Length - 1)
        {
            NextWave = 0;
            Debug.Log("All waves complete; looping...");

        } else
        {
            NextWave++;

        }

    }


    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
            return false;
        }
        return true;
    }

    //So we can wait a certain amount of seconds in the method
    IEnumerator SpawnWave(Wave _wave)
    {
        ClearClones();      //Clears clones if they exist
        Debug.Log("Spawning Wave:" + _wave.name);
        //Spawn stuff
        spawnState = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate); //For waiting a certain amount of seconds
        }

        //Done Spawning
        spawnState = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Debug.Log("Spawning enemy: " + _enemy.name);
        Instantiate(_enemy, transform.position,transform.rotation);
    }
}

[System.Serializable]
public class Wave
{
    public string name;
    public Transform enemy;
    public int count;
    public float rate;
}
