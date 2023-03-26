namespace App.Shared.Extensions
{
    public static class ExceptionExtensions
    {
        public static T ThrowIfNull<T>(this T item, string errorMessage)
        {
            if (item != null) return item;

            throw new ArgumentNullException(nameof(item), errorMessage);
        }

        public static T ThrowIf<T>(this T item, Func<T, bool> expression, string errorMessage)
        {
            if (!expression.Invoke(item)) return item;

            throw new ArgumentException(errorMessage, nameof(item));
        }
    }
}