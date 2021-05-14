using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace Acc.Cmd.Domain.DomainObjects
{
    public class GroupStepProcessPermistion : DOBase
    {
        #region Fields
        private int? _groupId;
        private int? _stepProcessId;
        private int? _permistion;
        #endregion Fields
        #region Constructors

        private GroupStepProcessPermistion()
        {
        }

        public GroupStepProcessPermistion(int? GroupId,
                                            int? StepProcessId,
                                            int? Permistion) : this()
        {
            _groupId = GroupId;
            _stepProcessId = StepProcessId;
            _permistion = Permistion;
        }
        #endregion Constructors
        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? GroupId { get => _groupId; }
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? StepProcessId { get => _stepProcessId; }
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? Permistion { get => _permistion; }
        #endregion Properties

        #region Behaviours
        public void SetGroupId(int? GroupId) { _groupId = !GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStepProcessId(int? StepProcessId) { _stepProcessId = !StepProcessId.HasValue ? _stepProcessId : StepProcessId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPermistion(int? Permistion) { _permistion = !Permistion.HasValue ? _permistion : Permistion; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
