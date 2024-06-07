using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipes : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
