using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] float size = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / size) * size;
        snapPos.z = Mathf.RoundToInt(transform.position.z / size) * size;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
