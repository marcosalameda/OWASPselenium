/* eslint-disable no-unused-vars */
import { computed, reactive } from 'vue'
import _merge from 'lodash-es/merge'

import netAPI from '@quidgest/clientapp/network'

/**
 * Represents a single option with a key, resourceId and reactive value.
 * Uses a WeakRef to hold the translation function so that the component
 * may be garbage-collected once it is no longer referenced elsewhere.
 */
export class Option {
	/**
	* @param {number} key - Unique identifier for this option.
	* @param {string} resourceId - Key used to look up the translated text.
	* @param {Function} fnResources - Function (resourceId -> string) from the Vue component.
	*/
	constructor({ key, resourceId, fnResources, helpResourceId, helpResourceVerboseId, group, icon } = {}) {
		this.key = key
		this.resourceId = resourceId
		this.helpResourceId = helpResourceId
		this.helpResourceVerboseId = helpResourceVerboseId
		this.group = group
		this.icon = icon

		// Store a weak reference to the translation function.
		// .deref() will return undefined if the original function has been
		// garbage-collected, avoiding retention of the component proxy.
		Object.defineProperty(this, '_weakFn', {
			value: typeof fnResources === 'function' ? new WeakRef(fnResources) : null,
			enumerable: false,
			configurable: true
		})

		// Create a computed property for the translated value. The computed
		// only depends on the weak reference, so when the component unmounts
		// and the function is reclaimed, this will fall back to resourceId.
		Object.defineProperty(this, 'value', {
			value: computed(() => {
				const fn = this._weakFn?.deref()
				return typeof fn === 'function'
					? fn(this.resourceId)
					: this.resourceId
			}),
			enumerable: true,
			configurable: true
		})

		if(typeof this.helpResourceId === 'string') {
			Object.defineProperty(this, 'description', {
				value: computed(() => {
					const fn = this._weakFn?.deref()
					return typeof fn === 'function'
						? fn(this.helpResourceId)
						: this.helpResourceId
				}),
				enumerable: false,
				configurable: true
			})
		}

		if(typeof this.helpResourceVerboseId === 'string') {
			Object.defineProperty(this, 'descriptionVerbose', {
				value: computed(() => {
					const fn = this._weakFn?.deref()
					return typeof fn === 'function'
						? fn(this.helpResourceVerboseId)
						: this.helpResourceVerboseId
				}),
				enumerable: false,
				configurable: true
			})
		}
	}
}

export class GroupOption {
	constructor({ id, resourceId, fnResources } = {}) {
		this.id = id
		this.resourceId = resourceId

		// Store a weak reference to the translation function.
		// .deref() will return undefined if the original function has been
		// garbage-collected, avoiding retention of the component proxy.
		Object.defineProperty(this, '_weakFn', {
			value: typeof fnResources === 'function' ? new WeakRef(fnResources) : null,
			enumerable: false,
			configurable: true
		})

		// Create a computed property for the translated value. The computed
		// only depends on the weak reference, so when the component unmounts
		// and the function is reclaimed, this will fall back to resourceId.
		if(typeof this.resourceId === 'string') {
			Object.defineProperty(this, 'title', {
				value: computed(() => {
					const fn = this._weakFn?.deref()
					return typeof fn === 'function'
						? fn(this.resourceId)
						: this.resourceId
				}),
				enumerable: true,
				configurable: true
			})
		}
	}
}

/* eslint-enable no-unused-vars */
/**
 * The a_categ array.
 */
export class QArrayA_categ
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'a_categ'
		this.singularName = 'a_categ'

		this.elements = [
			new Option({
				num: 1,
				key: 'G',
				resourceId: 'GLOBAL58588',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'N',
				resourceId: 'NACIONAL39968',
				fnResources,
			}),
		]

	}
}

/**
 * The a_facili array.
 */
export class QArrayA_facili
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'a_facili'
		this.singularName = 'a_facili'

		this.elements = [
			new Option({
				num: 1,
				key: 'F',
				resourceId: 'FACTIBLE13061',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'ND',
				resourceId: 'NO_DISPONIBLE08299',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'NA',
				resourceId: 'NO_APLICA13087',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'NF',
				resourceId: 'NO_FACTIBLE14448',
				fnResources,
			}),
		]

	}
}

/**
 * The a_nivele array.
 */
export class QArrayA_nivele
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'a_nivele'
		this.singularName = 'a_nivele'

		this.elements = [
			new Option({
				num: 1,
				key: 'I',
				resourceId: 'NIVEL_I61863',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'II',
				resourceId: 'NIVEL_II23028',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'III',
				resourceId: 'NIVEL_III58608',
				fnResources,
			}),
		]

	}
}

/**
 * The aCCustos array.
 */
export class QArrayAccustos
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'AFETACAO_CONTABILIDA13834'
		this.singularName = 'AFETACAO_CONTABILIDA13834'

		this.elements = [
			new Option({
				num: 1,
				key: 'S',
				resourceId: 'SIM28552',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'N',
				resourceId: 'NAO06521',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'C',
				resourceId: 'NAO_EXISTE_CC__CONTA42559',
				fnResources,
			}),
		]

	}
}

/**
 * The aCondTst array.
 */
export class QArrayAcondtst
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'CONDICOES28572'
		this.singularName = 'CONDICAO44011'

		this.elements = [
			new Option({
				num: 1,
				key: 'BLOCK',
				resourceId: 'BLOCK_FIELD33648',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'HIDE',
				resourceId: 'HIDE_FIELD21772',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'REQUIRE',
				resourceId: 'REQUIRE_FIELD20203',
				fnResources,
			}),
		]

	}
}

/**
 * The Active array.
 */
export class QArrayActive
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'ACTIVE03270'
		this.singularName = 'ACTIVE03270'

		this.elements = [
			new Option({
				num: 1,
				key: 'Y',
				resourceId: 'YES34196',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'N',
				resourceId: 'NO57340',
				fnResources,
			}),
		]

	}
}

/**
 * The activida array.
 */
export class QArrayActivida
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'L'
		this.pluralName = 'ACTIVIDADE44684'
		this.singularName = 'ACTIVIDADE44684'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: 'ACTIVE03270',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 0,
				resourceId: 'INACTIVO19228',
				fnResources,
			}),
		]

	}
}

/**
 * The adatqual array.
 */
export class QArrayAdatqual
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'adatqual'
		this.singularName = 'adatqual'

		this.elements = [
			new Option({
				num: 1,
				key: 5,
				resourceId: 'MUITO_BOA49280',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 4,
				resourceId: 'BOA18662',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 3,
				resourceId: 'RAZOAVEL14967',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 2,
				resourceId: 'MA11547',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 1,
				resourceId: 'MUITO_MA26606',
				fnResources,
			}),
		]

	}
}

/**
 * The AddressT array.
 */
export class QArrayAddresst
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'ADDRESS_TYPES26269'
		this.singularName = 'ADDRESS_TYPE12455'

		this.elements = [
			new Option({
				num: 1,
				key: 'postal',
				resourceId: 'POSTAL23608',
				fnResources,
				helpResourceId: '_109335067',
			}),
			new Option({
				num: 2,
				key: 'physical',
				resourceId: 'PHYSICAL14657',
				fnResources,
				helpResourceId: '_109432218',
			}),
			new Option({
				num: 3,
				key: 'both',
				resourceId: 'POSTAL___PHYSICAL44710',
				fnResources,
				helpResourceId: '_109531561',
			}),
		]

	}
}

/**
 * The AddressU array.
 */
export class QArrayAddressu
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'ADDRESS_USES22490'
		this.singularName = 'ADDRESS_USE16014'

		this.elements = [
			new Option({
				num: 1,
				key: 'home',
				resourceId: 'HOME23643',
				fnResources,
				helpResourceId: '_108747561',
			}),
			new Option({
				num: 2,
				key: 'work',
				resourceId: 'WORK50501',
				fnResources,
				helpResourceId: '_108820200',
			}),
			new Option({
				num: 3,
				key: 'temp',
				resourceId: 'TEMPORARY00792',
				fnResources,
				helpResourceId: '_108919783',
			}),
			new Option({
				num: 4,
				key: 'old',
				resourceId: 'OLD___INCORRECT09129',
				fnResources,
				helpResourceId: '_109034838',
			}),
			new Option({
				num: 5,
				key: 'billing',
				resourceId: 'BILLING63268',
				fnResources,
				helpResourceId: '_109131109',
			}),
		]

	}
}

/**
 * The addrtyco array.
 */
export class QArrayAddrtyco
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'ADDRESS_TYPE12455'
		this.singularName = 'ADDRESS_TYPE12455'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: 'BILL_TO10407',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 2,
				resourceId: 'SHIP_TO13065',
				fnResources,
			}),
		]

	}
}

/**
 * The aestadM array.
 */
export class QArrayAestadm
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aestadM'
		this.singularName = 'aestadM'

		this.elements = [
			new Option({
				num: 1,
				key: 'DELAYED',
				resourceId: 'ADIADO25085',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'COMPLETE',
				resourceId: 'CONCLUIDO29216',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'ONCOURSE',
				resourceId: 'EM_CURSO28102',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'CLOSED',
				resourceId: 'ENCERRADO36123',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'STOPPED',
				resourceId: 'PARADO62293',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 'PLANNED',
				resourceId: 'PLANEADO30031',
				fnResources,
			}),
		]

	}
}

/**
 * The aestado array.
 */
export class QArrayAestado
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aestado'
		this.singularName = 'aestado'

		this.elements = [
			new Option({
				num: 1,
				key: 'DELAYED',
				resourceId: 'ADIADA24595',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'COMPLETE',
				resourceId: 'CONCLUIDA26734',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'ONCOURSE',
				resourceId: 'EM_CURSO28102',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'CLOSED',
				resourceId: 'ENCERRADA29062',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'STOPPED',
				resourceId: 'PARADA59671',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 'PLANNED',
				resourceId: 'PLANEADA29857',
				fnResources,
			}),
		]

	}
}

/**
 * The aestrate array.
 */
export class QArrayAestrate
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aestrate'
		this.singularName = 'aestrate'

		this.elements = [
			new Option({
				num: 1,
				key: 'P',
				resourceId: 'PRODUTIVIDADE55481',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'C',
				resourceId: 'CRESCIMENTO17722',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'A',
				resourceId: 'PROD__E_CRESC_35758',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'N',
				resourceId: 'N_A00986',
				fnResources,
			}),
		]

	}
}

/**
 * The aGanttUn array.
 */
export class QArrayAganttun
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'ESCALAS_DOS_GRAFICOS11509'
		this.singularName = 'ESCALA_DO_GRAFICO_GA17953'

		this.elements = [
			new Option({
				num: 1,
				key: 'day',
				resourceId: 'DAY27593',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'week',
				resourceId: 'SEMANA00471',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'month',
				resourceId: 'MES61580',
				fnResources,
			}),
		]

	}
}

/**
 * The aHorasSe array.
 */
export class QArrayAhorasse
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'NO_HORAS_DE_TRABALHO54995'
		this.singularName = 'NO_HORAS_DE_TRABALHO54995'

		this.elements = [
			new Option({
				num: 1,
				key: 35,
				resourceId: '_3534512',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 40,
				resourceId: '_4033029',
				fnResources,
			}),
		]

	}
}

/**
 * The alaglead array.
 */
export class QArrayAlaglead
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'alaglead'
		this.singularName = 'alaglead'

		this.elements = [
			new Option({
				num: 1,
				key: 'LG',
				resourceId: 'LAG58416',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'LD',
				resourceId: 'LEAD45626',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'RE',
				resourceId: 'RESULTADOS20000',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'EF',
				resourceId: 'EFICACIA03259',
				fnResources,
			}),
		]

	}
}

/**
 * The aLocRegr array.
 */
export class QArrayAlocregr
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'LOCAIS_DA_REGRA25886'
		this.singularName = 'LOCAL_DA_REGRA49987'

		this.elements = [
			new Option({
				num: 1,
				key: 'T',
				resourceId: 'TABELA44049',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'F',
				resourceId: 'FORM54242',
				fnResources,
			}),
		]

	}
}

/**
 * The aMeses array.
 */
export class QArrayAmeses
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aMeses'
		this.singularName = 'aMeses'

		this.elements = [
			new Option({
				num: 1,
				key: '1',
				resourceId: 'JANEIRO25316',
				fnResources,
			}),
			new Option({
				num: 2,
				key: '2',
				resourceId: 'FEVEREIRO25443',
				fnResources,
			}),
			new Option({
				num: 3,
				key: '3',
				resourceId: 'MARCO22234',
				fnResources,
			}),
			new Option({
				num: 4,
				key: '4',
				resourceId: 'ABRIL58220',
				fnResources,
			}),
			new Option({
				num: 5,
				key: '5',
				resourceId: 'MAIO10443',
				fnResources,
			}),
			new Option({
				num: 6,
				key: '6',
				resourceId: 'JUNHO15214',
				fnResources,
			}),
			new Option({
				num: 7,
				key: '7',
				resourceId: 'JULHO20764',
				fnResources,
			}),
			new Option({
				num: 8,
				key: '8',
				resourceId: 'AGOSTO05568',
				fnResources,
			}),
			new Option({
				num: 9,
				key: '9',
				resourceId: 'SETEMBRO19956',
				fnResources,
			}),
			new Option({
				num: 10,
				key: '10',
				resourceId: 'OUTUBRO17690',
				fnResources,
			}),
			new Option({
				num: 11,
				key: '11',
				resourceId: 'NOVEMBRO18614',
				fnResources,
			}),
			new Option({
				num: 12,
				key: '12',
				resourceId: 'DEZEMBRO01950',
				fnResources,
			}),
		]

	}
}

/**
 * The aparttyp array.
 */
export class QArrayAparttyp
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'APARTMENT_TYPES10946'
		this.singularName = 'APARTMENT_TYPE01925'

		this.elements = [
			new Option({
				num: 1,
				key: 0,
				resourceId: 'T036607',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 1,
				resourceId: 'T133664',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 2,
				resourceId: 'T233813',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 3,
				resourceId: 'T3_AND_OTHERS19907',
				fnResources,
			}),
		]

	}
}

/**
 * The aPerAcum array.
 */
export class QArrayAperacum
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aPerAcum'
		this.singularName = 'aPerAcum'

		this.elements = [
			new Option({
				num: 1,
				key: 'P',
				resourceId: 'PERIODO18539',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'A',
				resourceId: 'ACUMULADO06566',
				fnResources,
			}),
		]

	}
}

/**
 * The aperiodi array.
 */
export class QArrayAperiodi
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'PERIODICIDADES_DE_RE37021'
		this.singularName = 'PERIODICIDADE_DE_REC55654'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: 'HORARIO56549',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 2,
				resourceId: 'DIARIO16236',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 3,
				resourceId: 'SEMANAL19148',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 4,
				resourceId: 'MENSAL53343',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 10,
				resourceId: 'BIMESTRAL50606',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 5,
				resourceId: 'TRIMESTRAL58756',
				fnResources,
			}),
			new Option({
				num: 7,
				key: 6,
				resourceId: 'SEMESTRAL24523',
				fnResources,
			}),
			new Option({
				num: 8,
				key: 7,
				resourceId: 'ANUAL55239',
				fnResources,
			}),
			new Option({
				num: 9,
				key: 9,
				resourceId: 'VARIAVEL46886',
				fnResources,
			}),
			new Option({
				num: 10,
				key: 11,
				resourceId: 'BIANUAL25027',
				fnResources,
			}),
			new Option({
				num: 11,
				key: 12,
				resourceId: '_5_ANOS28378',
				fnResources,
			}),
		]

	}
}

/**
 * The apolarid array.
 */
export class QArrayApolarid
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'apolarid'
		this.singularName = 'apolarid'

		this.elements = [
			new Option({
				num: 1,
				key: 'CR',
				resourceId: 'MAIOR_E_MELHOR43422',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'DE',
				resourceId: 'MENOR_E_MELHOR57832',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'C',
				resourceId: 'CENTRADA33827',
				fnResources,
			}),
		]

	}
}

/**
 * The apriorid array.
 */
export class QArrayApriorid
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'apriorid'
		this.singularName = 'apriorid'

		this.elements = [
			new Option({
				num: 1,
				key: 'HIGH',
				resourceId: 'HIGH47127',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'MEDIUM',
				resourceId: 'AVERAGE50639',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'LOW',
				resourceId: 'LOW09468',
				fnResources,
			}),
		]

	}
}

/**
 * The AreaTecn array.
 */
export class QArrayAreatecn
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'TECHNICAL_AREAS40861'
		this.singularName = 'TECHNICAL_AREA50773'

		this.elements = [
			new Option({
				num: 1,
				key: 'M',
				resourceId: 'MECHANICAL47923',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'E',
				resourceId: 'ELECTRICITY31511',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'L',
				resourceId: 'CLEANING01363',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'G',
				resourceId: 'MANAGEMENT02985',
				fnResources,
			}),
		]

	}
}

/**
 * The aRecolha array.
 */
export class QArrayArecolha
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aRecolha'
		this.singularName = 'aRecolha'

		this.elements = [
			new Option({
				num: 2,
				key: 'D',
				resourceId: 'RECOLHA_DIRETA_DOS_D20088',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'C',
				resourceId: 'CONJUNTO_DE_DADOS_ES36750',
				fnResources,
			}),
		]

	}
}

/**
 * The aScorOut array.
 */
export class QArrayAscorout
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aScorOut'
		this.singularName = 'aScorOut'

		this.elements = [
			new Option({
				num: 1,
				key: 'TREE',
				resourceId: 'ARVORE44219',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'LIST',
				resourceId: 'LISTA13474',
				fnResources,
			}),
		]

	}
}

/**
 * The aSide array.
 */
export class QArrayAside
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'LADOS13995'
		this.singularName = 'LADO49085'

		this.elements = [
			new Option({
				num: 1,
				key: 'L',
				resourceId: 'LEFT43751',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'R',
				resourceId: 'RIGHT33051',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'T',
				resourceId: 'TOP31303',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'B',
				resourceId: 'BOTTOM53759',
				fnResources,
			}),
		]

	}
}

/**
 * The aSimNao array.
 */
export class QArrayAsimnao
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'SIM___NAO31594'
		this.singularName = 'SIM___NAO31594'

		this.elements = [
			new Option({
				num: 1,
				key: '0',
				resourceId: '_48180',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'S',
				resourceId: 'SIM28552',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'N',
				resourceId: 'NAO06521',
				fnResources,
			}),
		]

	}
}

/**
 * The AssetTyp array.
 */
export class QArrayAssettyp
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'ASSET_TYPES33420'
		this.singularName = 'ASSET_TYPE02033'

		this.elements = [
			new Option({
				num: 1,
				key: 'E',
				resourceId: 'EQUIPMENT03632',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'C',
				resourceId: 'COMMODITY03939',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'B',
				resourceId: 'BUILDING13586',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'L',
				resourceId: 'LAND27818',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'O',
				resourceId: 'OFFICE_SUPPLIES00254',
				fnResources,
			}),
		]

	}
}

/**
 * The atipoInd array.
 */
export class QArrayAtipoind
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'TIPOS_DE_INDICADOR06486'
		this.singularName = 'TIPO_DE_INDICADOR41971'

		this.elements = [
			new Option({
				num: 2,
				key: 'RESULT',
				resourceId: 'RESULTADOS20000',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'PROCES',
				resourceId: 'PROCESSOS12945',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'PRODU',
				resourceId: 'PRODUTO57112',
				fnResources,
			}),
		]

	}
}

/**
 * The atipopro array.
 */
export class QArrayAtipopro
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'atipopro'
		this.singularName = 'atipopro'

		this.elements = [
			new Option({
				num: 1,
				key: 'PR',
				resourceId: 'PROGRAMA08229',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'PJ',
				resourceId: 'PROYECTO07336',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'C',
				resourceId: 'COMPONENTE41748',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'A',
				resourceId: 'ACCION51528',
				fnResources,
			}),
		]

	}
}

/**
 * The atipouo array.
 */
export class QArrayAtipouo
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'TIPOS_DE_UNIDADE_ORG29246'
		this.singularName = 'TIPO_DE_UNIDADE_ORG_11394'

		this.elements = [
			new Option({
				num: 1,
				key: 'I',
				resourceId: 'INTERNO52273',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'E',
				resourceId: 'EXTERNO12394',
				fnResources,
			}),
		]

	}
}

/**
 * The aTpActiv array.
 */
export class QArrayAtpactiv
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aTpActiv'
		this.singularName = 'aTpActiv'

		this.elements = [
			new Option({
				num: 1,
				key: '0',
				resourceId: 'RECORRENTE45302',
				fnResources,
			}),
			new Option({
				num: 2,
				key: '1',
				resourceId: 'ENCADEADA10510',
				fnResources,
			}),
		]

	}
}

/**
 * The atpacumu array.
 */
export class QArrayAtpacumu
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'atpacumu'
		this.singularName = 'atpacumu'

		this.elements = [
			new Option({
				num: 1,
				key: 'U',
				resourceId: 'VALOR_UNICO39183',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'S',
				resourceId: 'SOMATORIO37638',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'M',
				resourceId: 'AVERAGE50639',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'C',
				resourceId: 'CONTAGEM11714',
				fnResources,
			}),
		]

	}
}

/**
 * The aTpAvali array.
 */
export class QArrayAtpavali
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aTpAvali'
		this.singularName = 'aTpAvali'

		this.elements = [
			new Option({
				num: 1,
				key: 'T',
				resourceId: 'DIRIGENTES_E_FUNCION02178',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'D',
				resourceId: 'DIRIGENTES24546',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'F',
				resourceId: 'FUNCIONARIOS50597',
				fnResources,
			}),
		]

	}
}

/**
 * The aTpBonif array.
 */
export class QArrayAtpbonif
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aTpBonif'
		this.singularName = 'aTpBonif'

		this.elements = [
			new Option({
				num: 1,
				key: 'A',
				resourceId: 'AUTOMATICAS54417',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'M',
				resourceId: 'MANUAIS00572',
				fnResources,
			}),
		]

	}
}

/**
 * The aTpIndic array.
 */
export class QArrayAtpindic
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aTpIndic'
		this.singularName = 'aTpIndic'

		this.elements = [
			new Option({
				num: 1,
				key: 'Q',
				resourceId: 'QUALIDADE42726',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'E',
				resourceId: 'EFICIENCIA22805',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'F',
				resourceId: 'EFICACIA33755',
				fnResources,
			}),
		]

	}
}

/**
 * The aTpMes array.
 */
export class QArrayAtpmes
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aTpMes'
		this.singularName = 'aTpMes'

		this.elements = [
			new Option({
				num: 1,
				key: 'S',
				resourceId: 'PERIODO_SEGUINTE40793',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'E',
				resourceId: 'PERIODO_ACTUAL45198',
				fnResources,
			}),
		]

	}
}

/**
 * The aTpMeta array.
 */
export class QArrayAtpmeta
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'aTpMeta'
		this.singularName = 'aTpMeta'

		this.elements = [
			new Option({
				num: 1,
				key: 'SUM',
				resourceId: 'SOMA06480',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'AVG',
				resourceId: 'AVERAGE50639',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'NAN',
				resourceId: 'NENHUMA23117',
				fnResources,
			}),
		]

	}
}

/**
 * The atpscore array.
 */
export class QArrayAtpscore
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'atpscore'
		this.singularName = 'atpscore'

		this.elements = [
			new Option({
				num: 1,
				key: 'EVAL',
				resourceId: 'AVALIACAO18442',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'MONI',
				resourceId: 'MONITORIZACAO41068',
				fnResources,
			}),
		]

	}
}

/**
 * The aTpSeg array.
 */
export class QArrayAtpseg
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'TIPOS_DE_SEGMENTOS32926'
		this.singularName = 'TIPO_DE_SEGMENTO49650'

		this.elements = [
			new Option({
				num: 1,
				key: 'SEX',
				resourceId: 'SEXO52099',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'SEC',
				resourceId: 'SECTOR41481',
				fnResources,
			}),
		]

	}
}

/**
 * The aVisPeri array.
 */
export class QArrayAvisperi
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'aVisPeri'
		this.singularName = 'aVisPeri'

		this.elements = [
			new Option({
				num: 1,
				key: 4,
				resourceId: 'MENSAL53343',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 5,
				resourceId: 'TRIMESTRAL58756',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 6,
				resourceId: 'SEMESTRAL24523',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 7,
				resourceId: 'ANUAL55239',
				fnResources,
			}),
		]

	}
}

/**
 * The Baggage array.
 */
export class QArrayBaggage
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'BAGGAGES58641'
		this.singularName = 'BAGGAGE61714'

		this.elements = [
			new Option({
				num: 1,
				key: '0',
				resourceId: 'CABIN___CHECKIN_LUGG64007',
				fnResources,
			}),
			new Option({
				num: 2,
				key: '1',
				resourceId: 'CABIN_LUGGAGE_ONLY28929',
				fnResources,
			}),
		]

	}
}

/**
 * The Bagtype array.
 */
export class QArrayBagtype
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'BAGGAGE_TYPES55106'
		this.singularName = 'BAGGAGE_TYPE35947'

		this.elements = [
			new Option({
				num: 1,
				key: '0',
				resourceId: 'CABIN___CHECKIN_LUGG64007',
				fnResources,
			}),
			new Option({
				num: 2,
				key: '1',
				resourceId: 'CABIN_LUGGAGE_ONLY33466',
				fnResources,
			}),
		]

	}
}

/**
 * The bankComp array.
 */
export class QArrayBankcomp
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'BANK_COMPANIES56474'
		this.singularName = 'BANK_COMPANY19319'

		this.elements = [
			new Option({
				num: 1,
				key: 'ST',
				resourceId: 'SANTANDER27925',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'CB',
				resourceId: 'CAIXA_BANK13668',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'IG',
				resourceId: 'ING19160',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'NB',
				resourceId: 'NOVOBANCO44101',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'AB',
				resourceId: 'ACTIVOBANK40861',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 'OB',
				resourceId: 'OPENBANK20445',
				fnResources,
			}),
		]

	}
}

/**
 * The buildtyp array.
 */
export class QArrayBuildtyp
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'BUILDING_TYPES23872'
		this.singularName = 'BUILDING_TYPE57152'

		this.elements = [
			new Option({
				num: 1,
				key: 'A',
				resourceId: 'APARTMENT12665',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'H',
				resourceId: 'HOUSE01993',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'O',
				resourceId: 'OTHER37293',
				fnResources,
			}),
		]

	}
}

/**
 * The CLASS array.
 */
export class QArrayClass
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'CLASSE_DA_VIAGEM28403'
		this.singularName = 'CLASSE_DA_VIAGEM28403'

		this.elements = [
			new Option({
				num: 1,
				key: '1C',
				resourceId: '_1ACLASSE14213',
				fnResources,
			}),
			new Option({
				num: 2,
				key: '2C',
				resourceId: '_2ACLASSE01747',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'CE',
				resourceId: 'CLASSE_ECONOMICA36282',
				fnResources,
			}),
		]

	}
}

/**
 * The CLASSNUM array.
 */
export class QArrayClassnum
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'CLASS_DA_VIAGEM34402'
		this.singularName = 'CLASS_DA_VIAGEM34402'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: '_1O_CLASSE38057',
				fnResources,
				helpResourceId: '_114530146',
				helpResourceVerboseId: '_1145_VERBOSE04491',
			}),
			new Option({
				num: 2,
				key: 2,
				resourceId: '_2A_CLASSE35193',
				fnResources,
				helpResourceId: '_114630263',
				helpResourceVerboseId: '_1146_VERBOSE39468',
			}),
			new Option({
				num: 3,
				key: 3,
				resourceId: 'ECONOMICA05942',
				fnResources,
			}),
		]

	}
}

/**
 * The DataType array.
 */
export class QArrayDatatype
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'DATA_TYPES15706'
		this.singularName = 'DATA_TYPE47159'

		this.elements = [
			new Option({
				num: 1,
				key: 'T',
				resourceId: 'TEXT04938',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'N',
				resourceId: 'NUMERIC19292',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'D',
				resourceId: 'DATE18475',
				fnResources,
			}),
		]

	}
}

/**
 * The DecPlace array.
 */
export class QArrayDecplace
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'DECIMAL_PLACES62575'
		this.singularName = 'DECIMAL_PLACES62575'

		this.elements = [
			new Option({
				num: 1,
				key: 0,
				resourceId: 'NONE51124',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 1,
				resourceId: 'ONE44350',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 2,
				resourceId: 'TWO16230',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 3,
				resourceId: 'THREE09760',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 4,
				resourceId: 'FOUR61011',
				fnResources,
			}),
		]

	}
}

/**
 * The DispStat array.
 */
export class QArrayDispstat
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'DISPATCH_STATUS62739'
		this.singularName = 'DISPATCH_STATUS62739'

		this.elements = [
			new Option({
				num: 1,
				key: 'I',
				resourceId: 'PREPARING26576',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'P',
				resourceId: 'PREPARED38522',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'D',
				resourceId: 'DISPATCHED04380',
				fnResources,
			}),
		]

	}
}

/**
 * The dsiponib array.
 */
export class QArrayDsiponib
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'AVAILABILITY56489'
		this.singularName = 'AVAILABILITY56489'

		this.elements = [
			new Option({
				num: 1,
				key: 'A',
				resourceId: 'DISPONIVEL07725',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'D',
				resourceId: 'DESCONTINUADO02736',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'O',
				resourceId: 'SEM_EXISTENCIAS63530',
				fnResources,
			}),
		]

	}
}

/**
 * The FacilTyp array.
 */
export class QArrayFaciltyp
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'FACILITY_TYPES57319'
		this.singularName = 'FACILITY_TYPE44577'

		this.elements = [
			new Option({
				num: 1,
				key: 'B',
				resourceId: 'BUILDING13586',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'C',
				resourceId: 'CONTAINER_DEPOT28181',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'P',
				resourceId: 'PARK62080',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'S',
				resourceId: 'SHIP04380',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'A',
				resourceId: 'AIRPLANE10508',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 'O',
				resourceId: 'OFFICE22960',
				fnResources,
			}),
		]

	}
}

/**
 * The FreqEmpr array.
 */
export class QArrayFreqempr
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'LOAN_FREQUENCIES00512'
		this.singularName = 'LOAN_FREQUENCY00701'

		this.elements = [
			new Option({
				num: 1,
				key: 7,
				resourceId: 'AVERAGE50639',
				fnResources,
				helpResourceId: '___1040299',
				icon: {
					icon: 'average',
					type: 'svg',
				},
			}),
			new Option({
				num: 2,
				key: 1,
				resourceId: 'HIGH47127',
				fnResources,
				helpResourceId: '___1140948',
				icon: {
					icon: 'high',
					type: 'svg',
				},
			}),
			new Option({
				num: 3,
				key: 15,
				resourceId: 'LOW09468',
				fnResources,
				helpResourceId: '___1238797',
				icon: {
					icon: 'low',
					type: 'svg',
				},
			}),
			new Option({
				num: 4,
				key: 30,
				resourceId: 'RARE54339',
				fnResources,
				helpResourceId: '___1337918',
				icon: {
					icon: 'rare',
					type: 'svg',
				},
			}),
		]

	}
}

/**
 * The GenConta array.
 */
export class QArrayGenconta
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'CONTACT_GENRES29532'
		this.singularName = 'CONTACT_TYPE65233'

		this.elements = [
			new Option({
				num: 1,
				key: 'T',
				resourceId: 'PHONE56703',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'E',
				resourceId: 'EMAIL25170',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'M',
				resourceId: 'ADDRESS04342',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'O',
				resourceId: 'OTHER37293',
				fnResources,
			}),
		]

	}
}

/**
 * The Gender array.
 */
export class QArrayGender
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'ADMINISTRATIVE_GENDE39506'
		this.singularName = 'ADMINISTRATIVE_GENDE46518'

		this.elements = [
			new Option({
				num: 1,
				key: 'M',
				resourceId: 'MALE32397',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'F',
				resourceId: 'FEMALE46107',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'O',
				resourceId: 'OTHER37293',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'U',
				resourceId: 'UNKNOWN49785',
				fnResources,
			}),
		]

	}
}

/**
 * The Genero array.
 */
export class QArrayGenero
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'GENERA04858'
		this.singularName = 'GENUS37471'

		this.elements = [
			new Option({
				num: 1,
				key: 'M',
				resourceId: 'MALE32397',
				fnResources,
				helpResourceId: '____715057',
			}),
			new Option({
				num: 2,
				key: 'F',
				resourceId: 'FEMALE46107',
				fnResources,
				helpResourceId: '____821504',
			}),
			new Option({
				num: 3,
				key: 'I',
				resourceId: 'UNDIFFERENTIATED28573',
				fnResources,
				helpResourceId: '____921651',
			}),
		]

	}
}

/**
 * The GpsInput array.
 */
export class QArrayGpsinput
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'GPS_INPUT13625'
		this.singularName = 'GPS_INPUT13625'

		this.elements = [
			new Option({
				num: 1,
				key: 'L',
				resourceId: 'LATITUDE_AND_LONGITU45730',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'P',
				resourceId: 'POINT_IN_MAP40870',
				fnResources,
			}),
		]

	}
}

/**
 * The IdentTyp array.
 */
export class QArrayIdenttyp
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'IDENTIFIER_TYPES53348'
		this.singularName = 'IDENTIFIER_TYPE60623'

		this.elements = [
			new Option({
				num: 1,
				key: 'I',
				resourceId: 'INDIVIDUAL42893',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'R',
				resourceId: 'RETURNABLE23883',
				fnResources,
			}),
		]

	}
}

/**
 * The Months array.
 */
export class QArrayMonths
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'MONTHS54799'
		this.singularName = 'MONTH46035'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: 'JANUARY26193',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 2,
				resourceId: 'FEBRUARY35476',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 3,
				resourceId: 'MARCH41748',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 4,
				resourceId: 'APRIL13388',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 5,
				resourceId: 'MAY55681',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 6,
				resourceId: 'JUNE07845',
				fnResources,
			}),
			new Option({
				num: 7,
				key: 7,
				resourceId: 'JULY41219',
				fnResources,
			}),
			new Option({
				num: 8,
				key: 8,
				resourceId: 'AUGUST15687',
				fnResources,
			}),
			new Option({
				num: 9,
				key: 9,
				resourceId: 'SEPTEMBER29714',
				fnResources,
			}),
			new Option({
				num: 10,
				key: 10,
				resourceId: 'OCTOBER62709',
				fnResources,
			}),
			new Option({
				num: 11,
				key: 11,
				resourceId: 'NOVEMBER01178',
				fnResources,
			}),
			new Option({
				num: 12,
				key: 12,
				resourceId: 'DECEMBER43699',
				fnResources,
			}),
		]

	}
}

/**
 * The ObjeType array.
 */
export class QArrayObjetype
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'OBJECT_TYPE18115'
		this.singularName = 'OBJECT_TYPE18115'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: 'ACCOUNT64260',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 2,
				resourceId: 'CONTACT59247',
				fnResources,
			}),
		]

	}
}

/**
 * The phonepre array.
 */
export class QArrayPhonepre
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'phonepre'
		this.singularName = 'PHONE_PREFIX34764'

		this.elements = [
			new Option({
				num: 1,
				key: 'USA',
				resourceId: '_100989',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'ESP',
				resourceId: '_3417988',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'POR',
				resourceId: '_35140328',
				fnResources,
			}),
		]

	}
}

/**
 * The PRIMVIAG array.
 */
export class QArrayPrimviag
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'L'
		this.pluralName = 'PRIMEIRA_VIAGEM55889'
		this.singularName = 'PRIMEIRA_VIAGEM55889'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: 'YES34196',
				fnResources,
				helpResourceId: '_112615498',
				helpResourceVerboseId: '_1126_VERBOSE07113',
			}),
			new Option({
				num: 2,
				key: 0,
				resourceId: 'NO57340',
				fnResources,
				helpResourceId: '_112514035',
				helpResourceVerboseId: '_1125_VERBOSE10394',
			}),
		]

	}
}

/**
 * The QarTipQu array.
 */
export class QArrayQartipqu
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'QarTipQu'
		this.singularName = 'QarTipQu'

		this.elements = [
			new Option({
				num: 1,
				key: '1',
				resourceId: 'NAO_CONFORMIDADES28147',
				fnResources,
			}),
			new Option({
				num: 2,
				key: '2',
				resourceId: 'RECLAMACOES47951',
				fnResources,
			}),
			new Option({
				num: 3,
				key: '3',
				resourceId: 'ACCOES_PREVENTIVAS51089',
				fnResources,
			}),
			new Option({
				num: 4,
				key: '4',
				resourceId: 'ACCOES_CORRECTIVAS43681',
				fnResources,
			}),
			new Option({
				num: 5,
				key: '5',
				resourceId: 'ACCOES_DE_MELHORIA28491',
				fnResources,
			}),
		]

	}
}

/**
 * The RADIOBTN array.
 */
export class QArrayRadiobtn
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'RADIO_BUTTON21249'
		this.singularName = 'RADIO_BUTTON21249'

		this.elements = [
			new Option({
				num: 1,
				key: 'Radio',
				resourceId: 'RADIO44833',
				fnResources,
				helpResourceId: '_112615498',
				helpResourceVerboseId: '_1126_VERBOSE07113',
			}),
			new Option({
				num: 2,
				key: 'op2',
				resourceId: 'OPCAO_214220',
				fnResources,
				helpResourceId: '_112514035',
				helpResourceVerboseId: '_1125_VERBOSE10394',
			}),
		]

	}
}

/**
 * The s_modpro array.
 */
export class QArrayS_modpro
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'MODOS_DE_PROCESSAMEN07602'
		this.singularName = 'MODO_DE_PROCESSAMENT14469'

		this.elements = [
			new Option({
				num: 1,
				key: 'INDIV',
				resourceId: 'INDIVIDUAL42893',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'global',
				resourceId: 'GLOBAL58588',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'unidade',
				resourceId: 'UNIDADE_ORGANICA38383',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'horario',
				resourceId: 'HORARIO56549',
				fnResources,
			}),
		]

	}
}

/**
 * The s_module array.
 */
export class QArrayS_module
{
	constructor(lang)
	{
		this.type = 'C'
		this.pluralName = 'MODULES33542'
		this.singularName = 'MODULE42049'

		this.currentLang = typeof lang === 'string' ? lang.replace('-', '').toUpperCase() : null
		this.itemsAlreadyRequested = false
		this.array = reactive([])

	}

	get elements()
	{
		if (!this.itemsAlreadyRequested)
		{
			this.itemsAlreadyRequested = true
			netAPI.fetchDynamicArray('S_module', this.currentLang, (res) => _merge(this.array, res))
		}

		return this.array
	}
}

/**
 * The s_prstat array.
 */
export class QArrayS_prstat
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'ESTADOS_DO_PROCESSO59118'
		this.singularName = 'ESTADO_DO_PROCESSO07540'

		this.elements = [
			new Option({
				num: 1,
				key: 'EE',
				resourceId: 'EM_EXECUCAO53706',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'FE',
				resourceId: 'EM_FILA_DE_ESPERA21822',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'AG',
				resourceId: 'AGENDADO_PARA_EXECUC11223',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'T',
				resourceId: 'TERMINADO46276',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'C',
				resourceId: 'CANCELADO05982',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 'NR',
				resourceId: 'NAO_RESPONDE33275',
				fnResources,
			}),
			new Option({
				num: 7,
				key: 'AB',
				resourceId: 'ABORTADO52378',
				fnResources,
			}),
			new Option({
				num: 8,
				key: 'AC',
				resourceId: 'A_CANCELAR43988',
				fnResources,
			}),
		]

	}
}

/**
 * The s_resul array.
 */
export class QArrayS_resul
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'RESULTADOS20000'
		this.singularName = 'RESULTADO50955'

		this.elements = [
			new Option({
				num: 1,
				key: 'ok',
				resourceId: 'SUCESSO65230',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'er',
				resourceId: 'ERRO38355',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'wa',
				resourceId: 'AVISO03237',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'c',
				resourceId: 'CANCELADO05982',
				fnResources,
			}),
		]

	}
}

/**
 * The s_roles array.
 */
export class QArrayS_roles
{
	constructor(lang)
	{
		this.type = 'C'
		this.pluralName = 'ROLE60946'
		this.singularName = 'ROLES61449'

		this.currentLang = typeof lang === 'string' ? lang.replace('-', '').toUpperCase() : null
		this.itemsAlreadyRequested = false
		this.array = reactive([])

	}

	get elements()
	{
		if (!this.itemsAlreadyRequested)
		{
			this.itemsAlreadyRequested = true
			netAPI.fetchDynamicArray('S_roles', this.currentLang, (res) => _merge(this.array, res))
		}

		return this.array
	}
}

/**
 * The s_tpproc array.
 */
export class QArrayS_tpproc
{
	constructor(lang)
	{
		this.type = 'C'
		this.pluralName = 'TIPOS_DE_PROCESSOS46922'
		this.singularName = 'TIPO_DE_PROCESSO20818'

		this.currentLang = typeof lang === 'string' ? lang.replace('-', '').toUpperCase() : null
		this.itemsAlreadyRequested = false
		this.array = reactive([])

	}

	get elements()
	{
		if (!this.itemsAlreadyRequested)
		{
			this.itemsAlreadyRequested = true
			netAPI.fetchDynamicArray('S_tpproc', this.currentLang, (res) => _merge(this.array, res))
		}

		return this.array
	}
}

/**
 * The SEXO array.
 */
export class QArraySexo
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'SEXO_DA_PESSOAS63459'
		this.singularName = 'SEXO_DA_PESSOA59108'

		this.elements = [
			new Option({
				num: 1,
				key: 'Masculino',
				resourceId: 'MALE32397',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'Feminino',
				resourceId: 'FEMALE46107',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'Outro',
				resourceId: 'OTHER37293',
				fnResources,
			}),
		]

	}
}

/**
 * The SpaceTyp array.
 */
export class QArraySpacetyp
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'SPACE_TYPES45728'
		this.singularName = 'SPACE_TYPE42493'

		this.elements = [
			new Option({
				num: 1,
				key: 'F',
				resourceId: 'FLOOR19993',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'R',
				resourceId: 'ROOM50867',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'S',
				resourceId: 'SHELF59898',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'Y',
				resourceId: 'YARD38498',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'A',
				resourceId: 'ANOTHER00311',
				fnResources,
			}),
		]

	}
}

/**
 * The TipoArti array.
 */
export class QArrayTipoarti
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'TYPE_OF_ARTICLE43082'
		this.singularName = 'ARTICLE_TYPES43343'

		this.elements = [
			new Option({
				num: 1,
				key: 'B',
				resourceId: 'VERY_MOBILE37160',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'V',
				resourceId: 'VEHICLE49593',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'I',
				resourceId: 'PROPERTY43977',
				fnResources,
			}),
		]

	}
}

/**
 * The tipoCond array.
 */
export class QArrayTipocond
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'TIPOS_DE_CONDICAO05146'
		this.singularName = 'TIPO_DE_CONDICAO09986'

		this.elements = [
			new Option({
				num: 1,
				key: 'W',
				resourceId: 'WARNING52043',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'E',
				resourceId: 'ERRO38355',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'M',
				resourceId: 'OBRIGATORIO46267',
				fnResources,
			}),
			new Option({
				num: 4,
				key: 'I',
				resourceId: 'INSERIR43365',
				fnResources,
			}),
			new Option({
				num: 5,
				key: 'U',
				resourceId: 'EDITAR11616',
				fnResources,
			}),
			new Option({
				num: 6,
				key: 'V',
				resourceId: 'QUERY30986',
				fnResources,
			}),
			new Option({
				num: 7,
				key: 'D',
				resourceId: 'DELETE48637',
				fnResources,
			}),
		]

	}
}

/**
 * The typen array.
 */
export class QArrayTypen
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'N'
		this.pluralName = 'TYPES__NUMERIC_37826'
		this.singularName = 'TYPE__NUMERIC_54341'

		this.elements = [
			new Option({
				num: 1,
				key: 1,
				resourceId: 'TYPE_119298',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 2,
				resourceId: 'TYPE_219663',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 3,
				resourceId: 'TYPE_319548',
				fnResources,
			}),
		]

	}
}

/**
 * The typet array.
 */
export class QArrayTypet
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'C'
		this.pluralName = 'TYPES___TEXT_11871'
		this.singularName = 'TYPE__TEXT_50814'

		this.elements = [
			new Option({
				num: 1,
				key: 'A',
				resourceId: 'TYPE_A35795',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 'B',
				resourceId: 'TYPE_B36158',
				fnResources,
			}),
			new Option({
				num: 3,
				key: 'C',
				resourceId: 'TYPE_C35981',
				fnResources,
			}),
		]

	}
}

/**
 * The YesNo array.
 */
export class QArrayYesno
{
	// eslint-disable-next-line no-unused-vars
	constructor(fnResources)
	{
		this.type = 'L'
		this.pluralName = 'YES___NO18321'
		this.singularName = 'YES___NO18321'

		this.elements = [
			new Option({
				num: 1,
				key: 0,
				resourceId: 'NOT_IN_USE41845',
				fnResources,
			}),
			new Option({
				num: 2,
				key: 1,
				resourceId: 'IN_USE42606',
				fnResources,
			}),
		]

	}
}


export default {
	QArrayA_categ,
	QArrayA_facili,
	QArrayA_nivele,
	QArrayAccustos,
	QArrayAcondtst,
	QArrayActive,
	QArrayActivida,
	QArrayAdatqual,
	QArrayAddresst,
	QArrayAddressu,
	QArrayAddrtyco,
	QArrayAestadm,
	QArrayAestado,
	QArrayAestrate,
	QArrayAganttun,
	QArrayAhorasse,
	QArrayAlaglead,
	QArrayAlocregr,
	QArrayAmeses,
	QArrayAparttyp,
	QArrayAperacum,
	QArrayAperiodi,
	QArrayApolarid,
	QArrayApriorid,
	QArrayAreatecn,
	QArrayArecolha,
	QArrayAscorout,
	QArrayAside,
	QArrayAsimnao,
	QArrayAssettyp,
	QArrayAtipoind,
	QArrayAtipopro,
	QArrayAtipouo,
	QArrayAtpactiv,
	QArrayAtpacumu,
	QArrayAtpavali,
	QArrayAtpbonif,
	QArrayAtpindic,
	QArrayAtpmes,
	QArrayAtpmeta,
	QArrayAtpscore,
	QArrayAtpseg,
	QArrayAvisperi,
	QArrayBaggage,
	QArrayBagtype,
	QArrayBankcomp,
	QArrayBuildtyp,
	QArrayClass,
	QArrayClassnum,
	QArrayDatatype,
	QArrayDecplace,
	QArrayDispstat,
	QArrayDsiponib,
	QArrayFaciltyp,
	QArrayFreqempr,
	QArrayGenconta,
	QArrayGender,
	QArrayGenero,
	QArrayGpsinput,
	QArrayIdenttyp,
	QArrayMonths,
	QArrayObjetype,
	QArrayPhonepre,
	QArrayPrimviag,
	QArrayQartipqu,
	QArrayRadiobtn,
	QArrayS_modpro,
	QArrayS_module,
	QArrayS_prstat,
	QArrayS_resul,
	QArrayS_roles,
	QArrayS_tpproc,
	QArraySexo,
	QArraySpacetyp,
	QArrayTipoarti,
	QArrayTipocond,
	QArrayTypen,
	QArrayTypet,
	QArrayYesno,
}
