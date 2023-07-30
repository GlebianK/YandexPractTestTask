using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailRenderer : MonoBehaviour
{
    [SerializeField] private int ClonesPerSecond = 10;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform tf;
    [SerializeField] private List<SpriteRenderer> clones;
    [SerializeField] private Vector3 scalePerSecond = new Vector3(1f, 1f, 1f);
    [SerializeField] private Color colorPerSecond = new Color(255, 255, 255, 1f);

    void Start()
    {
        clones = new List<SpriteRenderer>();
        StartCoroutine(Trail());
    }

    void Update()
    {
        for (int i = 0; i < clones.Count; i++)
        {
            clones[i].color -= colorPerSecond * Time.deltaTime;
            clones[i].transform.localScale -= scalePerSecond * Time.deltaTime;
            if (clones[i].color.a <= 0f || clones[i].transform.localScale == Vector3.zero)
            {
                Destroy(clones[i].gameObject);
                clones.RemoveAt(i);
                i--;
            }
        }
    }

    private IEnumerator Trail()
    {
        for (; ; ) //while(true)
        {
            if (rb.velocity != Vector2.zero)
            {
                GameObject clone = new GameObject("trailClone");
                clone.transform.position = tf.position;
                clone.transform.localScale = tf.localScale;

                SpriteRenderer cloneRend = clone.AddComponent<SpriteRenderer>();
                cloneRend.sprite = sr.sprite;
                cloneRend.sortingOrder = sr.sortingOrder - 1;

                clones.Add(cloneRend);
            }

            yield return new WaitForSeconds(1f / ClonesPerSecond);
        }
    }
}
