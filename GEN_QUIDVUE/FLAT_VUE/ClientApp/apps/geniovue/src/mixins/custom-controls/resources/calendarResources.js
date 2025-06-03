export default class CalendarResources
{
	constructor(fnGetResource)
	{
		this._fnGetResource = typeof fnGetResource !== 'function' ? resId => resId : fnGetResource
		Object.defineProperty(this, '_fnGetResource', { enumerable: false })

		Object.defineProperty(this, 'startDate', {
			get: () => this._fnGetResource('DATA_DE_INICIO37610'),
			enumerable: true
		})
		Object.defineProperty(this, 'endDate', {
			get: () => this._fnGetResource('DATA_DE_FIM18270'),
			enumerable: true
		})
		Object.defineProperty(this, 'eventTitle', {
			get: () => this._fnGetResource('TITULO_DO_EVENTO64085'),
			enumerable: true
		})
		Object.defineProperty(this, 'eventDescription', {
			get: () => this._fnGetResource('DESCRICAO_DO_EVENTO47400'),
			enumerable: true
		})
		Object.defineProperty(this, 'yes', {
			get: () => this._fnGetResource('SIM28552'),
			enumerable: true
		})
		Object.defineProperty(this, 'cancel', {
			get: () => this._fnGetResource('CANCELAR49513'),
			enumerable: true
		})
		Object.defineProperty(this, 'move', {
			get: () => this._fnGetResource('MOVER62644'),
			enumerable: true
		})
		Object.defineProperty(this, 'duplicate', {
			get: () => this._fnGetResource('DUPLICAR09748'),
			enumerable: true
		})
		Object.defineProperty(this, 'doMoveEvent', {
			get: () => this._fnGetResource('PRETENDE_MOVER_O_EVE36449'),
			enumerable: true
		})
		Object.defineProperty(this, 'doEditEvent', {
			get: () => this._fnGetResource('PRETENDE_ALTERAR_O_E59231'),
			enumerable: true
		})
		Object.defineProperty(this, 'successfulEventEdit', {
			get: () => this._fnGetResource('EVENTO_ALTERADO_COM_57794'),
			enumerable: true
		})
		Object.defineProperty(this, 'successfulEventMove', {
			get: () => this._fnGetResource('EVENTO_MOVIDO_COM_SU59433'),
			enumerable: true
		})
		Object.defineProperty(this, 'successfulDuplication', {
			get: () => this._fnGetResource('DUPLICACAO_BEM_SUCED21475'),
			enumerable: true
		})
		Object.defineProperty(this, 'errorOnlyEventsLastLevel', {
			get: () => this._fnGetResource('APENAS_E_PERMITIDO_A39067'),
			enumerable: true
		})
		Object.defineProperty(this, 'errorProcessingRequest', {
			get: () => this._fnGetResource('OCORREU_UM_ERRO_AO_P53091'),
			enumerable: true
		})
		Object.defineProperty(this, 'close', {
			get: () => this._fnGetResource('FECHAR32496'),
			enumerable: true
		})
	}
}
