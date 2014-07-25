using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backgammon2
{
    public class Scene
    {
        public Scene(List<Drawable> items, int[] _possibleSources, Dictionary<int, int[]> _possibleTargets)
        {
            this._items = items;
            this.PossibleSources = _possibleSources;
            this.PossibleTargets = _possibleTargets;
        }

        private List<Drawable> _items;
        public List<Drawable> Items
        {
            get { return _items; }
        }

        public readonly int[] PossibleSources;
        public readonly Dictionary<int, int[]> PossibleTargets;
    }
}
