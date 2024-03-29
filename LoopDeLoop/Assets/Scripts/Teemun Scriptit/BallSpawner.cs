using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public GameObject ball;
    public int ballCount;
    public int maxBallCount = 15;
    public float spawnTime;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    Transform finalSpawnPoint;
    int spawnNum;
    bool canSpawn = true;

    public IEnumerator Timer() {
        spawnNum = Random.Range(0, 4);
        if(spawnNum == 0) {
            finalSpawnPoint = spawnPoint1;
            }
        else if(spawnNum == 1) {
            finalSpawnPoint = spawnPoint2;
            }
        else if(spawnNum == 2) {
            finalSpawnPoint = spawnPoint3;
            }
        else if(spawnNum == 3) {
            finalSpawnPoint = spawnPoint4;
            }
        var ballCopy = Instantiate(ball);
        ballCount++;
        ballCopy.transform.position = finalSpawnPoint.position;
        canSpawn = false;
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
        //if (ballCount < maxBallCount) {
        //    StartCoroutine(Timer());
        //    }
        }

    void Start() {
        //spawnNum = Random.Range(0, 4);
        //StartCoroutine(Timer());
        }

    void Update() {
        if(ballCount < maxBallCount && canSpawn) {
            StartCoroutine(Timer());
            }
        }

    }