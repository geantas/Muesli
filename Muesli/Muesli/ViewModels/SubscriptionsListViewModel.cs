using Muesli.Models;
using System.Collections.Generic;

namespace Muesli.ViewModels
{
    public class SubscriptionsListViewModel
    {
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int? CurrentUser { get; set; }
    }
}