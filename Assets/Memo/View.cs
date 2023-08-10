using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

public class View : MonoBehaviour
{
    [SerializeField] Memo memoObj;
    [SerializeField] GameObject root;

    [SerializeField] Button button;

    public Button Button => button;

    public static View Create(View obj)
    {
        return Instantiate<View>(obj);
    }

    public void AddMemo(MemoData memoData, float offset)
    {
        var memo = Instantiate(memoObj, root.transform, false);
        memo.transform.position = root.transform.position + Vector3.right * 30.0f * offset;
        memo.AddMemo(memoData);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        MessageBroker.Default.Publish(new SampleEvent(false));
    }
}
