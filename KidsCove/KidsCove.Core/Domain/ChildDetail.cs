using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KidsCove.Core.Domain
{
    /// <summary>
    /// Entity / Domain model for the child group.
    /// </summary>
    public class ChildDetail : Entity
    {
        /// <summary>
        /// First Name
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Parents Name
        /// </summary>
        public virtual string Parent1Name { get; set; }

        /// <summary>
        /// Parents Name
        /// </summary>
        public virtual string Parent2Name { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public virtual DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// the group the child belongs to
        /// </summary>
        public virtual int ChildGroupId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ChildGroup Group { get; set; }
    }
}
