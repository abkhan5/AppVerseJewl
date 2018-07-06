using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Logging;
using Prism.Mvvm;

namespace AppVerse.Jewel.Core.ApplicationBase
{
    public abstract class BaseViewModel : BindableBase
    {
        #region Private memebers

        protected IUnityContainer _unityContainer;
        private IEventAggregator _evenAggregator;
        protected ILoggerFacade _logger;
        #endregion


        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unityContainer"></param>
        protected BaseViewModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            Initialize();
        }
        #endregion

        #region Properties
        public IEventAggregator AppEventAggregator => _evenAggregator ?? (_evenAggregator = _unityContainer.Resolve<IEventAggregator>());


        public string Title { get; protected set; }
        #endregion

        #region methods
        protected abstract void Initialize();
        #endregion


    }
}