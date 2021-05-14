using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class LogEvent : DOBase
    {
        #region Fields
        private int? _userId;
        private string _event;
        private string _action;
        private int? _ownerById;
        private string _ownerByTable;
        private int? _functionId;
        private string _message;
        #endregion Fields

        #region Constructors

        private LogEvent()
        {
        }

        public LogEvent(int? UserId,
                        string Event,
                        string Action,
                        int? OwnerById,
                        string OwnerByTable,
                        int? FunctionId,
                        string Message) : this()
        {
            _userId = UserId;
            _event = Event;
            _action = Action;
            _ownerById = OwnerById;
            _ownerByTable = OwnerByTable;
            _functionId = FunctionId;
            _message = Message;
        }
        #endregion Constructors

        #region Properties
        public int? UserId { get => _userId; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Event { get => _event; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Action { get => _action; }
        public int? OwnerById { get => _ownerById; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string OwnerByTable { get => _ownerByTable; }
        public int? FunctionId { get => _functionId; }
        public string Message { get => _message; }
        #endregion Properties

        #region Behaviours
        public void SetUserId(int? UserId) { _userId = !UserId.HasValue ? _userId : UserId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEvent(string Event) { _event = Event == null ? _event : Event; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetAction(string Action) { _action = Action == null ? _action : Action; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetOwnerById(int? OwnerById) { _ownerById = !OwnerById.HasValue ? _ownerById : OwnerById; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetOwnerByTable(string OwnerByTable) { _ownerByTable = OwnerByTable == null ? _ownerByTable : OwnerByTable; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetFunctionId(int? FunctionId) { _functionId = !FunctionId.HasValue ? _functionId : FunctionId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetMessage(string Message) { _message = Message == null ? _message : Message; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
