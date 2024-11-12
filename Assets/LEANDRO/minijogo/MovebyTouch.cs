using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovebyTouch : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] MoveFloatBuri _moveBuri;
    void Start()
    {
        _moveBuri = GetComponent<MoveFloatBuri>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + toque.deltaPosition.x/_speed,
                transform.position.y,
                transform.position.z);
                //Debug.Log(transform.position);
            }

            Touch toque2 = Input.GetTouch(1);

            if (toque2.phase == TouchPhase.Began)
            {
                _moveBuri.AtirarPeloTouch();
            }

            /*if(toque.phase == TouchPhase.Ended)
            {
                //bool value = true;
                _moveBuri.AtirarPeloTouch();
                Debug.Log("tocou");
            }
            if (toque.phase == TouchPhase.Began)
            {
                //bool value = true;
                _moveBuri.AtirarPeloTouch();
                Debug.Log("tocou");
            }*/
        }
    }
}
