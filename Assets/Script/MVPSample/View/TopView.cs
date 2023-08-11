#nullable enable
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.View;
using Common.UI;
using Core;
using Scriptable;
using Common.Factory;

public class TopView : MonoBehaviour, IView
{
    [SerializeField] Canvas? canvas;
    [SerializeField] UIButton? shop1;
    [SerializeField] UIButton? shop2;
    [SerializeField] UIButton? debug;

    # region プロパティ
    static Common.View.Screen? Screen => ComponentLocator.GetOrNull<Common.View.Screen>();
    public Canvas? Canvas => canvas;
    public UIButton? Shop1 => shop1;
    public UIButton? Shop2 => shop2;
    public UIButton? Debug => debug;
    public bool IsActive { get; private set; } = false;
    # endregion プロパティ

    public static TopView Create()
    {
        var view = PrefabsFactory.CreateTopView();
        view.Init();
        return view;
    }

    void Init()
    {
        gameObject.SetActive(false);
    }

    public void Push()
    {
        var screen = Screen;
        if (screen != null)
        {
            screen.Push(this);
        }
    }

    public void Pop()
    {
        var screen = Screen;
        if (screen != null)
        {
            screen.Pop();
        }
    }

    public void Open()
    {
        gameObject.SetActive(true);
        IsActive = true;
    }

    public void Close()
    {
        Destroy(gameObject);
        IsActive = false;
    }
}
