using UnityEngine;

public class Coin_Rotator : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0,1,45) * Time.deltaTime);
    }
}
