using System.Data.Common;

namespace Services.Common.APIs.Cmd.EF.IRepository
{
    public interface ISprocRepository
    {
        DbCommand GetStoredProcedure(string name, params (string, object)[] nameValueParams);
        DbCommand GetStoredProcedure(string name);
    }
}
