using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace LandingPage.Lora.Core.Utils;

public static class FormatString
{
    public static string RemoveDiacritics(string text, string separator = "_") {

        string normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (char c in normalizedString)
        {
            UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        string normalizedFinalString = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

        return Regex.Replace(normalizedFinalString, @"\s+", separator);
    }
}