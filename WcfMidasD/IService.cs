using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CadMidasD;
using ClnMidasD;

namespace WcfMidasD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract(Name = "MidasDService", Namespace = "WcfMidasD")]
    public interface IService
    {
        #region Cargo
        [OperationContract]
        int cargoInsertar(Header header, Cargo cargo);
        [OperationContract]
        int cargoEditar(Header header, Cargo cargo);
        [OperationContract]
        int cargoEliminar(Header header, int idCargo);
        [OperationContract]
        List<Cargo> cargoListar(Header header);
        [OperationContract]
        List<paListaCargoOficina_Result> cargoListarOficina(Header header, int idOficina,int gestion);
        [OperationContract]
        List<paListaCargoOficinaAdmin_Result> cargoListarOficinaAdmin(Header header, int idOficina, int gestion);
        [OperationContract]
        Cargo cargoGet(Header header, int idCargo);
        #endregion

        #region CargoOficina
        [OperationContract]
        int cargoOficinaInsertar(Header header, CargoOficina cargooficina);
        [OperationContract]
        int cargoOficinaEditar(Header header, CargoOficina cargooficina);
        [OperationContract]
        int cargoOficinaEliminar(Header header, int idCargoOficina);
        [OperationContract]
        List<CargoOficina> cargoOficinaListar(Header header);
        [OperationContract]
        CargoOficina cargoOficinaGet(Header header, int idCargoOficina);
        #endregion

        #region Descuento
        [OperationContract]
        int descuentoInsertar(Header header, Descuento descuento);
        [OperationContract]
        int descuentoEditar(Header header, Descuento descuento);
        [OperationContract]
        int descuentoEliminar(Header header, int idDescuento);
        [OperationContract]
        List<Descuento> descuentoListar(Header header);
        [OperationContract]
        Descuento descuentoGet(Header header, int idDescuento);
        [OperationContract]
        Descuento descuentoGetIdFianzaReclasificacion(Header header, int idFianza);
        [OperationContract]
        int descuentoEliminarfisico(Header header, int idDescuento, int mes, int anio);
        [OperationContract]
        int descuentoEliminarfisicoEditar(Header header, int idFianza);
        [OperationContract]
        Descuento descuentoVerificarMesRegistrado(Header header, int idfianza, int mes, int anio);
        #endregion

        #region Devolucion
        [OperationContract]
        int devolucionInsertar(Header header, Devolucion devolucion);
        [OperationContract]
        int devolucionEditar(Header header, Devolucion devolucion);
        [OperationContract]
        int devolucionEliminar(Header header, int idDevolucion);
        [OperationContract]
        List<Devolucion> devolucionListar(Header header);
        [OperationContract]
        Devolucion devolucionGet(Header header, int idDevolucion);
        [OperationContract]
        Devolucion devolucionGetidFianza(Header header, int idFianza);
        [OperationContract]
        List<paListarFuncionariosFianzaDevolucionContabilidadReporte_Result> paListarFuncionariosFianzaDevolucionContabilidadReporte(Header header, DateTime fecha1, DateTime fecha2);

        #endregion

        #region DireccionAdministrativa
        [OperationContract]
        int direccionAdministrativaInsertar(Header header, DireccionAdministrativa direccionadministrativa);
        [OperationContract]
        int direccionAdministrativaEditar(Header header, DireccionAdministrativa direccionadministrativa);
        [OperationContract]
        int direccionAdministrativaEliminar(Header header, int idDireccionAdministrativa);
        [OperationContract]
        List<DireccionAdministrativa> direccionAdministrativaListar(Header header);
        [OperationContract]
        DireccionAdministrativa direccionAdministrativaGet(Header header, int idDireccionAdministrativa);
        #endregion

        #region Encargados
        [OperationContract]
        int encargadosInsertar(Header header, Encargados encargados);
        [OperationContract]
        int encargadosEditar(Header header, Encargados encargados);
        [OperationContract]
        int encargadosEliminar(Header header, int idEncargado);
        [OperationContract]
        List<Encargados> encargadosListar(Header header);
        [OperationContract]
        Encargados encargadosGet(Header header, int idEncargado);
        [OperationContract]
        Encargados encargadosGetIdEncargado(Header header, int idCargo);
        #endregion

        #region EscalaSalarial
        [OperationContract]
        int escalaSalarialInsertar(Header header, EscalaSalarial escalasalarial);
        [OperationContract]
        int escalaSalarialEditar(Header header, EscalaSalarial escalasalarial);
        [OperationContract]
        int escalaSalarialEliminar(Header header, int idEscalaSalarial);
        [OperationContract]
        List<EscalaSalarial> escalaSalarialListar(Header header);
        [OperationContract]
        EscalaSalarial escalaSalarialGet(Header header, int idEscalaSalarial);
        [OperationContract]
        EscalaSalarial escalaSalarialId(Header header, int idSueldoMensual);
        [OperationContract]
        List<paEscalaSalarialGestion_Result> paEscalaSalarialGestion(Header header, int gestion);
        [OperationContract]
        int escalaSalariallActivar(Header header, int idEscalaSalarial);

        #endregion

        #region Fianza
        [OperationContract]
        int fianzaInsertar(Header header, Fianza fianza);
        [OperationContract]
        int fianzaEditar(Header header, Fianza fianza);
        [OperationContract]
        int ultimoNumeroFianza(Header header);
        [OperationContract]
        int ultimoNumeroFianzaBienesGravados(Header header);
        [OperationContract]
        int fianzaEliminar(Header header, int idFianza);
        [OperationContract]
        List<Fianza> fianzaListar(Header header);
        [OperationContract]
        List<paListarFuncionariosFianzaRRHH_Result> pafianzaListarFuncionariosBuscarRRHH(Header header, string letra,string usuario);
        [OperationContract]
        List<paListarFuncionariosFianzaConResolucion_Result> paListarFuncionariosFianzaConResolucion(Header header, string letra, string usuario);
        [OperationContract]
        List<paListarFuncionariosFianzaConResolucionBienesGravados_Result> paListarFuncionariosFianzaConResolucionBienesGravados(Header header, string letra, string usuario);
        [OperationContract]
        List<paListarFuncionariosFianzaDevolucion_Result> pafianzaListarFuncionariosBuscarDevolucion(Header header, string letra);
        [OperationContract]
        List<paListarFuncionariosFianzaDevolucionContabilidad_Result> pafianzaListarFuncionariosBuscarDevolucionContabilidad(Header header, string letra);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscarTipoFianza_Result> pafianzaListarFuncionariosBuscarTipoFianza(Header header, string letra, int idTipoFianza);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscarTipoFianzaTotalEstadoValidado_Result> pafianzaListarFuncionariosBuscarTipoFianzaTotalEstadoValidado(Header header, string letra, int idTipoFianza,int estadValidacion);
        [OperationContract]
        List<paFianzasListarMesAnioDescuentos_Result> pafianzaListarFianzasMesAnioDescuentos(Header header, int idUnidadEjecutora, int idtipoFianza, int anio);
        [OperationContract]
        List<paFianzasListarMesAnioContaVali_Result> pafianzaListarFianzasMesAnioContaVali(Header header, int idUnidadEjecutora, int idtipoFianza, int anio);
        [OperationContract]
        List<paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado_Result> paListarFianzasTipoFianzaGestionUnidadEjecutoraHabilitado(Header header, string letra, int idtipoDeFianza, int gestion, int idUnidadEjecutora);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscarMesAnioEditar_Result> palistarFianzasMesAnioEditar(Header header, string letra, int idUnidadEjecutora, int idtipoDeFianza, int mes, int anio);
        [OperationContract]
        Fianza fianzaGet(Header header, int idFianza);
        [OperationContract]
        Fianza fianzaIdFuncionario(Header header, int idFuncionario);
        [OperationContract]
        int fianzaVerificarEnCurso(Header header, int idFuncionario);
        //[OperationContract]
        //Fianza verificarFianzaCompletaActiva(Header header, int idFianza);
        [OperationContract]
        Fianza fianzaVerificarDevueltaContabilidad(Header header, int idFianza);
        [OperationContract]
        List<paValidacionEstadoFianzaHabilitado_Result> paValidacionEstadoFianzaHabilitado(Header header, string letra, int anio, int idUnidadEjecutora);
        [OperationContract]
        List<paValidacionEstadoFianzaContabilidad_Result> paValidacionEstadoFianzaContabilidad(Header header, string letra, int anio, int idUnidadEjecutora);
        [OperationContract]
        List<paValidacionEstadoFianzaRRHH_Result> paValidacionEstadoFianzaRRHH(Header header, string letra, int anio, int idUnidadEjecutora);
        [OperationContract]
        List<paValidacionParaCertificadosRRHH_Result> paValidacionParaCertificadosRRHH(Header header, string letra, int idtipoDeFianza, int anio, int idUnidadEjecutora);
        [OperationContract]
        List<paValidacionParaCertificadosHabilitado_Result> paValidacionParaCertificadosHabilitado(Header header, string letra, int anio, int idUnidadEjecutora);
        [OperationContract]
        List<paValidacionParaCertificadosContabilidad_Result> paValidacionParaCertificadosContabilidad(Header header, string letra, int anio, int idUnidadEjecutora);
        //[OperationContract]
        //List<paListarFianzasEconomicasReporte_Result> paListarFianzasEconomicasReporte(Header header, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio);
        [OperationContract]
        List<paListarFianzasEconomicasReporteGlobal_Result> paListarFianzasEconomicasReporteGlobal(Header header, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio);
        [OperationContract]
        List<paListarFianzasRealesReporteGlobal_Result> paListarFianzasRealesReporteGlobal(Header header, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio);
        [OperationContract]
        List<paListarFianzasEconomicasReporteT727_Result> paListarFianzasEconomicasReporteT727(Header header, int mes, int anio);
        [OperationContract]
        List<paReporteCartilla_Result> paFianzaReporteCartilla(Header header, int idFianza);
        [OperationContract]
        List<paReporteCartillaT727_Result> paFianzaReporteCartillaT727(Header header, int idFianza);
        [OperationContract]
        List<paFianzasPorFuncionarioBuscar_Result> paFianzasPorFuncionarioBuscar(Header header, string ci);
        [OperationContract]
        List<paReporteCartillaHabilitadoEditar_Result> paFianzaReporteCartillaHabilitadoEditar(Header header, int idFianza);
        [OperationContract]
        List<paReporteFormularioA2_Result> paFianzaReporteFormularioA2(Header header, string letra, int idTipoFianza, int mes, int gestion, int idUnidadEjecutora);
        [OperationContract]
        List<Contador_Impresion_Result> paContador_Impresion(Header header);
        [OperationContract]
        List<paListarFianzasEconomicasReporteGlobalUnidadEjecutora_Result> paListarFianzasEconomicasReporteGlobalUnidadEjecutora(Header header, string letra, int idTipoFianza1, int idtipoDeFianza2, int mes, int anio, int idUnidadEjecutora);
        [OperationContract]
        int contarFianzasParaResolucion(Header header);
        [OperationContract]
        int contarFianzasSinResolucion(Header header);
        [OperationContract]
        int contardevolucionesPendientesContabilidad(Header header);
        [OperationContract]
        int contarFianzasCompletasValidacionCertificacionHabilitado(Header header, int gestion);
        [OperationContract]
        int contarFianzasCompletasValidacionCertificacionContabilidad(Header header, int gestion);
        [OperationContract]
        int contarMesDescuentoHabilitado(Header header, int mes, int gestion);
        [OperationContract]
        int contarTransferenciasContabilidad(Header header);
        [OperationContract]
        int contarValidarMesDescuentoContabilidad(Header header, int mes, int gestion);
        [OperationContract]
        int contarFianzasValidacionBienesGravadosContabilidad(Header header, string usuario);
        [OperationContract]
        int contarFianzasTotalesValidacionContabilidad(Header header);
        #endregion

        #region Funcionario
        [OperationContract]
        int funcionarioInsertar(Header header, Funcionario funcionario);
        [OperationContract]
        int funcionarioEditar(Header header, Funcionario funcionario);
        [OperationContract]
        int funcionarioEliminar(Header header, int idFuncionario);
        [OperationContract]
        List<Funcionario> funcionarioListar(Header header);
        [OperationContract]
        Funcionario funcionarioGet(Header header, int idFuncionario);
        [OperationContract]
        Funcionario funcionarioValidarNuevo(Header header, string nroDocumento);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscar_Result> pafuncionarioFianzaActualBuscar(Header header, string letra, int idUnidadEjecutora,int idTipoFianza);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscarGeneral_Result> pafuncionarioFianzaActualBuscarGeneral(Header header, string letra, int idTipoFianza1, int idTipoFianza2);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscarGeneralAdministrador_Result> pafuncionarioFianzaActualBuscarGeneralAdministrador(Header header, string letra, int idTipoFianza1, int idTipoFianza2);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscarBaja_Result> pafuncionarioFianzaActualBuscarBaja(Header header, string letra, int idUnidadEjecutora, int idTipoFianza);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscarCartilla_Result> pafuncionarioFianzaActualBuscarCartilla(Header header, string letra, int idUnidadEjecutora, int idTipoFianza);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscarContaVali_Result> pafuncionarioFianzaActualBuscarContaVali(Header header, string letra, int idUnidadEjecutora, int idTipoFianza,int mes,int anio);
        [OperationContract]
        List<paFuncionarioFianzaActualBuscaridFianza_Result> pafuncionarioFianzaActualBuscaridFianza(Header header, int idUnidadEjecutora, int idFianza);
        [OperationContract]
        List<paFuncionarioVerificaridFianzaCompleta_Result> paFuncionarioVerificaridFianzaCompleta(Header header, int idUnidadEjecutora, int idFianza);
        [OperationContract]
        List<paReporteFuncionarioCertificadoidFianza_Result> paReporteCertificadoidFianza(Header header, int idUnidadEjecutora, int idfianza);
        #endregion

        #region Imagen
        [OperationContract]
        int imagenInsertar(Header header, Imagen imagen);
        [OperationContract]
        int imagenEditar(Header header, Imagen imagen);
        [OperationContract]
        int imagenEliminar(Header header, int idImagen);
        [OperationContract]
        List<Imagen> imagenListar(Header header);
        [OperationContract]
        Imagen imagenGet(Header header, int idImagen);
        [OperationContract]
        Imagen imagenGetidPersona(Header header, int idPersona);
        #endregion

        #region Menu
        [OperationContract]
        int menuInsertar(Header header, Menu menu);
        [OperationContract]
        int menuEditar(Header header, Menu menu);
        [OperationContract]
        int menuEliminar(Header header, int idMenu);
        [OperationContract]
        List<Menu> menuListar(Header header);
        [OperationContract]
        Menu menuGet(Header header, int idMenu);
        [OperationContract]
        Menu menuValidarNuevo(Header header, string menu);
        [OperationContract]
        int menuActivar(Header header, int idMenu);
        #endregion

        #region Oficina
        [OperationContract]
        int oficinaInsertar(Header header, Oficina oficina);
        [OperationContract]
        int oficinaEditar(Header header, Oficina oficina);
        [OperationContract]
        int oficinaEliminar(Header header, int idOficina);
        [OperationContract]
        List<Oficina> oficinaListar(Header header);
        [OperationContract]
        List<paListaOficinaUnidadEjecutora_Result> oficinaListarUnidadEjecutora(Header header, int idUnidadEjecutora);
        [OperationContract]
        List<paOficinasListar_Result> OficinasListarBuscar(Header header, string letra);
        [OperationContract]
        Oficina oficinaGet(Header header, int idOficina);
        [OperationContract]
        List<paOficinaBuscar_Result> paoficinaBuscar(Header header, string letra,int idUnidadEjecutora);
        #endregion

        #region Persona
        [OperationContract]
        int personaInsertar(Header header, Persona persona);
        [OperationContract]
        int personaEditar(Header header, Persona persona);
        [OperationContract]
        int personaEliminar(Header header, int idPersona);
        [OperationContract]
        List<Persona> personaListar(Header header);
        [OperationContract]
        Persona personaGet(Header header, int idPersona);
        [OperationContract]
        List<viPersonaListar> personaListarVista(Header header);
        [OperationContract]
        Persona personaValidarNuevo(Header header, string nroDocumento);
        [OperationContract]
        int personaActivar(Header header, int idPersona);
        [OperationContract]
        Persona personaGetPorNumeroDocumento(Header header, string numeroDocumento);
        [OperationContract]
        List<paPersonaBuscar_Result> personaBuscar(Header header, string personabuscar);
        #endregion

        #region Reclasificacion
        [OperationContract]
        int reclasificacionInsertar(Header header, Reclasificacion reclasificacion);
        [OperationContract]
        int reclasificacionEditar(Header header, Reclasificacion reclasificacion);
        [OperationContract]
        int reclasificacionEliminar(Header header, int idReclasificacion);
        [OperationContract]
        List<Reclasificacion> reclasificacionListar(Header header);
        [OperationContract]
        Reclasificacion reclasificacionGet(Header header, int idReclasificacion);
        [OperationContract]
        Reclasificacion reclasificacionGetidFianza(Header header, int idFianza);
        [OperationContract]
        List<paListarFianzasReclasificacion_Result> paListarFianzasReclasificacion(Header header, string letra);
        [OperationContract]
        List<paListarFianzasReclasificacionPendientes_Result> paListarFianzasReclasificacionPendientes(Header header, string letra);
        [OperationContract]
        List<paListarFianzasReclasificacionReporte_Result> paListarFianzasReclasificacionReporte(Header header, DateTime fecha1, DateTime fecha2);
        #endregion

        #region Rol
        [OperationContract]
        int rolInsertar(Header header, Rol rol);
        [OperationContract]
        int rolEditar(Header header, Rol rol);
        [OperationContract]
        int rolEliminar(Header header, int idRol);
        [OperationContract]
        List<Rol> rolListar(Header header);
        [OperationContract]
        Rol rolGet(Header header, int idRol);
        [OperationContract]
        Rol rolValidarNuevo(Header header, string rol);
        [OperationContract]
        int rolActivar(Header header, int idRol);
        #endregion

        #region Solicitudes
        [OperationContract]
        int solicitudesInsertar(Header header, Solicitudes solicitudes);
        [OperationContract]
        int solicitudesEditar(Header header, Solicitudes solicitudes);
        [OperationContract]
        int solicitudesEliminar(Header header, int idSolicitud);
        [OperationContract]
        List<Solicitudes> solicitudesListar(Header header);
        [OperationContract]
        Solicitudes solicitudesGet(Header header, int idSolicitud);
        [OperationContract]
        List<paListarSolicitudesFianza_Result> palistarSolicitudesFianzaBuscar(Header header, string letra, string usuario);
        [OperationContract]
        int ultimoNumeroSolicitud(Header header,int gestion);
        [OperationContract]
        List<paListarSolicitudesFianzaDiasRestantes_Result> paListarSolicitudesFianzaDiasRestantes(Header header, string letra, int dia1, int dia2, string usuario);
        [OperationContract]
        List<paListarSolicitudesFianzaDiasRestantesReporte_Result> paListarSolicitudesFianzaDiasRestantesReporte(Header header, string letra, int dia1, int dia2, string usuario);
        [OperationContract]
        List<paReporteSolDevolucion_Result> paReporteSolDevolucion(Header header, int idSolicitud);
        [OperationContract]
        List<paReporteSolFianEconomica_Result> paFuncionarioFianzaActpaReporteSolFianEconomica(Header header, int idSolicitud);
        [OperationContract]
        List<paReporteSolFianEconomicaTotal_Result> paFuncionarioFianzaActpaReporteSolFianEconomicaTotal(Header header, int idSolicitud);
        [OperationContract]
        List<paReporteSolFianEconomicaNoRequiereFianza_Result> paFuncionarioFianzaActpaReporteSolNoRequiereFianza(Header header, int idSolicitud);
        [OperationContract]
        List<paValidacionRegistroSolicitudes_Result> paValidacionRegistroSolicitudes(Header header, string numeroDocumento);
        #endregion

        #region Transferencia
        [OperationContract]
        int transferenciaInsertar(Header header, Transferencia transferencia);
        [OperationContract]
        int transferenciaEditar(Header header, Transferencia transferencia);
        [OperationContract]
        int transferenciaEliminar(Header header, int idTransferencia);
        [OperationContract]
        List<Transferencia> transferenciaListar(Header header);
        [OperationContract]
        Transferencia transferenciaGet(Header header, int idTransferencia);
        [OperationContract]
        List<paListarFuncionariosFianzaTranferencias_Result> paListarFuncionariosFianzaTranferencias(Header header, string letra, string usuario);
        [OperationContract]
        List<paListarFuncionariosFianzaTranferenciasReporte_Result> paListarFuncionariosFianzaTranferenciasReporte(Header header, DateTime fecha1, DateTime fecha2);
        #endregion

        #region RolMenu
        [OperationContract]
        int rolMenuInsertar(Header header, RolMenu rolmenu);
        [OperationContract]
        int rolMenuEditar(Header header, RolMenu rolmenu);
        [OperationContract]
        int rolMenuEliminar(Header header, int idRolMenu);
        [OperationContract]
        List<RolMenu> rolMenuListar(Header header);
        [OperationContract]
        RolMenu rolMenuGet(Header header, int idRolMenu);
        [OperationContract]
        List<Menu> rolMenuListarPorRol(Header header, int idRol);
        [OperationContract]
        int rolMenuEliminarMenu(Header header, int idRol);
        #endregion

        #region RolUsuario
        [OperationContract]
        int rolUsuarioInsertar(Header header, RolUsuario rolusuario);
        [OperationContract]
        int rolUsuarioEditar(Header header, RolUsuario rolusuario);
        [OperationContract]
        int rolUsuarioEliminar(Header header, int idRolUsuario);
        [OperationContract]
        List<RolUsuario> rolUsuarioListar(Header header);
        [OperationContract]
        RolUsuario rolUsuarioGet(Header header, int idRolUsuario);
        [OperationContract]
        RolUsuario rolUsuarioGetIdUsuario(Header header, int idUsuario);
        [OperationContract]
        List<viRolUsuarioListar> rolUsuarioListarRoles(Header header, int idUsuario);
        #endregion

        #region SueldoMensual
        [OperationContract]
        int sueldoMensualInsertar(Header header, SueldoMensual sueldomensual);
        [OperationContract]
        int sueldoMensualEditar(Header header, SueldoMensual sueldomensual);
        [OperationContract]
        int sueldoMensualEliminar(Header header, int idSueldoMensual);
        [OperationContract]
        List<SueldoMensual> sueldoMensualListar(Header header);
        [OperationContract]
        SueldoMensual sueldoMensualGet(Header header, int idSueldoMensual);
        [OperationContract]
        List<paSueldosMensuales_Result> paSueldosMensuales(Header header, int anio);
        [OperationContract]
        int sueldoMensualActivar(Header header, int idSueldoMensual);
        [OperationContract]
        SueldoMensual sueldoMensualValidarNuevo(Header header, double monto);
        #endregion

        #region TipoDocumento
        [OperationContract]
        int tipoDocumentoInsertar(Header header, TipoDocumento tipodocumento);
        [OperationContract]
        int tipoDocumentoEditar(Header header, TipoDocumento tipodocumento);
        [OperationContract]
        int tipoDocumentoEliminar(Header header, int idTipoDocumento);
        [OperationContract]
        List<TipoDocumento> tipoDocumentoListar(Header header);
        [OperationContract]
        TipoDocumento tipoDocumentoGet(Header header, int idTipoDocumento);
        #endregion

        #region TipoFianza
        [OperationContract]
        int tipoFianzaInsertar(Header header, TipoFianza tipofianza);
        [OperationContract]
        int tipoFianzaEditar(Header header, TipoFianza tipofianza);
        [OperationContract]
        int tipoFianzaEliminar(Header header, int idTipoFianza);
        [OperationContract]
        List<TipoFianza> tipoFianzaListar(Header header);
        [OperationContract]
        TipoFianza tipoFianzaGet(Header header, int idTipoFianza);
        #endregion

        #region UnidadEjecutora
        [OperationContract]
        int unidadEjecutoraInsertar(Header header, UnidadEjecutora unidadejecutora);
        [OperationContract]
        int unidadEjecutoraEditar(Header header, UnidadEjecutora unidadejecutora);
        [OperationContract]
        int unidadEjecutoraEliminar(Header header, int idUnidadEjecutora);
        [OperationContract]
        List<UnidadEjecutora> unidadEjecutoraListar(Header header);
        [OperationContract]
        UnidadEjecutora unidadEjecutoraGet(Header header, int idUnidadEjecutora);
        #endregion

        #region Usuario
        [OperationContract]
        int usuarioInsertar(Header header, Usuario usuario);
        [OperationContract]
        int usuarioEditar(Header header, Usuario usuario);
        [OperationContract]
        int usuarioEliminar(Header header, int idUsuario);
        [OperationContract]
        List<Usuario> usuarioListar(Header header);
        [OperationContract]
        Usuario usuarioGet(Header header, int idUsuario);
        [OperationContract]
        Usuario usuarioPersonaGet(Header header, int idPersona);

        [OperationContract]
        Usuario usuarioGetId(Header header, string Usuario);
       
        [OperationContract]
        int usuarioCambiarClave(Header header, int idUsuario, string clave);
        [OperationContract]
        List<viUsuarioMenu> usuarioListarMenu(Header header, int idUsuario);
        [OperationContract]
        List<viUsuarioListarDatos> usuarioListarDatosUsuario(Header header);
        [OperationContract]
        Usuario usuarioValidarNuevo(Header header, int idPersona, string usuario);
        [OperationContract]
        Usuario usuarioValidarUsuario(Header header, string usuario);
        [OperationContract]
        int usuarioActivar(Header header, int idUsuario);
        [OperationContract]
        List<paUsuarioBuscar_Result> usuarioBuscar(Header header, string parametro);
        [OperationContract]
        int idUsuarioClave(Header header, string usuario, string clave);
       
        #endregion

        #region FechaServidor
        [OperationContract]
        DateTime fechaServidor();
        #endregion

   
        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.


    #region Cargo
    [DataContract]
    public class Cargo
    {
        [DataMember(Order = 1)]
        public int idCargo { get; set; }
        [DataMember(Order = 2)]
        public string denominacion_Puesto { get; set; }
        [DataMember(Order = 3)]
        public string descripcion_Puesto { get; set; }
        [DataMember(Order = 4)]
        public string tipo_Personal { get; set; }
        [DataMember(Order = 5)]
        public Nullable<int> idEscalaSalarial { get; set; }
        [DataMember(Order = 6)]
        public string sigla { get; set; }
        [DataMember(Order = 7)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 8)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 9)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region CargoOficina
    [DataContract]
    public class CargoOficina
    {
        [DataMember(Order = 1)]
        public int idCargoOficina { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idCargo { get; set; }
        [DataMember(Order = 3)]
        public Nullable<int> idOficina { get; set; }
        [DataMember(Order = 4)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Descuento
    [DataContract]
    public class Descuento
    {
        [DataMember(Order = 1)]
        public int idDescuento { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idFianza { get; set; }
        [DataMember(Order = 3)]
        public Nullable<double> monto_Beneficiario { get; set; }
        [DataMember(Order = 4)]
        public Nullable<double> t727 { get; set; }
        [DataMember(Order = 5)]
        public Nullable<double> t727_Fianza_Real { get; set; }
        [DataMember(Order = 6)]
        public Nullable<int> c21 { get; set; }
        [DataMember(Order = 7)]
        public Nullable<int> mes { get; set; }
        [DataMember(Order = 8)]
        public Nullable<int> anio { get; set; }
        [DataMember(Order = 9)]
        public Nullable<bool> validado { get; set; }
        [DataMember(Order = 10)]
        public string validado_Por { get; set; }
        [DataMember(Order = 11)]
        public string observacion { get; set; }
        [DataMember(Order = 12)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 13)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 14)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Devolucion
    [DataContract]
    public class Devolucion
    {
        [DataMember(Order = 1)]
        public int idDevolucion { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idFianza { get; set; }
        [DataMember(Order = 3)]
        public Nullable<int> idFuncionario { get; set; }
        [DataMember(Order = 4)]
        public string resolucion_Administrativa { get; set; }
        [DataMember(Order = 5)]
        public string c31 { get; set; }
        [DataMember(Order = 6)]
        public string nro_Cheque { get; set; }
        [DataMember(Order = 7)]
        public Nullable<double> t727 { get; set; }
        [DataMember(Order = 8)]
        public Nullable<double> monto_Devolucion { get; set; }
        [DataMember(Order = 9)]
        public Nullable<int> mes { get; set; }
        [DataMember(Order = 10)]
        public Nullable<int> anio { get; set; }
        [DataMember(Order = 11)]
        public string observacion { get; set; }
        [DataMember(Order = 12)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 13)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 14)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region DireccionAdministrativa
    [DataContract]
    public class DireccionAdministrativa
    {
        [DataMember(Order = 1)]
        public int idDireccionAdministrativa { get; set; }
        [DataMember(Order = 2)]
        public string codigo { get; set; }
        [DataMember(Order = 3)]
        public string descripcion { get; set; }
        [DataMember(Order = 4)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Encargados
    [DataContract]
    public class Encargados
    {
        [DataMember(Order = 1)]
        public int idEncargado { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idPersona { get; set; }
        [DataMember(Order = 3)]
        public Nullable<int> idCargo { get; set; }
        [DataMember(Order = 4)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region EscalaSalarial
    [DataContract]
    public class EscalaSalarial
    {
        [DataMember(Order = 1)]
        public int idEscalaSalarial { get; set; }
        [DataMember(Order = 2)]
        public string categoria { get; set; }
        [DataMember(Order = 3)]
        public Nullable<int> clase { get; set; }
        [DataMember(Order = 4)]
        public Nullable<int> nivel_Salarial { get; set; }
        [DataMember(Order = 5)]
        public string denominacion_Puesto { get; set; }
        [DataMember(Order = 6)]
        public Nullable<int> numero_Items { get; set; }
        [DataMember(Order = 7)]
        public Nullable<int> idSueldoMensual { get; set; }
        [DataMember(Order = 8)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 9)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 10)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Fianza
    [DataContract]
    public class Fianza
    {
        [DataMember(Order = 1)]
        public int idFianza { get; set; }
        [DataMember(Order = 2)]
        public Nullable<double> Nro_Fianza { get; set; }
        [DataMember(Order = 3)]
        public Nullable<double> Nro_Fianza_Fianza_Real { get; set; }
        [DataMember(Order = 4)]
        public Nullable<int> idTipoFianza { get; set; }
        [DataMember(Order = 5)]
        public Nullable<int> idFuncionario { get; set; }
        [DataMember(Order = 6)]
        public string registro_Sigma { get; set; }
        [DataMember(Order = 7)]
        public Nullable<DateTime> fecha_Limite_Fianza { get; set; }
        [DataMember(Order = 8)]
        public string resolucion_Administrativa { get; set; }
        [DataMember(Order = 9)]
        public string comprobante_CPBTE { get; set; }
        [DataMember(Order = 10)]
        public string descripcion_Tipo_Fianza_Real { get; set; }
        [DataMember(Order = 11)]
        public string ubicacion_Fianza_Real { get; set; }
        [DataMember(Order = 12)]
        public string folio_Fianza_Real { get; set; }
        [DataMember(Order = 13)]
        public string concepto_Fianza_Real { get; set; }
        [DataMember(Order = 14)]
        public string a_Favor_Fianza_Real { get; set; }
        [DataMember(Order = 15)]
        public Nullable<double> ultimo_Registro_Fianza_Real { get; set; }
        [DataMember(Order = 16)]
        public string tipo_Fianza_Real { get; set; }
        [DataMember(Order = 17)]
        public string a_Favor_2_Fianza_Real { get; set; }
        [DataMember(Order = 18)]
        public string estado_Bien_Inmueble_Fianza_Real { get; set; }
        [DataMember(Order = 19)]
        public Nullable<bool> fianza_Completa_Habilitado { get; set; }
        [DataMember(Order = 20)]
        public string usuario_Completa_Habilitado { get; set; }
        [DataMember(Order = 21)]
        public Nullable<DateTime> fecha_Completa_Habilitado { get; set; }
        [DataMember(Order = 22)]
        public Nullable<bool> fianza_Validada_Contabilidad { get; set; }
        [DataMember(Order = 23)]
        public string usuario_Validada_Contabilidad { get; set; }
        [DataMember(Order = 24)]
        public Nullable<DateTime> fecha_Validada_Contabilidad { get; set; }
        [DataMember(Order = 25)]
        public Nullable<bool> fianza_Devuelta_Contabilidad { get; set; }
        [DataMember(Order = 26)]
        public string usuario_Devuelta_Contabilidad { get; set; }
        [DataMember(Order = 27)]
        public Nullable<DateTime> fecha_Devuelta_Contabilidad { get; set; }
        [DataMember(Order = 28)]
        public Nullable<bool> fianza_Impresa_RRHH { get; set; }
        [DataMember(Order = 29)]
        public string usuario_Impresa_RRHH { get; set; }
        [DataMember(Order = 30)]
        public Nullable<DateTime> fecha_Impresa_RRHH { get; set; }
        [DataMember(Order = 31)]
        public string observacion { get; set; }
        [DataMember(Order = 32)]
        public string usuario_RRHH { get; set; }
        [DataMember(Order = 33)]
        public Nullable<DateTime> fecha_RRHH { get; set; }
        [DataMember(Order = 34)]
        public string usuario_Resolucion { get; set; }
        [DataMember(Order = 35)]
        public Nullable<DateTime> fecha_Resolucion { get; set; }
        [DataMember(Order = 36)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 37)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 38)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Funcionario
    [DataContract]
    public class Funcionario
    {
        [DataMember(Order = 1)]
        public int idFuncionario { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idPersona { get; set; }
        [DataMember(Order = 3)]
        public string numero_Memorando { get; set; }
        [DataMember(Order = 4)]
        public Nullable<int> tipo_Contrato_Item { get; set; }
        [DataMember(Order = 5)]
        public string vigencia_Contrato { get; set; }
        [DataMember(Order = 6)]
        public Nullable<int> idCargo { get; set; }
        [DataMember(Order = 7)]
        public Nullable<int> idOficina { get; set; }
        [DataMember(Order = 8)]
        public string codigo_Distrito { get; set; }
        [DataMember(Order = 9)]
        public Nullable<DateTime> fecha_Memorando { get; set; }
        [DataMember(Order = 10)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 11)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 12)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Imagen
    [DataContract]
    public class Imagen
    {
        [DataMember(Order = 1)]
        public int idImagen { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idPersona { get; set; }
        [DataMember(Order = 3)]
        public byte[] imagen1 { get; set; }
        [DataMember(Order = 4)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Menu
    [DataContract]
    public class Menu
    {
        [DataMember(Order = 1)]
        public int idMenu { get; set; }
        [DataMember(Order = 2)]
        public string menu1 { get; set; }
        [DataMember(Order = 3)]
        public string nombre_Elemento { get; set; }
        [DataMember(Order = 4)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Oficina
    [DataContract]
    public class Oficina
    {
        [DataMember(Order = 1)]
        public int idOficina { get; set; }
        [DataMember(Order = 2)]
        public string oficina1 { get; set; }
        [DataMember(Order = 3)]
        public string codigo_Distrito { get; set; }
        [DataMember(Order = 4)]
        public string codigo_Zeus { get; set; }
        [DataMember(Order = 5)]
        public Nullable<int> idZeus { get; set; }
        [DataMember(Order = 6)]
        public Nullable<int> idUnidadEjecutora { get; set; }
        [DataMember(Order = 7)]
        public Nullable<int> cuantia { get; set; }
        [DataMember(Order = 8)]
        public Nullable<double> porcentaje_Descuento { get; set; }
        [DataMember(Order = 9)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 10)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 11)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Persona
    [DataContract]
    public class Persona
    {
        [DataMember(Order = 1)]
        public int idPersona { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idTipoDocumento { get; set; }
        [DataMember(Order = 3)]
        public string numero_Documento { get; set; }
        [DataMember(Order = 4)]
        public string pais_Nacimiento { get; set; }
        [DataMember(Order = 5)]
        public string departamento_Nacimiento { get; set; }
        [DataMember(Order = 6)]
        public string localidad_Nacimiento { get; set; }
        [DataMember(Order = 7)]
        public string provincia_Nacimiento { get; set; }
        [DataMember(Order = 8)]
        public string paterno { get; set; }
        [DataMember(Order = 9)]
        public string materno { get; set; }
        [DataMember(Order = 10)]
        public string nombres { get; set; }
        [DataMember(Order = 11)]
        public string domicilio { get; set; }
        [DataMember(Order = 12)]
        public string profesion { get; set; }
        [DataMember(Order = 13)]
        public string sexo { get; set; }
        [DataMember(Order = 14)]
        public string estado_Civil { get; set; }
        [DataMember(Order = 15)]
        public Nullable<DateTime> fecha_Nacimiento { get; set; }
        [DataMember(Order = 16)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 17)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 18)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Reclasificacion
    [DataContract]
    public class Reclasificacion
    {
        [DataMember(Order = 1)]
        public int idReclasificacion { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idFianza { get; set; }
        [DataMember(Order = 3)]
        public Nullable<double> monto_727 { get; set; }
        [DataMember(Order = 4)]
        public Nullable<int> mes { get; set; }
        [DataMember(Order = 5)]
        public Nullable<int> anio { get; set; }
        [DataMember(Order = 6)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 7)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 8)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Rol
    [DataContract]
    public class Rol
    {
        [DataMember(Order = 1)]
        public int idRol { get; set; }
        [DataMember(Order = 2)]
        public string rol1 { get; set; }
        [DataMember(Order = 3)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 4)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region RolMenu
    [DataContract]
    public class RolMenu
    {
        [DataMember(Order = 1)]
        public int idRolMenu { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idRol { get; set; }
        [DataMember(Order = 3)]
        public Nullable<int> idMenu { get; set; }
        [DataMember(Order = 4)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region RolUsuario
    [DataContract]
    public class RolUsuario
    {
        [DataMember(Order = 1)]
        public int idRolUsuario { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idRol { get; set; }
        [DataMember(Order = 3)]
        public Nullable<int> idUsuario { get; set; }
        [DataMember(Order = 4)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region SueldoMensual
    [DataContract]
    public class SueldoMensual
    {
        [DataMember(Order = 1)]
        public int idSueldoMensual { get; set; }
        [DataMember(Order = 2)]
        public Nullable<double> monto { get; set; }
        [DataMember(Order = 3)]
        public Nullable<int> gestion { get; set; }
        [DataMember(Order = 4)]
        public Nullable<double> incremento { get; set; }
        [DataMember(Order = 5)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 7)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region TipoDocumento
    [DataContract]
    public class TipoDocumento
    {
        [DataMember(Order = 1)]
        public int idTipoDocumento { get; set; }
        [DataMember(Order = 2)]
        public string descripcion { get; set; }
        [DataMember(Order = 3)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 4)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region TipoFianza
    [DataContract]
    public class TipoFianza
    {
        [DataMember(Order = 1)]
        public int idTipoFianza { get; set; }
        [DataMember(Order = 2)]
        public string descripcion_Fianza { get; set; }
        [DataMember(Order = 3)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 4)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 5)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Solicitudes
    [DataContract]
    public class Solicitudes
    {
        [DataMember(Order = 1)]
        public int idSolicitud { get; set; }
        [DataMember(Order = 2)]
        public string tipo_Solicitud_Fianza { get; set; }
        [DataMember(Order = 3)]
        public string numero_memorando { get; set; }
        [DataMember(Order = 4)]
        public Nullable<DateTime> fecha_Memorando { get; set; }
        [DataMember(Order = 5)]
        public Nullable<int> numero_Fianza_Solicitud { get; set; }
        [DataMember(Order = 6)]
        public Nullable<int> gestion { get; set; }
        [DataMember(Order = 7)]
        public Nullable<DateTime> fecha_limite_presentacion { get; set; }
        [DataMember(Order = 8)]
        public string usuario_RRHH { get; set; }
        [DataMember(Order = 9)]
        public Nullable<DateTime> fecha_Registro_RRHH { get; set; }
        [DataMember(Order = 10)]
        public string usuario_Asesor_Acepta { get; set; }
        [DataMember(Order = 11)]
        public Nullable<bool> solicitud_Aceptada { get; set; }
        [DataMember(Order = 12)]
        public Nullable<DateTime> fecha_Aceptacion { get; set; }
        [DataMember(Order = 13)]
        public Nullable<int> idPersona { get; set; }
        [DataMember(Order = 14)]
        public Nullable<int> idCargo { get; set; }
        [DataMember(Order = 15)]
        public Nullable<int> idOficina { get; set; }
        [DataMember(Order = 16)]
        public Nullable<int> idEscalaSalarial { get; set; }
        [DataMember(Order = 17)]
        public Nullable<int> idSueldoMensual { get; set; }
        [DataMember(Order = 18)]
        public string tipo_Contrato_Item { get; set; }
        [DataMember(Order = 19)]
        public string vigencia_Contrato { get; set; }
        [DataMember(Order = 20)]
        public Nullable<int> idFianza_Transferir { get; set; }
        [DataMember(Order = 21)]
        public Nullable<double> monto_Fianza_Transferir { get; set; }
        [DataMember(Order = 22)]
        public Nullable<int> idFianza_Nueva { get; set; }
        [DataMember(Order = 23)]
        public Nullable<int> idTipoFianza { get; set; }
        [DataMember(Order = 24)]
        public Nullable<int> idDevolucion_Registro { get; set; }
        [DataMember(Order = 25)]
        public Nullable<int> idTransferencia_Nueva { get; set; }
        [DataMember(Order = 26)]
        public string observacion { get; set; }
        [DataMember(Order = 27)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 28)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 29)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Transferencia
    [DataContract]
    public class Transferencia
    {
        [DataMember(Order = 1)]
        public int idTransferencia { get; set; }
        [DataMember(Order = 2)]
        public Nullable<int> idFianza { get; set; }
        [DataMember(Order = 3)]
        public Nullable<int> idFuncionario { get; set; }
        [DataMember(Order = 4)]
        public Nullable<int> idCargoAnterior { get; set; }
        [DataMember(Order = 5)]
        public string numero_Memorando_Anterior { get; set; }
        [DataMember(Order = 6)]
        public Nullable<DateTime> fecha_Memorando_Anterior { get; set; }
        [DataMember(Order = 7)]
        public string tipo_Contrato_item_Anterior { get; set; }
        [DataMember(Order = 8)]
        public string vigencia_Contrato_Anterior { get; set; }
        [DataMember(Order = 9)]
        public Nullable<int> idTipoFianzaAnterior { get; set; }
        [DataMember(Order = 10)]
        public Nullable<int> idOficinaAnterior { get; set; }
        [DataMember(Order = 11)]
        public Nullable<int> idSueldoSueldoMensual { get; set; }
        [DataMember(Order = 12)]
        public string fecha_LimiteFianza_Anterior { get; set; }
        [DataMember(Order = 13)]
        public string resolucion_Administrativa_Anterior { get; set; }
        [DataMember(Order = 14)]
        public string usuario_RRHH_Anterior { get; set; }
        [DataMember(Order = 15)]
        public string fecha_RRHH_Anterior { get; set; }
        [DataMember(Order = 16)]
        public string usuario_Resolucion_Anterior { get; set; }
        [DataMember(Order = 17)]
        public Nullable<DateTime> fecha_Resolucion_Anterior { get; set; }
        [DataMember(Order = 18)]
        public string usuario_Impresa_Anterior { get; set; }
        [DataMember(Order = 19)]
        public Nullable<DateTime> fecha_Impresa_Anterior { get; set; }
        [DataMember(Order = 20)]
        public string observacion_Anterior { get; set; }
        [DataMember(Order = 21)]
        public Nullable<double> monto_Fianza_Transferir { get; set; }
        [DataMember(Order = 22)]
        public string resolucion_Administrativa_Transferencia { get; set; }
        [DataMember(Order = 23)]
        public string usuario_Contabilidad_Transferencia { get; set; }
        [DataMember(Order = 24)]
        public Nullable<DateTime> fecha_Contabilidad_Transferencia { get; set; }
        [DataMember(Order = 25)]
        public Nullable<int> mes_Transferencia { get; set; }
        [DataMember(Order = 26)]
        public Nullable<int> anio_Tranferencia { get; set; }
        [DataMember(Order = 27)]
        public string observacion_Transferencia { get; set; }
        [DataMember(Order = 28)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 29)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 30)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region UnidadEjecutora
    [DataContract]
    public class UnidadEjecutora
    {
        [DataMember(Order = 1)]
        public int idUnidadEjecutora { get; set; }
        [DataMember(Order = 2)]
        public string codigo { get; set; }
        [DataMember(Order = 3)]
        public string descripcion { get; set; }
        [DataMember(Order = 4)]
        public int idDireccionAdministrativa { get; set; }
        [DataMember(Order = 5)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 6)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 7)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

    #region Usuario
    [DataContract]
    public class Usuario
    {
        [DataMember(Order = 1)]
        public int idUsuario { get; set; }
        [DataMember(Order = 2)]
        public string nombre_Usuario { get; set; }
        [DataMember(Order = 3)]
        public string clave { get; set; }
        [DataMember(Order = 4)]
        public int idPersona { get; set; }
        [DataMember(Order = 5)]
        public string rol { get; set; }
        [DataMember(Order = 6)]
        public Nullable<int> idCodigoZeus { get; set; }
        [DataMember(Order = 7)]
        public string usuarioRegistro { get; set; }
        [DataMember(Order = 8)]
        public Nullable<DateTime> fechaRegistro { get; set; }
        [DataMember(Order = 9)]
        public Nullable<bool> registroActivo { get; set; }
    }
    #endregion

}