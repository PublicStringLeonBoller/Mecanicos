using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comandos;
using MecanicoApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resultados;

namespace MecanicoApi.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]

    public class MecanicoController : ControllerBase
    {
        private readonly mecanicoApiContext db = new mecanicoApiContext();
        private readonly ILogger<MecanicoController> _logger;

        public MecanicoController(ILogger<MecanicoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Mecanico/TraerMecanico")]
        public ActionResult<ResultadoApi> Get()
        {    
            var resultado = new ResultadoApi();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.Mecanicos.ToList();
                return resultado;
            }
            catch (Exception e)
            {
                resultado.Ok = false;
                resultado.Return = "Error al cargar los Mecanicos..." + e.ToString();
                return resultado;
                
            }
        }

        //  ----------------- Cargar combo especialidades

        [HttpGet]
        [Route("Especialidades/TraerEspecialidades")]
        
        public ActionResult<ResultadoApi> GetEspecialidades()
        {    
            var resultado = new ResultadoApi();
            try
            {
                
                resultado.Ok = true;
                resultado.Return = db.Especialidades.ToList();
                return resultado;
            }
            catch (Exception e)
            {
                resultado.Ok = false;
                resultado.Return = "Error al cargar Especialidades..." + e.ToString();
                return resultado;
                
            }
        }

        // -------------------- cargar combo zonas

        [HttpGet]
        [Route("Zonas/TraerZonas")]
        
        public ActionResult<ResultadoApi> GetZonas()
        {    
            var resultado = new ResultadoApi();
            try
            {
                
                resultado.Ok = true;
                resultado.Return = db.Zonas.ToList();
                return resultado;
            }
            catch (Exception e)
            {
                resultado.Ok = false;
                resultado.Return = "Error al cargar Zonas..." + e.ToString();
                return resultado;
                
            }
        }

        // -------------------- Registrar Mecanico

        [HttpPost]
        [Route("Mecanico/RegistrarMecanico")]
        public ActionResult<ResultadoApi> RegistrarMecanico([FromBody]ComandoCrearMecanico comando)
        {
            var resultado = new ResultadoApi();

            if(comando.Nombre.Equals(""))
            {
                resultado.Ok = false;
                resultado.CodigoError = 1;
                resultado.Error = "Ingrese nombre";
                return resultado;
            }

            if(comando.Apellido.Equals(""))
            {
                resultado.Ok = false;
                resultado.CodigoError = 2;
                resultado.Error = "Ingrese apellido";
                return resultado;
            }

            var mec = new Mecanico();

            try
            {
                mec.Nombre = comando.Nombre;
                mec.Apellido = comando.Apellido;
                mec.SexoId = comando.SexoId;
                mec.EspecialidadId = comando.EspecialidadId;
                mec.FechaNacimiento = comando.FechaNacimiento;
                mec.ZonaId = comando.ZonaId;
                mec.Soltero = comando.Soltero;

                db.Mecanicos.Add(mec);
                db.SaveChanges();

                resultado.Ok = true;
                resultado.Return = db.Mecanicos.ToList();

                return resultado;
                
            }catch (Exception e){

                resultado.Ok = false;
                resultado.Return = "Error al cargar Mecanicos..." + e.ToString();
                return resultado;
                
            }
        }

        // ----------------------- Update Mecanico

        [HttpPut]
        [Route("Mecanico/UpdateMecanico")]
        public ActionResult<ResultadoApi> UpdateMecanico([FromBody]ComandoUpdateMecanico comando)
        {
            var resultado = new ResultadoApi();

            
            if(comando.Nombre.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese nombre";
                return resultado;
            }

            if(comando.Apellido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese apellido";
                return resultado;
            }

            var meca = db.Mecanicos.Where(c =>c.MecanicoId == comando.MecanicoId).FirstOrDefault();
            try
            {
                if(meca != null)
                {
                    meca.MecanicoId = comando.MecanicoId;
                    meca.Nombre = comando.Nombre;
                    meca.Apellido = comando.Apellido;
                    meca.EspecialidadId = comando.EspecialidadId;
                    meca.ZonaId = comando.ZonaId;
                    meca.Soltero = comando.Soltero;
                
                    db.SaveChanges();
                }

                resultado.Ok = true;
                resultado.Return = db.Mecanicos.ToList();;

                return resultado;

            }catch (Exception e){

                resultado.Ok = false;
                resultado.Return = "Error al cargar mecanicos..." + e.ToString();
                return resultado;
                
            }
        }















    }
}
