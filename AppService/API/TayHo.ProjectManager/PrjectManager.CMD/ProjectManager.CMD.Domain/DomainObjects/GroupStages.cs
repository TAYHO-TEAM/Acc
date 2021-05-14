using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class GroupStages : DOBase
    {
        #region Fields
        private int? _groupId;
        private int? _stageId;
        #endregion Fields
        #region Constructors
        private GroupStages()
        {
           
        }

        public GroupStages(int? GroupId,
                            int? StageId) : this()
        {
            _groupId = GroupId;
            _stageId = StageId;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        public int? GroupId { get => _groupId; }
        public int? StageId { get => _stageId; }
        #endregion Properties

        #region Behaviours
        public void SetGroupId(int? GroupId) { _groupId = GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStageId(int? StageId) { _stageId = StageId.HasValue ? _stageId : StageId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
