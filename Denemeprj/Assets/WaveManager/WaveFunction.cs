using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFunction : MonoBehaviour
{


    public enum spawnDurumu {
    SPAWN,WAITING,COUNTING
    }
    
    [System.Serializable]
    public class Wave{
        public string name;
        public Transform enemy;
        public int encount;
        public float spawnRate;

    }
    public Wave[] Waves;
    private int nextWave = 0;
    public int next_Wave {
        get { return nextWave + 1; }
    }
    public Transform[] spawnPoints;
    public float TimeBetweenWaves = 5f;
    private float WaveCountDown;
    public float Wave_CountDown {
        get { return WaveCountDown; }
    }
    public float SearchTime=1f;
    private float SearchTime_holder;

    private spawnDurumu state = spawnDurumu.COUNTING;
    public spawnDurumu State {
        get { return state; }
    }

    public void Start() {
        if (spawnPoints.Length == 0)
            Debug.Log("There are no Spawn points");

        WaveCountDown = 1f;
        SearchTime = SearchTime_holder;
    }
    public void Update() {
        if (state == spawnDurumu.WAITING)
        {
            if (!EnemiesAlive())
                WaveComplated();
            else
                return;
        }
        if (WaveCountDown <= 0)
        {
            if (state != spawnDurumu.SPAWN)
                StartCoroutine(SpawnWave(Waves[nextWave]));
        }
        else {
            WaveCountDown -= Time.deltaTime;
        }
    
    }
    bool EnemiesAlive() {
        SearchTime -= Time.deltaTime;
        if (SearchTime<= 0f) {
            SearchTime = SearchTime_holder;
            if (GameObject.FindGameObjectWithTag("Enemy"))
                return false;

        }
        return true;
    }

    void WaveComplated() {
        state = spawnDurumu.COUNTING;
        WaveCountDown = TimeBetweenWaves;
        if (nextWave + 1 > Waves.Length)
            Debug.Log("All Waves Complated");
        else {
            nextWave++;
        }
    }


    IEnumerator SpawnWave(Wave _wave) {
        state = spawnDurumu.SPAWN;
        for (int i = 0; i < _wave.encount; i++) {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.spawnRate);
        }
        state = spawnDurumu.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy) {
        Transform temp = spawnPoints[Random.Range(0,spawnPoints.Length)];
        Instantiate(_enemy, temp.position, temp.rotation);
    }
}
