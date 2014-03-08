using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;
using System.Windows.Threading;

namespace Hextasy.Framework.Utils
{
    public class DispatcherObservableCollection<T> : ObservableCollection<T>
    {
        #region Fields

        private static object _syncLock = new object();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DispatcherObservableCollection{T}"/> class.
        /// </summary>
        public DispatcherObservableCollection()
        {
            if (Synchronization.Enabled)
                BindingOperations.EnableCollectionSynchronization(this, _syncLock);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DispatcherObservableCollection{T}"/> class that contains
        /// elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection from which the elements are copied.</param>
        public DispatcherObservableCollection(IEnumerable<T> collection)
            : base(collection)
        {
            if (Synchronization.Enabled)
                BindingOperations.EnableCollectionSynchronization(this, _syncLock);
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Overridden <see cref="ObservableCollection{T}.CollectionChanged"/>-event to be able to raise it manually.
        /// </summary>
        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion Events

        #region Protected Methods

        /// <summary>
        /// Raise CollectionChanged event to any listeners.
        /// Properties/methods modifying this ObservableCollectionEx will raise
        /// a collection changed event through this virtual method.
        /// </summary>
        /// <param name="eventArgs">Event arguments which contain information about the collection changes.</param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs eventArgs)
        {
            using (BlockReentrancy())
            {
                var eventHandler = CollectionChanged;
                if (eventHandler == null)
                {
                    return;
                }

                var collectionChangedHandlers = eventHandler.GetInvocationList().Cast<NotifyCollectionChangedEventHandler>();
                InvokeCollectionChangedHandlers(collectionChangedHandlers, eventArgs);
            }
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Calls all of the given event handlers with the specified event arguments.
        /// </summary>
        /// <remarks>This method is "dispatcher-safe", i.e. it calls each handler on its correct <see cref="Dispatcher"/>-thread.</remarks>
        /// <param name="collectionChangedHandlers">Event handlers to be invoked.</param>
        /// <param name="eventArgs">Event arguments to be passed to the invoked <paramref name="collectionChangedHandlers"/>.</param>
        private void InvokeCollectionChangedHandlers(
            IEnumerable<NotifyCollectionChangedEventHandler> collectionChangedHandlers, NotifyCollectionChangedEventArgs eventArgs)
        {
            foreach (var collectionChangedHandler in collectionChangedHandlers)
            {
                var dispatcherObject = collectionChangedHandler.Target as DispatcherObject;
                if (dispatcherObject != null && !dispatcherObject.CheckAccess())
                {
                    dispatcherObject.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, collectionChangedHandler, this, eventArgs);
                }
                else
                {
                    collectionChangedHandler(this, eventArgs);
                }
            }
        }

        #endregion Private Methods
    }
}