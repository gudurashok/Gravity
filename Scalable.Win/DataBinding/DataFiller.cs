using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;
using Scalable.Win.Enums;

namespace Scalable.Win.DataBinding
{
    public class DataFiller
    {
        #region Declarations

        private Control _container;
        private object _dataSource;
        private DataFillerAction _action;

        #endregion

        #region Constructor

        public DataFiller(Control container, object dataSource, DataFillerAction action)
        {
            _container = container;
            _dataSource = dataSource;
            _action = action;
        }

        #endregion

        #region Data Fill

        public void Execute()
        {
            executeCore(_container);
        }

        private void executeCore(Control container)
        {
            foreach (Control control in container.Controls)
            {
                var uBaseForm = control as UBaseForm;
                if (uBaseForm != null)
                {
                    if (isFillForm())
                        uBaseForm.DataSource = getDataSource(control);
                    else
                        setDataSource(control, uBaseForm.DataSource);
                }
                else if (control.Tag != null) // && control.Parent.Visible)
                {
                    if (isDataBind())
                        setDataBinding(control);
                    else
                        fillData(control);
                }
                else if (control is Panel)
                    executeCore(control);
            }
        }

        private bool isDataBind()
        {
            return _action == DataFillerAction.SetDataBinding;
        }

        private void setDataSource(Control control, object value)
        {
            if (control.Tag == null)
                return;

            var tag = new ControlTag(control.Tag.ToString());
            var objectProperty = _dataSource.GetType().GetProperty(tag.DataMember);
            objectProperty.SetValue(_dataSource, value, null);
        }

        private object getDataSource(Control control)
        {
            if (control.Tag == null)
                return _dataSource;

            var tag = new ControlTag(control.Tag.ToString());
            var objectProperty = _dataSource.GetType().GetProperty(tag.DataMember);
            return objectProperty.GetValue(_dataSource, null);
        }

        private void fillData(Control control)
        {
            var tag = new ControlTag(control.Tag.ToString());
            var controlProperty = control.GetType().GetProperty(tag.ControlMember);
            var objectProperty = _dataSource.GetType().GetProperty(tag.DataMember);

            if (bothObjectAndControlPropsFound(controlProperty, objectProperty))
                fillCore(control, controlProperty, objectProperty);
        }

        private bool bothObjectAndControlPropsFound(PropertyInfo controlProperty, PropertyInfo objectProperty)
        {
            return (controlProperty != null && objectProperty != null);
        }

        private void fillCore(Control control, PropertyInfo controlProperty, PropertyInfo objectProperty)
        {
            try
            {
                if (isFillForm())
                    setControlValue(control, controlProperty, objectProperty.GetValue(_dataSource, null));
                else
                    setObjectValue(control, objectProperty, controlProperty.GetValue(control, null));
            }
            catch (Exception ex)
            {
                //TODO: should throw a validation exception..??
                throw new ArgumentOutOfRangeException(_dataSource.ToString(), objectProperty.Name,
                                string.Format("Error occured while filling {0}", ex.Message));
            }
        }

        private bool isFillForm()
        {
            return _action == DataFillerAction.FillForm;
        }

        private void setControlValue(Control control, PropertyInfo controlProperty, object value)
        {
            if ((control is ComboBox) && value is Enum)
                setEnumValue(control as ComboBox, (int)value);
            else
                controlProperty.SetValue(control, value, null);
        }

        private void setObjectValue(Control control, PropertyInfo objectProperty, object value)
        {
            if ((control is ComboBox) && objectProperty.GetValue(_dataSource, null) is Enum)
                objectProperty.SetValue(_dataSource, getEnumValue(control as ComboBox), null);
            else
                objectProperty.SetValue(_dataSource, value, null);
        }

        private void setEnumValue(ComboBox control, int value)
        {
            var values = (List<KeyValuePair<int, string>>)control.DataSource;
            var item = values.Where(kv => kv.Key == value).SingleOrDefault();
            control.SelectedItem = item;
        }

        private int getEnumValue(ComboBox control)
        {
            var item = (KeyValuePair<int, string>)control.SelectedItem;
            return item.Key;
        }

        #endregion

        #region Data Binding

        private void setDataBinding(Control control)
        {
            var tag = new ControlTag(control.Tag.ToString());
            control.DataBindings.Add(tag.ControlMember, _dataSource, tag.DataMember);
        }

        #endregion
    }
}
