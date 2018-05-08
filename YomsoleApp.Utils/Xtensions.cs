using System;

namespace YomsoleApp.Utils
{
    public static class Xtensions
    {
        public static TReturn FormatWith<TSource, TReturn>(this TSource source, Func<TSource, TReturn> evaluator)
            => evaluator.Invoke(source);

        public static string Quote(this string text)
            => $"\"{text}\"";
    }
}
