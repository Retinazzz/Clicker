using UnityEngine;
using System.Text;

public static class NumberFormatter
{
    // Массив суффиксов
    private static readonly string[] suffixes = { "", "K", "M", "B", "T", "Q" };

    /// <summary>
    /// Форматирует число в сокращённый вид (1000 → "1K").
    /// </summary>
    public static string FormatNumber(double number, int decimalPlaces = 1)
    {
        if (number < 1000)
        {
            return number.ToString("F0"); // Меньше 1000 — без сокращения
        }

        int suffixIndex = 0;
        while (number >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            number /= 1000;
            suffixIndex++;
        }

        // Форматируем с заданным количеством знаков после запятой
        return number.ToString("F" + decimalPlaces) + suffixes[suffixIndex];
    }
}