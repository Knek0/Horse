using UnityEngine.InputSystem;
using UnityEngine;


public class HorseAnimations : MonoBehaviour
{
    public Animation horse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horse = GetComponent<Animation>();
  
    }
    public void OnMove()
    {
        horse.Play("Horse_001_run");
    }

}
