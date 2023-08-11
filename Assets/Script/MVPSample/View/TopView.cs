#nullable enable
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.View;
using Common.UI;

public class TopView : MonoBehaviour, IView
{
    [SerializeField] Canvas? canvas;
    [SerializeField] UIButton? shop1;
    [SerializeField] UIButton? shop2;
    [SerializeField] UIButton? debug;
    [SerializeField] UIButton? exit;

    static Common.View.Screen? screen;
    public Canvas Canvas => throw new System.NotImplementedException();

    public void Push()
    {

    }

    public void Pop()
    {

    }

    public void Open()
    {

    }

    public void Close()
    {

    }
}
