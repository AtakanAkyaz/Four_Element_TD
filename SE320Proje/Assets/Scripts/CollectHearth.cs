using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHearth : MonoBehaviour
{
    bool booool;
    float timeee;
    public AudioClip heartSound;
    public AudioSource ssource;

    // Start is called before the first frame update
    void Update()
    {
        if (booool)
        {
            timeee += Time.deltaTime;
        }
        transform.Rotate(0f, 25f * Time.deltaTime, 0f, Space.World);
        if (timeee >= 1.5)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var asd=gameObject.GetComponent<MeshRenderer>();
        Destroy(asd);
        var asdd = gameObject.GetComponent<MeshCollider>();
        Destroy(asdd);
        ssource.PlayOneShot(heartSound);
        booool = true;
        Lives.life += 1;
    }
}
