using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalColors : MonoBehaviour
{
    private Renderer objectRenderer;
    private float colorChangeSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component attached to the object
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate color values based on time
        float r = Mathf.PingPong(Time.time * colorChangeSpeed, 1.0f);
        float g = Mathf.PingPong(Time.time * colorChangeSpeed * 0.7f, 1.0f);
        float b = Mathf.PingPong(Time.time * colorChangeSpeed * 0.4f, 1.0f);

        // Set the color of the object
        objectRenderer.material.color = new Color(r, g, b);
    }
}
