using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectsS : MonoBehaviour
{
    public AudioSource ignotSoundSource;
    public AudioClip coinSound;
    float timee;
    bool boool;
    void Update()
    {
        if (boool)
        {
            timee += Time.deltaTime;
        }
        transform.Rotate(0f, 25f * Time.deltaTime, 0f, Space.World);
        if (timee >= 1.5)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var das = gameObject.GetComponent<MeshRenderer>();
        Destroy(das);
        var dass = gameObject.GetComponent<BoxCollider>();
        Destroy(dass);
        boool = true;
        ignotSoundSource.PlayOneShot(coinSound);
        Money.money += 100;
    }

}
