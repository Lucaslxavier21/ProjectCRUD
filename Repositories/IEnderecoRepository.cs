using ProjectCRUD.Models;

namespace ProjectCRUD.Repositories
{
    public interface IEnderecoRepository
    {
        EnderecoModel Get(int id);
        List<EnderecoModel> GetEnderecos();
        int Adicionar(EnderecoModel endereco);
        int Atualizar(EnderecoModel endereco);
        int Deletar(int id);

    }
}
