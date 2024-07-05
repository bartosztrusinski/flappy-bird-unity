using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int random;
    Vector3 position;
    private void OnTriggerEnter(Collider other)
    {

        this.gameObject.SetActive(false);   

    }

    void Update()
    {
        
        transform.Rotate(Vector3.fwd, 100.0F * Time.deltaTime);
    }

    private void Start()
    {
        random = Random.Range(1, 8);
        position = transform.position;

        if (random < 4) {
            this.gameObject.SetActive(false);
        }

        switch (random)
        {
            case 4:
                position.z = position.z + 3;
                break;
            case 5:
                position.z = position.z - 3;
                break;
            case 6:
                position.z = position.y + 1;
                break;
            case 7:
                position.z = position.y - 1;
                break;

        }


    }
}

