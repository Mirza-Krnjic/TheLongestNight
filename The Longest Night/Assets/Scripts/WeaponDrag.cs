using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrag : MonoBehaviour
{
    private Vector3 initialPosition;
    [SerializeField] float dragAmount = 0f;
    [SerializeField] float maxDragAmount = 0f;
    [SerializeField] float dragSmoothnes = 0f;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float Xmovment = -Input.GetAxis("Mouse X") * dragAmount;
        float Ymovment = -Input.GetAxis("Mouse Y") * dragAmount;

        Xmovment = Mathf.Clamp(Xmovment, -maxDragAmount, maxDragAmount);
        Ymovment = Mathf.Clamp(Ymovment, -maxDragAmount, maxDragAmount);

        Vector3 finalPosition = new Vector3(Xmovment, Ymovment, 0f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * dragSmoothnes);
    }
}
