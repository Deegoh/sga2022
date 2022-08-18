using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private GameObject star;

    [SerializeField]
    private float starInterval = 3.5f;

    private Vector2 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    void Start()
    {
        StartCoroutine(spawnStar(starInterval, star));
        var rb = star.GetComponent<Rigidbody>();
        rb.velocity = RandomVector(-10.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null)
            {
                // here you need to insert a check if the object is really a tree
                // for example by tagging all trees with "Tree" and checking hit.transform.tag
                GameObject.Destroy(hit.transform.gameObject);
            }
        }
    }

    private IEnumerator spawnStar(float interval, GameObject star)
    {
        yield return new WaitForSeconds(interval);
        GameObject newStar = Instantiate(star, new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)), Quaternion.identity);
        StartCoroutine(spawnStar(interval, star));
    }
}
