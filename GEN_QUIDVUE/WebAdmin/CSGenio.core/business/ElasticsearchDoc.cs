using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GenioServer.business
{
	public class ElasticsearchDocConfig
	{
		public ICollection<string> FieldsToSuggest { get; set; }
		public ICollection<string> FieldsToSearch { get; set; }
		public ICollection<string> FieldsToReturn { get; set; }
		public ICollection<string> FieldsToCard { get; set; }
		public ICollection<string> FieldsToAggs { get; set; }
		public ICollection<string> FieldsToHighlight { get; set; }
		public string Area { get; set; }
		public string Index { get; set; }
	}

	public class ElasticsearchDoc
    {

		/// <summary>
		/// Representa:
		/// area = ITEM
		/// id = DEXITTM
		/// name = ITEMS
		/// </summary>
		public class STDexittm
		{
			public string Coditem { get; set; }
			public string Itemdes { get; set; }
			public string Itemcod { get; set; }
			public DateTime? Date { get; set; }
			public List<string> Highlighted { get; set; }

			
		}
		/// <summary>
		/// Representa:
		/// area = REPAR
		/// id = PREPAIRS
		/// name = Repairs
		/// </summary>
		public class STPrepairs
		{
			public string Codrepar { get; set; }
 			[DisplayName("")]
			public List<PessoSTPrepairs> ListPessoSTPrepairs { get; set; }
			public string Descript { get; set; }
			public long Nrrepara { get; set; }
 			[DisplayName("")]
			public List<SpeciSTPrepairs> ListSpeciSTPrepairs { get; set; }
			public List<string> Highlighted { get; set; }

						 											 									 																											 			
			/// <summary>
			/// Representa PESSO
			/// </summary>
			public class PessoSTPrepairs
			{
				[DisplayName("Name")]
				public string Name { get; set; }
				public ICollection<string> Highlighted { get; set; }
			}

			/// <summary>
			/// Representa SPECI
			/// </summary>
			public class SpeciSTPrepairs
			{
				[DisplayName("Specialty")]
				public string Especial { get; set; }
				public ICollection<string> Highlighted { get; set; }
			}

		}
		/// <summary>
		/// Representa:
		/// area = REPAR
		/// id = REPARACO
		/// name = Repairs
		/// </summary>
		public class STReparaco
		{
			public string Codrepar { get; set; }
			public long Nrrepara { get; set; }
			public string Descript { get; set; }
 			[DisplayName("")]
			public List<PessoSTReparaco> ListPessoSTReparaco { get; set; }
 			[DisplayName("")]
			public List<SpeciSTReparaco> ListSpeciSTReparaco { get; set; }
			public List<string> Highlighted { get; set; }

								 									 															 																					 			
			/// <summary>
			/// Representa PESSO
			/// </summary>
			public class PessoSTReparaco
			{
				[DisplayName("Name")]
				public string Name { get; set; }
				public ICollection<string> Highlighted { get; set; }
			}

			/// <summary>
			/// Representa SPECI
			/// </summary>
			public class SpeciSTReparaco
			{
				[DisplayName("Specialty")]
				public string Especial { get; set; }
				public ICollection<string> Highlighted { get; set; }
			}

		}
		/// <summary>
		/// Representa:
		/// area = REPAR
		/// id = REPARASO
		/// name = Repairs
		/// </summary>
		public class STReparaso
		{
			public string Codrepar { get; set; }
 			[DisplayName("")]
			public List<PessoSTReparaso> ListPessoSTReparaso { get; set; }
			public string Descript { get; set; }
			public long Nrrepara { get; set; }
 			[DisplayName("")]
			public List<SpeciSTReparaso> ListSpeciSTReparaso { get; set; }
			public List<string> Highlighted { get; set; }

						 											 									 																											 			
			/// <summary>
			/// Representa PESSO
			/// </summary>
			public class PessoSTReparaso
			{
				[DisplayName("Name")]
				public string Name { get; set; }
				public ICollection<string> Highlighted { get; set; }
			}

			/// <summary>
			/// Representa SPECI
			/// </summary>
			public class SpeciSTReparaso
			{
				[DisplayName("Specialty")]
				public string Especial { get; set; }
				public ICollection<string> Highlighted { get; set; }
			}

		}
		/// <summary>
		/// Representa:
		/// area = ITEM
		/// id = TMLINEM
		/// name = Articles
		/// </summary>
		public class STTmlinem
		{
			public string Coditem { get; set; }
			public string Itemdes { get; set; }
			public string Itemcod { get; set; }
			public DateTime? Date { get; set; }
			public List<string> Highlighted { get; set; }

			
		}
		/// <summary>
		/// Representa:
		/// area = ITEM
		/// id = TMLINEW
		/// name = Articles
		/// </summary>
		public class STTmlinew
		{
			public string Coditem { get; set; }
			public string Itemdes { get; set; }
			public string Itemcod { get; set; }
			public DateTime? Date { get; set; }
			public List<string> Highlighted { get; set; }

			
		}
		/// <summary>
		/// Representa:
		/// area = ITEM
		/// id = TMLINEY
		/// name = Articles
		/// </summary>
		public class STTmliney
		{
			public string Coditem { get; set; }
			public string Itemdes { get; set; }
			public string Itemcod { get; set; }
			public DateTime? Date { get; set; }
			public List<string> Highlighted { get; set; }

			
		}
		/// <summary>
		/// Representa:
		/// area = ITEM
		/// id = TMlLEDAY
		/// name = Articles
		/// </summary>
		public class STTmlleday
		{
			public string Coditem { get; set; }
			public string Itemdes { get; set; }
			public string Itemcod { get; set; }
			public DateTime? Date { get; set; }
			public List<string> Highlighted { get; set; }

			
		}
		/// <summary>
		/// Representa:
		/// area = VISIT
		/// id = VISITAS
		/// name = Visitas de inspeção
		/// </summary>
		public class STVisitas
		{
			public string Codvisit { get; set; }
			public string Title { get; set; }
			public string Observat { get; set; }
			public List<string> Highlighted { get; set; }

		
		}
	}
}
