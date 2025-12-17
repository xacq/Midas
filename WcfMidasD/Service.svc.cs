using ClnMidasD;
using CadMidasD;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Data;

namespace WcfMidasD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    [AutomapServiceBehavior]
    public class Service : IService
    {
        #region Cargo
        public int cargoInsertar(Header header, Cargo cargo)
        {
            return CargoCln.insertar(header, Mapper.Map<Cargo, CadMidasD.Cargo>(cargo));
        }

        public int cargoEditar(Header header, Cargo cargo)
        {
            return CargoCln.editar(header, Mapper.Map<Cargo, CadMidasD.Cargo>(cargo));
        }

        public int cargoEliminar(Header header, int idCargo)
        {
            return CargoCln.eliminar(header, idCargo);
        }

        public List<Cargo> cargoListar(Header header)
        {
            var cargo = CargoCln.listar(header);
            return Mapper.Map<List<CadMidasD.Cargo>, List<Cargo>>(cargo);
        }

        public List<paListaCargoOficina_Result> cargoListarOficina(Header header,int idOficina,int gestion)
        {
            return CargoCln.listarOficinaCargos(header, idOficina,gestion);
        }

        public List<paListaCargoOficinaAdmin_Result> cargoListarOficinaAdmin(Header header, int idOficina, int gestion)
        {
            return CargoCln.listarOficinaCargosAdmin(header, idOficina, gestion);
        }

        public Cargo cargoGet(Header header, int idCargo)
        {
            var cargo = CargoCln.get(header, idCargo);
            return Mapper.Map<CadMidasD.Cargo, Cargo>(cargo);
        }
        #endregion

        #region CargoOficina
        public int cargoOficinaInsertar(Header header, CargoOficina cargoOficina)
        {
            return CargoOficinaCln.insertar(header, Mapper.Map<CargoOficina, CadMidasD.CargoOficina>(cargoOficina));
        }

        public int cargoOficinaEditar(Header header, CargoOficina cargoOficina)
        {
            return CargoOficinaCln.editar(header, Mapper.Map<CargoOficina, CadMidasD.CargoOficina>(cargoOficina));
        }

        public int cargoOficinaEliminar(Header header, int idCargoOficina)
        {
            return CargoOficinaCln.eliminar(header, idCargoOficina);
        }

        public List<CargoOficina> cargoOficinaListar(Header header)
        {
            var cargoOficina = CargoOficinaCln.listar(header);
            return Mapper.Map<List<CadMidasD.CargoOficina>, List<CargoOficina>>(cargoOficina);
        }

        public CargoOficina cargoOficinaGet(Header header, int idCargoOficina)
        {
            var cargoOficina = CargoOficinaCln.get(header, idCargoOficina);
            return Mapper.Map<CadMidasD.CargoOficina, CargoOficina>(cargoOficina);
        }
        #endregion

        #region Descuento
        public int descuentoInsertar(Header header, Descuento descuento)
        {
            return DescuentoCln.insertar(header, Mapper.Map<Descuento, CadMidasD.Descuento>(descuento));
        }

        public int descuentoEditar(Header header, Descuento descuento)
        {
            return DescuentoCln.editar(header, Mapper.Map<Descuento, CadMidasD.Descuento>(descuento));
        }

        public int descuentoEliminar(Header header, int idDescuento)
        {
            return DescuentoCln.eliminar(header, idDescuento);
        }

        public List<Descuento> descuentoListar(Header header)
        {
            var descuento = DescuentoCln.listar(header);
            return Mapper.Map<List<CadMidasD.Descuento>, List<Descuento>>(descuento);
        }

        public Descuento descuentoGetIdFianzaReclasificacion(Header header, int idFianza)
        {
            var descuento = DescuentoCln.getIdFianzaReclasificacion(header, idFianza);
            return Mapper.Map<CadMidasD.Descuento, Descuento>(descuento);
        }

        public Descuento descuentoGet(Header header, int idDescuento)
        {
            var descuento = DescuentoCln.get(header, idDescuento);
            return Mapper.Map<CadMidasD.Descuento, Descuento>(descuento);
        }

        public int descuentoEliminarfisico(Header header, int idFianza,int mes , int anio)
        {
            return DescuentoCln.eliminarfisico(header, idFianza, mes, anio);
        }

        public int descuentoEliminarfisicoEditar(Header header, int idFianza)
        {
            return DescuentoCln.eliminarfisicoEditar(header, idFianza);
        }

        public Descuento descuentoVerificarMesRegistrado(Header header, int idfianza, int mes, int anio)
        {
            var descuento = DescuentoCln.verificarFianzaDescuentoMesRegistrado(header, idfianza,mes,anio);
            return Mapper.Map<CadMidasD.Descuento, Descuento>(descuento);
        }

        #endregion

        #region Devolucion
        public int devolucionInsertar(Header header, Devolucion devolucion)
        {
            return DevolucionCln.insertar(header, Mapper.Map<Devolucion, CadMidasD.Devolucion>(devolucion));
        }

        public int devolucionEditar(Header header, Devolucion devolucion)
        {
            return DevolucionCln.editar(header, Mapper.Map<Devolucion, CadMidasD.Devolucion>(devolucion));
        }

        public int devolucionEliminar(Header header, int idDevolucion)
        {
            return DevolucionCln.eliminar(header, idDevolucion);
        }

        public List<Devolucion> devolucionListar(Header header)
        {
            var devolucion = DevolucionCln.listar(header);
            return Mapper.Map<List<CadMidasD.Devolucion>, List<Devolucion>>(devolucion);
        }

        public Devolucion devolucionGet(Header header, int idDevolucion)
        {
            var devolucion = DevolucionCln.get(header, idDevolucion);
            return Mapper.Map<CadMidasD.Devolucion, Devolucion>(devolucion);
        }

        public Devolucion devolucionGetidFianza(Header header, int idFianza)
        {
            var devolucion = DevolucionCln.getidFianza(header, idFianza);
            return Mapper.Map<CadMidasD.Devolucion, Devolucion>(devolucion);
        }

        public List<paListarFuncionariosFianzaDevolucionContabilidadReporte_Result> paListarFuncionariosFianzaDevolucionContabilidadReporte(Header header, DateTime fecha1, DateTime fecha2)
        {
            return DevolucionCln.paListarFuncionariosFianzaDevolucionContabilidadReporte(header, fecha1, fecha2);
        }
        #endregion

        #region DireccionAdministrativa
        public int direccionAdministrativaInsertar(Header header, DireccionAdministrativa direccionAdministrativa)
        {
            return DireccionAdministrativaCln.insertar(header, Mapper.Map<DireccionAdministrativa, CadMidasD.DireccionAdministrativa>(direccionAdministrativa));
        }

        public int direccionAdministrativaEditar(Header header, DireccionAdministrativa direccionAdministrativa)
        {
            return DireccionAdministrativaCln.editar(header, Mapper.Map<DireccionAdministrativa, CadMidasD.DireccionAdministrativa>(direccionAdministrativa));
        }

        public int direccionAdministrativaEliminar(Header header, int idDireccionAdministrativa)
        {
            return DireccionAdministrativaCln.eliminar(header, idDireccionAdministrativa);
        }

        public List<DireccionAdministrativa> direccionAdministrativaListar(Header header)
        {
            var direccionAdministrativa = DireccionAdministrativaCln.listar(header);
            return Mapper.Map<List<CadMidasD.DireccionAdministrativa>, List<DireccionAdministrativa>>(direccionAdministrativa);
        }

        public DireccionAdministrativa direccionAdministrativaGet(Header header, int idDireccionAdministrativa)
        {
            var direccionAdministrativa = DireccionAdministrativaCln.get(header, idDireccionAdministrativa);
            return Mapper.Map<CadMidasD.DireccionAdministrativa, DireccionAdministrativa>(direccionAdministrativa);
        }
        #endregion

        #region Encargados
        public int encargadosInsertar(Header header, Encargados encargados)
        {
            return EncargadosCln.insertar(header, Mapper.Map<Encargados, CadMidasD.Encargados>(encargados));
        }

        public int encargadosEditar(Header header, Encargados encargados)
        {
            return EncargadosCln.editar(header, Mapper.Map<Encargados, CadMidasD.Encargados>(encargados));
        }

        public int encargadosEliminar(Header header, int idEncargado)
        {
            return EncargadosCln.eliminar(header, idEncargado);
        }

        public List<Encargados> encargadosListar(Header header)
        {
            var encargados = EncargadosCln.listar(header);
            return Mapper.Map<List<CadMidasD.Encargados>, List<Encargados>>(encargados);
        }

        public Encargados encargadosGet(Header header, int idEncargado)
        {
            var encargados = EncargadosCln.get(header, idEncargado);
            return Mapper.Map<CadMidasD.Encargados, Encargados>(encargados);
        }

        public Encargados encargadosGetIdEncargado(Header header, int idCargo)
        {
            var encargados = EncargadosCln.getIdEncargadoFinanciero(header, idCargo);
            return Mapper.Map<CadMidasD.Encargados, Encargados>(encargados);
        }
        #endregion

        #region EscalaSalarial
        public int escalaSalarialInsertar(Header header, EscalaSalarial escalaSalarial)
        {
            return EscalaSalarialCln.insertar(header, Mapper.Map<EscalaSalarial, CadMidasD.EscalaSalarial>(escalaSalarial));
        }

        public int escalaSalarialEditar(Header header, EscalaSalarial escalaSalarial)
        {
            return EscalaSalarialCln.editar(header, Mapper.Map<EscalaSalarial, CadMidasD.EscalaSalarial>(escalaSalarial));
        }

        public int escalaSalarialEliminar(Header header, int idEscalaSalarial)
        {
            return EscalaSalarialCln.eliminar(header, idEscalaSalarial);
        }

        public List<EscalaSalarial> escalaSalarialListar(Header header)
        {
            var escalaSalarial = EscalaSalarialCln.listar(header);
            return Mapper.Map<List<CadMidasD.EscalaSalarial>, List<EscalaSalarial>>(escalaSalarial);
        }

        public EscalaSalarial escalaSalarialGet(Header header, int idEscalaSalarial)
        {
            var escalaSalarial = EscalaSalarialCln.get(header, idEscalaSalarial);
            return Mapper.Map<CadMidasD.EscalaSalarial, EscalaSalarial>(escalaSalarial);
        }

        public EscalaSalarial escalaSalarialId(Header header, int idSueldoMensual)
        {
            var escalaSalarial = EscalaSalarialCln.idEscalaSalarial(header, idSueldoMensual);
            return Mapper.Map<CadMidasD.EscalaSalarial, EscalaSalarial>(escalaSalarial);
        }

        public List<paEscalaSalarialGestion_Result> paEscalaSalarialGestion(Header header,int gestion)
        {
            return EscalaSalarialCln.paEscalaSalarialGestion(header,gestion);

        }

        public int escalaSalariallActivar(Header header, int idEscalaSalarial)
        {
            return EscalaSalarialCln.activar(header, idEscalaSalarial);
        }
        #endregion

        #region Fianza
        public int fianzaInsertar(Header header, Fianza fianza)
        {
            return FianzaCln.insertar(header, Mapper.Map<Fianza, CadMidasD.Fianza>(fianza));
        }

        public int fianzaEditar(Header header, Fianza fianza)
        {
            return FianzaCln.editar(header, Mapper.Map<Fianza, CadMidasD.Fianza>(fianza));
        }

        public int ultimoNumeroFianza(Header header)
        {
            return FianzaCln.ultimoNumeroFianza(header);
        }

        public int ultimoNumeroFianzaBienesGravados(Header header)
        {
            return FianzaCln.ultimoNumeroFianzaBienesGravados(header);
        }

        public int fianzaEliminar(Header header, int idFianza)
        {
            return FianzaCln.eliminar(header, idFianza);
        }

        public List<Fianza> fianzaListar(Header header)
        {
            var fianza = FianzaCln.listar(header);
            return Mapper.Map<List<CadMidasD.Fianza>, List<Fianza>>(fianza);
        }

        public List<paListarFuncionariosFianzaRRHH_Result> pafianzaListarFuncionariosBuscarRRHH(Header header, string letra,string usuario)
        {
            return FianzaCln.palistarFuncionariosFianzaBuscarRRHH(header, letra,usuario);
        }

        public List<paListarFuncionariosFianzaConResolucion_Result> paListarFuncionariosFianzaConResolucion(Header header, string letra,string usuario)
        {
            return FianzaCln.paListarFuncionariosFianzaConResolucion(header, letra, usuario);
        }

        public List<paListarFuncionariosFianzaConResolucionBienesGravados_Result> paListarFuncionariosFianzaConResolucionBienesGravados(Header header, string letra, string usuario)
        {
            return FianzaCln.paListarFuncionariosFianzaConResolucionBienesGravados(header, letra, usuario);
        }
        public List<paListarFuncionariosFianzaDevolucion_Result> pafianzaListarFuncionariosBuscarDevolucion(Header header, string letra)
        {
            return FianzaCln.palistarFuncionariosFianzaBuscarDevolucion(header, letra);
        }

        public List<paListarFuncionariosFianzaDevolucionContabilidad_Result> pafianzaListarFuncionariosBuscarDevolucionContabilidad(Header header, string letra)
        {
            return FianzaCln.palistarFuncionariosFianzaBuscarDevolucionContabilidad(header, letra);
        }


        public List<paFuncionarioFianzaActualBuscarTipoFianza_Result> pafianzaListarFuncionariosBuscarTipoFianza(Header header, string letra,int idTipoFianza)
        {
            return FianzaCln.palistarFuncionariosFianzaBuscarTipoFianza(header, letra,idTipoFianza);
        }

        public List<paFuncionarioFianzaActualBuscarTipoFianzaTotalEstadoValidado_Result> pafianzaListarFuncionariosBuscarTipoFianzaTotalEstadoValidado(Header header, string letra, int idTipoFianza,int estadoValidacion)
        {
            return FianzaCln.palistarFuncionariosFianzaBuscarTipoFianzaTotalEstadoValidado(header, letra, idTipoFianza,estadoValidacion);
        }

        public List<paFianzasListarMesAnioDescuentos_Result> pafianzaListarFianzasMesAnioDescuentos(Header header, int idUnidadEjecutora, int idtipoFianza, int anio)
        {
            return FianzaCln.palistarFianzasMesAnioDescuentos(header, idUnidadEjecutora,idtipoFianza,anio);
        }

        public List<paFianzasListarMesAnioContaVali_Result> pafianzaListarFianzasMesAnioContaVali(Header header, int idUnidadEjecutora, int idtipoFianza, int anio)
        {
            return FianzaCln.palistarFianzasMesAnioContaVali(header, idUnidadEjecutora, idtipoFianza, anio);
        }

        public List<paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado_Result> paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado(Header header, string letra, int idtipoDeFianza, int gestion, int idUnidadEjecutora)
        {
            return FianzaCln.paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado(header, letra, idtipoDeFianza, gestion,idUnidadEjecutora);
        }


        public List<paFuncionarioFianzaActualBuscarMesAnioEditar_Result> palistarFianzasMesAnioEditar(Header header, string letra, int idUnidadEjecutora, int idtipoDeFianza, int mes, int anio)
        {
            return FianzaCln.palistarFianzasMesAnioEditar(header, letra, idUnidadEjecutora, idtipoDeFianza, mes,anio);
        }

        public Fianza fianzaGet(Header header, int idFianza)
        {
            var fianza = FianzaCln.get(header, idFianza);
            return Mapper.Map<CadMidasD.Fianza, Fianza>(fianza);
        }

        public Fianza fianzaIdFuncionario(Header header, int idFuncionario)
        {
            var fianza = FianzaCln.fianzaIdFuncionario(header, idFuncionario);
            return Mapper.Map<CadMidasD.Fianza, Fianza>(fianza);
        }

        public int fianzaVerificarEnCurso(Header header, int idFuncionario)
        {
            return FianzaCln.verificarFianzaEnCurso(header, idFuncionario);  
        }

        //public Fianza verificarFianzaCompletaActiva(Header header, int idFianza)
        //{
        //    var fianza = FianzaCln.verificarFianzaCompletaActiva(header, idFianza);
        //    return Mapper.Map<CadMidasD.Fianza, Fianza>(fianza);
        //}

        public Fianza fianzaVerificarDevueltaContabilidad(Header header, int idFianza)
        {
            var fianza = FianzaCln.verificarFianzaDevueltaContabilidad(header, idFianza);
            return Mapper.Map<CadMidasD.Fianza, Fianza>(fianza);
        }


        public List<paValidacionEstadoFianzaContabilidad_Result> paValidacionEstadoFianzaContabilidad(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            return FianzaCln.paValidacionEstadoFianzaContabilidad(header,letra, anio, idUnidadEjecutora);
        }

        public List<paValidacionEstadoFianzaHabilitado_Result> paValidacionEstadoFianzaHabilitado(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            return FianzaCln.paValidacionEstadoFianzaHabilitado(header, letra, anio, idUnidadEjecutora);
        }

        public List<paValidacionEstadoFianzaRRHH_Result> paValidacionEstadoFianzaRRHH(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            return FianzaCln.paValidacionEstadoFianzaRRHH(header, letra, anio, idUnidadEjecutora);
        }

        public List<paValidacionParaCertificadosHabilitado_Result> paValidacionParaCertificadosHabilitado(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            return FianzaCln.paValidacionParaCertificadosHabilitado(header, letra, anio, idUnidadEjecutora);
        }

        public List<paValidacionParaCertificadosContabilidad_Result> paValidacionParaCertificadosContabilidad(Header header, string letra, int anio, int idUnidadEjecutora)
        {
            return FianzaCln.paValidacionParaCertificadosContabilidad(header, letra, anio, idUnidadEjecutora);
        }

        public List<paValidacionParaCertificadosRRHH_Result> paValidacionParaCertificadosRRHH(Header header, string letra, int idtipoDeFianza, int anio, int idUnidadEjecutora)
        {
            return FianzaCln.paValidacionParaCertificadosRRHH(header, letra, idtipoDeFianza, anio, idUnidadEjecutora);
        }

        //public List<paListarFianzasEconomicasReporte_Result> paListarFianzasEconomicasReporte(Header header, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio)
        //{
        //    return FianzaCln.paListarFianzasEconomicasReporte(header,idTipoFianza1, idtipoDeFianza2, mes, anio);
        //}

        public List<paListarFianzasEconomicasReporteGlobal_Result> paListarFianzasEconomicasReporteGlobal(Header header, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio)
        {
            return FianzaCln.paListarFianzasEconomicasReporteGlobal(header, idTipoFianza1, idtipoDeFianza2, mes, anio);
        }

        public List<paListarFianzasRealesReporteGlobal_Result> paListarFianzasRealesReporteGlobal(Header header, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio)
        {
            return FianzaCln.paListarFianzasRealesReporteGlobal(header, idTipoFianza1, idtipoDeFianza2, mes, anio);
        }

        public List<paListarFianzasEconomicasReporteT727_Result> paListarFianzasEconomicasReporteT727(Header header, int mes, int anio)
        {
            return FianzaCln.paListarFianzasEconomicasReporteT727(header,"", mes, anio);
        }

        public List<paReporteCartilla_Result> paFianzaReporteCartilla(Header header, int idFianza)
        {
            return FianzaCln.paFianzaReporteCartilla(header,idFianza);
        }

        public List<paReporteCartillaT727_Result> paFianzaReporteCartillaT727(Header header, int idFianza)
        {
            return FianzaCln.paFianzaReporteCartillaT727(header, idFianza);
        }

        public List<paFianzasPorFuncionarioBuscar_Result> paFianzasPorFuncionarioBuscar(Header header, string ci)
        {
            return FianzaCln.paFianzasPorFuncionarioBuscar(header, ci);
        }

        public List<paReporteCartillaHabilitadoEditar_Result> paFianzaReporteCartillaHabilitadoEditar(Header header, int idFianza)
        {
            return FianzaCln.paFianzaReporteCartillaHabilitadoEditar(header, idFianza);
        }

        public List<paReporteFormularioA2_Result> paFianzaReporteFormularioA2(Header header, string letra, int idTipoFianza, int mes, int gestion, int idUnidadEjecutora)
        {
            return FianzaCln.paFianzaReporteFormularioA2(header,letra, idTipoFianza, mes, gestion, idUnidadEjecutora);
        }

        public List<Contador_Impresion_Result> paContador_Impresion (Header header)
        {
            return FianzaCln.paContador_Impresion(header);
        }

        public List<paListarFianzasEconomicasReporteGlobalUnidadEjecutora_Result> paListarFianzasEconomicasReporteGlobalUnidadEjecutora(Header header,string letra, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio,int idUnidadEjecutora)
        {
            return FianzaCln.paListarFianzasEconomicasReporteGlobalUnidadEjecutora(header,letra,idTipoFianza1, idtipoDeFianza2, mes, anio,idUnidadEjecutora);
        }

        public int contarFianzasParaResolucion(Header header)
        {
            return FianzaCln.contarFianzasParaResolucion(header);
        }

        public int contarFianzasSinResolucion(Header header)
        {
            return FianzaCln.contarFianzasSinResolucion(header);
        }

        public int contardevolucionesPendientesContabilidad(Header header)
        {
            return FianzaCln.contardevolucionesPendientesContabilidad(header);
        }

        public int contarFianzasCompletasValidacionCertificacionHabilitado(Header header,int gestion)
        {
            return FianzaCln.contarFianzasCompletasValidacionCertificacionHabilitado(header,gestion);
        }


        public int contarFianzasCompletasValidacionCertificacionContabilidad(Header header, int gestion)
        {
            return FianzaCln.contarFianzasCompletasValidacionCertificacionContabilidad(header, gestion);
        }

        public int contarMesDescuentoHabilitado(Header header,int mes, int gestion)
        {
            return FianzaCln.contarMesDescuentoHabilitado(header, mes,gestion);
        }

        public int contarTransferenciasContabilidad(Header header)
        {
            return FianzaCln.contarTransferenciasContabilidad(header);
        }

        public int contarValidarMesDescuentoContabilidad(Header header, int mes, int gestion)
        {
            return FianzaCln.contarValidarMesDescuentoContabilidad(header,mes,gestion);
        }

        public int contarFianzasValidacionBienesGravadosContabilidad(Header header, string usuario)
        {
            return FianzaCln.contarFianzasValidacionBienesGravadosContabilidad(header, usuario);
        }

        public int contarFianzasTotalesValidacionContabilidad(Header header)
        {
            return FianzaCln.contarFianzasTotalesValidacionContabilidad(header);
        }


        #endregion

        #region Funcionario
        public int funcionarioInsertar(Header header, Funcionario funcionario)
        {
            return FuncionarioCln.insertar(header, Mapper.Map<Funcionario, CadMidasD.Funcionario>(funcionario));
        }

        public int funcionarioEditar(Header header, Funcionario funcionario)
        {
            return FuncionarioCln.editar(header, Mapper.Map<Funcionario, CadMidasD.Funcionario>(funcionario));
        }

        public int funcionarioEliminar(Header header, int idFuncionario)
        {
            return FuncionarioCln.eliminar(header, idFuncionario);
        }

        public List<Funcionario> funcionarioListar(Header header)
        {
            var funcionario = FuncionarioCln.listar(header);
            return Mapper.Map<List<CadMidasD.Funcionario>, List<Funcionario>>(funcionario);
        }

        public Funcionario funcionarioGet(Header header, int idFuncionario)
        {
            var funcionario = FuncionarioCln.get(header, idFuncionario);
            return Mapper.Map<CadMidasD.Funcionario, Funcionario>(funcionario);
        }

        public Funcionario funcionarioValidarNuevo(Header header, string nroDocumento)
        {
            var personal = FuncionarioCln.validarNuevoFuncionario(header, nroDocumento);
            return Mapper.Map<CadMidasD.Funcionario, Funcionario>(personal);
        }

        public List<paFuncionarioFianzaActualBuscar_Result> pafuncionarioFianzaActualBuscar(Header header,string letra, int idUnidadEjecutora,int idTipoFianza)
        {
            return FuncionarioCln.paFuncionarioFianzaActualBuscar(header,letra,idUnidadEjecutora,idTipoFianza);
        }

        public List<paFuncionarioFianzaActualBuscarGeneral_Result> pafuncionarioFianzaActualBuscarGeneral(Header header, string letra, int idTipoFianza1, int idTipoFianza2)
        {
            return FuncionarioCln.paFuncionarioFianzaActualBuscarGeneral(header, letra, idTipoFianza1, idTipoFianza2);
        }

        public List<paFuncionarioFianzaActualBuscarGeneralAdministrador_Result> pafuncionarioFianzaActualBuscarGeneralAdministrador(Header header, string letra, int idTipoFianza1, int idTipoFianza2)
        {
            return FuncionarioCln.paFuncionarioFianzaActualBuscarGeneralAdministrador(header, letra, idTipoFianza1, idTipoFianza2);
        }

        public List<paFuncionarioFianzaActualBuscarBaja_Result> pafuncionarioFianzaActualBuscarBaja(Header header, string letra, int idUnidadEjecutora, int idTipoFianza)
        {
            return FuncionarioCln.paFuncionarioFianzaActualBuscarBaja(header, letra, idUnidadEjecutora, idTipoFianza);
        }

        public List<paFuncionarioFianzaActualBuscarCartilla_Result> pafuncionarioFianzaActualBuscarCartilla(Header header, string letra, int idUnidadEjecutora, int idTipoFianza)
        {
            return FuncionarioCln.paFuncionarioFianzaActualBuscarCartilla(header, letra, idUnidadEjecutora, idTipoFianza);
        }

        public List<paFuncionarioFianzaActualBuscarContaVali_Result> pafuncionarioFianzaActualBuscarContaVali(Header header, string letra, int idUnidadEjecutora, int idTipoFianza,int mes , int anio)
        {
            return FuncionarioCln.paFuncionarioFianzaActualBuscarContaVali(header, letra, idUnidadEjecutora, idTipoFianza,mes,anio);
        }

        public List<paFuncionarioFianzaActualBuscaridFianza_Result> pafuncionarioFianzaActualBuscaridFianza(Header header, int idUnidadEjecutora,int idFianza)
        {
            return FuncionarioCln.paFuncionarioFianzaActualBuscaridFianza(header, idUnidadEjecutora,idFianza);
        }

        public List<paFuncionarioVerificaridFianzaCompleta_Result> paFuncionarioVerificaridFianzaCompleta(Header header, int idUnidadEjecutora, int idFianza)
        {
            return FuncionarioCln.paFuncionarioVerificaridFianzaCompleta(header, idUnidadEjecutora, idFianza);
        }

        public List<paReporteFuncionarioCertificadoidFianza_Result> paReporteCertificadoidFianza(Header header, int idUnidadEjecutora, int idfianza)
        {
            return FuncionarioCln.paReporteCertificadoidFianza(header, idUnidadEjecutora, idfianza);
        }
        #endregion

        #region Imagen
        public int imagenInsertar(Header header, Imagen imagen)
        {
            return ImagenCln.insertar(header, Mapper.Map<Imagen, CadMidasD.Imagen>(imagen));
        }

        public int imagenEditar(Header header, Imagen imagen)
        {
            return ImagenCln.editar(header, Mapper.Map<Imagen, CadMidasD.Imagen>(imagen));
        }

        public int imagenEliminar(Header header, int idImagen)
        {
            return ImagenCln.eliminar(header, idImagen);
        }

        public List<Imagen> imagenListar(Header header)
        {
            var imagen = ImagenCln.listar(header);
            return Mapper.Map<List<CadMidasD.Imagen>, List<Imagen>>(imagen);
        }

        public Imagen imagenGet(Header header, int idImagen)
        {
            var imagen = ImagenCln.get(header, idImagen);
            return Mapper.Map<CadMidasD.Imagen, Imagen>(imagen);
        }

        public Imagen imagenGetidPersona(Header header, int idPersona)
        {
            var imagen = ImagenCln.getidPersona(header, idPersona);
            return Mapper.Map<CadMidasD.Imagen, Imagen>(imagen);
        }
        #endregion

        #region Menu
        public int menuInsertar(Header header, Menu menu)
        {
            return MenuCln.insertar(header, Mapper.Map<Menu, CadMidasD.Menu>(menu));
        }

        public int menuEditar(Header header, Menu menu)
        {
            return MenuCln.editar(header, Mapper.Map<Menu, CadMidasD.Menu>(menu));
        }

        public int menuEliminar(Header header, int idMenu)
        {
            return MenuCln.eliminar(header, idMenu);
        }

        public List<Menu> menuListar(Header header)
        {
            var menu = MenuCln.listar(header);
            return Mapper.Map<List<CadMidasD.Menu>, List<Menu>>(menu);
        }

        public Menu menuGet(Header header, int idMenu)
        {
            var menu = MenuCln.get(header, idMenu);
            return Mapper.Map<CadMidasD.Menu, Menu>(menu);
        }

        public Menu menuValidarNuevo(Header header, string menu)
        {
            var menus = MenuCln.validarNuevo(header, menu);
            return Mapper.Map<CadMidasD.Menu, Menu>(menus);
        }

        public int menuActivar(Header header, int idMenu)
        {
            return MenuCln.activar(header, idMenu);
        }
        #endregion

        #region Oficina
        public int oficinaInsertar(Header header, Oficina oficina)
        {
            return OficinaCln.insertar(header, Mapper.Map<Oficina, CadMidasD.Oficina>(oficina));
        }

        public int oficinaEditar(Header header, Oficina oficina)
        {
            return OficinaCln.editar(header, Mapper.Map<Oficina, CadMidasD.Oficina>(oficina));
        }

        public int oficinaEliminar(Header header, int idOficina)
        {
            return OficinaCln.eliminar(header, idOficina);
        }

        public List<Oficina> oficinaListar(Header header)
        {
            var oficina = OficinaCln.listar(header);
            return Mapper.Map<List<CadMidasD.Oficina>, List<Oficina>>(oficina);
        }

        public List<paListaOficinaUnidadEjecutora_Result> oficinaListarUnidadEjecutora(Header header,int idUnidadEjecutora)
        {
            return OficinaCln.listarUnidadEjecutora(header, idUnidadEjecutora);
        }

        public List<paOficinasListar_Result> OficinasListarBuscar(Header header, string letra)
        {
            return OficinaCln.oficinasListarBuscar(header, letra);
        }

        public Oficina oficinaGet(Header header, int idOficina)
        {
            var oficina = OficinaCln.get(header, idOficina);
            return Mapper.Map<CadMidasD.Oficina, Oficina>(oficina);
        }

        public List<paOficinaBuscar_Result> paoficinaBuscar(Header header, string letra,int idUnidadEjecutora)
        {
            return OficinaCln.paoficinaBuscar(header, letra, idUnidadEjecutora);
        }
        #endregion

        #region Persona
        public int personaInsertar(Header header, Persona persona)
        {
            return PersonaCln.insertar(header, Mapper.Map<Persona, CadMidasD.Persona>(persona));
        }

        public int personaEditar(Header header, Persona persona)
        {
            return PersonaCln.editar(header, Mapper.Map<Persona, CadMidasD.Persona>(persona));
        }

        public int personaEliminar(Header header, int idPersona)
        {
            return PersonaCln.eliminar(header, idPersona);
        }

        public List<Persona> personaListar(Header header)
        {
            var persona = PersonaCln.listar(header);
            return Mapper.Map<List<CadMidasD.Persona>, List<Persona>>(persona);
        }

        public Persona personaGet(Header header, int idPersona)
        {
            var persona = PersonaCln.get(header, idPersona);
            return Mapper.Map<CadMidasD.Persona, Persona>(persona);
        }

        public List<viPersonaListar> personaListarVista(Header header)
        {
            return PersonaCln.personaListar(header);
        }
        public Persona personaValidarNuevo(Header header, string nroDocumento)
        {
            var persona = PersonaCln.validarNuevo(header, nroDocumento);
            return Mapper.Map<CadMidasD.Persona, Persona>(persona);
        }

        public int personaActivar(Header header, int idPersona)
        {
            return PersonaCln.activar(header, idPersona);
        }
        public Persona personaGetPorNumeroDocumento(Header header, string numeroDocumento)
        {
            var persona = PersonaCln.getPorNumeroDocumento(header, numeroDocumento);
            return Mapper.Map<CadMidasD.Persona, Persona>(persona);
        }
        public List<paPersonaBuscar_Result> personaBuscar(Header header, string personabuscar)
        {
            return PersonaCln.personaBuscar(header, personabuscar);
        }
        #endregion

        #region Reclasificacion
        public int reclasificacionInsertar(Header header, Reclasificacion reclasificacion)
        {
            return ReclasificacionCln.insertar(header, Mapper.Map<Reclasificacion, CadMidasD.Reclasificacion>(reclasificacion));
        }

        public int reclasificacionEditar(Header header, Reclasificacion reclasificacion)
        {
            return ReclasificacionCln.editar(header, Mapper.Map<Reclasificacion, CadMidasD.Reclasificacion>(reclasificacion));
        }

        public int reclasificacionEliminar(Header header, int idReclasificacion)
        {
            return ReclasificacionCln.eliminar(header, idReclasificacion);
        }

        public List<Reclasificacion> reclasificacionListar(Header header)
        {
            var reclasificacion = ReclasificacionCln.listar(header);
            return Mapper.Map<List<CadMidasD.Reclasificacion>, List<Reclasificacion>>(reclasificacion);
        }

        public Reclasificacion reclasificacionGet(Header header, int idReclasificacion)
        {
            var reclasificacion = ReclasificacionCln.get(header, idReclasificacion);
            return Mapper.Map<CadMidasD.Reclasificacion, Reclasificacion>(reclasificacion);
        }

        public Reclasificacion reclasificacionGetidFianza(Header header, int idFianza)
        {
            var reclasificacion = ReclasificacionCln.getidFianza(header, idFianza);
            return Mapper.Map<CadMidasD.Reclasificacion, Reclasificacion>(reclasificacion);
        }

        public List<paListarFianzasReclasificacion_Result> paListarFianzasReclasificacion(Header header, string letra)
        {
            return ReclasificacionCln.paListarFianzasReclasificacion(header, letra);
        }

        public List<paListarFianzasReclasificacionPendientes_Result> paListarFianzasReclasificacionPendientes(Header header, string letra)
        {
            return ReclasificacionCln.paListarFianzasReclasificacionendientes(header, letra);
        }

        public List<paListarFianzasReclasificacionReporte_Result> paListarFianzasReclasificacionReporte(Header header, DateTime fecha1, DateTime fecha2)
        {
            return ReclasificacionCln.paListarFianzasReclasificacionReporte(header, fecha1, fecha2);
        }
        #endregion

        #region Rol
        public int rolInsertar(Header header, Rol rol)
        {
            return RolCln.insertar(header, Mapper.Map<Rol, CadMidasD.Rol>(rol));
        }

        public int rolEditar(Header header, Rol rol)
        {
            return RolCln.editar(header, Mapper.Map<Rol, CadMidasD.Rol>(rol));
        }

        public int rolEliminar(Header header, int idRol)
        {
            return RolCln.eliminar(header, idRol);
        }

        public List<Rol> rolListar(Header header)
        {
            var rol = RolCln.listar(header);
            return Mapper.Map<List<CadMidasD.Rol>, List<Rol>>(rol);
        }

        public Rol rolGet(Header header, int idRol)
        {
            var rol = RolCln.get(header, idRol);
            return Mapper.Map<CadMidasD.Rol, Rol>(rol);
        }

        public Rol rolValidarNuevo(Header header, string rol)
        {
            var roles = RolCln.validarNuevo(header, rol);
            return Mapper.Map<CadMidasD.Rol, Rol>(roles);
        }

        public int rolActivar(Header header, int idRol)
        {
            return RolCln.activar(header, idRol);
        }
        #endregion

        #region RolMenu
        public int rolMenuInsertar(Header header, RolMenu rolMenu)
        {
            return RolMenuCln.insertar(header, Mapper.Map<RolMenu, CadMidasD.RolMenu>(rolMenu));
        }

        public int rolMenuEditar(Header header, RolMenu rolMenu)
        {
            return RolMenuCln.editar(header, Mapper.Map<RolMenu, CadMidasD.RolMenu>(rolMenu));
        }

        public int rolMenuEliminar(Header header, int idRolMenu)
        {
            return RolMenuCln.eliminar(header, idRolMenu);
        }

        public List<RolMenu> rolMenuListar(Header header)
        {
            var rolMenu = RolMenuCln.listar(header);
            return Mapper.Map<List<CadMidasD.RolMenu>, List<RolMenu>>(rolMenu);
        }

        public RolMenu rolMenuGet(Header header, int idRolMenu)
        {
            var rolMenu = RolMenuCln.get(header, idRolMenu);
            return Mapper.Map<CadMidasD.RolMenu, RolMenu>(rolMenu);
        }

        public List<Menu> rolMenuListarPorRol(Header header, int idRol)
        {
            var rolMenu = RolMenuCln.listarPorRol(header, idRol);
            return Mapper.Map<List<CadMidasD.Menu>, List<Menu>>(rolMenu);
        }

        public int rolMenuEliminarMenu(Header header, int idRol)
        {
            return RolMenuCln.eliminarMenu(header, idRol);
        }
        #endregion

        #region RolUsuario
        public int rolUsuarioInsertar(Header header, RolUsuario rolUsuario)
        {
            return RolUsuarioCln.insertar(header, Mapper.Map<RolUsuario, CadMidasD.RolUsuario>(rolUsuario));
        }

        public int rolUsuarioEditar(Header header, RolUsuario rolUsuario)
        {
            return RolUsuarioCln.editar(header, Mapper.Map<RolUsuario, CadMidasD.RolUsuario>(rolUsuario));
        }

        public int rolUsuarioEliminar(Header header, int idRolUsuario)
        {
            return RolUsuarioCln.eliminar(header, idRolUsuario);
        }

        public List<RolUsuario> rolUsuarioListar(Header header)
        {
            var rolUsuario = RolUsuarioCln.listar(header);
            return Mapper.Map<List<CadMidasD.RolUsuario>, List<RolUsuario>>(rolUsuario);
        }

        public RolUsuario rolUsuarioGet(Header header, int idRolUsuario)
        {
            var rolUsuario = RolUsuarioCln.get(header, idRolUsuario);
            return Mapper.Map<CadMidasD.RolUsuario, RolUsuario>(rolUsuario);
        }

        public RolUsuario rolUsuarioGetIdUsuario(Header header, int idUsuario)
        {
            var rolUsuario = RolUsuarioCln.getUsuarioRol(header, idUsuario);
            return Mapper.Map<CadMidasD.RolUsuario, RolUsuario>(rolUsuario);
        }
        public List<viRolUsuarioListar> rolUsuarioListarRoles(Header header, int idUsuario)
        {
            return RolUsuarioCln.listarRoles(header, idUsuario);
        }
        #endregion

        #region SueldoMensual
        public int sueldoMensualInsertar(Header header, SueldoMensual sueldoMensual)
        {
            return SueldoMensualCln.insertar(header, Mapper.Map<SueldoMensual, CadMidasD.SueldoMensual>(sueldoMensual));
        }

        public int sueldoMensualEditar(Header header, SueldoMensual sueldoMensual)
        {
            return SueldoMensualCln.editar(header, Mapper.Map<SueldoMensual, CadMidasD.SueldoMensual>(sueldoMensual));
        }

        public int sueldoMensualEliminar(Header header, int idSueldoMensual)
        {
            return SueldoMensualCln.eliminar(header, idSueldoMensual);
        }

        public List<SueldoMensual> sueldoMensualListar(Header header)
        {
            var sueldoMensual = SueldoMensualCln.listar(header);
            return Mapper.Map<List<CadMidasD.SueldoMensual>, List<SueldoMensual>>(sueldoMensual);
        }

        public SueldoMensual sueldoMensualGet(Header header, int idSueldoMensual)
        {
            var sueldoMensual = SueldoMensualCln.get(header, idSueldoMensual);
            return Mapper.Map<CadMidasD.SueldoMensual, SueldoMensual>(sueldoMensual);
        }

        public List<paSueldosMensuales_Result> paSueldosMensuales(Header header, int anio)
        {
            return SueldoMensualCln.paSueldosMensuales(header, anio);
        }

        public int sueldoMensualActivar(Header header, int idSueldoMensual)
        {
            return SueldoMensualCln.activar(header, idSueldoMensual);
        }

        public SueldoMensual sueldoMensualValidarNuevo(Header header, double monto)
        {
            var sueldosMensuales = SueldoMensualCln.validarNuevo(header,monto);
            return Mapper.Map<CadMidasD.SueldoMensual, SueldoMensual>(sueldosMensuales);
        }
        #endregion

        #region Solicitudes
        public int solicitudesInsertar(Header header, Solicitudes solicitudes)
        {
            return SolicitudesCln.insertar(header, Mapper.Map<Solicitudes, CadMidasD.Solicitudes>(solicitudes));
        }

        public int solicitudesEditar(Header header, Solicitudes solicitudes)
        {
            return SolicitudesCln.editar(header, Mapper.Map<Solicitudes, CadMidasD.Solicitudes>(solicitudes));
        }

        public int solicitudesEliminar(Header header, int idSolicitud)
        {
            return SolicitudesCln.eliminar(header, idSolicitud);
        }

        public List<Solicitudes> solicitudesListar(Header header)
        {
            var solicitudes = SolicitudesCln.listar(header);
            return Mapper.Map<List<CadMidasD.Solicitudes>, List<Solicitudes>>(solicitudes);
        }

        public Solicitudes solicitudesGet(Header header, int idSolicitud)
        {
            var solicitudes = SolicitudesCln.get(header, idSolicitud);
            return Mapper.Map<CadMidasD.Solicitudes, Solicitudes>(solicitudes);
        }

        public  List<paListarSolicitudesFianza_Result> palistarSolicitudesFianzaBuscar(Header header, string letra, string usuario)
        {
            return SolicitudesCln.palistarSolicitudesFianzaBuscar(header, letra, usuario);
        }

        public int ultimoNumeroSolicitud(Header header,int gestion)
        {
            return SolicitudesCln.ultimoNumeroSolicitud(header,gestion);
        }
        public List<paListarSolicitudesFianzaDiasRestantes_Result> paListarSolicitudesFianzaDiasRestantes(Header header, string letra, int dia1, int dia2, string usuario)
        {
            return SolicitudesCln.paListarSolicitudesFianzaDiasRestantes(header, letra, dia1, dia2, usuario);
        }

        public List<paListarSolicitudesFianzaDiasRestantesReporte_Result> paListarSolicitudesFianzaDiasRestantesReporte(Header header, string letra, int dia1, int dia2, string usuario)
        {
            return SolicitudesCln.paListarSolicitudesFianzaDiasRestantesReporte(header, letra, dia1, dia2, usuario);
        }

        public List<paReporteSolDevolucion_Result> paReporteSolDevolucion(Header header, int idSolicitud)
        {
            return SolicitudesCln.paReporteSolDevolucion(header, idSolicitud);
        }

        public List<paReporteSolFianEconomica_Result> paFuncionarioFianzaActpaReporteSolFianEconomica(Header header, int idSolicitud)
        {
            return SolicitudesCln.paFuncionarioFianzaActpaReporteSolFianEconomica(header, idSolicitud);
        }

        public List<paReporteSolFianEconomicaTotal_Result> paFuncionarioFianzaActpaReporteSolFianEconomicaTotal(Header header, int idSolicitud)
        {
            return SolicitudesCln.paFuncionarioFianzaActpaReporteSolFianEconomicaTotal(header, idSolicitud);
        }

        public List<paReporteSolFianEconomicaNoRequiereFianza_Result> paFuncionarioFianzaActpaReporteSolNoRequiereFianza(Header header, int idSolicitud)
        {
            return SolicitudesCln.paFuncionarioFianzaActpaReporteSolNoRequiereFianza(header, idSolicitud);
        }

        public List<paValidacionRegistroSolicitudes_Result> paValidacionRegistroSolicitudes(Header header, string numeroDocumento)
        {
            return SolicitudesCln.paValidacionRegistroSolicitudes(header, numeroDocumento);
        }
        #endregion

        #region Transferencia
        public int transferenciaInsertar(Header header, Transferencia transferencia)
        {
            return TransferenciaCln.insertar(header, Mapper.Map<Transferencia, CadMidasD.Transferencia>(transferencia));
        }

        public int transferenciaEditar(Header header, Transferencia transferencia)
        {
            return TransferenciaCln.editar(header, Mapper.Map<Transferencia, CadMidasD.Transferencia>(transferencia));
        }

        public int transferenciaEliminar(Header header, int idTransferencia)
        {
            return TransferenciaCln.eliminar(header, idTransferencia);
        }

        public List<Transferencia> transferenciaListar(Header header)
        {
            var transferencia = TransferenciaCln.listar(header);
            return Mapper.Map<List<CadMidasD.Transferencia>, List<Transferencia>>(transferencia);
        }

        public Transferencia transferenciaGet(Header header, int idTransferencia)
        {
            var transferencia = TransferenciaCln.get(header, idTransferencia);
            return Mapper.Map<CadMidasD.Transferencia, Transferencia>(transferencia);
        }

        public List<paListarFuncionariosFianzaTranferencias_Result> paListarFuncionariosFianzaTranferencias(Header header, string letra, string usuario)
        {
            return TransferenciaCln.paListarFuncionariosFianzaTranferencias(header, letra,usuario);
        }

        public List<paListarFuncionariosFianzaTranferenciasReporte_Result> paListarFuncionariosFianzaTranferenciasReporte(Header header, DateTime fecha1, DateTime fecha2)
        {
            return TransferenciaCln.paListarFuncionariosFianzaTranferenciasReporte(header, fecha1, fecha2);
        }
        #endregion

        #region TipoDocumento
        public int tipoDocumentoInsertar(Header header, TipoDocumento tipoDocumento)
        {
            return TipoDocumentoCln.insertar(header, Mapper.Map<TipoDocumento, CadMidasD.TipoDocumento>(tipoDocumento));
        }

        public int tipoDocumentoEditar(Header header, TipoDocumento tipoDocumento)
        {
            return TipoDocumentoCln.editar(header, Mapper.Map<TipoDocumento, CadMidasD.TipoDocumento>(tipoDocumento));
        }

        public int tipoDocumentoEliminar(Header header, int idTipoDocumento)
        {
            return TipoDocumentoCln.eliminar(header, idTipoDocumento);
        }

        public List<TipoDocumento> tipoDocumentoListar(Header header)
        {
            var tipoDocumento = TipoDocumentoCln.listar(header);
            return Mapper.Map<List<CadMidasD.TipoDocumento>, List<TipoDocumento>>(tipoDocumento);
        }

        public TipoDocumento tipoDocumentoGet(Header header, int idTipoDocumento)
        {
            var tipoDocumento = TipoDocumentoCln.get(header, idTipoDocumento);
            return Mapper.Map<CadMidasD.TipoDocumento, TipoDocumento>(tipoDocumento);
        }
        #endregion

        #region TipoFianza
        public int tipoFianzaInsertar(Header header, TipoFianza tipoFianza)
        {
            return TipoFianzaCln.insertar(header, Mapper.Map<TipoFianza, CadMidasD.TipoFianza>(tipoFianza));
        }

        public int tipoFianzaEditar(Header header, TipoFianza tipoFianza)
        {
            return TipoFianzaCln.editar(header, Mapper.Map<TipoFianza, CadMidasD.TipoFianza>(tipoFianza));
        }

        public int tipoFianzaEliminar(Header header, int idTipoFianza)
        {
            return TipoFianzaCln.eliminar(header, idTipoFianza);
        }

        public List<TipoFianza> tipoFianzaListar(Header header)
        {
            var tipoFianza = TipoFianzaCln.listar(header);
            return Mapper.Map<List<CadMidasD.TipoFianza>, List<TipoFianza>>(tipoFianza);
        }

        public TipoFianza tipoFianzaGet(Header header, int idTipoFianza)
        {
            var tipoFianza = TipoFianzaCln.get(header, idTipoFianza);
            return Mapper.Map<CadMidasD.TipoFianza, TipoFianza>(tipoFianza);
        }
        #endregion

        #region UnidadEjecutora
        public int unidadEjecutoraInsertar(Header header, UnidadEjecutora unidadEjecutora)
        {
            return UnidadEjecutoraCln.insertar(header, Mapper.Map<UnidadEjecutora, CadMidasD.UnidadEjecutora>(unidadEjecutora));
        }

        public int unidadEjecutoraEditar(Header header, UnidadEjecutora unidadEjecutora)
        {
            return UnidadEjecutoraCln.editar(header, Mapper.Map<UnidadEjecutora, CadMidasD.UnidadEjecutora>(unidadEjecutora));
        }

        public int unidadEjecutoraEliminar(Header header, int idUnidadEjecutora)
        {
            return UnidadEjecutoraCln.eliminar(header, idUnidadEjecutora);
        }

        public List<UnidadEjecutora> unidadEjecutoraListar(Header header)
        {
            var unidadEjecutora = UnidadEjecutoraCln.listar(header);
            return Mapper.Map<List<CadMidasD.UnidadEjecutora>, List<UnidadEjecutora>>(unidadEjecutora);
        }

        public UnidadEjecutora unidadEjecutoraGet(Header header, int idUnidadEjecutora)
        {
            var unidadEjecutora = UnidadEjecutoraCln.get(header, idUnidadEjecutora);
            return Mapper.Map<CadMidasD.UnidadEjecutora, UnidadEjecutora>(unidadEjecutora);
        }
        #endregion

        #region Usuario
        public int usuarioInsertar(Header header, Usuario usuario)
        {
            return UsuarioCln.insertar(header, Mapper.Map<Usuario, CadMidasD.Usuario>(usuario));
        }

        public int usuarioEditar(Header header, Usuario usuario)
        {
            return UsuarioCln.editar(header, Mapper.Map<Usuario, CadMidasD.Usuario>(usuario));
        }

        public int usuarioEliminar(Header header, int idUsuario)
        {
            return UsuarioCln.eliminar(header, idUsuario);
        }

        public List<Usuario> usuarioListar(Header header)
        {
            var usuario = UsuarioCln.listar(header);
            return Mapper.Map<List<CadMidasD.Usuario>, List<Usuario>>(usuario);
        }

        public Usuario usuarioGet(Header header, int idUsuario)
        {
            var usuario = UsuarioCln.get(header, idUsuario);
            return Mapper.Map<CadMidasD.Usuario, Usuario>(usuario);
        }

        public Usuario usuarioPersonaGet(Header header, int idPersona)
        {
            var usuario = UsuarioCln.getUsuarioPersona(header, idPersona);
            return Mapper.Map<CadMidasD.Usuario, Usuario>(usuario);
        }

        public Usuario usuarioGetId(Header header, string Usuario)
        {
            var usuario = UsuarioCln.getId(header, Usuario);
            return Mapper.Map<CadMidasD.Usuario, Usuario>(usuario);
        }

        public int usuarioCambiarClave(Header header, int idUsuario, string clave)
        {
            return UsuarioCln.cambiarClave(header, idUsuario, clave);
        }
        public List<viUsuarioMenu> usuarioListarMenu(Header header, int idUsuario)
        {
            return UsuarioCln.usuarioListarMenu(header, idUsuario);
        }
        public List<viUsuarioListarDatos> usuarioListarDatosUsuario(Header header)
        {
            return UsuarioCln.listarDatosUsuario(header);
        }
        public Usuario usuarioValidarNuevo(Header header, int idPersona, string usuario)
        {
            var user = UsuarioCln.validarNuevo(header, idPersona, usuario);
            return Mapper.Map<CadMidasD.Usuario, Usuario>(user);
        }

        public Usuario usuarioValidarUsuario(Header header, string usuario)
        {
            var user = UsuarioCln.validarUsuario(header, usuario);
            return Mapper.Map<CadMidasD.Usuario, Usuario>(user);
        }

        public int usuarioActivar(Header header, int idUsuario)
        {
            return UsuarioCln.activar(header, idUsuario);
        }


        public List<paUsuarioBuscar_Result> usuarioBuscar(Header header, string parametro)
        {
            return UsuarioCln.buscar(header, parametro);
        }

        public DateTime fechaServidor()
        {
            return Utilitario.fechaActual();
        }

        public int idUsuarioClave(Header header, string usuario, string clave)
        {
            return UsuarioCln.idUsuarioClave(header, usuario, clave);
        }

        #endregion

    }
}
