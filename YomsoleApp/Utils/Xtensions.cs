using System;

namespace YomsoleApp.Utils
{
    internal static class Xtensions
    {
        public static TReturn With<TSource, TReturn>(this TSource source, Func<TSource, TReturn> evaluator)
            => evaluator.Invoke(source);

        public static string Quote(this string text)
            => $"\"{text}\"";
    }
}
