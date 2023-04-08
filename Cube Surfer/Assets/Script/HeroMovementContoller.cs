using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementContoller : MonoBehaviour
{
    [SerializeField] private HeroController heroController;

    //Düz koþmasý için gerekli hýz deðiþkeni
    [SerializeField] private float forwardMovementSpeed;
    //yatay da hýz
    [SerializeField] private float horizontalMovementSpeed;
    //yatay da plane boyutuna göre limit koymak için
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
