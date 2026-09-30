using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _random = new Random();

    public ScriptureLibrary()
    {
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));

        _scriptures.Add(new Scripture(
            new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy."));

        _scriptures.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."));

        _scriptures.Add(new Scripture(
            new Reference("Moses", 1, 39),
            "For behold, this is my work and my glory\u2014to bring to pass the immortality and eternal life of man."));
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
