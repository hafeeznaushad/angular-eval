using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KidsCove.Core.Domain
{
    public abstract class Entity
    {
        /// <summary>
        /// Group Name
        /// </summary>
        public virtual int Key { get; set; }
    }
}
