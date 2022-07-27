using Dapper;
using ProjectCRUD.Models;
using System.Data.SqlClient;

namespace ProjectCRUD.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IConfiguration _configuration;
        public EnderecoRepository(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("Data Source=localhost;Initial Catalog=project;Integrated Security=True")
                .GetSection("Default").Value;
            return connection;
        }

        public int Adicionar(EnderecoModel endereco)
        {
            int count = 0;
            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {
                con.Open();
                var query = "INSERT INTO Enderecos(Endereco, CEP, Cidade, Estado)" +
                    "VALUES(@Endereco, @CEP, @Cidade, @Estado);" +
                    "SELECT CAST(SCOPE_IDENTITY() as INT);";
                count = con.QueryFirst<int>(query, endereco);
                con.Close();

                return count;
            }
        }

        public int Atualizar(EnderecoModel endereco)
        {
            var count = 0;
            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {

                con.Open();
                var query = "UPDATE Enderecos SET Endereco = @Endereco, CEP = @Cep, Cidade = @Cidade," +
                    "Estado = @Estado WHERE Id = " + endereco.Id; 
                count = con.QueryFirst<int>(query, endereco);
                con.Close();

                return count;
            }
        }

        public int Deletar(int id)
        {

            var count = 0;

            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {
                con.Open();
                var query = "DELETE FROM Enderecos" + "WHERE Id = @Id";
                count = con.QueryFirst<int>(query);
                con.Close();

                return count;
            }

        }

        public EnderecoModel Get(int id)
        {
            EnderecoModel endereco = new EnderecoModel();

            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {
                var query = "SELECT * FROM Enderecos WHERE Id =" + id;
                endereco = con.Query<EnderecoModel>(query).FirstOrDefault();

                con.Close();

                return endereco;
            }
        }

        public List<EnderecoModel> GetEnderecos()
        {
            List<EnderecoModel> enderecos = new List<EnderecoModel>();
            using (var con = new SqlConnection("Data Source=localhost;Initial Catalog=project;Integrated Security=True"))
            {
                con.Open();
                var query = "SELECT * FROM Enderecos";
                enderecos = con.Query<EnderecoModel>(query).ToList();
                con.Close();

                return enderecos;
            }
        }
    }
}
