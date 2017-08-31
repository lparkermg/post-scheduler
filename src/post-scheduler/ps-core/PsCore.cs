using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ps_adaptors;
using ps_adaptors.Interfaces;
using ps_entities;

namespace ps_core
{
    public static class PsCore
    {
        private static List<ScheduleItem> _scheduledItems;
        private static List<IAdaptor> _postAdaptors;

        public static void Initialise(List<ScheduleItem> items, List<IAdaptor> adaptors)
        {
            _scheduledItems = items;
            _postAdaptors = adaptors;
            
        }

        public static bool Start()
        {
            //TODO: Initialise a timer to poll the CheckPost function.
            return true;
        }
        
        public static bool Stop()
        {
            //TODO: Save existing scheduled items before closedown?
            return true;
        }

        public static bool AddToQueue(PostData data,PostLocations postingTo )
        {
            if (!data.IsValid())
                return false;
            
            _scheduledItems.Add(new ScheduleItem(Guid.NewGuid(),data,postingTo));
            return true;
        }

        

        private static void CheckPost()
        {
            var itemsToRemove = new List<ScheduleItem>();
            foreach (var item in _scheduledItems)
            {
                var postingTo = _postAdaptors.FirstOrDefault(a => a.PostLocation == item.PostLocation);
                var success = false;
                if (postingTo == null)
                    break; //Something went wrong...
                
                if(DateTime.Compare(item.Data.ScheduledTime, DateTime.Now) <= 0)
                    success = Post(item,postingTo); 
                
                if(success)
                    itemsToRemove.Add(item);
            }

            foreach (var item in itemsToRemove)
            {
                _scheduledItems.Remove(item);
            }
            
            //TODO: Update existing scheduled files to match ones in list.
        }

        private static bool Post(ScheduleItem item, IAdaptor postingTo)
        {
            return postingTo.Post(item.Data).Result; //Should probably make this async later...
        }
    }
}