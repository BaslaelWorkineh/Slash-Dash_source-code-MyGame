using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject Bombparticle;
    public AudioClip BombAudio;
    public GameObject blood;
    public GameObject Splash;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void DiePlayer()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        Instantiate(Splash, transform.position, Quaternion.identity);
        

    }
    public void BombParticle()
    {
        AudioSource.PlayClipAtPoint(BombAudio, transform.position);
        Instantiate(Bombparticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
       

    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BombParticle();
        if (collision.gameObject.name == "Player")
        {

            DiePlayer();
            Destroy(collision.gameObject);


        }
    }

}
