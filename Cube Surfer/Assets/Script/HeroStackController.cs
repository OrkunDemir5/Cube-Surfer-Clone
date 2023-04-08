using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HeroStackController : MonoBehaviour
{
    
    public List<GameObject> blockList = new List<GameObject>();
    private GameObject lastBlockObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLastBlockObject();
    }
    
    //yeni k�p ekleme ve eklenen k�p�n konumu belirleme
    public void IncreaseBlockStack(GameObject _gameObject)
    {
        //k�p eklendil�e ana k�p�n y�ksekli�i 2f artacak
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);

        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x, lastBlockObject.transform.position.y - 2f, lastBlockObject.transform.position.z);
        //yeni eklenen k�p ana k�p�n child � ol
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);
        UpdateLastBlockObject();
    }

    public void DecreaseBlock(GameObject _gameObject)
    {
        _gameObject.transform.parent= null;
        blockList.Remove(_gameObject);
        UpdateLastBlockObject();
    }
    private void UpdateLastBlockObject()
    {
        // son nesneyi alm�� oluyoruz
        lastBlockObject = blockList[blockList.Count - 1];
    }
}
