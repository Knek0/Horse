using UnityEngine.InputSystem;
using UnityEngine;


public class HorseAnimations : MonoBehaviour
{
    public PlayerController player;
    public Animation anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        anim = GetComponent<Animation>();
        anim["Horse_001_run"].layer = 123;
        anim["Horse_001_idle"].layer = 123;
    }
    public void Update()
    {
        if (player.inputDirection.sqrMagnitude > 0.01f)
        {
            anim.Play("Horse_001_run");
        }
        else
        {
            anim.Play("Horse_001_idle");
        }
        
    }

}
