using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class FirstSteps : MonoBehaviour
{
    [Header("Header")]
    [SerializeField]
    [Tooltip("The value of the intensity for the bouncing")]
    [Range(0, 10)]
    private float BouncingValue = 1;
    [Space]
    [SerializeField]
    private bool IsBouncy = false;

    private Rigidbody Rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Environment") && IsBouncy)
        {
            Rigidbody.AddForce(new Vector3(0, BouncingValue*.001f, 0), ForceMode.Impulse);
        }
    }
}
