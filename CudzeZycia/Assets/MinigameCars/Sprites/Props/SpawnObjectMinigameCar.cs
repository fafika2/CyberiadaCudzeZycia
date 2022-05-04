using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectMinigameCar : MonoBehaviour
{
    public GameObject[] _spawnPrefab;
    public Animation _anim;
    private int randomnumber;
    private int PropType;
    private float _time;
    private bool couritneExe = false;


    [Range(0, 12)]
    public float MaxTimer;

    [Range(0, 12)]
    public float MinTimer;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(_anim["LoopRoad"].speed >= 1)
        {
            StartCoroutine(_SpawnObject());
        }
    }

    IEnumerator _SpawnObject()
    {
        if (couritneExe)
        {
            yield break;
        }

        couritneExe = true;

        _time = Random.Range(MinTimer, MaxTimer);
        yield return new WaitForSeconds(_time);
        randomnumber = Random.Range(0, 10);

        if(randomnumber >= 9)
        {
            Instantiate(_spawnPrefab[9], transform.position, transform.rotation);
        }
        else if(randomnumber < 9 && randomnumber > 5)
        {
            Instantiate(_spawnPrefab[8], transform.position, transform.rotation);
        }
        else
        {
            PropType = Random.Range(0, 7);
            Instantiate(_spawnPrefab[PropType], transform.position, transform.rotation);
        }
        

        couritneExe = false;
    }
}
