using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementContoller : MonoBehaviour
{
    [SerializeField] private HeroController heroController;

    //D�z ko�mas� i�in gerekli h�z de�i�keni
    [SerializeField] private float forwardMovementSpeed;
    //yatay da h�z
    [SerializeField] private float horizontalMovementSpeed;
    //yatay da plane boyutuna g�re limit koymak i�in
    [SerializeField] private float horizontalLimitValue;

    private float newPositionX;

    void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizantalMovement();
    }

    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.down * forwardMovementSpeed * Time.fixedDeltaTime);
    }

    private void SetHeroHorizantalMovement()
    {
        newPositionX= transform.position.x + heroController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
