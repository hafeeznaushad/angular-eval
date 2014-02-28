using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KidsCove.Core.Domain;

namespace KidsCove.Database.Mappings
{
    public class ChildMap : ClassMap<ChildDetail>
    {
        public ChildMap()
        {
            Table("kc_child_detail");
            Id(x => x.Key).Column("id");
            Map(x => x.FirstName, "first_name");
            Map(x => x.LastName, "last_name");
            Map(x => x.Parent1Name, "parent1_name");
            Map(x => x.Parent2Name, "parent2_name");
            Map(x => x.DateOfBirth, "date_of_birth");
            References(x => x.Group, "child_group_id");
        }
    }
}
