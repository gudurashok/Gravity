using System.Collections.Generic;
using System.Linq;
using Mingle.Domain.Entities;
using Mingle.Domain.Enums;
using Mingle.Domain.Repositories;

namespace Mingle.Domain.Model
{
    public static class ReferenceList
    {
        private const string _listPrefix = "References";
        private static IList<ReferenceListEntity> _lists = new List<ReferenceListEntity>();

        public static IList<string> GetList(ListType listType)
        {
            var id = string.Format("{0}/{1}", _listPrefix, listType);
            var result = _lists.SingleOrDefault(l => l.Id == id);

            if (result == null)
            {
                result = new ReferenceListEntity { Id = id, Items = new List<string>() };
                _lists.Add(result);
            }

            return result.Items;
        }

        public static void LoadLists()
        {
            if (_lists != null && _lists.Count != 0)
            {
                updateCount();
                return;
            }

            var repo = new PartyRepository();
            _lists = repo.GetAllReferenceLists();
            updateCount();
        }

        public static void SaveLists()
        {
            var repo = new PartyRepository();

            foreach (var list in _lists.Where(list => list.Items.Count != list.ItemsCount))
            {
                list.Items = list.Items
                                 .Where(i => i != null)
                                 .OrderBy(i => i.ToString())
                                 .ToList();
                repo.SaveLists(list);
            }

            LoadLists();
        }

        private static void updateCount()
        {
            foreach (var list in _lists)
                list.ItemsCount = list.Items.Count;
        }
    }
}
