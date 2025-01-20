using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartOrdering : MonoBehaviour
{
    public bool calcOnce = true;
    public int offset = 0;
    public GameObject syncThis;
    
    private Renderer _renderer;
    private Renderer _syncRenderer;
    private bool _updateSync;

    private void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        
        if(syncThis != null)
        {
            _syncRenderer = syncThis.GetComponent<Renderer>();
            _updateSync = true;
        }
    }

    private void LateUpdate()
    {
        _renderer.sortingOrder = 1 - Convert.ToInt32(gameObject.transform.position.y * 100) - offset;
        
        if(_updateSync)
            _syncRenderer.sortingOrder = _renderer.sortingOrder + 1;
        
        if(calcOnce) Destroy(this);
    }
}
