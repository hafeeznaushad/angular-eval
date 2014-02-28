using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KidsCove.Core.Domain;

namespace KidsCove.Database.Mappings
{
    public class ChildGroupMap : ClassMap<ChildGroup>
    {
        public ChildGroupMap()
        {
            Table("kc_child_group");
            Id(x => x.Key).Column("id");
            Map(x => x.GroupName, "group_name");
        }
    }
}
