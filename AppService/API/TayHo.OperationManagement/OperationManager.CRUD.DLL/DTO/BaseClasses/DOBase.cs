using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Interfaces;

namespace OperationManager.CRUD.DAL.DTO.BaseClasses
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
