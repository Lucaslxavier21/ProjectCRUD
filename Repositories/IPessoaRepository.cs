using ProjectCRUD.Models;

namespace ProjectCRUD.Repositories
{
    public interface IPessoaRepository
    {
        PessoaModel Get(int id);
        List<PessoaModel> GetPessoas();
        int Adicionar(PessoaModel pessoa);
        int Atualizar(PessoaModel pessoa);
        int Deletar(int id);
        
    }
}
