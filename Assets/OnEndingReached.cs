using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEndingReached : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject _camera;
    [SerializeField] private Animator fadeIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {
            _camera.GetComponent<FollowPlayer>().Stop();
            Destroy(spawner);
            foreach (var star in LevelManager.Instance.Paragraphs.stars)
            {
                Destroy(star.gameObject);
            }
            StartCoroutine(waitForFade());
        }
    }
    IEnumerator waitForFade()
    {
        fadeIn.SetTrigger("fadeIn 0");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("DeathScreen");
    }
}
