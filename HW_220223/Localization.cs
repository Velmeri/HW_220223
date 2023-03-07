using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_220223
{
    public interface ILocalization
    {
        string GetText(string key, string culture);
    }  

    public class Localization : ILocalization
    {
        private readonly Dictionary<string, Dictionary<string, string>> _localizations;

        public Localization (Dictionary<string, Dictionary<string, string>> localizations)
        {
            _localizations = localizations;
        }

        public string GetText (string key, string culture)
        {
            if (_localizations.TryGetValue(culture, out Dictionary<string, string> texts))
            {
                if (texts.TryGetValue(key, out string text))
                {
                    return text;
                }
            }
            return $"<?{key}?>";
        }

        public void AddTranslation(string key, string culture, string text)
        {
            if (!_localizations.ContainsKey(culture))
            {
                _localizations[culture] = new Dictionary<string, string>();
            }
            _localizations[culture][key] = text;
        }

        public void RemoveTranslation(string key, string culture)
        {
            if (_localizations.TryGetValue(culture, out Dictionary<string, string> texts))
            {
                texts.Remove(key);
            }
        }

        public void ClearTranslations()
        {
            _localizations.Clear();
        }
    }
}
