//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Topppro.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assn_CategorySerieProduct
    {
        public int AssnCategorySerieProductId { get; set; }
        public int AssnCategorySerieId { get; set; }
        public int ProductId { get; set; }
        public bool AllowCompare { get; set; }
        public Nullable<int> Priority { get; set; }
        public bool Enabled { get; set; }
    
        public virtual Assn_CategorySerie Assn_CategorySerie { get; set; }
        public virtual Product Product { get; set; }
    }
}
