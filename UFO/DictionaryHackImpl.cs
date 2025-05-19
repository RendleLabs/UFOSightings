using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UFO;

public class DictionaryHackImpl
{
    public static Dictionary<string, int> Run()
    {
        using var reader = File.OpenText("/Users/rendle/workshop/NDCOslo2025/UFO/ufo_sightings_original.csv");

        var dict = new Dictionary<string, int>();

        _ = reader.ReadLine();

        while (reader.ReadLine() is {Length: > 0} line)
        {
            var span = line.AsSpan();
            
            var e = span.Split(',');
            Debug.Assert(e.MoveNext());
            Debug.Assert(e.MoveNext());
            Debug.Assert(e.MoveNext());
            var state = span[e.Current];
            Debug.Assert(e.MoveNext());
            var country = span[e.Current];
            
            var key = $"{state},{country}".ToUpperInvariant();

            CollectionsMarshal.GetValueRefOrAddDefault(dict, key, out _) += 1;
        }

        return dict;
    }
}