using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvancedRenamer.Regexes
{
    /// <summary>
    /// Implements matching based on a regular expression
    /// </summary>
    public class RegexMatcher
    {
        public void MatchFiles(string expressionString, string pattern, bool ignoreCase, IList<RenameSuggestion> files)
        {
            RegexOptions options = RegexOptions.Compiled;
            if (ignoreCase)
                options |= RegexOptions.IgnoreCase;

            Regex re = new Regex(expressionString, options);

            RenamePattern renamePattern = new RenamePattern(pattern);

            foreach (RenameSuggestion renameSuggestion in files)
            {
                if (re.IsMatch(renameSuggestion.OriginalName))
                {
                    Match match = re.Match(renameSuggestion.OriginalName);

                    Dictionary<string, string> substitutions = new Dictionary<string, string>();
                    for (int i = 1; i < match.Groups.Count; i++)
                        substitutions.Add("<" + i + ">", match.Groups[i].Value);

                    renameSuggestion.SuggestedName = renamePattern.ApplyPattern(substitutions);
                }
                else
                {
                    renameSuggestion.ShouldRename = false;
                }
            }
        }

        /// <summary>
        /// Test that the given regular expression is valid
        /// </summary>
        /// <param name="pattern">The regular expression pattern</param>
        /// <returns>True if valid, false otherwise</returns>
        public bool TestRegex(string pattern)
        {
            bool valid = true;
            try
            {
                Regex re = new Regex(pattern);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}
