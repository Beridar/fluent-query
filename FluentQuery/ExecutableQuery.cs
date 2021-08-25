using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace FluentQuery
{
    public interface IExecutableQuery
    {
        IExecutableQuery ForDatabase(string databaseName);
        IExecutableQuery Query(string query);
        IExecutableQuery WithParameters(object parameters);
        public string Database { get; set; }
        bool IsExecutable();
        IQueryResults Execute();
        IExecutableQuery WithConnectionString(string connectionString);
    }

    public class ExecutableQuery : IExecutableQuery
    {
        public IExecutableQuery ForDatabase(string databaseName)
        {
            Database = databaseName;

            return this;
        }

        public IExecutableQuery Query(string query)
        {
            QueryText = query;

            return this;
        }

        public IExecutableQuery WithParameters(object parameters)
        {
            QueryParameters = parameters is IDictionary<string, object> dictionaryParameters
                ? dictionaryParameters
                : ConvertObjectToDictionary(parameters);

            return this;
        }

        private IDictionary<string, object> ConvertObjectToDictionary(object parameters)
        {
            if (parameters == null) return new Dictionary<string, object>();

            return parameters
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public)
                .ToDictionary(k => k.Name, v => v.GetValue(parameters));
        }

        public bool IsExecutable()
        {
            return Database != null
                   && QueryText != null
                   && ConnectionString != null;
        }

        public IQueryResults Execute()
        {
            if (IsExecutable() == false)
                throw new InvalidOperationException("IExecutableQuery is not in an executable state.");

            using var command = CreateOpenCommandTo(Database);

            InjectParametersInto(command);

            var databaseResults = command.ExecuteReader();
            var extractedData = new List<IDictionary<string, object>>();
            var resultSetSchema = databaseResults.GetColumnSchema();

            while (databaseResults.HasRows)
            {
                extractedData.Add(resultSetSchema.ToDictionary(column => column.ColumnName,
                    column => databaseResults[column.ColumnName]));

                databaseResults.Read();
            }

            return new QueryResults(extractedData);
        }

        private DbCommand CreateOpenCommandTo(string database)
        {
            var command = new SqlCommand();

            command.Connection = new SqlConnection(ConnectionString);
            command.Connection.Open();
            command.Connection.ChangeDatabase(database);

            return command;
        }

        private void InjectParametersInto(DbCommand connection)
        {
            foreach (var parameter in QueryParameters)
                connection.Parameters.Add(new SqlParameter
                {
                    ParameterName = parameter.Key,
                    Value = parameter.Value
                });
        }

        public string Database { get; set; }

        public IDictionary<string, object> QueryParameters { get; private set; } = new Dictionary<string, object>();

        public string QueryText { get; private set; }

        public string ConnectionString { get; private set; }

        public IExecutableQuery WithConnectionString(string connectionString)
        {
            ConnectionString = connectionString;

            return this;
        }
    }
}
