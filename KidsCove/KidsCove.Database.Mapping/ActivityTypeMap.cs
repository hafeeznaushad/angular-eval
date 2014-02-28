using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using KidsCove.Core.Domain;

namespace KidsCove.Database.Mappings
{
    public class ActivityTypeMap : ClassMap<ChildActivityType>
    {
        public ActivityTypeMap()
        {
            Table("kc_event_type");
            Id(x => x.Key).Column("id");
            Map(x => x.Activity, "event_type").CustomType(typeof(CaseInsensitiveEnumType<ActivityType>));
        }
    }
}
