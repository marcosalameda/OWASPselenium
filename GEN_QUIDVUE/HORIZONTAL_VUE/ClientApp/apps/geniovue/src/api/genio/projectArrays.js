/* eslint-disable no-unused-vars */
import { computed, reactive } from 'vue'
import _merge from 'lodash-es/merge'

import netAPI from '@quidgest/clientapp/network'
/* eslint-enable no-unused-vars */
/**
 * The a_categ array.
 */
export const QArrayA_categ = {
	type: 'C',
	pluralName: 'a_categ',
	singularName: 'a_categ',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'G',
				resourceId: 'GLOBAL58588',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'N',
				resourceId: 'NACIONAL39968',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The a_facili array.
 */
export const QArrayA_facili = {
	type: 'C',
	pluralName: 'a_facili',
	singularName: 'a_facili',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'F',
				resourceId: 'FACTIBLE13061',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'ND',
				resourceId: 'NO_DISPONIBLE08299',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'NA',
				resourceId: 'NO_APLICA13087',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'NF',
				resourceId: 'NO_FACTIBLE14448',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The a_nivele array.
 */
export const QArrayA_nivele = {
	type: 'C',
	pluralName: 'a_nivele',
	singularName: 'a_nivele',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'I',
				resourceId: 'NIVEL_I61863',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'II',
				resourceId: 'NIVEL_II23028',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'III',
				resourceId: 'NIVEL_III58608',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aCCustos array.
 */
export const QArrayAccustos = {
	type: 'C',
	pluralName: 'AFETACAO_CONTABILIDA13834',
	singularName: 'AFETACAO_CONTABILIDA13834',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'S',
				resourceId: 'SIM28552',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'N',
				resourceId: 'NAO06521',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'C',
				resourceId: 'NAO_EXISTE_CC__CONTA42559',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aCondTst array.
 */
export const QArrayAcondtst = {
	type: 'C',
	pluralName: 'CONDICOES28572',
	singularName: 'CONDICAO44011',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'BLOCK',
				resourceId: 'BLOCK_FIELD33648',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'HIDE',
				resourceId: 'HIDE_FIELD21772',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'REQUIRE',
				resourceId: 'REQUIRE_FIELD20203',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The Active array.
 */
export const QArrayActive = {
	type: 'C',
	pluralName: 'ACTIVE03270',
	singularName: 'ACTIVE03270',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'Y',
				resourceId: 'YES34196',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'N',
				resourceId: 'NO57340',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The activida array.
 */
export const QArrayActivida = {
	type: 'L',
	pluralName: 'ACTIVIDADE44684',
	singularName: 'ACTIVIDADE44684',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'ACTIVE03270',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 0,
				resourceId: 'INACTIVO19228',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The adatqual array.
 */
export const QArrayAdatqual = {
	type: 'N',
	pluralName: 'adatqual',
	singularName: 'adatqual',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 5,
				resourceId: 'MUITO_BOA49280',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 4,
				resourceId: 'BOA18662',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 3,
				resourceId: 'RAZOAVEL14967',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 2,
				resourceId: 'MA11547',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 1,
				resourceId: 'MUITO_MA26606',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The AddressT array.
 */
export const QArrayAddresst = {
	type: 'C',
	pluralName: 'ADDRESS_TYPES26269',
	singularName: 'ADDRESS_TYPE12455',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'postal',
				resourceId: 'POSTAL23608',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_109335067',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 2,
				key: 'physical',
				resourceId: 'PHYSICAL14657',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_109432218',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 3,
				key: 'both',
				resourceId: 'POSTAL___PHYSICAL44710',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_109531561',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
		]
	},
}

/**
 * The AddressU array.
 */
export const QArrayAddressu = {
	type: 'C',
	pluralName: 'ADDRESS_USES22490',
	singularName: 'ADDRESS_USE16014',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'home',
				resourceId: 'HOME23643',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_108747561',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 2,
				key: 'work',
				resourceId: 'WORK50501',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_108820200',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 3,
				key: 'temp',
				resourceId: 'TEMPORARY00792',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_108919783',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 4,
				key: 'old',
				resourceId: 'OLD___INCORRECT09129',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_109034838',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 5,
				key: 'billing',
				resourceId: 'BILLING63268',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_109131109',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
		]
	},
}

/**
 * The addrtyco array.
 */
export const QArrayAddrtyco = {
	type: 'N',
	pluralName: 'ADDRESS_TYPE12455',
	singularName: 'ADDRESS_TYPE12455',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'BILL_TO10407',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'SHIP_TO13065',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aestadM array.
 */
export const QArrayAestadm = {
	type: 'C',
	pluralName: 'aestadM',
	singularName: 'aestadM',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'DELAYED',
				resourceId: 'ADIADO25085',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'COMPLETE',
				resourceId: 'CONCLUIDO29216',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'ONCOURSE',
				resourceId: 'EM_CURSO28102',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'CLOSED',
				resourceId: 'ENCERRADO36123',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'STOPPED',
				resourceId: 'PARADO62293',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: 'PLANNED',
				resourceId: 'PLANEADO30031',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aestado array.
 */
export const QArrayAestado = {
	type: 'C',
	pluralName: 'aestado',
	singularName: 'aestado',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'DELAYED',
				resourceId: 'ADIADA24595',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'COMPLETE',
				resourceId: 'CONCLUIDA26734',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'ONCOURSE',
				resourceId: 'EM_CURSO28102',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'CLOSED',
				resourceId: 'ENCERRADA29062',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'STOPPED',
				resourceId: 'PARADA59671',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: 'PLANNED',
				resourceId: 'PLANEADA29857',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aestrate array.
 */
export const QArrayAestrate = {
	type: 'C',
	pluralName: 'aestrate',
	singularName: 'aestrate',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'P',
				resourceId: 'PRODUTIVIDADE55481',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'C',
				resourceId: 'CRESCIMENTO17722',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'A',
				resourceId: 'PROD__E_CRESC_35758',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'N',
				resourceId: 'N_A00986',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aGanttUn array.
 */
export const QArrayAganttun = {
	type: 'C',
	pluralName: 'ESCALAS_DOS_GRAFICOS11509',
	singularName: 'ESCALA_DO_GRAFICO_GA17953',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'day',
				resourceId: 'DAY27593',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'week',
				resourceId: 'SEMANA00471',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'month',
				resourceId: 'MES61580',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aHorasSe array.
 */
export const QArrayAhorasse = {
	type: 'N',
	pluralName: 'NO_HORAS_DE_TRABALHO54995',
	singularName: 'NO_HORAS_DE_TRABALHO54995',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 35,
				resourceId: '_3554693',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 40,
				resourceId: '_4000330',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The alaglead array.
 */
export const QArrayAlaglead = {
	type: 'C',
	pluralName: 'alaglead',
	singularName: 'alaglead',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'LG',
				resourceId: 'LAG58416',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'LD',
				resourceId: 'LEAD45626',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'RE',
				resourceId: 'RESULTADOS20000',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'EF',
				resourceId: 'EFICACIA03259',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aLocRegr array.
 */
export const QArrayAlocregr = {
	type: 'C',
	pluralName: 'LOCAIS_DA_REGRA25886',
	singularName: 'LOCAL_DA_REGRA49987',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'T',
				resourceId: 'TABELA44049',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'F',
				resourceId: 'FORM54242',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aMeses array.
 */
export const QArrayAmeses = {
	type: 'C',
	pluralName: 'aMeses',
	singularName: 'aMeses',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: '1',
				resourceId: 'JANEIRO25316',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: '2',
				resourceId: 'FEVEREIRO25443',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: '3',
				resourceId: 'MARCO22234',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: '4',
				resourceId: 'ABRIL58220',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: '5',
				resourceId: 'MAIO10443',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: '6',
				resourceId: 'JUNHO15214',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 7,
				key: '7',
				resourceId: 'JULHO20764',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 8,
				key: '8',
				resourceId: 'AGOSTO05568',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 9,
				key: '9',
				resourceId: 'SETEMBRO19956',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 10,
				key: '10',
				resourceId: 'OUTUBRO17690',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 11,
				key: '11',
				resourceId: 'NOVEMBRO18614',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 12,
				key: '12',
				resourceId: 'DEZEMBRO01950',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aparttyp array.
 */
export const QArrayAparttyp = {
	type: 'N',
	pluralName: 'APARTMENT_TYPES10946',
	singularName: 'APARTMENT_TYPE01925',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 0,
				resourceId: 'T036607',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 1,
				resourceId: 'T133664',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 2,
				resourceId: 'T233813',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 3,
				resourceId: 'T3_AND_OTHERS19907',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aPerAcum array.
 */
export const QArrayAperacum = {
	type: 'C',
	pluralName: 'aPerAcum',
	singularName: 'aPerAcum',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'P',
				resourceId: 'PERIODO18539',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'A',
				resourceId: 'ACUMULADO06566',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aperiodi array.
 */
export const QArrayAperiodi = {
	type: 'N',
	pluralName: 'PERIODICIDADES_DE_RE37021',
	singularName: 'PERIODICIDADE_DE_REC55654',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'HORARIO56549',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'DIARIO16236',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 3,
				resourceId: 'SEMANAL19148',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 4,
				resourceId: 'MENSAL53343',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 10,
				resourceId: 'BIMESTRAL50606',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: 5,
				resourceId: 'TRIMESTRAL58756',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 7,
				key: 6,
				resourceId: 'SEMESTRAL24523',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 8,
				key: 7,
				resourceId: 'ANUAL55239',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 9,
				key: 9,
				resourceId: 'VARIAVEL46886',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 10,
				key: 11,
				resourceId: 'BIANUAL25027',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 11,
				key: 12,
				resourceId: '_5_ANOS50688',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The apolarid array.
 */
export const QArrayApolarid = {
	type: 'C',
	pluralName: 'apolarid',
	singularName: 'apolarid',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'CR',
				resourceId: 'MAIOR_E_MELHOR43422',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'DE',
				resourceId: 'MENOR_E_MELHOR57832',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'C',
				resourceId: 'CENTRADA33827',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The apriorid array.
 */
export const QArrayApriorid = {
	type: 'C',
	pluralName: 'apriorid',
	singularName: 'apriorid',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'HIGH',
				resourceId: 'HIGH47127',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'MEDIUM',
				resourceId: 'AVERAGE50639',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'LOW',
				resourceId: 'LOW09468',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The AreaTecn array.
 */
export const QArrayAreatecn = {
	type: 'C',
	pluralName: 'TECHNICAL_AREAS40861',
	singularName: 'TECHNICAL_AREA50773',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'M',
				resourceId: 'MECHANICAL47923',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'E',
				resourceId: 'ELECTRICITY31511',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'L',
				resourceId: 'CLEANING01363',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'G',
				resourceId: 'MANAGEMENT02985',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aRecolha array.
 */
export const QArrayArecolha = {
	type: 'C',
	pluralName: 'aRecolha',
	singularName: 'aRecolha',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'A',
				resourceId: 'UTILIZACAO_DE_DADOS_26961',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'D',
				resourceId: 'RECOLHA_DIRETA_DOS_D20088',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'C',
				resourceId: 'CONJUNTO_DE_DADOS_ES36750',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aScorOut array.
 */
export const QArrayAscorout = {
	type: 'C',
	pluralName: 'aScorOut',
	singularName: 'aScorOut',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'TREE',
				resourceId: 'ARVORE44219',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'LIST',
				resourceId: 'LISTA13474',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aSide array.
 */
export const QArrayAside = {
	type: 'C',
	pluralName: 'LADOS13995',
	singularName: 'LADO49085',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'L',
				resourceId: 'LEFT43751',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'R',
				resourceId: 'RIGHT33051',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'T',
				resourceId: 'TOP31303',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'B',
				resourceId: 'BOTTOM53759',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aSimNao array.
 */
export const QArrayAsimnao = {
	type: 'C',
	pluralName: 'SIM___NAO31594',
	singularName: 'SIM___NAO31594',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: '0',
				resourceId: '_48180',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'S',
				resourceId: 'SIM28552',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'N',
				resourceId: 'NAO06521',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The assetCategory array.
 */
export const QArrayAssetcategory = {
	type: 'C',
	pluralName: 'ASSET_CATEGORY65154',
	singularName: 'ASSET_CATEGORIES64344',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'RE',
				resourceId: 'REAL_ESTATE07188',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'asset-real-estate',
					type: 'svg',
				},
			},
			{
				num: 2,
				key: 'VCL',
				resourceId: 'VEHICLE49593',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'asset-vehicle',
					type: 'svg',
				},
			},
			{
				num: 3,
				key: 'EQUIP',
				resourceId: 'EQUIPMENT03632',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'asset-equipment',
					type: 'svg',
				},
			},
			{
				num: 4,
				key: 'FNTR',
				resourceId: 'FURNITURE42200',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'asset-furniture',
					type: 'svg',
				},
			},
		]
	},
}

/**
 * The assetTags array.
 */
export const QArrayAssettags = {
	type: 'N',
	pluralName: 'ASSET_TAGS23725',
	singularName: 'ASSET_TAG59305',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'URGENT40554',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'asset-warning',
					type: 'svg',
				},
			},
			{
				num: 2,
				key: 2,
				resourceId: 'CHECKED31708',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'asset-check-mark',
					type: 'svg',
				},
			},
			{
				num: 3,
				key: 3,
				resourceId: 'IN_REPAIR33602',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'asset-tools-repair',
					type: 'svg',
				},
			},
			{
				num: 4,
				key: 4,
				resourceId: 'IMPORTANT21753',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'asset-pin-priority',
					type: 'svg',
				},
			},
		]
	},
}

/**
 * The AssetTyp array.
 */
export const QArrayAssettyp = {
	type: 'C',
	pluralName: 'ASSET_TYPES33420',
	singularName: 'ASSET_TYPE02033',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'E',
				resourceId: 'EQUIPMENT03632',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'C',
				resourceId: 'COMMODITY03939',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'B',
				resourceId: 'BUILDING13586',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'L',
				resourceId: 'LAND27818',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'O',
				resourceId: 'OFFICE_SUPPLIES00254',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The atipoInd array.
 */
export const QArrayAtipoind = {
	type: 'C',
	pluralName: 'TIPOS_DE_INDICADOR06486',
	singularName: 'TIPO_DE_INDICADOR41971',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'IMPACT',
				resourceId: 'IMPACTO36269',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'RESULT',
				resourceId: 'RESULTADOS20000',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'PROCES',
				resourceId: 'PROCESSOS12945',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'PRODU',
				resourceId: 'PRODUTO57112',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The atipopro array.
 */
export const QArrayAtipopro = {
	type: 'C',
	pluralName: 'atipopro',
	singularName: 'atipopro',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'PR',
				resourceId: 'PROGRAMA08229',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'PJ',
				resourceId: 'PROYECTO07336',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'C',
				resourceId: 'COMPONENTE41748',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'A',
				resourceId: 'ACCION51528',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The atipouo array.
 */
export const QArrayAtipouo = {
	type: 'C',
	pluralName: 'TIPOS_DE_UNIDADE_ORG29246',
	singularName: 'TIPO_DE_UNIDADE_ORG_11394',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'I',
				resourceId: 'INTERNO52273',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'E',
				resourceId: 'EXTERNO12394',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aTpActiv array.
 */
export const QArrayAtpactiv = {
	type: 'C',
	pluralName: 'aTpActiv',
	singularName: 'aTpActiv',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: '0',
				resourceId: 'RECORRENTE45302',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: '1',
				resourceId: 'ENCADEADA10510',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The atpacumu array.
 */
export const QArrayAtpacumu = {
	type: 'C',
	pluralName: 'atpacumu',
	singularName: 'atpacumu',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'U',
				resourceId: 'VALOR_UNICO39183',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'S',
				resourceId: 'SOMATORIO37638',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'M',
				resourceId: 'AVERAGE50639',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'C',
				resourceId: 'CONTAGEM11714',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aTpAvali array.
 */
export const QArrayAtpavali = {
	type: 'C',
	pluralName: 'aTpAvali',
	singularName: 'aTpAvali',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'T',
				resourceId: 'DIRIGENTES_E_FUNCION02178',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'D',
				resourceId: 'DIRIGENTES24546',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'F',
				resourceId: 'FUNCIONARIOS50597',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'O',
				resourceId: 'UNIDADE_ORGANICA59623',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aTpBonif array.
 */
export const QArrayAtpbonif = {
	type: 'C',
	pluralName: 'aTpBonif',
	singularName: 'aTpBonif',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'A',
				resourceId: 'AUTOMATICAS54417',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'M',
				resourceId: 'MANUAIS00572',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aTpIndic array.
 */
export const QArrayAtpindic = {
	type: 'C',
	pluralName: 'aTpIndic',
	singularName: 'aTpIndic',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'Q',
				resourceId: 'QUALIDADE42726',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'E',
				resourceId: 'EFICIENCIA22805',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'F',
				resourceId: 'EFICACIA33755',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aTpMes array.
 */
export const QArrayAtpmes = {
	type: 'C',
	pluralName: 'aTpMes',
	singularName: 'aTpMes',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'S',
				resourceId: 'PERIODO_SEGUINTE40793',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'E',
				resourceId: 'PERIODO_ACTUAL45198',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aTpMeta array.
 */
export const QArrayAtpmeta = {
	type: 'C',
	pluralName: 'aTpMeta',
	singularName: 'aTpMeta',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'SUM',
				resourceId: 'SOMA06480',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'AVG',
				resourceId: 'AVERAGE50639',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'NAN',
				resourceId: 'NENHUMA23117',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The atpscore array.
 */
export const QArrayAtpscore = {
	type: 'C',
	pluralName: 'atpscore',
	singularName: 'atpscore',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'EVAL',
				resourceId: 'AVALIACAO18442',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'MONI',
				resourceId: 'MONITORIZACAO41068',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aTpSeg array.
 */
export const QArrayAtpseg = {
	type: 'C',
	pluralName: 'TIPOS_DE_SEGMENTOS32926',
	singularName: 'TIPO_DE_SEGMENTO49650',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'SEX',
				resourceId: 'SEXO52099',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'SEC',
				resourceId: 'SECTOR41481',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The authentication_options array.
 */
export const QArrayAuthentication_options = {
	type: 'C',
	pluralName: 'AUTHENTICATION_OPTIO56668',
	singularName: 'AUTHENTICATION_OPTIO56668',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'D',
				resourceId: 'DEFAULT10658',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'L',
				resourceId: 'LIGHT29213',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'S',
				resourceId: 'SECONDARY47548',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The aVisPeri array.
 */
export const QArrayAvisperi = {
	type: 'N',
	pluralName: 'aVisPeri',
	singularName: 'aVisPeri',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 4,
				resourceId: 'MENSAL53343',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 5,
				resourceId: 'TRIMESTRAL58756',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 6,
				resourceId: 'SEMESTRAL24523',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 7,
				resourceId: 'ANUAL55239',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The Baggage array.
 */
export const QArrayBaggage = {
	type: 'C',
	pluralName: 'BAGGAGES58641',
	singularName: 'BAGGAGE61714',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: '0',
				resourceId: 'CABIN___CHECKIN_LUGG64007',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: '1',
				resourceId: 'CABIN_LUGGAGE_ONLY28929',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The Bagtype array.
 */
export const QArrayBagtype = {
	type: 'C',
	pluralName: 'BAGGAGE_TYPES55106',
	singularName: 'BAGGAGE_TYPE35947',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: '0',
				resourceId: 'CABIN___CHECKIN_LUGG64007',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: '1',
				resourceId: 'CABIN_LUGGAGE_ONLY33466',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The bankComp array.
 */
export const QArrayBankcomp = {
	type: 'C',
	pluralName: 'BANK_COMPANIES56474',
	singularName: 'BANK_COMPANY19319',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'ST',
				resourceId: 'SANTANDER27925',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'CB',
				resourceId: 'CAIXA_BANK13668',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'IG',
				resourceId: 'ING19160',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'NB',
				resourceId: 'NOVOBANCO44101',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'AB',
				resourceId: 'ACTIVOBANK40861',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: 'OB',
				resourceId: 'OPENBANK20445',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The buildtyp array.
 */
export const QArrayBuildtyp = {
	type: 'C',
	pluralName: 'BUILDING_TYPES23872',
	singularName: 'BUILDING_TYPE57152',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'A',
				resourceId: 'APARTMENT12665',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'H',
				resourceId: 'HOUSE01993',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'O',
				resourceId: 'OTHER37293',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The CITY array.
 */
export const QArrayCity = {
	type: 'C',
	pluralName: 'CITIES41573',
	singularName: 'CITIES41573',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'LS',
				resourceId: 'LISBOA65493',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'CS',
				resourceId: 'CASCAIS37276',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'PO',
				resourceId: 'PORTO56181',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'GM',
				resourceId: 'GUIMARAES11953',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The CLASS array.
 */
export const QArrayClass = {
	type: 'C',
	pluralName: 'CLASSE_DA_VIAGEM28403',
	singularName: 'CLASSE_DA_VIAGEM28403',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: '1C',
				resourceId: '_1ACLASSE52698',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: '2C',
				resourceId: '_2ACLASSE04789',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'CE',
				resourceId: 'CLASSE_ECONOMICA36282',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The CLASSNUM array.
 */
export const QArrayClassnum = {
	type: 'N',
	pluralName: 'CLASS_DA_VIAGEM34402',
	singularName: 'CLASS_DA_VIAGEM34402',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: '_1O_CLASSE18418',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_114530146',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: '_2A_CLASSE50409',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_114630263',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 3,
				key: 3,
				resourceId: 'ECONOMICA05942',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The componenticons array.
 */
export const QArrayComponenticons = {
	type: 'N',
	pluralName: 'COMPONENTS_ICON53573',
	singularName: 'COMPONENTS_ICON53573',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 2,
				resourceId: 'DATA_INPUT23684',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'components-class-DataInput-01',
					type: 'svg',
				},
			},
			{
				num: 2,
				key: 6,
				resourceId: 'DATA_DISPLAY32113',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'components-class-DataDisplay-02',
					type: 'svg',
				},
			},
			{
				num: 3,
				key: 3,
				resourceId: 'DATA_GRID17400',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'components-class-DataGrid',
					type: 'svg',
				},
			},
			{
				num: 4,
				key: 4,
				resourceId: 'ACTION41832',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'components-class-Action',
					type: 'svg',
				},
			},
			{
				num: 5,
				key: 5,
				resourceId: 'CONTAINER62757',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'components-class-LayoutContainer',
					type: 'svg',
				},
			},
			{
				num: 6,
				key: 8,
				resourceId: 'RELATIONAL_STRUCTURE39801',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'components-class-relationalStructure',
					type: 'svg',
				},
			},
			{
				num: 7,
				key: 7,
				resourceId: 'INTERACTIVE04535',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'components-class-AdvancedInteractive',
					type: 'svg',
				},
			},
			{
				num: 8,
				key: 1,
				resourceId: 'MEDIA07084',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'components-class-media',
					type: 'svg',
				},
			},
		]
	},
}

/**
 * The DataType array.
 */
export const QArrayDatatype = {
	type: 'C',
	pluralName: 'DATA_TYPES15706',
	singularName: 'DATA_TYPE47159',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'T',
				resourceId: 'TEXT04938',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'N',
				resourceId: 'NUMERIC19292',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'D',
				resourceId: 'DATE18475',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The DecPlace array.
 */
export const QArrayDecplace = {
	type: 'N',
	pluralName: 'DECIMAL_PLACES62575',
	singularName: 'DECIMAL_PLACES62575',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 0,
				resourceId: 'NONE51124',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 1,
				resourceId: 'ONE44350',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 2,
				resourceId: 'TWO16230',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 3,
				resourceId: 'THREE09760',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 4,
				resourceId: 'FOUR61011',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The DispStat array.
 */
export const QArrayDispstat = {
	type: 'C',
	pluralName: 'DISPATCH_STATUS62739',
	singularName: 'DISPATCH_STATUS62739',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'I',
				resourceId: 'PREPARING26576',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'P',
				resourceId: 'PREPARED38522',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'D',
				resourceId: 'DISPATCHED04380',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The Dropdown array.
 */
export const QArrayDropdown = {
	type: 'N',
	pluralName: 'DROPDOWN57413',
	singularName: 'DROPDOWN57413',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'DROPDOWN51902',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'INLINE64198',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The dsiponib array.
 */
export const QArrayDsiponib = {
	type: 'C',
	pluralName: 'AVAILABILITY56489',
	singularName: 'AVAILABILITY56489',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'A',
				resourceId: 'DISPONIVEL07725',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'D',
				resourceId: 'DESCONTINUADO02736',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'O',
				resourceId: 'SEM_EXISTENCIAS63530',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The FacilTyp array.
 */
export const QArrayFaciltyp = {
	type: 'C',
	pluralName: 'FACILITY_TYPES57319',
	singularName: 'FACILITY_TYPE44577',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'B',
				resourceId: 'BUILDING13586',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'C',
				resourceId: 'CONTAINER_DEPOT28181',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'P',
				resourceId: 'PARK62080',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'S',
				resourceId: 'SHIP04380',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'A',
				resourceId: 'AIRPLANE10508',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: 'O',
				resourceId: 'OFFICE22960',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The feedback array.
 */
export const QArrayFeedback = {
	type: 'N',
	pluralName: 'USER_FEEDBACK44195',
	singularName: 'USER_FEEDBACK44195',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: '_1_STAR25353',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: '_2_STARS16357',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 3,
				resourceId: '_3_STARS22471',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 4,
				resourceId: '_4_STARS65305',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 5,
				resourceId: '_5_STARS57620',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The FreqEmpr array.
 */
export const QArrayFreqempr = {
	type: 'N',
	pluralName: 'LOAN_FREQUENCIES00512',
	singularName: 'LOAN_FREQUENCY00701',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 7,
				resourceId: 'AVERAGE50639',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '___1040299',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
				icon: {
					icon: 'average',
					type: 'svg',
				},
			},
			{
				num: 2,
				key: 1,
				resourceId: 'HIGH47127',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '___1140948',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
				icon: {
					icon: 'high',
					type: 'svg',
				},
			},
			{
				num: 3,
				key: 15,
				resourceId: 'LOW09468',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '___1238797',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
				icon: {
					icon: 'low',
					type: 'svg',
				},
			},
			{
				num: 4,
				key: 30,
				resourceId: 'RARE54339',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '___1337918',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
				icon: {
					icon: 'rare',
					type: 'svg',
				},
			},
		]
	},
}

/**
 * The GenConta array.
 */
export const QArrayGenconta = {
	type: 'C',
	pluralName: 'CONTACT_GENRES29532',
	singularName: 'CONTACT_TYPE65233',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'T',
				resourceId: 'PHONE56703',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'E',
				resourceId: 'EMAIL25170',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'M',
				resourceId: 'ADDRESS04342',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'O',
				resourceId: 'OTHER37293',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The Gender array.
 */
export const QArrayGender = {
	type: 'C',
	pluralName: 'ADMINISTRATIVE_GENDE39506',
	singularName: 'ADMINISTRATIVE_GENDE46518',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'M',
				resourceId: 'MALE32397',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'F',
				resourceId: 'FEMALE46107',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'O',
				resourceId: 'OTHER37293',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'U',
				resourceId: 'UNKNOWN49785',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The Genero array.
 */
export const QArrayGenero = {
	type: 'C',
	pluralName: 'GENERA04858',
	singularName: 'GENUS37471',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'M',
				resourceId: 'MALE32397',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '____715057',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 2,
				key: 'F',
				resourceId: 'FEMALE46107',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '____821504',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 3,
				key: 'I',
				resourceId: 'UNDIFFERENTIATED28573',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '____921651',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
		]
	},
}

/**
 * The GpsInput array.
 */
export const QArrayGpsinput = {
	type: 'C',
	pluralName: 'GPS_INPUT13625',
	singularName: 'GPS_INPUT13625',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'L',
				resourceId: 'LATITUDE_AND_LONGITU45730',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'P',
				resourceId: 'POINT_IN_MAP40870',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The header array.
 */
export const QArrayHeader = {
	type: 'N',
	pluralName: 'HEADER12520',
	singularName: 'HEADER12520',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'HEADER35023',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'FOOTER43150',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The iconrating array.
 */
export const QArrayIconrating = {
	type: 'N',
	pluralName: 'RATING45804',
	singularName: 'RATING45804',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'GOOD01908',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: computed(() => `${this.$app.resourcesPath}Quidgest_no_signature_blue.png?v=3638`),
					type: 'img',
				},
			},
			{
				num: 2,
				key: 2,
				resourceId: 'AVERAGE50639',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'average',
					type: 'svg',
				},
			},
			{
				num: 3,
				key: 3,
				resourceId: 'BAD40612',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				icon: {
					icon: 'delete',
					type: 'svg',
				},
			},
		]
	},
}

/**
 * The IdentTyp array.
 */
export const QArrayIdenttyp = {
	type: 'C',
	pluralName: 'IDENTIFIER_TYPES53348',
	singularName: 'IDENTIFIER_TYPE60623',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'I',
				resourceId: 'INDIVIDUAL42893',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'R',
				resourceId: 'RETURNABLE23883',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The Months array.
 */
export const QArrayMonths = {
	type: 'N',
	pluralName: 'MONTHS54799',
	singularName: 'MONTH46035',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'JANUARY26193',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'FEBRUARY35476',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 3,
				resourceId: 'MARCH41748',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 4,
				resourceId: 'APRIL13388',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 5,
				resourceId: 'MAY55681',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: 6,
				resourceId: 'JUNE07845',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 7,
				key: 7,
				resourceId: 'JULY41219',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 8,
				key: 8,
				resourceId: 'AUGUST15687',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 9,
				key: 9,
				resourceId: 'SEPTEMBER29714',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 10,
				key: 10,
				resourceId: 'OCTOBER62709',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 11,
				key: 11,
				resourceId: 'NOVEMBER01178',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 12,
				key: 12,
				resourceId: 'DECEMBER43699',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The ObjeType array.
 */
export const QArrayObjetype = {
	type: 'N',
	pluralName: 'OBJECT_TYPE18115',
	singularName: 'OBJECT_TYPE18115',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'ACCOUNT64260',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'CONTACT59247',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The phonepre array.
 */
export const QArrayPhonepre = {
	type: 'C',
	pluralName: 'phonepre',
	singularName: 'PHONE_PREFIX34764',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'USA',
				resourceId: '_100989',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'ESP',
				resourceId: '_3417988',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'POR',
				resourceId: '_35140328',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The PRIMVIAG array.
 */
export const QArrayPrimviag = {
	type: 'L',
	pluralName: 'PRIMEIRA_VIAGEM55889',
	singularName: 'PRIMEIRA_VIAGEM55889',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'YES34196',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_112615498',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 2,
				key: 0,
				resourceId: 'NO57340',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_112514035',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
		]
	},
}

/**
 * The QarTipQu array.
 */
export const QArrayQartipqu = {
	type: 'C',
	pluralName: 'QarTipQu',
	singularName: 'QarTipQu',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: '1',
				resourceId: 'NAO_CONFORMIDADES28147',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: '2',
				resourceId: 'RECLAMACOES47951',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: '3',
				resourceId: 'ACCOES_PREVENTIVAS51089',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: '4',
				resourceId: 'ACCOES_CORRECTIVAS43681',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: '5',
				resourceId: 'ACCOES_DE_MELHORIA28491',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The quickfeedback array.
 */
export const QArrayQuickfeedback = {
	type: 'C',
	pluralName: 'QUICKFEEDBACK04451',
	singularName: 'QUICKFEEDBACK04451',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'A',
				resourceId: 'THE_INFORMATION_IS_H08002',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'B',
				resourceId: 'NEED_MORE_DETAILS27800',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'C',
				resourceId: 'I_CAN_T_FIND_WHAT_I_33456',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'D',
				resourceId: 'I_D_LIKE_TO_HAVE_MOR23763',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'E',
				resourceId: 'I_HAVE_TECHNICAL_ISS49055',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The RADIOBTN array.
 */
export const QArrayRadiobtn = {
	type: 'C',
	pluralName: 'RADIO_BUTTON21249',
	singularName: 'RADIO_BUTTON21249',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'Radio',
				resourceId: 'RADIO44833',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_112615498',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
			{
				num: 2,
				key: 'op2',
				resourceId: 'OPCAO_214220',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
				helpResourceId: '_112514035',
				get description() { return computed(() => vm.fnResources ? vm.fnResources(this.helpResourceId) : this.helpResourceId) },
			},
		]
	},
}

/**
 * The s_modpro array.
 */
export const QArrayS_modpro = {
	type: 'C',
	pluralName: 'MODOS_DE_PROCESSAMEN07602',
	singularName: 'MODO_DE_PROCESSAMENT14469',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'INDIV',
				resourceId: 'INDIVIDUAL42893',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'global',
				resourceId: 'GLOBAL58588',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'unidade',
				resourceId: 'UNIDADE_ORGANICA38383',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'horario',
				resourceId: 'HORARIO56549',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The s_module array.
 */
export const QArrayS_module = {
	type: 'C',
	pluralName: 'MODULES33542',
	singularName: 'MODULE42049',
	fnResources: null,
	setLanguage(lang)
	{
		if (lang)
			this.lang = lang.replace('-', '').toUpperCase()
		return this
	},
	get elements()
	{
		if (!this.array)
		{
			this.array = reactive([])
			netAPI.fetchDynamicArray('S_module', this.lang, (res) => _merge(this.array, res))
		}

		return this.array
	},
}

/**
 * The s_prstat array.
 */
export const QArrayS_prstat = {
	type: 'C',
	pluralName: 'ESTADOS_DO_PROCESSO59118',
	singularName: 'ESTADO_DO_PROCESSO07540',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'EE',
				resourceId: 'EM_EXECUCAO53706',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'FE',
				resourceId: 'EM_FILA_DE_ESPERA21822',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'AG',
				resourceId: 'AGENDADO_PARA_EXECUC11223',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'T',
				resourceId: 'TERMINADO46276',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'C',
				resourceId: 'CANCELADO05982',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: 'NR',
				resourceId: 'NAO_RESPONDE33275',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 7,
				key: 'AB',
				resourceId: 'ABORTADO52378',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 8,
				key: 'AC',
				resourceId: 'A_CANCELAR43988',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The s_resul array.
 */
export const QArrayS_resul = {
	type: 'C',
	pluralName: 'RESULTADOS20000',
	singularName: 'RESULTADO50955',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'ok',
				resourceId: 'SUCESSO65230',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'er',
				resourceId: 'ERRO38355',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'wa',
				resourceId: 'AVISO03237',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'c',
				resourceId: 'CANCELADO05982',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The s_roles array.
 */
export const QArrayS_roles = {
	type: 'C',
	pluralName: 'ROLE60946',
	singularName: 'ROLES61449',
	fnResources: null,
	setLanguage(lang)
	{
		if (lang)
			this.lang = lang.replace('-', '').toUpperCase()
		return this
	},
	get elements()
	{
		if (!this.array)
		{
			this.array = reactive([])
			netAPI.fetchDynamicArray('S_roles', this.lang, (res) => _merge(this.array, res))
		}

		return this.array
	},
}

/**
 * The s_tpproc array.
 */
export const QArrayS_tpproc = {
	type: 'C',
	pluralName: 'TIPOS_DE_PROCESSOS46922',
	singularName: 'TIPO_DE_PROCESSO20818',
	fnResources: null,
	setLanguage(lang)
	{
		if (lang)
			this.lang = lang.replace('-', '').toUpperCase()
		return this
	},
	get elements()
	{
		if (!this.array)
		{
			this.array = reactive([])
			netAPI.fetchDynamicArray('S_tpproc', this.lang, (res) => _merge(this.array, res))
		}

		return this.array
	},
}

/**
 * The SERVICETYPE array.
 */
export const QArrayServicetype = {
	type: 'C',
	pluralName: 'SERVICE_TYPE33071',
	singularName: 'SERVICE_TYPE33071',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'A',
				resourceId: 'CUSTOMER_SERVICE44538',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'B',
				resourceId: 'PLATFORM_PERFORMANCE46169',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'C',
				resourceId: 'OTHER37293',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The SEXO array.
 */
export const QArraySexo = {
	type: 'C',
	pluralName: 'SEXO_DA_PESSOAS63459',
	singularName: 'SEXO_DA_PESSOA59108',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'Masculino',
				resourceId: 'MALE32397',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'Feminino',
				resourceId: 'FEMALE46107',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'Outro',
				resourceId: 'OTHER37293',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The side array.
 */
export const QArraySide = {
	type: 'N',
	pluralName: 'SIDE35103',
	singularName: 'SIDE35103',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'LEFT43751',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'RIGHT33051',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The SpaceTyp array.
 */
export const QArraySpacetyp = {
	type: 'C',
	pluralName: 'SPACE_TYPES45728',
	singularName: 'SPACE_TYPE42493',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'F',
				resourceId: 'FLOOR19993',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'R',
				resourceId: 'ROOM50867',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'S',
				resourceId: 'SHELF59898',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'Y',
				resourceId: 'YARD38498',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'A',
				resourceId: 'ANOTHER00311',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The Sstatus array.
 */
export const QArraySstatus = {
	type: 'C',
	pluralName: 'SALE_STATUS08619',
	singularName: 'SALE_STATUS08619',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'AV',
				resourceId: 'AVAILABLE21624',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'SO',
				resourceId: 'SOLD59824',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'RT',
				resourceId: 'RENTED41828',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The TipoArti array.
 */
export const QArrayTipoarti = {
	type: 'C',
	pluralName: 'TYPE_OF_ARTICLE43082',
	singularName: 'ARTICLE_TYPES43343',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'B',
				resourceId: 'VERY_MOBILE37160',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'V',
				resourceId: 'VEHICLE49593',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'I',
				resourceId: 'PROPERTY43977',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The tipoCond array.
 */
export const QArrayTipocond = {
	type: 'C',
	pluralName: 'TIPOS_DE_CONDICAO05146',
	singularName: 'TIPO_DE_CONDICAO09986',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'W',
				resourceId: 'WARNING52043',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'E',
				resourceId: 'ERRO38355',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'M',
				resourceId: 'OBRIGATORIO46267',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 4,
				key: 'I',
				resourceId: 'INSERIR43365',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 5,
				key: 'U',
				resourceId: 'EDITAR11616',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 6,
				key: 'V',
				resourceId: 'QUERY30986',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 7,
				key: 'D',
				resourceId: 'DELETE48637',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The typen array.
 */
export const QArrayTypen = {
	type: 'N',
	pluralName: 'TYPES__NUMERIC_37826',
	singularName: 'TYPE__NUMERIC_54341',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'TYPE_119298',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'TYPE_219663',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 3,
				resourceId: 'TYPE_319548',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The typet array.
 */
export const QArrayTypet = {
	type: 'C',
	pluralName: 'TYPES___TEXT_11871',
	singularName: 'TYPE__TEXT_50814',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 'A',
				resourceId: 'TYPE_A35795',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 'B',
				resourceId: 'TYPE_B36158',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 'C',
				resourceId: 'TYPE_C35981',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The usefulfeedb array.
 */
export const QArrayUsefulfeedb = {
	type: 'N',
	pluralName: 'USEFUL_FEEDBACK43215',
	singularName: 'USEFUL_FEEDBACK43215',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 1,
				resourceId: 'YES34196',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 2,
				resourceId: 'NO57340',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 3,
				key: 3,
				resourceId: 'PARTIALLY30150',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
}

/**
 * The YesNo array.
 */
export const QArrayYesno = {
	type: 'L',
	pluralName: 'YES___NO18321',
	singularName: 'YES___NO18321',
	fnResources: null,
	setResources(fnResources)
	{
		this.fnResources = fnResources
		return this
	},
	get elements()
	{
		// eslint-disable-next-line no-unused-vars
		const vm = this
		return [
			{
				num: 1,
				key: 0,
				resourceId: 'NOT_IN_USE41845',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
			{
				num: 2,
				key: 1,
				resourceId: 'IN_USE42606',
				get value() { return computed(() => vm.fnResources ? vm.fnResources(this.resourceId) : this.resourceId) },
			},
		]
	},
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
	QArrayAssetcategory,
	QArrayAssettags,
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
	QArrayAuthentication_options,
	QArrayAvisperi,
	QArrayBaggage,
	QArrayBagtype,
	QArrayBankcomp,
	QArrayBuildtyp,
	QArrayCity,
	QArrayClass,
	QArrayClassnum,
	QArrayComponenticons,
	QArrayDatatype,
	QArrayDecplace,
	QArrayDispstat,
	QArrayDropdown,
	QArrayDsiponib,
	QArrayFaciltyp,
	QArrayFeedback,
	QArrayFreqempr,
	QArrayGenconta,
	QArrayGender,
	QArrayGenero,
	QArrayGpsinput,
	QArrayHeader,
	QArrayIconrating,
	QArrayIdenttyp,
	QArrayMonths,
	QArrayObjetype,
	QArrayPhonepre,
	QArrayPrimviag,
	QArrayQartipqu,
	QArrayQuickfeedback,
	QArrayRadiobtn,
	QArrayS_modpro,
	QArrayS_module,
	QArrayS_prstat,
	QArrayS_resul,
	QArrayS_roles,
	QArrayS_tpproc,
	QArrayServicetype,
	QArraySexo,
	QArraySide,
	QArraySpacetyp,
	QArraySstatus,
	QArrayTipoarti,
	QArrayTipocond,
	QArrayTypen,
	QArrayTypet,
	QArrayUsefulfeedb,
	QArrayYesno,
}
