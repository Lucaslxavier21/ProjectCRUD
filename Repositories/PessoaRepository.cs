using Dapper;
using ProjectCRUD.Models;
using System.Data;
using System.Data.SqlClient;


namespace ProjectCRUD.Repositories
{
    public class PessoaRepository : IPessoaRepository 
    {
        private readonly IConfiguration _configuration;
        public PessoaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("Data Source=localhost;Initial Catalog=project;Integrated Security=True")
                .GetSection("Default").Value;
            return connection;
        }

        public int Adicionar(PessoaModel pessoa)
        {
            int count = 0;
            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {
                    con.Open();
                    var query = "INSERT INTO pessoas(Nome, Telefone, CPF)" +
                        "VALUES(@Nome, @Telefone, @CPF);" +
                        "SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.QueryFirst<int>(query, pessoa);
                    con.Close();
               
                return count;
            }
        }
        public int Deletar(int id)
        {
            int count = 0;

            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {   
                    con.Open();
                    var query = "DELETE FROM pessoas WHERE Id =" + id;
                count = con.QueryFirst<int>(query);
                    con.Close();
                
                return count;
            }
                
        }

        public int Atualizar(PessoaModel pessoa)
        {
            int count = 0;
            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {
                    con.Open();
                    var query = "UPDATE pessoas SET Nome = @Nome, Telefone = @Telefone, CPF = @CPF WHERE Id = " + pessoa.Id;
                    count = con.ExecuteScalar<int>(query, pessoa); 
                    con.Close(); 
                
                return count; 
            } 
        }


        public PessoaModel Get(int id)
        {
            PessoaModel pessoa = new PessoaModel();

            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {
                    var query = "SELECT * FROM Pessoas WHERE Id =" + id;
                    pessoa = con.Query<PessoaModel>(query).FirstOrDefault();
                
                    con.Close();
                
                return pessoa;
            }
        }
        public List<PessoaModel> GetPessoas()
        {
            List<PessoaModel> pessoa = new List<PessoaModel>();
            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            { 
                    con.Open();
                    var query = "SELECT * FROM Pessoas";
                    pessoa = con.Query<PessoaModel>(query).ToList();
                    con.Close();
               
                return pessoa; 
            } 
        }

    }
}
