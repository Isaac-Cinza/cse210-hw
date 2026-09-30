using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return HideLetters();
        }

        return _text;
    }

    // Replaces each letter or digit with an underscore and keeps punctuation.
    private string HideLetters()
    {
        string hiddenText = "";

        foreach (char character in _text)
        {
            if (char.IsLetterOrDigit(character))
            {
                hiddenText += "_";
            }
            else
            {
                hiddenText += character;
            }
        }

        return hiddenText;
    }
}
