using System;

public class TextEvents
{
    public event Action <string, float> DisplayText;
    public virtual void OnDisplayText(string text, float time)
    {
        DisplayText?.Invoke(text, time);
    }
}
