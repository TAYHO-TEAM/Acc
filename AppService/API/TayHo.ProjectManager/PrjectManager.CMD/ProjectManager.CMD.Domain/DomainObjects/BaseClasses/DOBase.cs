using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Interfaces;

namespace ProjectManager.CMD.Domain.DomainObjects.BaseClasses
{
    public abstract class DOBase : EntityDO, IAggregateRoot
    {
        #region Fields
     
        #endregion Fields
        #region Constructors
        public DOBase()
        {
        }
    
        #endregion Constructors

    }
}
