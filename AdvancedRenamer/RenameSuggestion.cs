using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedRenamer
{
    public class RenameSuggestion
    {
        private string suggestedString = null;

        /// <summary>
        /// The file being renamed
        /// </summary>
        public FileInfo TargetFile { get; private set; }
        
        /// <summary>
        /// The original file name
        /// </summary>
        public string OriginalName
        {
            get
            {
                return TargetFile.Name;
            }
        }

        /// <summary>
        /// Gets or sets whether or not this file should be renamed
        /// </summary>
        public bool ShouldRename { get; set; }

        /// <summary>
        /// Gets or sets the suggested name for the file
        /// </summary>
        public string SuggestedName
        {
            get
            {
                if (suggestedString == null)
                    return OriginalName;
                else
                    return suggestedString;
            }
            set
            {
                // Remove any illegal characters
                string newValue = value;
                foreach (char illegal in Path.GetInvalidFileNameChars())
                    newValue = newValue.Replace(illegal.ToString(), "");

                if (newValue != SuggestedName)
                {
                    suggestedString = newValue;
                    if (suggestedString != null)
                        ShouldRename = true;
                }
            }
        }

        public RenameSuggestion(FileInfo file)
        {
            TargetFile = file;
        }
    }
}
