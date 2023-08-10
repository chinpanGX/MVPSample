using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct SampleEvent
{
    public readonly bool onEvent;
    public SampleEvent(bool value) => onEvent = value;
}
