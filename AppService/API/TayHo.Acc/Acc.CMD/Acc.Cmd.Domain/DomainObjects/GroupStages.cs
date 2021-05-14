using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class GroupStages : DOBase
    {
        #region Fields
        private int? _stageId;
        private int? _groupId;
        #endregion Fields
        #region Constructors

        private GroupStages()
        {
        }

        public GroupStages(int? StagesId,
                            int? GroupId) : this()
        {
            _stageId = StagesId;
            _groupId = GroupId;

        }
        #endregion Constructors
        #region Properties
        public int? StageId { get => _stageId; }
        public int? GroupId { get => _groupId; }
        #endregion Properties

        #region Behaviours
        public void SetStagesId(int? StagesId) { _stageId = StagesId.HasValue ? _stageId : StagesId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
