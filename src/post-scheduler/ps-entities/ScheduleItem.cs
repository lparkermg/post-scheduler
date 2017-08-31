using System;
using ps_adaptors;

namespace ps_entities
{
    public class ScheduleItem
    {
        public Guid Id { get; }
        public PostData Data { get; }
        public PostLocations PostLocation { get; }
        
        public ScheduleItem(Guid id, PostData data, PostLocations postLocation)
        {
            Id = id;
            Data = data;
            PostLocation = postLocation;
        }

        public bool IsValid()
        {
            if (Id == Guid.Empty)
                return false;

            return Data.IsValid();
        }
    }
}