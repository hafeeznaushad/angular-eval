using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KidsCove.Core.Domain
{
    /// <summary>
    /// Entity / Domain model for the child activity.
    /// </summary>
    public class ChildActivityDetail : Entity
    {
        /// <summary>
        /// the type of activity performned
        /// </summary>
        public virtual ChildDetail Child { get; set; }

        /// <summary>
        /// the type of activity performned
        /// </summary>
        public virtual ChildActivityType Activity { get; set; }

        public virtual DateTime EventDate { get; set; }

        public virtual DateTime StartTime { get; set; }

        public virtual DateTime? EndTime { get; set; } 
    }
}
