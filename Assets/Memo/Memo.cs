using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Memo : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text description;

    public void AddMemo(MemoData memoData)
    {
        title.text = memoData.Title;    
        description.text = memoData.Description;
    }
}

