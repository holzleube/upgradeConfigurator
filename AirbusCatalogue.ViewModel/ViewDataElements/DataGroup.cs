﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.ViewModel.ViewDataElements
{
    
        public class DataGroup : DataCommon
        {
            public DataGroup(String uniqueId, String title, String imagePath)
                : base(uniqueId, title, imagePath)
            {
                Items.CollectionChanged += ItemsCollectionChanged;
            }

            private ObservableCollection<IIdentable> _items = new ObservableCollection<IIdentable>();
            public ObservableCollection<IIdentable> Items
            {
                get
                {
                    return this._items;
                }

                set { _items = value;
                    _topItem = value;
                }
            }

            private void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                // Provides a subset of the full items collection to bind to from a GroupedItemsPage
                // for two reasons: GridView will not virtualize large items collections, and it
                // improves the user experience when browsing through groups with large numbers of
                // items.
                //
                // A maximum of 12 items are displayed because it results in filled grid columns
                // whether there are 1, 2, 3, 4, or 6 rows displayed

                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        if (e.NewStartingIndex < 12)
                        {
                            TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                            if (TopItems.Count > 12)
                            {
                                TopItems.RemoveAt(12);
                            }
                        }
                        break;
                    case NotifyCollectionChangedAction.Move:
                        if (e.OldStartingIndex < 12 && e.NewStartingIndex < 12)
                        {
                            TopItems.Move(e.OldStartingIndex, e.NewStartingIndex);
                        }
                        else if (e.OldStartingIndex < 12)
                        {
                            TopItems.RemoveAt(e.OldStartingIndex);
                            TopItems.Add(Items[11]);
                        }
                        else if (e.NewStartingIndex < 12)
                        {
                            TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                            TopItems.RemoveAt(12);
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        if (e.OldStartingIndex < 12)
                        {
                            TopItems.RemoveAt(e.OldStartingIndex);
                            if (Items.Count >= 12)
                            {
                                TopItems.Add(Items[11]);
                            }
                        }
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        if (e.OldStartingIndex < 12)
                        {
                            TopItems[e.OldStartingIndex] = Items[e.OldStartingIndex];
                        }
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        TopItems.Clear();
                        while (TopItems.Count < Items.Count && TopItems.Count < 12)
                        {
                            TopItems.Add(Items[TopItems.Count]);
                        }
                        break;
                }
            }



            private ObservableCollection<IIdentable> _topItem = new ObservableCollection<IIdentable>();


            public ObservableCollection<IIdentable> TopItems
            {
                get { return this._topItem; }
            }

            public int Size { get { return Items.Count; } }
        }
    
}
