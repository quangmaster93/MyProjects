using DotNetNuke.ComponentModel.DataAnnotations;
//using DotNetNuke.ComponentModel.DataAnnotations;


namespace MVCModule.Models
{
    [TableName("MVCModule_Products")]
    //setup the primary key for table
    [PrimaryKey("ProductId", AutoIncrement = true)]
    //configure caching using PetaPoco
    //[Cacheable("Products", CacheProductPriority.Default, 20)]
    ////scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}