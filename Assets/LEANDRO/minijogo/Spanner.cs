using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanner : MonoBehaviour
{
    public GameObject _number1;
    public GameObject[] _number;
    
    private float _timer;

    public Transform _t1;
    public Transform _t2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 2.0f)
        {
            _timer = 0;
            float _xRandom = Random.Range(_t1.transform.position.x, _t2.transform.position.x);
            //Instantiate(_number1, new Vector3(_xRandom, _t1.position.y, 0), Quaternion.Euler(0, 0, 0));

            int _random = Random.Range(0, 8);
            Instantiate(_number[_random], new Vector3(_xRandom, _t1.position.y, 0), Quaternion.Euler(0, 0, 0));

        }
    }
}
