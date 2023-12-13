using System;
#if !NETSTANDARD
using System.Drawing;
#endif

public static partial class Extensions
{
#if !NETSTANDARD
    /// <summary>
    ///     Translates the specified  structure to an HTML string color representation.
    /// </summary>
    /// <param name="c">The  structure to translate.</param>
    /// <returns>The string that represents the HTML color.</returns>
    public static String ToHtml(this Color c)
    {
        return ColorTranslator.ToHtml(c);
    }
    Console
#endif
}