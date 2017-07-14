using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace MVCModule.Models
{
    [TableName("MVCModule_Statistics")]
    //setup the primary key for table
    [PrimaryKey("StatisticId", AutoIncrement = true)]
    //configure caching using PetaPoco
    //[Cacheable("Statistics", CacheStatisticPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Statistic
    {
        public int StatisticId { get; set; }
        public string IconClass { get; set; }
        public int Quantity { get; set; }
        public string Heading { get; set; }
        public int ModuleId { get; set; }
        public int SiteId { get; set; }

        [ReadOnlyColumn]
        public bool IsActived { get; set; } = false;
    }
}