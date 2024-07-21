using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Communication.Requests;
using MyFirstApi.Communication.Responses;

namespace MyFirstApi.Controllers;

// Neste caso, o endereço ficaria 
// h ttps://localhost:7144/api (opicional)/[nome dado para a classe sem o controller]
// [Route("api/[controller]")]

// Indica que é uma classe especia, ou seja, um controler para API (Obrigatório).
// [ApiController]
public class UserController : MyFirstApiBaseController
{
    // Criando um EndPoint do tipo GET
    [HttpGet]

    // Passando parâmetros pela ROTA
    [Route("{id}")]

    // Tratando a resposta
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    // [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult GetUserById([FromRoute]int id)
    {
        var response = new User
        {
            Id = 1,
            Age = 7,
            Name = "Gabriel"
        };

        return Ok(response);
    }

    // Criando um EndPoint do tipo POST
    [HttpPost]

    [ProducesResponseType(typeof(ResponseRegisterUserJSON), StatusCodes.Status201Created)]
    public IActionResult CreateUser([FromBody] RequestRegisterUserJSON request)
    {
        var response = new ResponseRegisterUserJSON
        {
            Id = 1,
            Name = request.Name,
        };

        return Created(string.Empty, response);
    }

    // Criando um EndPoint do tipo PUT
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public IActionResult UpdateUser([FromBody] RequestUpdateUserProfileJSON request)
    {
        return NoContent();
    }

    // Criando um EndPoint do tipo DELETE
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public IActionResult DeleteUser() 
    {
        return NoContent();
    }

    // ---------------------------------------------------------------------------------------------
    
    // Criando um novo EndPoint do tipo GET para devolver TODOS OS USUÁRIOS
    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public IActionResult GetAllUsers()
    {
        var response = new List<User>()
        {
            new User { Id = 1, Age = 7, Name = "Gabriel" },
            new User { Id = 2, Age = 7, Name = "Larissa" }
        };

        var key = GetCustomKey();

        return Ok(key);
    }

    // Criando um novo EndPoint do tipo PUT para alterar a SENHA
    // "change-password" -> Nome para ser adicionado ao final da Rota para evitar colisão de métodos de requisição.
    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public IActionResult ChangeUserPassword([FromBody] RequestChangeUserPasswordJSON request)
    {
        return NoContent();
    }
}
