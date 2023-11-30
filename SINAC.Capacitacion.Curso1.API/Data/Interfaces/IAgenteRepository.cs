using SINAC.Capacitacion.Curso1.API.Models;

namespace SINAC.Capacitacion.Curso1.API.Data.Interfaces
{
    public interface IAgenteRepository
    {
        public IQueryable<Agents> ObtenerAgentes();
        public Agents? ObtenerAgente(string codigoAgente);
        public Agents CrearAgente(Agents Agente);
        public Agents ActualizarAgente(Agents agents);
        public void EliminarAgente(string codigoAgente);

    }
}
