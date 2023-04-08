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
    
    //yeni küp ekleme ve eklenen küpün konumu belirleme
    public void IncreaseBlockStack(GameObject _gameObject)
    {
        //küp eklendilçe ana küpün yüksekliði 2f artacak
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);

        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x, lastBlockObject.transform.position.y - 2f, lastBlockObject.transform.position.z);
        //yeni eklenen küp ana küpün child ý ol
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
        // son nesneyi almýþ oluyoruz
        lastBlockObject = blockList[blockList.Count - 1];
    }
}
