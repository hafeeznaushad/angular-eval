using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KidsCove.Core.Domain
{
    /// <summary>
    /// Entity / Domain model for the child group.
    /// </summary>
    public class ChildGroup : Entity
    {

        /// <summary>
        /// Group Name
        /// </summary>
        public virtual string GroupName { get; set; }
    }
}
