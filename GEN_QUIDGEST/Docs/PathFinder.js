//----------------
//The methods in this class assume the node objects will have the following internal structure:
//	[{name:_, imports:[{source, type, link} ...]} ...]
//----------------


//Calculates the nodes that participate in all the paths between the start node and the end node in a a graph
//@graph: A graph consisting of an array of nodes
//@start: The starting node
//@end: The target node
//returns: An array with all the nodes participating in the path. The array will be empty if no path was found.
function StartNodeSpan(graph, start, end)
{
	var participant = [];
	var visited = [];
	__RecurseNodeSpan(graph, start, end, participant, visited);
	
	return participant;
}

//Private recursive function for exclusive use by StartNodeSpan
function __RecurseNodeSpan(graph, node, end, participant, visited)
{
//console.log(node);
	
	if(visited.indexOf(node) != -1)
		return (participant.indexOf(node) != -1);

	var p = false;
	var nodeIx = -1;
	graph.forEach(function(n, ix) { if(n.name == node) nodeIx = ix;});
	
	if(nodeIx == -1)
		return false;	
	
	visited.push(node);

//console.log(graph[nodeIx]);

	graph[nodeIx].imports.forEach(function(child) {
		if(__RecurseNodeSpan(graph, child[0], end, participant, visited))
			p = true;
	});
	if(node == end)
		p = true;
		
	
	if(p)
		participant.push(node);
		
	return p;
}


//Looks for imports that are not in the nodes and creates an empty node as a placeholder
//The array will be modified in place so this function has no return value
//@classes: And array of nodes
function expandClasses(classes) {
	var map = {};
	
	classes.forEach(function(c) {
		map[c.name] = c;
	});
	
	classes.forEach(function(c) {
		c.imports.forEach(function(i){
			var node = map[i[0]];
			if(!node)
			{
				node = { name: i[0], imports: []};
				map[i[0]] = node;
				classes.push(node);
			}
		});
	});
}


//Given a starting node expands forward and backwards to all the reachable nodes in a graph.
//Additinally the node objects will be marked with the attribute 'class' with value 'sources' or 'dests' according to how they where expanded.
//@graph: the complete graph
//@form: the starting node id
//return: And array containing all the reachable node objects
function expandNode(graph, form) {
	//calculate sources propagation
	var newNodes = [];
	var visited = {};
	__filterFormRecurseSources(graph, form, newNodes, visited);
	
	//calculate destinations propagation
	var backQueue = __filterFormRecurseDests(graph, form);
	
	//classify the nodes
	//console.log(backQueue);
	backQueue.forEach(function(n) { n.class = "dests" });
	newNodes.forEach(function(n) { n.class = "sources" });
	
	
	//merge the two lists
	backQueue.forEach(function(n) {
		if(!findObject(newNodes, function(x) { return x.name == n.name;} ))
			newNodes.push(n);
	});
	
	return newNodes;
}

//private function for filterForm
function __filterFormRecurseDests(nodes, form) {
	var visited = {};
	var backQueue = [];
	
	var core = findObject(nodes, function(elem) {return elem.name == form;});
	backQueue.push(core);
	visited[form] = true;
	var oldcount = 0;
	var newcount = 1;
	while(oldcount < newcount)
	{
		oldcount = newcount;
		
		nodes.forEach(function(n) {
			if(!visited[n.name]) {	
				var found = false;
				for(var i=0; i< backQueue.length; i++) {
					if(findObject(n.imports, function(x) { return x[0] == backQueue[i].name;}))
					{
						found = true;
						break;
					}
				}
				if(found)
				{
					backQueue.push(n);
					visited[n.name] = true;
					//newNodes.push(n);
					//console.log(n.name);
				}
			}
		});
		
		newcount = backQueue.length;
	}
	return backQueue;
}


//private function for filterForm
function __filterFormRecurseSources(nodes, form, newNodes, visited) {
	var core = findObject(nodes, function(elem) {return elem.name == form;});
	if(!core) return;
	
	newNodes.push(core);
	visited[form] = true;
	
	core.imports.forEach(function(c){
		var cname = c[0];
		if(!visited[cname])
			__filterFormRecurseSources(nodes, cname, newNodes, visited);
	});
}


//Computes a reacheability matrix for a graph. Each node will be added a list of all the other nodes it can reach
function reachabilityMatrix(graph)
{
	var matrix = {};
	graph.forEach(function(n){
		__reacheabilityRecurse(graph, matrix, n);
	});
	return matrix;
}

//private function to recurse reachabilityMatrix
function __reacheabilityRecurse(graph, matrix, n)
{
	//already calculated
	if(matrix[n.name]) return;
	
	var dests = [];
	
	//add our own dests
	n.imports.forEach(function(i) {		
		//ensure the destination of our dest are calculated (recursive)
		var dnode = findObject(graph, function(x) { return x.name == i[0]; });
		if(dnode) //discard unknown nodes
		{
			if(dests.indexOf(i[0]) == -1)
				dests.push(i[0]);
			__reacheabilityRecurse(graph, matrix, dnode);
		
			//add the dests of this dest to our own
			matrix[i[0]].forEach(function(d) {
				if(dests.indexOf(d) == -1)
					dests.push(d);
			});
		}
	});
	//cache our result
	matrix[n.name] = dests;
}


function isPrimaryEdge(reachMatrix, src, dst)
{
	//an edge is primary if a node X does not exist such that:
	//1. src reaches X
	//2. X reaches dst
	//3. X!=src && X!=dst
	var primary = true;
	for(var i=0; i< reachMatrix[src].length; i++)
	{
		var x = reachMatrix[src][i];
		if(x != dst && reachMatrix[x].indexOf(dst) > -1)
		{
			primary = false;
			break;
		}
	}
	
	return primary;
}


//Finds the first object for which the condition is true in an array
//@array: The array to search
//@f: A function that receive each element of the array and returns true or false
//return: The first object in the array for which the condition is true
function findObject(array, f)
{
	for(var i =0; i < array.length; i++)
		if(f(array[i]))
			return array[i];
			
	return null;
}


//Finds all the objects in an array for which the condition is true
//@array: The array to search
//@f: A function that receive each element of the array and returns true or false
//return: All the objects in the array for which the condition is true
function findAllObjects(array, f)
{
	var res = [];
	for(var i =0; i < array.length; i++)
		if(f(array[i]))
			res.push(array[i]);
			
	return res;
}


//Draws a relational model graph within a html node
//@model: the relational model to draw
//@div: the html node where the graph will be rendered. Requires both a <sgv> node with a placeholder <g> node.
var RelationalModelGraph = function(model, div, type=null) {
	
	this.g = new dagreD3.graphlib.Graph().setGraph({});
	this.g.graph().rankdir = "BT";
	if (type == "role")
		this.g.graph().rankdir = "TB";
	this.g.graph().ranker = "network-simplex"; //network-simplex, longest-path, tight-tree
	
	// setup the nodes
	model.forEach( function(i) {
		this.g.setNode(i.name, {label: i.name, class:i.class});
	}, this);
	
	this.model = model;
	this.showAllEdges = false;
	this.reach = reachabilityMatrix(model);	
	this.updateEdges();

	this.svg = div.select("svg"),
    this.inner = this.svg.select("g");

	// Set up zoom support
	var self = this; //d3 substitutes this for the DOM element, so we need to backup the this value into the self variable
	
	this.zoom = d3.behavior.zoom().on("zoom", function() {
		  self.inner.attr("transform", "translate(" + d3.event.translate + ")" +
									  "scale(" + d3.event.scale + ")");
		});
	this.svg.call(this.zoom);

	// Create the renderer
	this.updateRender();

	this.normalSize();
	
	//setup the toolbar
	div.select(".fit-to-size").on("click", function() { self.fitSize();});
	div.select(".fit-normal").on("click", function() { self.normalSize();});
	
	div.select(".primary-links").on("click", function() { self.setLinksPrimary();});
	div.select(".all-links").on("click", function () { self.setLinksAll(); });
};


RelationalModelGraph.prototype.updateEdges = function() {
	//TODO: remove only the unnecessary edges 
	
	//remove all the previous edges
	this.g.edges().forEach( function(edge) {
		this.g.removeEdge(edge.v, edge.w);
	}, this);
	
	// setup the edges
	this.model.forEach( function(i) {
		i.imports.forEach( function(src) {
			if(this.g.node(src[0]))
			{
				if(this.showAllEdges || isPrimaryEdge(this.reach, i.name, src[0]))
				{
					var clEdge = "";
					var wgEdge = 1;
					if(src[1].substring(0,1) == "F")
					{
						clEdge = "secLink";
						wgEdge = 0.5;
					}
					
					this.g.setEdge(i.name, src[0], {label:"", lineInterpolate: 'basis', class: clEdge, weight: wgEdge });
				}
			}
		}, this);
	}, this);
	
}


RelationalModelGraph.prototype.setLinksPrimary = function() {
	if(this.showAllEdges)
	{
		this.showAllEdges = false;
		this.updateEdges();
		this.updateRender();
		this.normalSize();
	}
}

RelationalModelGraph.prototype.setLinksAll = function() {
	if(!this.showAllEdges)
	{
		this.showAllEdges = true;
		this.updateEdges();
		this.updateRender();
		this.normalSize();
	}
}

RelationalModelGraph.prototype.updateRender = function() {
	var render = new dagreD3.render();
	// Run the renderer. This is what draws the final graph.
	render(this.inner, this.g);	
}


RelationalModelGraph.prototype.fitSize = function() {
	// Center the graph	
	var initialScale = 0.75;
	//resize to fit
	var initialScale = (this.svg.attr("width") * 1.0) / (this.g.graph().width + 50.0);
	if(initialScale > 0.75)
		initialScale = 0.75;
	this.rescale(initialScale);
};

RelationalModelGraph.prototype.normalSize = function() {
	this.rescale(0.75);
};

RelationalModelGraph.prototype.rescale = function(newScale) {
	// Center the graph
	this.zoom
	  .translate([(this.svg.attr("width") - this.g.graph().width * newScale) / 2, 20])
	  .scale(newScale)
	  .event(this.svg);
	  
	//minimize the height of the container
	this.svg.attr('height', this.g.graph().height * newScale + 40);	
};

RelationalModelGraph.prototype.setSelected = function(nodeName) {
	this.g.node(nodeName).elem.classList.add("selected");
};


