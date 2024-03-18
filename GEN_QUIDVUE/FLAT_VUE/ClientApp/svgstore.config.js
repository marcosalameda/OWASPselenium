const svgstore = require('svgstore')
const fs = require('fs')
const path = require('path')

/**
 * Specific bundling setup for this project.
 */
function ProjectPack()
{
	PackSvg('./public/Content/svg/', './public/Content/svgbundle.svg')
}

/**
 * Bundles all the svg files found in a souce directory into an single svg output file.
 * @param {string} dirname - The path to the directory containing all the svgs to be bundled
 * @param {string} output - The full filename of the desired output bundle
 */
function PackSvg(dirname, output)
{
	let sprites = svgstore()
	const files = fs.readdirSync(dirname)

	files.forEach((file) => {
		if (path.extname(file) === '.svg')
		{
			let id = path.parse(file).name
			let content = fs.readFileSync(path.join(dirname, file), 'utf8')
			sprites.add(id, content)
		}
	})

	fs.writeFileSync(output, sprites.toString())
}

module.exports = ProjectPack