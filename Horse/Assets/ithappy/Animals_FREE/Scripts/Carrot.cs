using UnityEngine;

public class Carrot : MonoBehaviour
{
    private Vector3 initialPos;
    private float amp = 0.5f;

    void Start()
    {
        initialPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initialPos.x, Mathf.Sin(Time.time) * amp + initialPos.y, initialPos.z);
    }
}
