using System;
using Xunit;
using SilviaCosmeticos.Controllers;
using Moq;
using SilviaCosmeticos.Repositories;
using System.Collections.Generic;
using SilviaCosmeticos.Models;

namespace SilviaCosmeticos.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestandoUsurarioCadastro()
        {
            Usuario raphael = new Usuario();
            raphael.Nome = "Raphael";
            raphael.Senha = "RAPHAEL123";
            raphael.Email = "raphael123@hotmail.com";


            //Arrange
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(x => x.CadastrarUsuario(raphael));
            //Act
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);
            var result = produtoController.UsuarioCadastro(raphael);
            //Assert
            usuarioRepositoryMock.Verify(x => x.CadastrarUsuario(raphael), Times.Once);
        }
        [Fact]
        public void TestandoBuscarUsuarioPorId()
        {
            Usuario raphael = new Usuario();
            raphael.Nome = "Raphael";
            raphael.Senha = "RAPHAEL123";
            raphael.Email = "raphael123@hotmail.com";

            //Arrange
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(x => x.EntrarBuscarUsuarioPorId(raphael));
            //Act
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);
            var result = produtoController.EntrarBuscarUsuarioPorId(raphael);
            //Assert
            usuarioRepositoryMock.Verify(x => x.EntrarBuscarUsuarioPorId(raphael), Times.AtLeastOnce);
        }

        [Fact]
        public void TestandoListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario()
            {
                Email = "lucas@test.com",
                Nome = "Lucas",
                Senha = "123"
            });
            //Arrange
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(x => x.ListarUsuarios()).Returns(usuarios);
            //Act
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);
            var result = produtoController.ListarUsuarios();

            //Assert
            usuarioRepositoryMock.Verify(x => x.ListarUsuarios(), Times.Once);
        }
        [Fact]
        public void TestandoDeletarUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario2 = new Usuario();
            usuario2.Nome = "usuario2";
            usuario2.Email = "usuario2@hotmail.com";
            usuario2.Senha = "usuario2";

            usuarios.Add(usuario2);

            Usuario usuario1 = new Usuario();
            usuario1.Nome = "usuario1";
            usuario1.Email = "usuario1@hotmail.com";
            usuario1.Senha = "usuario1";

            usuarios.Add(usuario1);

            //Arrange
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(x => x.ListarUsuarios()).Returns(usuarios);
            //Act
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);
            var result = produtoController.DeletarUsuario(usuario1.Id);

            //Assert
            usuarioRepositoryMock.Verify(x => x.DeletarUsuario(usuario1.Id), Times.Once);
            usuarioRepositoryMock.Verify(x => x.DeletarUsuario(usuario2.Id));
        }
    
        [Fact]
        public void TestandoEditarUsuario()
        {
            //Arrange
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();

            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);
           
            Usuario usuarioy = new Usuario()
            {
                Email = "usuarioxEditado@hotmail.com",
                Nome = "usuarioxEditado",
                Senha = "usuarioxEditado123",
                Id = 1
            };

            //Act
            produtoController.EditarUsuario(usuarioy);

            //Assert
            usuarioRepositoryMock.Verify(x => x.EditarUsuario(usuarioy), Times.Once);


        }
    }
}
                         