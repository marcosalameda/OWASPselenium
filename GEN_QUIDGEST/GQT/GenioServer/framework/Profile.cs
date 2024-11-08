using CSGenio.business;
using CSGenio.persistence;
using Quidgest.Persistence;
using System.Collections.Generic;
using Quidgest.Persistence.GenericQuery;

namespace CSGenio.framework
{
    /// <summary>
	/// Objecto que corresponde ao fields do profile do user
	/// </summary>
	public class Profile
    {
        
        AreaRef profileArea;
        FieldRef key;
        FieldRef name;
        FieldRef foto;
        
        List<Relation> relations;
		
		/// <summary>
		/// Contrutor da classe
		/// </summary>
        public Profile(AreaRef profileArea, FieldRef key, FieldRef name, FieldRef foto, List<Relation> relations) 
        {
            this.profileArea = profileArea;
            this.key = key;
            this.name = name;
            this.foto = foto;
            this.relations = relations;        
        }

        /// <summary>
        /// Método que devolve o name da area do perfil
        /// </summary>
        public AreaRef ProfileArea
        {
            get { return profileArea; }
        }

        /// <summary>
        /// Método que devolve o Qfield key primaria do perfil
        /// </summary>
        public FieldRef Key
        {
            get { return key; }
        }

        /// <summary>
        /// Método que devolve o Qfield name do perfil
        /// </summary>
        public FieldRef Name
        {
            get { return name; }
        }

        /// <summary>
        /// Método que devolve o Qfield foto do perfil
        /// </summary>
        public FieldRef Photo
        {
            get { return foto; }
        }

        /// <summary>
        /// Método que devolve a relações to obter o perfil
        /// </summary>
        public List<Relation> Relations
        {
            get { return relations; }
        }

        

        /// <summary>
        /// Método que devolve todos os profiles definidos
        /// </summary>
        public static List<Profile> GetProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            //TODO: gerar os profiles identificados e as respetivas tables
            
			// USE /[MANUAL GQT PROFILEINFO]/
            
            return profiles;
        }
    }

    public class UserProfileInfo
    {
        /// <summary>
        /// Devolve a imagem (avatar) do utilizador 
        /// </summary>
        /// <param name="sp">O suporte persistente de onde obter a lista</param>
        /// <param name="user">O contexto do user</param>
        /// <returns>um array de byte representando a imagem</returns>
        public static UserInfo getUserImage(PersistentSupport sp, User user)
        {
            //image field
            byte[] image = null;
            //user full name
            string fullname = "";
            //user position or profile
            string position = "";

            //A rotina deve atribuir a variavel image o "byte[]" da imagem
            //A rotina deve atribuir a variavel fullname o nome a ser apresentado
            //A rotina deve atribuir a variavel pasition o cargo/funусo a ser apresentado
            
                 if (user.Ephs != null && user.Ephs.ContainsKey("WMS_USERS"))
            {
                string[] eph = (string[])user.Ephs["WMS_USERS"];

                SelectQuery selquery = new SelectQuery()
                                    .Select(CSGenioAperso.FldName)
                                    .Select(CSGenioAperso.FldPhoto)
                                    .Select(CSGenioAperso.FldIdentifi)
                                    .From(Area.AreaPERSO)
                                    .Where(Quidgest.Persistence.GenericQuery.CriteriaSet.And()
                                        .Equal(CSGenioAperso.FldCodperso, eph[0])
                                    );

                DataMatrix data = sp.Execute(selquery);
                if (data.NumRows > 0)
                {
                    fullname = data.GetString(0, 0);
                    image = data.GetBinary(0, 1);
                    position = data.GetString(0, 2);
                }
            }
            
            return new UserInfo {Image = image, Fullname = fullname, Position = position};
        }
    }
}
