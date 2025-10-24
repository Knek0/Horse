using Unity.VisualScripting;
using UnityEngine;


public class HorseAnimations : MonoBehaviour
{
    public GameObject horse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            horse.GetComponent<Animator>().Play("Horse_001_walk");
        }
    }
}
