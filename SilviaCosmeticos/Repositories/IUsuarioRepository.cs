using SilviaCosmeticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilviaCosmeticos.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarUsuarios();

        Usuario EntrarBuscarUsuarioPorId(Usuario usuario);

        Usuario BuscarUsuarioPorEmail(string email);

        Usuario CadastrarUsuario(Usuario usuario);

        Usuario DeletarUsuario(int id);

        Usuario ChamarEditarUsuario(int id);

        Usuario EditarUsuario(Usuario usuario);

        Produto CadastrarProduto(Produto produto);

        List<Produto> ListarProdutos();

        Produto DeletarProduto(int id);

        Produto ChamarEditarProduto(int id);

        Produto EditarProduto(Produto produto);
    }
}
