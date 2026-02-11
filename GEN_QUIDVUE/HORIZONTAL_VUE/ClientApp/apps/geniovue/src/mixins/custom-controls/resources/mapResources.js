export default class MapResources
{
	constructor(fnGetResource)
	{
		this._fnGetResource = typeof fnGetResource !== 'function' ? resId => resId : fnGetResource
		Object.defineProperty(this, '_fnGetResource', { enumerable: false })

		Object.defineProperty(this, 'search', {
			get: () => this._fnGetResource('PESQUISAR34506'),
			enumerable: true
		})
		Object.defineProperty(this, 'defaultLayer', {
			get: () => this._fnGetResource('CAMADA_PADRAO16799'),
			enumerable: true
		})
		Object.defineProperty(this, 'clusterGroupLayer', {
			get: () => this._fnGetResource('CAMADA_DE_GRUPO23322'),
			enumerable: true
		})
		Object.defineProperty(this, 'shapesLayer', {
			get: () => this._fnGetResource('CAMADA_DE_FORMAS24489'),
			enumerable: true
		})
		Object.defineProperty(this, 'latitude', {
			get: () => this._fnGetResource('LATITUDE11291'),
			enumerable: true
		})
		Object.defineProperty(this, 'longitude', {
			get: () => this._fnGetResource('LONGITUDE01015'),
			enumerable: true
		})
		Object.defineProperty(this, 'description', {
			get: () => this._fnGetResource('DESCRICAO_19279'),
			enumerable: true
		})
		Object.defineProperty(this, 'cancel', {
			get: () => this._fnGetResource('CANCELAR49513'),
			enumerable: true
		})
		Object.defineProperty(this, 'finish', {
			get: () => this._fnGetResource('TERMINAR61258'),
			enumerable: true
		})
		Object.defineProperty(this, 'deleteLastPoint', {
			get: () => this._fnGetResource('EXCLUIR_ULTIMO_PONTO23497'),
			enumerable: true
		})
		Object.defineProperty(this, 'drawPolyline', {
			get: () => this._fnGetResource('DESENHAR_UMA_POLILIN61896'),
			enumerable: true
		})
		Object.defineProperty(this, 'drawPolygon', {
			get: () => this._fnGetResource('DESENHAR_UM_POLIGONO12868'),
			enumerable: true
		})
		Object.defineProperty(this, 'drawRectangle', {
			get: () => this._fnGetResource('DESENHAR_UM_RETANGUL46722'),
			enumerable: true
		})
		Object.defineProperty(this, 'drawCircle', {
			get: () => this._fnGetResource('DESENHAR_UM_CIRCULO51276'),
			enumerable: true
		})
		Object.defineProperty(this, 'drawMarker', {
			get: () => this._fnGetResource('DESENHAR_UM_MARCADOR25870'),
			enumerable: true
		})
		Object.defineProperty(this, 'drawCircleMarker', {
			get: () => this._fnGetResource('DESENHAR_UM_MARCADOR34224'),
			enumerable: true
		})
		Object.defineProperty(this, 'drawText', {
			get: () => this._fnGetResource('DESENHAR_TEXTO17458'),
			enumerable: true
		})
		Object.defineProperty(this, 'radius', {
			get: () => this._fnGetResource('RAIO02224'),
			enumerable: true
		})
		Object.defineProperty(this, 'area', {
			get: () => this._fnGetResource('AREA19058'),
			enumerable: true
		})
		Object.defineProperty(this, 'perimeter', {
			get: () => this._fnGetResource('PERIMETRO27301'),
			enumerable: true
		})
		Object.defineProperty(this, 'startCircleDraw', {
			get: () => this._fnGetResource('CLIQUE_NO_MAPA_PARA_36879'),
			enumerable: true
		})
		Object.defineProperty(this, 'endCircleDraw', {
			get: () => this._fnGetResource('CLIQUE_NO_MAPA_PARA_12531'),
			enumerable: true
		})
		Object.defineProperty(this, 'placeCircleMarker', {
			get: () => this._fnGetResource('CLIQUE_NO_MAPA_PARA_01379'),
			enumerable: true
		})
		Object.defineProperty(this, 'placeMarker', {
			get: () => this._fnGetResource('CLIQUE_NO_MAPA_PARA_27665'),
			enumerable: true
		})
		Object.defineProperty(this, 'placeText', {
			get: () => this._fnGetResource('CLIQUE_NO_MAPA_PARA_49809'),
			enumerable: true
		})
		Object.defineProperty(this, 'startShapeDraw', {
			get: () => this._fnGetResource('CLIQUE_PARA_COMECAR_46982'),
			enumerable: true
		})
		Object.defineProperty(this, 'continueShapeDraw', {
			get: () => this._fnGetResource('CLIQUE_PARA_CONTINUA55696'),
			enumerable: true
		})
		Object.defineProperty(this, 'endShapeDraw', {
			get: () => this._fnGetResource('CLIQUE_NO_PRIMEIRO_P63933'),
			enumerable: true
		})
		Object.defineProperty(this, 'endLineDraw', {
			get: () => this._fnGetResource('CLIQUE_NO_ULTIMO_PON17740'),
			enumerable: true
		})
		Object.defineProperty(this, 'endDrawing', {
			get: () => this._fnGetResource('CLIQUE_NO_MAPA_PARA_15804'),
			enumerable: true
		})
		Object.defineProperty(this, 'editLayers', {
			get: () => this._fnGetResource('EDITAR_CAMADAS13617'),
			enumerable: true
		})
		Object.defineProperty(this, 'deleteLayers', {
			get: () => this._fnGetResource('EXCLUIR_CAMADAS60432'),
			enumerable: true
		})
		Object.defineProperty(this, 'dragLayers', {
			get: () => this._fnGetResource('ARRASTAR_CAMADAS24431'),
			enumerable: true
		})
		Object.defineProperty(this, 'cutLayers', {
			get: () => this._fnGetResource('RECORTAR_CAMADAS43897'),
			enumerable: true
		})
		Object.defineProperty(this, 'rotateLayers', {
			get: () => this._fnGetResource('RODAR_CAMADAS32297'),
			enumerable: true
		})
		Object.defineProperty(this, 'scaleLayers', {
			get: () => this._fnGetResource('REDIMENSIONAR_CAMADA64500'),
			enumerable: true
		})
		Object.defineProperty(this, 'snapVertices', {
			get: () => this._fnGetResource('JUNTAR_O_MARCADOR_AR20474'),
			enumerable: true
		})
		Object.defineProperty(this, 'pinVertices', {
			get: () => this._fnGetResource('PRENDER_OS_VERTICES_56161'),
			enumerable: true
		})
		Object.defineProperty(this, 'autoTrace', {
			get: () => this._fnGetResource('DETETAR_LINHA_AUTOMA12070'),
			enumerable: true
		})
		Object.defineProperty(this, 'length', {
			get: () => this._fnGetResource('COMPRIMENTO42533'),
			enumerable: true
		})
		Object.defineProperty(this, 'segmentLength', {
			get: () => this._fnGetResource('COMPRIMENTO_DO_SEGME01997'),
			enumerable: true
		})
		Object.defineProperty(this, 'height', {
			get: () => this._fnGetResource('ALTURA57630'),
			enumerable: true
		})
		Object.defineProperty(this, 'width', {
			get: () => this._fnGetResource('LARGURA03667'),
			enumerable: true
		})
		Object.defineProperty(this, 'position', {
			get: () => this._fnGetResource('POSICAO07486'),
			enumerable: true
		})
		Object.defineProperty(this, 'positionMarker', {
			get: () => this._fnGetResource('MARCADOR_DA_POSICAO09118'),
			enumerable: true
		})
		Object.defineProperty(this, 'externalLayer', {
			get: () => this._fnGetResource('CAMADA_EXTERNA30603'),
			enumerable: true
		})
		Object.defineProperty(this, 'printMap', {
			get: () => this._fnGetResource('IMPRIMIR_MAPA10717'),
			enumerable: true
		})
		Object.defineProperty(this, 'centerControlMap', {
			get: () => this._fnGetResource('CENTRAR_NO_MAPA05060'),
			enumerable: true
		})
		Object.defineProperty(this, 'printLandscape', {
			get: () => this._fnGetResource('PAISAGEM06194'),
			enumerable: true
		})
		Object.defineProperty(this, 'printPortrait', {
			get: () => this._fnGetResource('RETRATO07729'),
			enumerable: true
		})
	}
}
