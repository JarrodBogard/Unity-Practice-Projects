using UnityEngine;

public class StopWingAnimation : MonoBehaviour
{

    BirdScript birdScript;
    Animator myAnimation;

    void Start()
    {
        birdScript = GetComponentInParent<BirdScript>();
        myAnimation = GetComponent<Animator>();
    }

    void Update()
    {

        if (!birdScript.birdIsAlive)
        {
            myAnimation.enabled = false;
        }
    }
}
