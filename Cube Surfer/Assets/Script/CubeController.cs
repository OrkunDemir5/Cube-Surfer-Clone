using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private HeroStackController heroStackController;
    private Vector3 direction = Vector3.back;

    private bool isStack = false;
    private RaycastHit hit;
    void Start()
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        SetCubeRaycast();
    }
    private void SetCubeRaycast()
    {
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (!isStack)
            {
                isStack = true;
                heroStackController.IncreaseBlockStack(gameObject);
                SetDriection();
            }
            if(hit.transform.name == "ObstacleCube")
            {
                //azaltma iþlemi
                heroStackController.DecreaseBlock(gameObject);
            }
        }
    }
    private void SetDriection()
    {
        direction = Vector3.forward;
    }
}
