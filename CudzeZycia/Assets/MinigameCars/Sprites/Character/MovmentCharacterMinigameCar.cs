using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentCharacterMinigameCar : MonoBehaviour
{
    public Transform TopRoad, MidRoad, BottomRoad;
    public Animator _animation;
    public Animation _Roadspeed;
    public SpriteRenderer SR;

    private float t;
    private int position;
    private bool _start = false;

    void Start()
    {
        position = 0;
        transform.position = MidRoad.position;
        _start = true;
        SR.sortingOrder = -1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && position != 1)
        {
            position += 1;
            SR.sortingOrder += 1;
            
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && position != -1)
        {
            position -= 1;
            SR.sortingOrder -= 1;
        }

        if(_start == true)
        {
            _animation.SetBool("Run", true);
        }

        
    }


    private void FixedUpdate()
    {
        if(position == 0)
        {
            transform.position = MidRoad.position;
        }
        else if (position == 1)
        {
            transform.position = BottomRoad.position;
        }
        if (position == -1)
        {
            transform.position = TopRoad.position;
        }

        t += 0.5f * Time.deltaTime;
        startRoad();
    }




    private void startRoad()
    {
        if(_start == true)
        {
            _Roadspeed["LoopRoad"].speed = Mathf.Lerp(0,1,t);
        }
    }


    
}
