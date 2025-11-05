using System; 
using CSGenio.framework;
using System.Text;
using System.Collections.Generic;
using System.Linq;
 
namespace CSGenio
{

    /// <summary>
    /// Estabelece o mapeamento de um id de interface (por exemplo um form)
    /// e uma área. Pode tambem definir niveis de acesso associados a esse objecto.
    /// </summary>
    /// <!--
    /// Created: RS 2011.02.25
    /// -->
    public class InterfaceObjectPermission
    {
        private string m_id;
        /// <summary>
        /// O identifier do objecto
        /// </summary>        
        public string Id 
        { 
            get { return m_id; } 
            set { m_id = value; }
        }

        private string m_area;
        /// <summary>
        /// Area
        /// </summary>        
        public string Area
        {
            get { return m_area; }
            set { m_area = value; }
        }        

        private string m_nivelVer;
        /// <summary>
        /// O level de visualização deste objecto. -1 to não definir nada.
        /// </summary>        
        public string NivelVer
        {
            get { return m_nivelVer; }
            set { m_nivelVer = value; }
        }

        private string m_nivelAlterar;
        /// <summary>
        /// O level de alteração deste objecto. -1 to não definir nada.
        /// </summary>
        public string NivelAlterar
        {
            get { return m_nivelAlterar; }
            set { m_nivelAlterar = value; }
        }

        /// <summary>
        /// Obtem a lista de mapeamentos de permissões to objectos de interface
        /// </summary>
        /// <returns>A lista de mapeamentos de permissões to objectos de interface</returns>
        public static List<InterfaceObjectPermission> GetPermissionList()
        {
            List<InterfaceObjectPermission> res = new List<InterfaceObjectPermission>();
            InterfaceObjectPermission iop;
            iop = new InterfaceObjectPermission();
            iop.Id = "QwFQWEBFORM";
            iop.Area = "flds";
            iop.NivelVer = "";
            iop.NivelAlterar = "";
            res.Add(iop);
            
            return res;
        }
        
        /// <summary>
        /// Método to obter as permissões por level de user
        /// </summary>
        /// <returns>Devolve uma string com as permissões deste user em cada objecto de interface</returns>
        public static string getPermissoesPorNivel(User user)
        {
            if (user == null)
                throw new ArgumentNullException("utilizador");

            StringBuilder response = new StringBuilder();

            foreach (var module in Configuration.Application.Modules.Select(m => m.Key))
            {
                foreach (InterfaceObjectPermission iop in InterfaceObjectPermission.GetPermissionList())
                {
                    var moduleRoles = user.GetModuleRoles(module);

                    //calcular os acessos pela table
                    CSGenio.business.AreaInfo info = CSGenio.business.Area.GetInfoArea(iop.Area);
                    bool ver = moduleRoles.Any(role => info.QLevel.CanConsult(role));
                    bool ins = moduleRoles.Any(role => info.QLevel.CanCreate(role));
                    bool alt = moduleRoles.Any(role => info.QLevel.CanChange(role));
                    bool eli = moduleRoles.Any(role => info.QLevel.CanDelete(role));

                    //calcular os acessos pelo form
                    if (ver && iop.NivelVer.Length > 0)
                    {
                        var role = Role.GetRole(iop.NivelVer);
                        ver = moduleRoles.Any(r => role.HasRole(r));
                    }
                    if (ver && iop.NivelAlterar.Length > 0)
                    {
                        var role = Role.GetRole(iop.NivelAlterar);
                        alt = moduleRoles.Any(r => role.HasRole(r));            
                    }
                        
                    //se tem permiss?o to tudo ent?o n?o ? necess?rio change as permiss?es
                    if (ver && ins && alt && eli)
                        continue;

                    //construir a parcela de permiss?es deste objecto to este m?dulo
                    response.Append(module);
                    response.Append(".");
                    response.Append(iop.Id);
                    response.Append("=");
                    if (ver)
                        response.Append("V");
                    if (ins)
                        response.Append("ID");
                    if (alt)
                        response.Append("A");
                    if (eli)
                        response.Append("E");
                    response.Append("X"); //pode sempre executar

                    response.Append(";");
                }
            }
            //retirar o ultimo separador
            if(response.Length > 0)
                response.Remove(response.Length - 1, 1);
            return response.ToString();
        }
    }
    
}