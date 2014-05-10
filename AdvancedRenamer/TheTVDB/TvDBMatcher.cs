using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvancedRenamer.TheTVDB
{
    /// <summary>
    /// Implements the filename matcher for the The TV DB plugin
    /// </summary>
    public class TvDBMatcher
    {
        TvDBApi api = TvDBApi.Create("http://thetvdb.com", "614F24DC95826311");
        List<Regex> matchingExpressions = new List<Regex>();

        Dictionary<string, TvDBCachedShow> showCache = new Dictionary<string, TvDBCachedShow>();
        int cacheSize = 50;

        /// <summary>
        /// Gets or sets the number of shows to cache
        /// </summary>
        public int CacheSize
        {
            get { return cacheSize; }
            set { cacheSize = value; }
        }

        public TvDBMatcher()
        {
            // Add regular expressions for common TV show matching
            matchingExpressions.Add(new Regex(@"(?<season>\d{1,2})[\D]{1,2}(?<episode>\d{1,2})"));
            matchingExpressions.Add(new Regex(@"(^|\D)(?<season>\d)(?<episode>\d{2})(\D|$)"));
        }


        public void MatchFiles(string showTitle, string seasonName, string pattern, IList<RenameSuggestion> files)
        {
            if (files.Count == 0)
                return;

            RenamePattern renamer = new RenamePattern(pattern);

            Regex re = new Regex(@"(?<season>\d{1,2})$");
            if (!re.IsMatch(seasonName))
                return;

            Match m = re.Match(seasonName);
            int seasonNumber = Convert.ToInt32(m.Groups["season"].Value);

            TvDBShow show = null;
            if (showCache.ContainsKey(showTitle))
            {
                // Use the cached copy of the show object
                Console.Out.WriteLine("Using cached TV show object");
                show = showCache[showTitle].Show;
            }
            else
            {
                // Lookup the show
                TvDBSearchResult result = FindShow(showTitle);
                if (result == null)
                    return;

                show = api.GetShow(result.SeriesID);
                if (show == null)
                    return;

                // Add the show to cache
                if (showCache.Count >= CacheSize) {
                    //Remove the oldest cached item
                    string delKey = showCache.OrderBy(t => t.Value.CachedAt).First().Key;
                    showCache.Remove(delKey);
                }

                showCache.Add(showTitle, new TvDBCachedShow(show));
            }

            TvDBSeason season = show.GetSeason(seasonNumber);
            if (season == null)
                return;

            foreach (RenameSuggestion file in files)
            {
                // Get the filename without the extension
                string filename = file.TargetFile.Name.Substring(0, file.TargetFile.Name.Length - file.TargetFile.Extension.Length);
                int episodeNumber = GetEpisode(filename);
                if (episodeNumber != -1)
                {
                    TvDBEpisode episode = season.FirstOrDefault(r => r.Number == episodeNumber);
                    if (episode != null)
                    {
                        Dictionary<string, string> substitutions = new Dictionary<string, string>();
                        substitutions.Add("show", show.Title);
                        substitutions.Add("season", seasonNumber.ToString());
                        substitutions.Add("episode", episodeNumber.ToString().PadLeft(Math.Max(season.Count.ToString().Length, 2), '0'));
                        substitutions.Add("title", episode.Title);

                        file.SuggestedName = renamer.ApplyPattern(substitutions) + file.TargetFile.Extension;
                    }
                }
            }
        }

        private int GetEpisode(string filename)
        {
            foreach (Regex re in matchingExpressions)
            {
                if (re.IsMatch(filename))
                {
                    Match m = re.Match(filename);
                    return Convert.ToInt32(m.Groups["episode"].Value);
                }
            }

            //No match!
            return -1;
        }

        /// <summary>
        /// Find a TV show on the TV Db
        /// </summary>
        /// <param name="showTitle">The title to search for</param>
        /// <returns>The choosen search result or null if none are found</returns>
        private TvDBSearchResult FindShow(string showTitle)
        {
            TvDBSearchResult result = null;
            List<TvDBSearchResult> results = api.Search(showTitle);
            if (results.Count == 1)
            {
                result = results[0];
            }
            else if (results.Count > 1)
            {
                FrmTvDBSearchResults frmResults = new FrmTvDBSearchResults(showTitle, results);
                if (frmResults.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    result = frmResults.ChoosenResult;
            }

            return result;
        }
    }
}
