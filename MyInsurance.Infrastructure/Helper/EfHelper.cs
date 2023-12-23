using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MyInsurance.Infrastructure.Helper
{
    public static class ExceptionExtensions
    {
        public static EfError? GetEfError(this Exception ex)
        {
            if (ex.InnerException is SqlException sqlEx)
            {
                return (EfError)sqlEx.Number;
            }
            return null;
        }
    }

    public enum EfError
    { 
        DuplicateRecord = 2601
    }
}
