using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SINAC.Capacitacion.Curso1.API.Data.Interfaces;
using SINAC.Capacitacion.Curso1.API.Models;

namespace SINAC.Capacitacion.Curso1.API.Data.Repositorios
{
    public class AgentesRepository : IAgenteRepository
    {
        private readonly CapacitacionContext _context;

        public AgentesRepository(CapacitacionContext context)
        {
            _context = context;
        }

        public Agents ActualizarAgente(Agents agente)
        {
            _context.Entry<Agents>(agente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return agente;
        }

        public Agents CrearAgente(Agents agente)
        {
            _context.Agents.Add(agente);
            _context.SaveChanges();

            return agente;
        }

        public void EliminarAgente(string codigoAgente)
        {
            Agents? agente = ObtenerAgente(codigoAgente);

            if (agente != null)
            {
                _context.Agents.Remove(agente);
                _context.SaveChanges();
            }
        }

        public Agents? ObtenerAgente(string codigoAgente)
        {
            return _context.Agents.FirstOrDefault(x => x.AgentCode == codigoAgente);
        }

        public IQueryable<Agents> ObtenerAgentes()
        {
            return _context.Agents;
        }
    }
}
