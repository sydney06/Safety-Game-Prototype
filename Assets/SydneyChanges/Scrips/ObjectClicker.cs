using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject safeUnsafePanel;
    public GameObject ignoreFixPanel;
    public GameObject safeUnsafeColliders;
    public GameObject ignoreFixColliders;
    public GameObject successMessage;
    public GameObject failedMessage;

    [Header("ParticleEffects")]
    public ParticleSystem smokeEffect;
    public ParticleSystem bigExplosionEffect;
    public ParticleSystem flamesParticleEffect;

    [Header("Buttons")]
    public GameObject safeButton;
    public GameObject unsafeButton;
    public GameObject fixbutton;
    public GameObject ignoreButton;

    [Header("Raycast Length")]
    public float raycastMaxDistance = 600f;

    [Header("Sounds")]
    public AudioSource explosionSound;
    public AudioClip explosion;

    private void Start()
    {
        bigExplosionEffect.Stop();
        flamesParticleEffect.Stop();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, raycastMaxDistance))
        {
            if (hit.transform != null)
            {
                //print(hit.transform.gameObject);
                if (hit.collider.tag == "SafeBtn")
                {
                    print(hit.collider.tag);
                    safeButton.SetActive(true);
                    unsafeButton.SetActive(false);
                }
                else if (hit.collider.tag == "UnsafeBtn")
                {
                    print(hit.collider.tag);
                    safeButton.SetActive(false);
                    unsafeButton.SetActive(true);
                }
                else if (hit.collider.tag == "FixBtn")
                {
                    print(hit.collider.tag);
                    fixbutton.SetActive(true);
                    ignoreButton.SetActive(false);
                }
                else if (hit.collider.tag == "IgnoreBtn")
                {
                    print(hit.collider.tag);
                    fixbutton.SetActive(false);
                    ignoreButton.SetActive(true);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, raycastMaxDistance))
            {
                if (hit.transform != null)
                {
                    //print(hit.transform.gameObject);
                    //print(hit.collider.tag);
                    if (hit.collider.tag == "SafeBtn")
                    {
                        //print(hit.collider.tag);
                        StartCoroutine(PlayExplosion());
                        flamesParticleEffect.Play();
                        safeUnsafePanel.SetActive(false);
                        safeUnsafeColliders.SetActive(false);
                        ignoreFixPanel.SetActive(false);
                        ignoreFixColliders.SetActive(false);
                        failedMessage.SetActive(true);
                    }
                    else if (hit.collider.tag == "UnsafeBtn")
                    {
                        //print(hit.collider.tag);
                        safeUnsafePanel.SetActive(false);
                        safeUnsafeColliders.SetActive(false);
                        ignoreFixPanel.SetActive(true);
                        ignoreFixColliders.SetActive(true);
                    }
                    else if (hit.collider.tag == "FixBtn")
                    {
                        //print(hit.collider.tag);
                        safeUnsafePanel.SetActive(false);
                        safeUnsafeColliders.SetActive(false);
                        ignoreFixPanel.SetActive(false);
                        ignoreFixColliders.SetActive(false);
                        successMessage.SetActive(true);
                        smokeEffect.Stop();
                        bigExplosionEffect.Stop();
                        flamesParticleEffect.Stop();
                    }
                    else if(hit.collider.tag == "IgnoreBtn")
                    {
                        //print(hit.collider.tag);
                        StartCoroutine(PlayExplosion());
                        flamesParticleEffect.Play();
                        safeUnsafePanel.SetActive(false);
                        safeUnsafeColliders.SetActive(false);
                        ignoreFixPanel.SetActive(false);
                        ignoreFixColliders.SetActive(false);
                        failedMessage.SetActive(true);
                    }
                }
            }
        }
    }

    IEnumerator PlayExplosion()
    {
        bigExplosionEffect.Play();
        explosionSound.PlayOneShot(explosion);
        yield return new WaitForSeconds(3);
        bigExplosionEffect.Stop();
    }
}
