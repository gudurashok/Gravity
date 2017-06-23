using System.Windows.Forms;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;
using System.Linq;

namespace Scalable.Win.Picklist
{
    public abstract class PicklistBase : IPicklist
    {
        private FList _form;
        protected readonly string _searchProperty;
        protected bool _isSetup;

        protected PicklistBase(string searchProperty)
        {
            _searchProperty = searchProperty;
        }

        public UPicklist Control
        {
            get { return createControl(); }
        }

        public FList Form
        {
            get
            {
                if (_form == null)
                    _form = createForm();

                if (_form.Modal)
                    _form = createForm();

                return _form;
            }
        }

        protected virtual UPicklist createControl()
        {
            return createControl(false);
        }

        protected virtual UPicklist createControl(bool onlySelection)
        {
            var uList = new UPicklist();
            uList.SearchProperty = _searchProperty;
            build(uList);
            uList.btnOpen.Visible = !onlySelection;
            return uList;
        }

        protected virtual FList createForm()
        {
            var form = new FList(Control);
            form.SetFormTitle(getTitleText());
            var width = getSumOfColumnWidths(form.uPicklist.ListView);

            form.Initialize();
            if (width > form.Width) form.Width = width;
            if (form.uPicklist.Height > form.Height) form.Height = form.uPicklist.Height;

            return form;
        }

        private int getSumOfColumnWidths(ListView lvw)
        {
            return lvw.Columns.Cast<ColumnHeader>().Sum(c => c.Width);
        }

        protected void build(UListView ulv)
        {
            createColumns(ulv.ListView);
            ulv.Repository = createRepository();
        }

        protected abstract string getTitleText();
        protected abstract void createColumns(iListView lvw);
        protected abstract IListRepository createRepository();
    }
}
