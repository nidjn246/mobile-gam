using System.Collections.Generic;
using Unity.Microsoft.GDK;
using Unity.VisualScripting;
using UnityEngine;

public class CheckWhatNumber : MonoBehaviour
{
    float tempY = 0;
    bool onGround;
    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private GameObject NumberOnTop;
    
    private Vector3 startPos;
    private Rigidbody rb;


    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * 6, ForceMode.Impulse);
        rb.AddTorque(new Vector3 (Random.Range(0, 3),Random.Range(0, 3),Random.Range(0, 3)), ForceMode.Impulse);
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.tag == "Number")
            {
                numbers.Add(child.gameObject);
            }
        }
    }
    void CheckNumber()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            
            if (numbers[i].transform.position.y > tempY)
            {
                tempY = numbers[i].transform.position.y;
                NumberOnTop = numbers[i];
            }
        }
        GameManager.instance.AddScore(int.Parse(NumberOnTop.name));
        ResetDice();
    }

    private void ResetDice()
    {
        onGround = false;
        tempY = 0;
        transform.position = startPos;
        rb.AddForce(Vector3.forward * 6, ForceMode.Impulse);
        rb.AddTorque(new Vector3 (Random.Range(0, 3),Random.Range(0, 3),Random.Range(0, 3)), ForceMode.Impulse);
    }

    void Update()
    {
        if (onGround)
        {
            if (rb.linearVelocity == Vector3.zero) CheckNumber();


        }
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
