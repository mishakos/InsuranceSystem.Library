using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace InsuranceSystem.Infrastructure
{
    /// <summary>
    /// Base class to facilitate the creation of <see cref="T:Prism.Regions.IRegionAdapter" /> implementations.
    /// </summary>
    /// <typeparam name="T">Type of object to adapt.</typeparam>
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory factory)
            :base(factory)
        {

        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }

                // handle remove
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
