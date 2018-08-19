using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pos.Arquitetura.Docker.Conversor.API.Models;

namespace Pos.Arquitetura.Docker.Conversor.API.Controllers
{
    /// <summary>
    /// Conversor de Temperaturas
    /// </summary>
    [Route("api/[controller]")]
    public class TemperaturaController : ControllerBase
    {
        /// <summary>
        /// Tranforma temperatura Fahrenheit para Celsius e Kelvin.
        /// </summary>
        /// <param name="temperatura">Temperatura em Fahrenheit</param>
        /// <returns>Retorna objeto com temperatura em Celsius e Kelvin</returns>
        [HttpGet("Fahrenheit/{temperatura}")]
        public Temperatura GetTemperaturasFromFahrenheit(double temperatura)
        {
            var dados = new Temperatura();

            dados.ValorFahrenheit = temperatura;
            dados.ValorCelsius = Math.Round((temperatura - 32.0) / 1.8, 2);
            dados.ValorKelvin = Math.Round(dados.ValorCelsius + 273.15, 2);

            return dados;
        }

        /// <summary>
        /// Tranforma temperatura Celsius para Fahrenheit e Kelvin.
        /// </summary>
        /// <param name="temperatura">Temperatura em Celsius</param>
        /// <returns>Retorna objeto com temperatura em Fahrenheit e Kelvin</returns>
        [HttpGet("Celsius/{temperatura}")]
        public Temperatura GetTemperaturasFromCelsius(double temperatura)
        {
            var dados = new Temperatura();

            dados.ValorFahrenheit = Math.Round((1.8 * temperatura) + 32, 2);
            dados.ValorCelsius = temperatura; 
            dados.ValorKelvin = Math.Round(dados.ValorCelsius + 273.15, 2);

            return dados;
        }
    }
}
