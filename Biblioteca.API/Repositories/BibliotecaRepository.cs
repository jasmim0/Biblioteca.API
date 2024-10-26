using Biblioteca.API.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto.Generators;
using System.Data;

namespace Biblioteca.API.Repositories
{
    public class BibliotecaRepository
    {
        private readonly string _connectionString;

        public BibliotecaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private IDbConnection Connection =>
            new MySqlConnection(_connectionString);


        public async Task<IEnumerable<Livros>> ListarTodosLivros(bool? ativo = null)
        {
            var sql = "SELECT * FROM Livros";

            using (var conn = Connection)

                if (ativo.HasValue)
                {
                    sql += " WHERE Ativo = @Ativo";
                    return await conn.QueryAsync<Livros>(sql, new { Ativo = ativo });
                }
                else
                {
                    sql += " ORDER BY Nome ASC";
                    return await conn.QueryAsync<Livros>(sql);
                }
        }

        public async Task<Livros> emprestimolivro(int livros)
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM  Livros liv" +
                    " WHERE liv.Disponivel = 1 and liv.id =1";
                return await conn.QueryAsync<Livros>(sql);
            }
        }



        public async Task<Livros> ValidaExistslivros(int Id)
        {
            using (var conn = Connection)
            {

                var sql = "SELECT * FROM  Livros Liv WHERE Liv.id = @Id";
                return await conn.QueryFirstOrDefaultAsync<Livros>(sql, new { Id = Id });
            }
        }

        public async Task<int> ExcluirPorId(int id)
        {
            var sql = "DELETE FROM Livros WHERE Id = @Id";

            using (var conn = Connection)
            {
                return await conn.ExecuteAsync(sql, new { Id = id });
            }
        }

    }
