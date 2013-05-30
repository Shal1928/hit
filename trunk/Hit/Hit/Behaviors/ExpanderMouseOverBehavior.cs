using System;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace Hit.Behaviors
{
    public class ExpanderMouseOverBehavior : Behavior<Expander>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseEnter += OnMouseOverDelay;
            AssociatedObject.MouseLeave += OnMouseLeave;
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseEnter -= OnMouseOverDelay;
        }

        private static DispatcherTimer _dispatcherTimer;

        private void OnMouseOverDelay(object sender, EventArgs e)
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += MosueTickCheck;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            _dispatcherTimer.Start();
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            AssociatedObject.IsExpanded = false;
            _dispatcherTimer.Stop();
            _dispatcherTimer = null;
        }

        private void MosueTickCheck(object sender, EventArgs e)
        {
            AssociatedObject.IsExpanded = true;
        }
    }
}