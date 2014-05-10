using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedRenamer
{
    public class RenamePattern
    {
        /// <summary>
        /// Gets or sets the rename pattern
        /// </summary>
        public string Pattern { get; private set; }

        public RenamePattern(string pattern)
        {
            Pattern = pattern;
        }

        /// <summary>
        /// Apply a renaming pattern to the given string
        /// </summary>
        /// <param name="substitutions">Any substitutions to replace in the pattern</param>
        /// <returns>The output string</returns>
        public string ApplyPattern(Dictionary<string, string> substitutions)
        {
            string str = Pattern;
            foreach (string key in substitutions.Keys)
            {
                string placeholder = key;
                if (!placeholder.StartsWith("<"))
                    placeholder = "<" + placeholder;

                if (!placeholder.EndsWith(">"))
                    placeholder = placeholder + ">";

                str = str.Replace(placeholder, substitutions[key]);
            }

            return str;
        }

    }
}
