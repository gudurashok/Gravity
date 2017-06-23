using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Scalable.Shared.Enums;

namespace Scalable.Shared.Common
{
    public static class EventHandlerExecutor
    {
        #region Delegate declarations

        public delegate void ExecutionCallback(EventHandlerExecutionResult result);
        public delegate void EmptyParamsEventHandler();
        public delegate void SenderEventHandler(object sender);

        #endregion

        #region Public methods

        public static void Execute(SenderEventHandler handler, object sender)
        {
            Execute(handler, sender, null);
        }

        public static void Execute(SenderEventHandler handler, object sender,
                                               ExecutionCallback callback)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                handler(sender);
                onExecution(callback, EventHandlerExecutionResult.Success);
            }
            catch (Exception ex)
            {
                postProcessFailedExecution(ex, null, callback);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void Execute(EmptyParamsEventHandler handler)
        {
            Execute(handler, null);
        }

        public static void Execute(EmptyParamsEventHandler handler, ExecutionCallback callback)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                handler();
                onExecution(callback, EventHandlerExecutionResult.Success);
            }
            catch (Exception ex)
            {
                postProcessFailedExecution(ex, null, callback);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void Execute(EventHandler handler, object sender, EventArgs e)
        {
            Execute(handler, sender, e, null);
        }

        public static void Execute(EventHandler handler, object sender, EventArgs e,
                                               ExecutionCallback callback)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                handler(sender, e);
                onExecution(callback, EventHandlerExecutionResult.Success);
            }
            catch (Exception ex)
            {
                postProcessFailedExecution(ex, sender, callback);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Private methods

        private static void postProcessFailedExecution(Exception exception, object sender,
                                                                 ExecutionCallback callback)
        {
            if (exception is ValidationException)
            {
                var ex = exception as ValidationException;
                MessageBoxUtil.ShowMessage(exception.Message);
                onExecution(callback, EventHandlerExecutionResult.Fail);
                FindControl.SetFocusToControl(sender, ex.ValidationResult.MemberNames.FirstOrDefault());
                return;
            }

            MessageBoxUtil.ShowError(exception);
            onExecution(callback, EventHandlerExecutionResult.Fail);
        }

        private static void onExecution(ExecutionCallback callback,
                                                    EventHandlerExecutionResult result)
        {
            if (callback != null)
                callback(result);
        } 

        #endregion
    }
}
