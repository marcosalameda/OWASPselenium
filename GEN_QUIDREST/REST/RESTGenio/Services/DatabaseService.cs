using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System.Data;

namespace RESTGenio
{

    /// <summary>
    /// Helper class for the insert case, where you must also return the value of the primary key
    /// </summary>
    public class StatusMensagemInserir : StatusMessage
    {
        private string primaryKey;

        /// <summary>
        /// Property used to assign/get the value of the primary key
        /// </summary>
        public string PrimaryKey
        {
            get { return primaryKey; }
            set { primaryKey = value; }
        }

        public StatusMensagemInserir(Status status, string mensagem, string primaryKey)
            : base(status, mensagem)
        {
            this.primaryKey = primaryKey;
        }

    }

    public class DatabaseService
    {
        public static DataTable SelectSeveral(String modulo, String areaName, User user, string id, int numRecords, CriteriaSet cond, int pag, IList<ColumnSort> orderBy, PersistentSupport sp)
        {
            // assumes that data validations have already been done
            // good idea (?)
            Area area = Area.createArea(areaName, user, modulo);

            if (!area.AccessRightsToConsult(user))
                throw new Exception("User does not have sufficient access rights");


            Listing listagem = new Listing(area, orderBy, modulo, id, user, sp);

            cond.SubSet(listagem.EphQueryConditions);

            if (pag == 1)
                // if it's the first page, a GET is made
                listagem = listagem.select(id, cond, numRecords);
            else
            {
                // if it is another page, it is calculated what was the last line read and a GET+ is made
                // for WebServices, you cannot cache the ultimaLida because you do not know the order of the requests
                int ultimaLida = (pag - 1) * numRecords;
                listagem = listagem.selectMore(id, cond, numRecords, ultimaLida, area.Alias + "." + area.PrimaryKeyName);
            }

            return listagem.DataMatrix.Tables[0];
        }

        public static int SelectCount(String modulo, string areaName, User user, CriteriaSet cond, string id, PersistentSupport sp)
        {
            Area area = Area.createArea(areaName, user, modulo);

            if (!area.AccessRightsToConsult(user))
                throw new Exception("User does not have sufficient access rights");

            IDictionary<string, CSGenio.persistence.PersistentSupport.ControlQueryDefinition> hcq = PersistentSupport.getControlQueries();
            CSGenio.persistence.PersistentSupport.ControlQueryDefinition cqd = hcq[id];
            SelectQuery qs = cqd.ToSelectQuery();
            qs.WhereCondition.SubSet(cond);

            QueryUtils.addWhere(qs, Listing.CalculateConditionsEphGeneric(area, ""), CriteriaSetOperator.And);


            qs = QueryUtils.buildQueryCount(qs);
            object result = sp.ExecuteScalar(qs);

            return Convert.ToInt32(result);
        }

        public static StatusMessage Delete(string areaName, User user, string primaryKey, PersistentSupport sp)
        {
            Area area = Area.createArea(areaName, user, user.CurrentModule);
            Field key = area.DBFields[area.PrimaryKeyName];
            ValidarCampoChave(key, primaryKey);
            area.QPrimaryKey = primaryKey;

            return area.eliminate(sp);
        }
		
		public static StatusMessage Update(Area area, PersistentSupport sp)
        {
            Field key = area.DBFields[area.PrimaryKeyName];
            if (string.IsNullOrEmpty(area.QPrimaryKey))
                throw new Exception("Primary key is mandatory for update operations");
            ValidarCampoChave(key, area.QPrimaryKey);
            CriteriaSet condition = CriteriaSet.And().Equal(area.Alias, area.PrimaryKeyName, area.QPrimaryKey);
            return area.change(sp, condition);
        }
		
		public static void ValidarCampoChave(Field key, string valor)
        {
            // TODO here
            // ou [0-9] + ([0-9] | " ")* + [0-9] => [0-9]*

            try
            {
                // if it is not valid throw exception
                if (key.FieldFormat == FieldFormatting.GUID)
                    _ = new Guid(valor);
                else
                {
                    // can't have '
                    if (valor.Contains('\''))
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new Exception("Invalid primary key format");
            }
        }
		
        public static void MapRow2Area(DataRow row, Area area)
        {
            for (int i = 0; i < row.Table.Columns.Count; i++)
                area.insertNameValueField(row.Table.Columns[i].ColumnName, row[i]);
        }

        public static string FormatDataField(Area area, string fieldName)
        {
            var cp = (RequestedField)area.Fields[fieldName]!;

            if(cp.FieldType.GetFormatting() == FieldFormatting.BINARIO)
                return area.DBFields[cp.Name].isEmptyValue(cp.Value) ? "" : "i";
            else
                return Conversion.internal2String(cp.Value, cp.FieldType);
        }


        public static string EncodeDocumRef(Area area, string documFieldName, User user)
        {
            RequestedField cpFilename = (RequestedField)area.Fields[documFieldName]!;
            var resource = new ResourceQuery("d", cpFilename.Area, cpFilename.Name, area.PrimaryKeyName, area.QPrimaryKey);
            return QResources.CreateTicketEncryptedBase64(user.Name, user.CurrentModule, resource);
        }

        public static string EncodeBinaryRef(Area area, string binFieldName, User user)
        {
            RequestedField cpBin = (RequestedField)area.Fields[binFieldName]!;
            var resource = new ResourceBinary("i", cpBin.Area, cpBin.Name, area.QPrimaryKey);
            return QResources.CreateTicketEncryptedBase64(user.Name, user.CurrentModule, resource);
        }

        public static string EncodeFileRef(Area area, string fileFieldName, User user)
        {
            RequestedField cpFile = (RequestedField)area.Fields[fileFieldName]!;
            var resource = new ResourceFile("f", cpFile.Value.ToString());
            return QResources.CreateTicketEncryptedBase64(user.Name, user.CurrentModule, resource);
        }


        public static Resource DecodeResourceRef(string ticket, User user)
        {
            object[] objs = QResources.DecryptTicketBase64(ticket);

            string username = objs[0] as string ?? throw new Exception("Invalid resource type");
            string location = objs[1] as string ?? throw new Exception("Invalid resource type");
            Resource rec = objs[2] as Resource ?? throw new Exception("Invalid resource type");

            if (username != user.Name)
                throw new Exception("User does not have permission for requested resource");

            //we are using location as a way to embed the module into the ticket
            //its not the best solution for the code, but it allows the api users to abstract away the concept of the module
            user.CurrentModule = location;

            return rec;
        }

        public static DbArea PositionBinaryRow(User user, PersistentSupport sp, ResourceBinary binRes)
        {
            DbArea area = Area.createArea(binRes.Table, user, user.CurrentModule) as DbArea ?? throw new Exception("Invalid area");
            area.insertNamesFields(new string[]
            {
                area.Alias + "." + area.PrimaryKeyName,
                area.Alias + "." + binRes.Field,
            });

            CriteriaSet condition = CriteriaSet.And().Equal(area.Alias, area.PrimaryKeyName, binRes.Pk);
            area.selectOne(condition, new List<ColumnSort>(), "", sp);
            return area;
        }

        public static DbArea PositionDocumentRow(User user, PersistentSupport sp, ResourceQuery docRes)
        {
            DbArea area = Area.createArea(docRes.Table, user, user.CurrentModule) as DbArea ?? throw new Exception("Invalid area");
            area.insertNamesFields(new string[]
            {
                area.Alias + "." + area.PrimaryKeyName,
                area.Alias + "." + docRes.KeyData ,
                area.Alias + "." + docRes.KeyData + "fk"
            });

            CriteriaSet condition = CriteriaSet.And().Equal(area.Alias, area.PrimaryKeyName, docRes.KeyValue);
            area.selectOne(condition, new List<ColumnSort>(), "", sp);
            return area;
        }

    }
}
