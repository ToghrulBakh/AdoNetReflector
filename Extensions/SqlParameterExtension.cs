using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetReflector.Extensions
{
    public static partial class Extension
    {

        public static List<SqlParameter> InitSqlParams()    

        {
            return new List<SqlParameter>();
        }

        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, DataTable value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Structured) { Value = value, Direction = direction });
            return parameters;
        }


        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, int value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Int) { Value = value, Direction = direction });
            return parameters;
        }


        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, int? value, ParameterDirection direction = ParameterDirection.Input)
        {

            if (value.HasValue)
            {
                parameters.Add(parameterName, value.Value, direction);
            }
            return parameters;
        }



        static public List<SqlParameter> AddRetval(this List<SqlParameter> parameters, string parameterName, ParameterDirection direction = ParameterDirection.ReturnValue)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Int) { Direction = direction });
            return parameters;
        }




        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, DateTime value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.DateTime) { Value = value, Direction = direction });
            return parameters;
        }

        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, DateTime? value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (value.HasValue)
            {
                parameters.Add(parameterName, value.Value, direction);
            }
            return parameters;
        }



        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, string value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (!string.IsNullOrEmpty(value))
            {
                parameters.Add(new SqlParameter(parameterName, SqlDbType.NVarChar, int.MaxValue) { Value = value, Direction = direction });
            }

            return parameters;
        }


        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, long value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.BigInt) { Value = value, Direction = direction });
            return parameters;
        }
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, long? value, ParameterDirection direction = ParameterDirection.Input)
        {

            if (value.HasValue)
            {
                parameters.Add(parameterName, value, direction);
            }
            return parameters;
        }



        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, float value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.BigInt) { Value = value, Direction = direction });
            return parameters;
        }
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, float? value, ParameterDirection direction = ParameterDirection.Input)
        {

            if (value.HasValue)
            {
                parameters.Add(parameterName, value, direction);
            }
            return parameters;
        }



        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, double value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Float) { Value = value, Direction = direction });
            return parameters;
        }
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, double? value, ParameterDirection direction = ParameterDirection.Input)
        {

            if (value.HasValue)
            {
                parameters.Add(parameterName, value, direction);
            }
            return parameters;
        }






        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, decimal value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Decimal) { Value = value, Direction = direction });
            return parameters;
        }
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, decimal? value, ParameterDirection direction = ParameterDirection.Input)
        {

            if (value.HasValue)
            {
                parameters.Add(parameterName, value, direction);
            }
            return parameters;
        }




        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, bool value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Bit) { Value = value, Direction = direction });
            return parameters;
        }
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, bool? value, ParameterDirection direction = ParameterDirection.Input)
        {

            if (value.HasValue)
            {
                parameters.Add(parameterName, value.Value, direction);
            }
            return parameters;
        }
    }
}
