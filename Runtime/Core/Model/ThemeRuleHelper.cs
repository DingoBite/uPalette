using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace uPalette.Runtime.Core.Model
{
    public static class ThemeRuleHelper
    {
        public static Func<string, string, string> BuildGetThemeForEntry(
            string activeThemeId,
            string activeThemeName,
            IEnumerable<Theme> themes,
            Regex folderRuleRegex,
            HashSet<string> visitedThemes)
        {
            var themesByName = new Dictionary<string, Theme>(StringComparer.OrdinalIgnoreCase);
            foreach (var t in themes)
            {
                var themeName = t?.Name?.Value;
                if (themeName != null)
                {
                    var split = themeName.Split(":");
                    themesByName.Add(split[0], t);
                }
            }

            return BuildGetThemeForEntryInternal(
                activeThemeId,
                activeThemeName,
                themesByName,
                folderRuleRegex,
                visitedThemes);
        }

        private static Func<string, string, string> BuildGetThemeForEntryInternal(
            string activeThemeId,
            string activeThemeName,
            IReadOnlyDictionary<string, Theme> themesByName,
            Regex folderRuleRegex,
            HashSet<string> visitedThemes)
        {
            if (!visitedThemes.Add(activeThemeId))
                return (_, _) => activeThemeId;

            var match = folderRuleRegex.Match(activeThemeName);
            if (!match.Success)
            {
                return (_, _) => activeThemeId;
            }

            var folderRule = match.Groups["folder"].Value.Trim();
            var nextThemeName = match.Groups["theme"].Value.Trim();

            if (!themesByName.TryGetValue(nextThemeName, out var nextTheme) ||
                nextTheme?.Name?.Value == null)
            {
                return (_, _) => activeThemeId;
            }

            var nextResolver = BuildGetThemeForEntryInternal(
                nextTheme.Id,
                nextTheme.Name.Value,
                themesByName,
                folderRuleRegex,
                visitedThemes);

            var folders = folderRule
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(f => f.Trim())
                .Where(f => f.Length > 0)
                .ToArray();

            if (folders.Length == 0)
                return nextResolver;

            return (entryId, entryName) =>
            {
                foreach (var folder in folders)
                {
                    if (entryName.StartsWith(folder + "/", StringComparison.OrdinalIgnoreCase))
                        return activeThemeId;
                }

                return nextResolver(entryId, entryName);
            };
        }
    }
}
