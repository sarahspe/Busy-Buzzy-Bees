using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }
}
