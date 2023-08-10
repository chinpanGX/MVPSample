using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] View view;

    Presenter presenter;
    
    // Start is called before the first frame update
    void Start()
    {
        presenter = new Presenter(this, Model.Create(), View.Create(view));
        presenter.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
