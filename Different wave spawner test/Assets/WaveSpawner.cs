using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    //Wave States
    public enum SpawnState {SPAWNING, WAITING, COUNTING, FINISHED};

    //Waves
    public Wave[] waves;
    public int NextWave;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public SpawnState spawnState = SpawnState.COUNTING;
    
    //Spawn locations
    public Transform[] spawnPoints;
    
    //Timer for each waves
    private float searchCountdown = 1f;
    
    //Countdown timer
    public float timeLeft;
    public bool timerOn = false;
    
    public Text timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        //Wave Countdowns
        waveCountdown = timeBetweenWaves;
        if (spawnPoints.Length == 0) 
        {
            Debug.LogError("No spawn points referenced");
        }
        
        //Countdown timer
        timerOn = true;
        
    }

    void Update()
    {
        if(spawnState == SpawnState.FINISHED) {
            return;
        }
        
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
        
        //Countdown timer
        if(timerOn) {
            if (timeLeft > 0) {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            } else {
                spawnState = SpawnState.FINISHED;
                Debug.Log("Time is UP!!!");
                timeLeft = 0;
                timerOn = false;
            }
        }
    }
    
    void updateTimer(float currTime) {
        currTime +=1;
        float minutes = Mathf.FloorToInt(currTime/60);
        float seconds = Mathf.FloorToInt(currTime%60);
        timerText.text = string.Format("{0:00} : {1:00}",minutes,seconds);
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

        if (timeLeft <= 0) {
            spawnState = SpawnState.FINISHED;
            ClearClones();
        } else 
        {
            if (NextWave + 1 > waves.Length - 1)
            {
                NextWave = 0;
                Debug.Log("All waves complete; looping...");

            } else
            {
                NextWave++;

            }
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
        //ClearClones();      //Clears clones if they exist
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
        if (spawnPoints.Length == 0) 
        {
            Debug.LogError("No spawn points referenced");
        }
        
        Transform _sp = spawnPoints[Random.Range (0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
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
