using System;

namespace ps_entities
{
    public class PostData
    {
        public string Body { get; }
        public string[] ImagePaths { get; }
        public DateTime ScheduledTime { get; }

        public PostData(string body, string[] imagePaths, DateTime scheduledTime)
        {
            Body = body;
            ImagePaths = imagePaths;
            ScheduledTime = scheduledTime;
        }

        public bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(Body))
                return false;

            if (ImagePaths.Length > 3)
                return false;

            foreach (var path in ImagePaths)
            {
                if (String.IsNullOrWhiteSpace(path)) return false;
            }

            if (DateTime.Compare(ScheduledTime, DateTime.Now) < 0)
                return false;
            
            return true;
        }
    }
}