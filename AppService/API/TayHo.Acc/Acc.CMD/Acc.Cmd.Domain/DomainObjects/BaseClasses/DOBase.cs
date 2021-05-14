using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
using System;


namespace Acc.Cmd.Domain.DomainObjects.BaseClasses
{

    public abstract class DOBase : EntityDO, IAggregateRoot
    {
        #region Constructors
        public DOBase()
        {
        }
      
        #endregion Constructors

    }
}
