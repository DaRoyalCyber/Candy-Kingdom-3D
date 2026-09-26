using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapButton : MonoBehaviour
{
    public bool isTrap;
    public Trap[] alltraps;
    public GameObject psSmoke;
    public AudioSource SFXwrong;

    // particle effect here too
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Candy") {
            if (isTrap)
            {
                foreach (Trap trap in alltraps)
                {

                    LevelCompleteUI.instance.CandyTriggerPressed();

                    SpinningAudio.instance.TriggerButtomn.Play();
                    trap.ActivateTrap();
                    gameObject.SetActive(false);
                }
            }
            else
            {
                Instantiate(psSmoke, other.transform.position, Quaternion.identity);

                SFXwrong.Play();
                Destroy(gameObject);
            }
        
        }
    }
}
