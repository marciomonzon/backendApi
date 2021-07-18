using Api.Models;
using Api.Models.DTO;
using Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected ResponseDto _response;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDto();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDto user)
        {
            var respuesta = await _userRepository.Register(
                new User
                {
                    UserName = user.UserName
                },
                user.Password);

            if (respuesta == -1)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario ya existe";
                return BadRequest(_response);
            }

            if (respuesta == -500)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el usuario";
                return BadRequest(_response);
            }

            _response.DisplayMessage = "Usuario creado con exito";
            _response.Result = respuesta;
            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDto user)
        {
            var respuesta = await _userRepository.Login(user.UserName, user.Password);

            if (respuesta == "nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no existe";
                return BadRequest(_response);
            }
            if (respuesta == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Password incorrecta";
                return BadRequest(_response);
            }

            return Ok("Usuario conectado");
        }
    }
}
