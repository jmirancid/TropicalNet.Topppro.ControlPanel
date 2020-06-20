//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml.Serialization;


namespace Topppro.Entities
{
    [Serializable]
    public partial class Download
    {
        #region Primitive Properties
    
        public virtual int DownloadId
        {
            get;
            set;
        }
    
        public virtual int CultureId
        {
            get { return _cultureId; }
            set
            {
                if (_cultureId != value)
                {
                    if (Culture != null && Culture.CultureId != value)
                    {
                        Culture = null;
                    }
                    _cultureId = value;
                }
            }
        }
        private int _cultureId;
    
        public virtual int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    if (Product != null && Product.ProductId != value)
                    {
                        Product = null;
                    }
                    _productId = value;
                }
            }
        }
        private int _productId;
    
        public virtual int PlatformId
        {
            get { return _platformId; }
            set
            {
                if (_platformId != value)
                {
                    if (Platform != null && Platform.PlatformId != value)
                    {
                        Platform = null;
                    }
                    _platformId = value;
                }
            }
        }
        private int _platformId;
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string Description
        {
            get;
            set;
        }
    
        public virtual bool External
        {
            get;
            set;
        }
    
        public virtual string Resource
        {
            get;
            set;
        }
    
        public virtual Nullable<int> Priority
        {
            get;
            set;
        }
    
        public virtual bool Enabled
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Culture Culture
        {
            get { return _culture; }
            set
            {
                if (!ReferenceEquals(_culture, value))
                {
                    var previousValue = _culture;
                    _culture = value;
                    FixupCulture(previousValue);
                }
            }
        }
        private Culture _culture;
    
        public virtual Product Product
        {
            get { return _product; }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    var previousValue = _product;
                    _product = value;
                    FixupProduct(previousValue);
                }
            }
        }
        private Product _product;
    
        public virtual Platform Platform
        {
            get { return _platform; }
            set
            {
                if (!ReferenceEquals(_platform, value))
                {
                    var previousValue = _platform;
                    _platform = value;
                    FixupPlatform(previousValue);
                }
            }
        }
        private Platform _platform;

        #endregion

        #region Association Fixup
    
        private void FixupCulture(Culture previousValue)
        {
            if (previousValue != null && previousValue.Downloads.Contains(this))
            {
                previousValue.Downloads.Remove(this);
            }
    
            if (Culture != null)
            {
                if (!Culture.Downloads.Contains(this))
                {
                    Culture.Downloads.Add(this);
                }
                if (CultureId != Culture.CultureId)
                {
                    CultureId = Culture.CultureId;
                }
            }
        }
    
        private void FixupProduct(Product previousValue)
        {
            if (previousValue != null && previousValue.Downloads.Contains(this))
            {
                previousValue.Downloads.Remove(this);
            }
    
            if (Product != null)
            {
                if (!Product.Downloads.Contains(this))
                {
                    Product.Downloads.Add(this);
                }
                if (ProductId != Product.ProductId)
                {
                    ProductId = Product.ProductId;
                }
            }
        }
    
        private void FixupPlatform(Platform previousValue)
        {
            if (previousValue != null && previousValue.Downloads.Contains(this))
            {
                previousValue.Downloads.Remove(this);
            }
    
            if (Platform != null)
            {
                if (!Platform.Downloads.Contains(this))
                {
                    Platform.Downloads.Add(this);
                }
                if (PlatformId != Platform.PlatformId)
                {
                    PlatformId = Platform.PlatformId;
                }
            }
        }

        #endregion

    }
}
