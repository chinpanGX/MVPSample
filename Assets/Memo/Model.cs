using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class MemoData
{

    public MemoData()
    {
        Title = string.Empty;
        Description = string.Empty;
    }

    public MemoData(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string Description { get; set; }
}


public class Model
{
    List<MemoData> memoDatas = new();

    public List<MemoData> MemoDatas => memoDatas;

    public static Model Create()
    {
        return new Model();
    }

    public (MemoData data, int count) Add(MemoData memoData)
    {
        var data = memoData;        
        if (data.Title == string.Empty)
        {
            data.Title = $"Title{memoDatas.Count + 1}";
        }
        if (data.Description == string.Empty)
        {
            if (memoDatas.Count % 2 == 1)
            {
                data.Description = $"FUGA:ALGS:VALO{memoDatas.Count + 1}";
           
            }
            else 
            {
                data.Description = $"hoge:HOGE:HOME{memoDatas.Count + 1}";
            }
        }
        
        memoDatas.Add(data);
        return (memoData, memoDatas.Count);
    }
}
