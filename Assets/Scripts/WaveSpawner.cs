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
    public bool spawnBool = false;
    
    //Spawn locations
    public Transform[] spawnPoints;
    
    //Timer for checking if any enemies are still alive; uncomment if we wanted to make it fair
    //private float searchCountdown = 1f;
    
    //Countdown timer
    public float timeLeft;
    public bool timerOn = true;
    
    public Text timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        //Wave Countdowns
        spawnBool = true;
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
        if(spawnBool == false) {
            StopCoroutine(SpawnWave(waves[NextWave]));
            ClearClones();
            return;
        } else
        {
            if (waveCountdown <= 0)
            {
                if (spawnState != SpawnState.SPAWNING)
                {
                    //Start Spawning wave
                    StartCoroutine(SpawnWave(waves[NextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }

            //Countdown timer
            if (timerOn)
            {
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    updateTimer(timeLeft);
                }
                else
                {
                    spawnState = SpawnState.FINISHED;
                    spawnBool = false;
                    Debug.Log("Time is UP!!!");
                    timeLeft = 0;
                    timerOn = false;
                }
            }
        }
        //If we wanted to make it fair; slightly buggy still since timer doesn't tick down when //WAITING state is reached
        
        /**if(spawnState == SpawnState.WAITING)
        {
            //Checks if enemies are still alive
            if(!EnemyIsAlive())
            {
                WaveCompleted();

            } else
            {
                return;
            }
        }**/

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


//If we wanted to make it fair, uncomment below
/**    void WaveCompleted()
    {
        Debug.Log("Wave completed");
        ClearClones();
        spawnState = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (timeLeft <= 0) {
            spawnState = SpawnState.FINISHED;
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

    }**/


/**    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            return false;
        }
        return true;
    }**/

    //So we can wait a certain amount of seconds in the method
    IEnumerator SpawnWave(Wave _wave)
    {
        if (spawnBool == false)
        {
            yield break;
        } else
        {
            //ClearClones();      //Clears clones if they exist
            Debug.Log("Spawning Wave:" + _wave.name);
            //Spawn stuff
            spawnState = SpawnState.SPAWNING;

            for (int i = 0; i < _wave.count; i++)
            {
                SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
                yield return new WaitForSeconds(1f / _wave.rate); //For waiting a certain amount of seconds
            }

            //Done Spawning
            spawnState = SpawnState.WAITING;
            yield break;
        }
    }

    void SpawnEnemy (Transform _enemy)
    {
        if(spawnState == SpawnState.FINISHED && timeLeft == 0)
        {
            Debug.Log("No spawning should be occuring as time is finished");
            return;
        } else
        {
            Debug.Log("Spawning enemy: " + _enemy.name);
            if (spawnPoints.Length == 0)
            {
                Debug.LogError("No spawn points referenced");
            }

            Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(_enemy, _sp.position, _sp.rotation);
        }
    }
}

[System.Serializable]
public class Wave
{
    public string name;
    public Transform[] enemy;
    public int count;
    public float rate;
}
