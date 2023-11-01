using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float objectSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        transform.Translate(objectSpeed * Time.deltaTime * Vector3.left);
    }
}
