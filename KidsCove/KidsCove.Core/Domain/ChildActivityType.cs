using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KidsCove.Core.Domain
{
    /// <summary>
    /// Entity / Domain model for the child activity.
    /// </summary>
    public class ChildActivityType : Entity
    {
        
        /// <summary>
        /// the type of activity performned
        /// </summary>
        public virtual ActivityType Activity { get; set; }

    }
}
