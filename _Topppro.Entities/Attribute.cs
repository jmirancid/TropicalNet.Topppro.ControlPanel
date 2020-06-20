﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Framework.Entities;
using Framework.Entities.Resources;
using Framework.IO.Attributes;
using Topppro.Entities.Resources;

namespace Topppro.Entities
{
    [MetadataType(typeof(Attribute_Metadata))]
    public partial class Attribute : BaseEntity
    {
        public override int Id
        {
            get
            {
                return AttributeId;
            }
            set
            {
                AttributeId = value;
            }
        }
    }

    public class Attribute_Metadata
    {
        [Import(Order = 0), Export(Order = 0)]
        public int AttributeId { get; set; }

        [Display(Name = "Entity_Product", ResourceType = typeof(Ent_AttributeResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public int ProductId { get; set; }

        [Import(Order = 1), Export(Order = 1)]
        [Display(Name = "Entity_Culture", ResourceType = typeof(Ent_AttributeResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public int CultureId { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Import(Order = 2), Export(Order = 2)]
        [Display(Name = "Entity_Name", ResourceType = typeof(Ent_AttributeResource))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Ent_ValidationResource))]
        public string Name { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Import(Order = 3), Export(Order = 3)]
        [Display(Name = "Entity_Value", ResourceType = typeof(Ent_AttributeResource))]
        public string Value { get; set; }

        [Import(Order = 4), Export(Order = 4)]
        [Display(Name = "Entity_Priority", ResourceType = typeof(Ent_AttributeResource))]
        public Nullable<int> Priority { get; set; }

        [Import(Order = 5), Export(Order = 5)]
        [Display(Name = "Entity_Enabled", ResourceType = typeof(Ent_AttributeResource))]
        public bool Enabled { get; set; }
    }
}