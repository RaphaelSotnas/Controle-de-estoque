using System;
using Xunit;
using SilviaCosmeticos.Controllers;
using Moq;
using SilviaCosmeticos.Repositories;
using System.Collections.Generic;
using SilviaCosmeticos.Models;
using Microsoft.AspNetCore.Mvc;

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
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            //Act
            var result = produtoController.UsuarioCadastro(raphael) as ViewResult;

            //Assert
            usuarioRepositoryMock.Verify(x => x.CadastrarUsuario(raphael), Times.Once);
            Assert.Equal("UsuarioSucesso", result.ViewName);
        }

        [Fact]
        public void TestandoUsurarioJaCadastrado()
        {

            //Arrange
            Usuario raphael = new Usuario();
            raphael.Nome = "Raphael";
            raphael.Senha = "RAPHAEL123";
            raphael.Email = "raphael123@hotmail.com";
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();

            usuarioRepositoryMock.Setup(x => x.BuscarUsuarioPorEmail(raphael.Email)).Returns(raphael);
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            //Act
            var result = produtoController.UsuarioCadastro(raphael) as ViewResult;

            //Assert
            Assert.Equal("/Views/Usuario/UsuarioExistente.cshtml", result.ViewName);
        }

        [Fact]
        public void TestandoBuscarUsuarioPorEmail()
        {
            //Arrange
            Usuario raphael = new Usuario();
            raphael.Nome = "Raphael";
            raphael.Senha = "RAPHAEL123";
            raphael.Email = "raphael123@hotmail.com";

            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(x => x.EntrarBuscarUsuarioPorEmail(raphael)).Returns(raphael);
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            //Act
            var result = produtoController.EntrarBuscarUsuarioPorEmail(raphael);
            //Assert
            usuarioRepositoryMock.Verify(x => x.EntrarBuscarUsuarioPorEmail(raphael), Times.Once);
        }

        [Fact]
        public void TestandoListarUsuarios()
        {
            //Arrange
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario()
            {
                Email = "lucas@test.com",
                Nome = "Lucas",
                Senha = "123"
            });

            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(x => x.ListarUsuarios()).Returns(usuarios);
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            //Act
            var result = produtoController.ListarUsuarios();

            //Assert
            usuarioRepositoryMock.Verify(x => x.ListarUsuarios(), Times.Once);
        }
        [Fact]
        public void TestandoDeletarUsuario()
        {
            //Arrange
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

            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(x => x.ListarUsuarios()).Returns(usuarios);

            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            //Act
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

        [Fact]
        public void TestandoCadastrarProduto()
        {
            //Arange
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();

            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            Produto produtox = new Produto()
            {
                Nome = "Essencial",
                Marca = "Natura",
                Tipo = "Perfume",
                Valor = 100,
                Quantidade = 10
            };
            usuarioRepositoryMock.Setup(x => x.CadastrarProduto(produtox)).Returns(produtox);

            //Act
            var result = produtoController.CadastrarProduto(produtox);

            //Assert
            usuarioRepositoryMock.Verify(x => x.CadastrarProduto(produtox), Times.Once);
        }
        [Fact]
        public void TestandoListarProduto()
        {
            //Arrange
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            List<Produto> produtos = new List<Produto>();
            produtos.Add(new Produto()
            {
                Marca = "Avon",
                Nome = "Luz",
                Tipo = "Creme",
                Quantidade = 12,
                Valor = 20
            });
            usuarioRepositoryMock.Setup(x => x.ListarProdutos()).Returns(produtos);

            //Act
            var result = produtoController.ListarProdutos();

            //Assert
            usuarioRepositoryMock.Verify(x => x.ListarProdutos(), Times.Once);
        }

        [Fact]
        public void TestandoDeletarProdutos()
        {
            //Arrange
            List<Produto> produtos = new List<Produto>();

            Produto produto1 = new Produto();
            produto1.Nome = "bebe";
            produto1.Marca = "Natura";
            produto1.Tipo = "Perfume";
            produto1.Valor = 100;
            produto1.Quantidade = 20;
            produtos.Add(produto1);

            Produto produto2 = new Produto();
            produto1.Nome = "Homem";
            produto1.Marca = "Natura";
            produto1.Tipo = "Óleo";
            produto1.Valor = 190;
            produto1.Quantidade = 10;
            produtos.Add(produto2);

            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            usuarioRepositoryMock.Setup(x => x.ListarProdutos()).Returns(produtos);

            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            //Act
            produtoController.DeletarProduto(produto1.Id);

            //Assert
            usuarioRepositoryMock.Verify(x => x.DeletarProduto(produto1.Id));
            usuarioRepositoryMock.Verify(x => x.DeletarProduto(produto2.Id));
        }

        [Fact]
        public void TestandoEditarProduto()
        {
            //Arrange
            Mock<IUsuarioRepository> usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            ProdutoController produtoController = new ProdutoController(usuarioRepositoryMock.Object);

            Produto produto = new Produto();
            produto.Marca = "Boticário";
            produto.Nome = "Ergo";
            produto.Tipo = "Perfume";
            produto.Valor = 100;
            produto.Quantidade = 20;

            //Act
            produtoController.EditarProduto(produto);

            //Assert
            usuarioRepositoryMock.Verify(x => x.EditarProduto(produto), Times.Once);
        }

    }

}
                         