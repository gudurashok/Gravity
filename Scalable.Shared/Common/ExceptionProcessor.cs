using System;
using System.ComponentModel.DataAnnotations;

namespace Scalable.Shared.Common
{
    public static class ExceptionProcessor
    {
        public static void Process(Exception exp)
        {
            if (exp is ValidationException)
                MessageBoxUtil.ShowMessage(exp.Message);
            else
                MessageBoxUtil.ShowError(exp);
        }
    }
}
