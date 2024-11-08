using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;


namespace GenioServer.security
{
    public interface IUserBusinessManager {
        
        void SetLocalProperties(PersistentSupport sp, User user);


        /// <summary>
        /// Creates the necessary association for COMODANTE EPH
        /// </summary>
        /// <param name="psw">A userlogin (psw) record</param>
        /// <param name="valEph">The value of the link field of the EPH (CODPESS1)</param>
        void CreateEph_COMODANTE(CSGenioApsw psw, string valEph);


    }
}