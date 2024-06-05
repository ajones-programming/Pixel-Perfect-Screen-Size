using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 pivot;
    [SerializeField] float rate;
    [SerializeField] float distance;
    float t = 0;
    void Start()
    {
        pivot = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pivot + Vector2.right * Mathf.Cos(t * rate)*distance;
        t += Time.deltaTime;
    }
}
