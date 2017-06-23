﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Scalable.Shared.Common;

namespace Scalable.Win.Controls
{
    public partial class iNumberTextBox : TextBox
    {
        #region Variables for Mask String

        private int _decimalPart;
        private int _integerPart;

        #endregion

        #region Variables for Format String

        private NumberFormatInfo _nfi;

        #endregion

        #region Public Properties

        private string _displayFormat;
        public string DisplayFormat
        {
            get { return _displayFormat; }
            set
            {
                _displayFormat = value;
                if (string.IsNullOrEmpty(_displayFormat)) return;
                _nfi = new NumberFormatInfo();
                if (_displayFormat.Contains("."))
                {
                    _nfi.NumberGroupSizes = getIntegerFormat(_displayFormat.Substring(0, _displayFormat.IndexOf(".")));
                    _nfi.NumberDecimalDigits = getDecimalFormat(_displayFormat.Substring(_displayFormat.IndexOf(".") + 1));
                }
                else
                    _nfi.NumberGroupSizes = getIntegerFormat(_displayFormat);
            }
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set 
            {
                _value = value;
                Text = _nfi == null ? _value.ToString() : _value.ToString("N", _nfi);
            }
        }

        [DefaultValue(false)]
        public bool AllowNegative { get; set; }

        private string _valueFormat;
        public string ValueFormat
        {
            get { return _valueFormat; }
            set
            {
                double number;
                if ((double.TryParse(value, out number) && number >= 1.0) || string.IsNullOrEmpty(value))
                    _valueFormat = value;
                else
                    throw new Exception("Invalid Mask Value");
            }
        }

        #endregion

        #region Overriden Events

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            EventHandlerExecutor.Execute(processTextChanged);
        }

        void processTextChanged()
        {
            if (string.IsNullOrEmpty(Text))
                return;

            if (Text.Substring(0, 1) != ".")
                return;

            Text = @"0" + Text;
            SelectionStart = 2;
            return;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            EventHandlerExecutor.Execute(processKeyPress, this, e);
        }

        void processKeyPress(object sender, EventArgs e)
        {
            var args = (KeyPressEventArgs)e;

            base.OnKeyPress(args);
            if (string.IsNullOrEmpty(_valueFormat))
                allowOnlyNumbers(args);
            else
            {
                getMaskDetails();
                args.Handled = !appendChar(args.KeyChar);
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            EventHandlerExecutor.Execute(processOnEnter);
        }

        void processOnEnter()
        {
            if (Value.ToString() != "0")
                Text = Value.ToString();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            EventHandlerExecutor.Execute(processOnLeave);
        }

        void processOnLeave()
        {
            if (string.IsNullOrEmpty(Text))
                Text = @"0";

            Value = Convert.ToDouble(Text);
            Text = _nfi == null ? Value.ToString() : Value.ToString("N", _nfi);
        }

        #endregion

        #region Constructors

        public iNumberTextBox()
        {
            TextAlign = HorizontalAlignment.Right;
        }

        #endregion

        #region Private Methods

        private int getDecimalFormat(string format)
        {
            return format.ToCharArray().Count(c => c == '#');
        }

        private int[] getIntegerFormat(string format)
        {
            var chars = format.Reverse();
            var result = new List<int>();
            var str = "";

            foreach (var c in chars)
            {
                if (c == '#')
                    str = str + c;
                else
                {
                    if (str.Length != 0)
                        result.Add(str.Length);

                    str = "";
                }
            }

            if (str.Length != 0)
                result.Add(str.Length);

            return result.ToArray();
        }

        private void allowOnlyNumbers(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !isBackSpace(e.KeyChar))
                e.Handled = true;

            if (isMinus(e.KeyChar) && AllowNegative)
            {
                setOrRemoveMinus();
                e.Handled = true;
            }
        }

        private void getMaskDetails()
        {
            var maskValue = Convert.ToDouble(_valueFormat);
            _decimalPart = (int)Math.Round((maskValue - Math.Floor(maskValue)) * 10);
            _integerPart = (int)Math.Floor(maskValue);
        }

        private bool appendChar(char keyChar)
        {
            if (isMinus(keyChar) && AllowNegative)
            {
                setOrRemoveMinus();
                return false;
            }

            if (isBackSpace(keyChar))
                return true;

            if (isDecimalPlaceValid() && isDecimal(keyChar) && isDecimalAllowed())
                return AppendDecimal();

            if (Char.IsDigit(keyChar))
            {
                if (SelectionLength > 0 && isResultLengthValid())
                    return true;

                if (integerIsZero())
                {
                    replaceZeroWithInput(keyChar);
                    return false;
                }

                if (keyChar == '0' && !isTextLengthValid())
                    return allowZeroAtBeginning();

                if (!isTextLengthValid())
                    return true;
            }

            return false;
        }

        private static bool isMinus(char keyChar)
        {
            return keyChar == (char)Keys.Insert;
        }

        private void setOrRemoveMinus()
        {
            var currentPosition = SelectionStart;
            if (Text.Contains("-"))
            {
                Text = Text.Substring(1, Text.Length - 1);
                SelectionStart = currentPosition == 0 ? 0 : currentPosition - 1;
            }
            else
            {
                Text = @"-" + Text;
                SelectionStart = currentPosition + 1;
            }
        }

        private static bool isBackSpace(char keyChar)
        {
            return keyChar == (char)Keys.Back;
        }

        private bool isDecimalAllowed()
        {
            return _valueFormat.Contains(".");
        }

        private static bool isDecimal(char keyChar)
        {
            return keyChar == (char)Keys.KeyCode || keyChar == '.';
        }

        private bool isDecimalPlaceValid()
        {
            var bit = Text.Contains("-") ? 1 : 0;

            if (SelectionLength == 0)
                return Text.Length - SelectionStart - bit <= _decimalPart;

            return true;
        }

        private bool AppendDecimal()
        {
            return !Text.Contains(".") || SelectedText.Contains(".");
        }

        private bool isResultLengthValid()
        {
            var bit = Text.Contains("-") ? 1 : 0;

            if (SelectedText.Contains("."))
                return Text.Length - SelectionLength - bit <= _integerPart;

            return true;
        }

        private bool integerIsZero()
        {
            var bit = Text.Contains("-") ? 1 : 0;
            return SelectionStart == (1 + bit) && Text.Substring(bit, 1) == "0";
        }

        private void replaceZeroWithInput(char keyChar)
        {
            var bit = Text.Contains("-") ? 1 : 0;
            var minus = Convert.ToBoolean(bit) ? "-" : "";
            Text = minus + keyChar + Text.Substring((1 + bit), Text.Length - (1 + bit));
        }

        private bool isTextLengthValid()
        {
            var result = false;
            var bit = Text.Contains("-") ? 1 : 0;

            if (Text.Contains("."))
            {
                if (SelectionStart <= Text.IndexOf('.'))
                    result = (Text.Substring(bit, Text.IndexOf('.') - bit).Length == _integerPart);
                else if (!isLastCharDecimal())
                    result = (Text.Substring(Text.IndexOf('.') + 1).Length == _decimalPart);
            }
            else
                result = (Text.Substring(bit, TextLength - bit).Length == _integerPart);

            return result;
        }

        private bool isLastCharDecimal()
        {
            return Text.Substring(TextLength - 1, 1) == ".";
        }

        private bool allowZeroAtBeginning()
        {
            var bit = Text.Contains("-") ? 1 : 0;
            if (!string.IsNullOrEmpty(Text) && Text != @"-")
            {
                if (SelectionStart == bit && Text.Substring(bit, 1) != @"0")
                    return false;

                if (SelectionStart == (1 + bit) && Text.Substring(bit, 1) == @"0")
                    return false;
            }
            return true;
        }

        #endregion
    }
}