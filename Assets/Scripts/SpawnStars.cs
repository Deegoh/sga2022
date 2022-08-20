using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{

    [SerializeField] private GameObject prefabStar;
    [SerializeField] private GameObject prefabBubbleStar;
    private Vector3 _center;
    [SerializeField] private Vector3 size;
    [SerializeField] private float delay = 2.0f;
    private void Start()
    {
        StartCoroutine(SpawnStar());
    }

    private IEnumerator SpawnStar()
    {
        while (true)
        {
            if (LevelManager.Instance.Paragraphs.sentences.Count <= LevelManager.Instance.level)
                break ;
            GameObject starType = prefabStar;
            if (LevelManager.Instance.level > 2)
            {
                if (Random.Range(1, 10) % 2 == 0)
                    starType = prefabBubbleStar;
            }
            _center = transform.position;
            LevelManager.Instance.letter = LevelManager.Instance.Paragraphs.choseRandomChar();
            int value;
            char chosenLetter = LevelManager.Instance.letter;
            LevelManager.Instance.Alphabet.TryGetValue(chosenLetter.ToString().ToLower()[0], out value);
            SpriteRenderer[] childList = prefabStar.GetComponentsInChildren<SpriteRenderer>();
            foreach (var renderer in childList)
            {
                if (renderer.CompareTag("Letter"))
                {
                    renderer.sprite = LevelManager.Instance.starSprites[value];
                    break;
                }
            }
            // LevelManager.Alphabet.chosenLetter;
            Vector3 pos = _center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(starType, pos, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }

    // public void SpawnStars()
    // {
    //     Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
    //
    //     Instantiate(prefabStar, pos, Quaternion.identity);
    // }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(_center, size);
    }
}
