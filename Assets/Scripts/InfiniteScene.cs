using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScene : MonoBehaviour
{
    public float sceneSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveScene();
    }

    private void MoveScene()
    {
        Vector2 movingScene = new Vector2(Time.time * sceneSpeed, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = movingScene;
    }
}
