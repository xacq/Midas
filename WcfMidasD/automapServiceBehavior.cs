using AutoMapper;
using CadMidasD;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;


namespace WcfMidasD
{
     public sealed class AutomapServiceBehavior : Attribute, IServiceBehavior
     {
         public AutomapServiceBehavior()
         {
         }

         public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
             Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
         {
            Mapper.CreateMap<Cargo, CadMidasD.Cargo>();
            Mapper.CreateMap<CadMidasD.Cargo, Cargo>();

            Mapper.CreateMap<CargoOficina, CadMidasD.CargoOficina>();
            Mapper.CreateMap<CadMidasD.CargoOficina, CargoOficina>();

            Mapper.CreateMap<Descuento, CadMidasD.Descuento>();
            Mapper.CreateMap<CadMidasD.Descuento, Descuento>();

            Mapper.CreateMap<DireccionAdministrativa, CadMidasD.DireccionAdministrativa>();
            Mapper.CreateMap<CadMidasD.DireccionAdministrativa, DireccionAdministrativa>();

            Mapper.CreateMap<EscalaSalarial, CadMidasD.EscalaSalarial>();
            Mapper.CreateMap<CadMidasD.EscalaSalarial, EscalaSalarial>();

            Mapper.CreateMap<Fianza, CadMidasD.Fianza>();
            Mapper.CreateMap<CadMidasD.Fianza, Fianza>();

            Mapper.CreateMap<Funcionario, CadMidasD.Funcionario>();
            Mapper.CreateMap<CadMidasD.Funcionario, Funcionario>();

            Mapper.CreateMap<Imagen, CadMidasD.Imagen>();
            Mapper.CreateMap<CadMidasD.Imagen, Imagen>();

            Mapper.CreateMap<Menu, CadMidasD.Menu>();
            Mapper.CreateMap<CadMidasD.Menu, Menu>();

            Mapper.CreateMap<Oficina, CadMidasD.Oficina>();
            Mapper.CreateMap<CadMidasD.Oficina, Oficina>();

            Mapper.CreateMap<Persona, CadMidasD.Persona>();
            Mapper.CreateMap<CadMidasD.Persona, Persona>();

            Mapper.CreateMap<Rol, CadMidasD.Rol>();
            Mapper.CreateMap<CadMidasD.Rol, Rol>();

            Mapper.CreateMap<RolMenu, CadMidasD.RolMenu>();
            Mapper.CreateMap<CadMidasD.RolMenu, RolMenu>();

            Mapper.CreateMap<RolUsuario, CadMidasD.RolUsuario>();
            Mapper.CreateMap<CadMidasD.RolUsuario, RolUsuario>();

            Mapper.CreateMap<SueldoMensual, CadMidasD.SueldoMensual>();
            Mapper.CreateMap<CadMidasD.SueldoMensual, SueldoMensual>();

            Mapper.CreateMap<TipoDocumento, CadMidasD.TipoDocumento>();
            Mapper.CreateMap<CadMidasD.TipoDocumento, TipoDocumento>();

            Mapper.CreateMap<TipoFianza, CadMidasD.TipoFianza>();
            Mapper.CreateMap<CadMidasD.TipoFianza, TipoFianza>();

            Mapper.CreateMap<UnidadEjecutora, CadMidasD.UnidadEjecutora>();
            Mapper.CreateMap<CadMidasD.UnidadEjecutora, UnidadEjecutora>();

            Mapper.CreateMap<Usuario, CadMidasD.Usuario>();
            Mapper.CreateMap<CadMidasD.Usuario, Usuario>();

            Mapper.CreateMap<Encargados, CadMidasD.Encargados>();
            Mapper.CreateMap<CadMidasD.Encargados, Encargados>();

            Mapper.CreateMap<Devolucion, CadMidasD.Devolucion>();
            Mapper.CreateMap<CadMidasD.Devolucion, Devolucion>();

            Mapper.CreateMap<Reclasificacion, CadMidasD.Reclasificacion>();
            Mapper.CreateMap<CadMidasD.Reclasificacion, Reclasificacion>();

            Mapper.CreateMap<Solicitudes, CadMidasD.Solicitudes>();
            Mapper.CreateMap<CadMidasD.Solicitudes, Solicitudes>();

            Mapper.CreateMap<Transferencia, CadMidasD.Transferencia>();
            Mapper.CreateMap<CadMidasD.Transferencia, Transferencia>();
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
         {
         }

         public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
         {
         }
     }
}
