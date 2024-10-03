using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mgok2.Helpers
{
    public static class VisualTreeHelper
    {
        public static IEnumerable<DependencyObject> GetChildren(this DependencyObject reference)
        {
            Queue<DependencyObject> queue = new Queue<DependencyObject>(16);
            queue.Enqueue(reference);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                var count = System.Windows.Media.VisualTreeHelper.GetChildrenCount(current);
                for (int i = 0; i < count; i++)
                {
                    queue.Enqueue(System.Windows.Media.VisualTreeHelper.GetChild(current, i));
                }
                yield return current;
            }
        }
        public static IEnumerable<T> GetChildren<T>(this DependencyObject reference)
           where T : DependencyObject
            => reference.GetChildren().OfType<T>();

    }
}

