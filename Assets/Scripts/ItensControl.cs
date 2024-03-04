using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensControl : MonoBehaviour
{
    [SerializeField] int _numberFrutas;

    [SerializeField] List<Transform> _posFrutas;

    // Start is called before the first frame update

    private void Start()
    {
        Invoke("ItensOn", 2);
    }

    void ItensOn()
    {
        Shuffle(_posFrutas);
        for (int i = 0; i < 10; i++)
        {
            Fruta1_On(i);
        }
       
 
    }

    void Fruta1_On(int value)
    {
        GameObject bullet = frutatipo1.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            //int number = Random.Range(0, _posFrutas.Count);
            bullet.transform.position =  _posFrutas[value].transform.position;
            //bullet.transform.rotation = turret.transform.rotation;
            //bullet.transform.SetParent(_grupoFrutas.transform);
            bullet.SetActive(true);
            //bullet.GetComponent<frutacoletar>().Restart2();
        }
    }

    public void Shuffle(List<Transform> lists)
    {
        for(int j = lists.Count - 1; j > 0; j --)
        {
            int rnd = UnityEngine.Random.Range(0, j + 1);
            Transform temp = lists[j];
            lists[j] = lists[rnd];
            lists[rnd] = temp;
        }
    }
}
