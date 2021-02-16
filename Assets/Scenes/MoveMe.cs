using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMe : MonoBehaviour
{

    void Update()
    {
        transform.position += Vector3.right * 100 * Time.deltaTime;
    }
}
