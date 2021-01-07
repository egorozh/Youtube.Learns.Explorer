﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChromER
{
    public class MainViewModel : BaseViewModel
    {
        #region Private Fields

        private readonly ISynchronizationHelper _synchronizationHelper;

        #endregion

        #region Public Properties

        public ITabClient InterTabClient { get; }

        public ObservableCollection<ChromerTabItemViewModel> TabItems { get; }

        public ChromerTabItemViewModel CurrentTabItem { get; set; }

        public IReadOnlyCollection<MenuItemViewModel> Bookmarks => ChromEr.Instance.BookmarksManager.Bookmarks;

        public Func<DirectoryTabItemViewModel> Factory { get; }

        #endregion

        #region Constructor

        public MainViewModel(ISynchronizationHelper synchronizationHelper, ITabClient tabClient,
            IEnumerable<DirectoryTabItemViewModel> init)
        {
            _synchronizationHelper = synchronizationHelper;
            InterTabClient = tabClient;

            TabItems = new ObservableCollection<ChromerTabItemViewModel>(init);

            Factory = CreateTabVm;
        }

        #endregion

        #region Private Methods

        private DirectoryTabItemViewModel CreateTabVm() => new(_synchronizationHelper);

        #endregion
    }
}