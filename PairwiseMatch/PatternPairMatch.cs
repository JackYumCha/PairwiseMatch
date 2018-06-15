using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace PairwiseMatch
{
    public class PatternPairMatch
    {
        public PatternPairMatch(Match left, Match right, string content)
        {
            Left = left;
            Right = right;
            Content = content;
        }

        public PatternPairMatch(Match left, Match right, string content, Regex rgxLeft, Regex rgxRight)
        {
            Left = left;
            Right = right;
            Content = content;
            ExpandBranch(rgxLeft, rgxRight);
        }

        public Match Left { get; private set; }
        public Match Right { get; private set; }
        public string Content { get; private set; }
        public ReadOnlyCollection<PatternPairMatch> Children { get; private set; }

        public int ExpandBranch(Regex left, Regex right)
        {
            Children = new ReadOnlyCollection<PatternPairMatch>(Content.PairwisePatternMatch(left, right, true));
            return Children.Count;
        }
    }
}
