using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frutacoletar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("frutacoletar"))
        {
            gameObject.SetActive(false);
        }
    }
}
