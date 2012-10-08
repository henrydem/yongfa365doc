using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightExtensions
{
    ///<summary>
    /// Silverlight鼠标事件帮助类
    /// </summary>
    public class MouseEventHelper
    {

        #region MouseDoubleClick

        public static MouseButtonEventHandler GetMouseDoubleClick(DependencyObject obj)
        {
            return (MouseButtonEventHandler)obj.GetValue(MouseDoubleClickProperty);
        }

        public static void SetMouseDoubleClick(DependencyObject obj, MouseButtonEventHandler value)
        {
            obj.SetValue(MouseDoubleClickProperty, value);
        }

        public static readonly DependencyProperty MouseDoubleClickProperty =
            DependencyProperty.RegisterAttached(
            "MouseDoubleClick",
            typeof(MouseButtonEventHandler),
            typeof(MouseEventHelper),
            new PropertyMetadata(new PropertyChangedCallback(OnMouseDoubleClickChanged))
            );

        #endregion

        #region MouseDoubleClickCommand

        public static ICommand GetMouseDoubleClickCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(MouseDoubleClickCommandProperty);
        }

        public static void SetMouseDoubleClickCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(MouseDoubleClickCommandProperty, value);
        }

        public static readonly DependencyProperty MouseDoubleClickCommandProperty =
            DependencyProperty.RegisterAttached(
            "MouseDoubleClickCommand",
            typeof(ICommand),
            typeof(MouseEventHelper),
            new PropertyMetadata(OnMouseDoubleClickChanged)
            );

        #endregion

        #region Method
        private static DateTime? LastClickTime = null;
        private const int MaxClickInterval = 500;//ms

        private static void OnMouseDoubleClickChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var element = obj as UIElement;
            if (element != null)
            {
                element.MouseLeftButtonUp += new MouseButtonEventHandler(element_MouseLeftButtonUp);
            }
        }


        /// <summary>
        /// 通过检测两次鼠标单机的间隔来模拟鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //进入双击事件
            if (LastClickTime.HasValue && DateTime.Now.Subtract(LastClickTime.Value).TotalMilliseconds <= MaxClickInterval)
            {
                //触发事件
                var handler = (sender as UIElement).GetValue(MouseDoubleClickProperty) as MouseButtonEventHandler;
                if (handler != null)
                {
                    handler(sender, e);
                }
                var command = (sender as UIElement).GetValue(MouseDoubleClickCommandProperty) as ICommand;
                if (command != null)
                {
                    if (command.CanExecute(sender))
                    {
                        command.Execute(sender);
                    }
                }
                //重新计时
                LastClickTime = null;
            }
            else
            {
                LastClickTime = DateTime.Now;
            }
        }

        #endregion

    }
}
