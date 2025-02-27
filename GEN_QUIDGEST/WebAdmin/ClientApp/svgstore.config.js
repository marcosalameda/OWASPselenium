import { readdirSync, readFileSync, writeFileSync } from 'fs'
import { extname, join, parse } from 'path'
import svgstore from 'svgstore'

/**
 * Specific bundling setup for this project.
 */
function PackBundle()
{
	PackSvg('./public/Content/svg/', './public/Content/svgbundle.svg')
}

/**
 * Bundles all the svg files found in a souce directory into an single svg output file.
 * @param {string} dirname - Path to svg directory
 * @param {string} output - Path to resulting svg bundle
 */
function PackSvg(dir, output)
{
    let sprites = svgstore()

    const svgs = readdirSync(dir)

    svgs.forEach((svg) => {
        if (extname(svg) === '.svg')
        {
            const iconId = parse(svg).name
            const iconContent = readFileSync(join(dir, svg), 'utf8')

            sprites.add(iconId, iconContent)
        }
    })

    writeFileSync(output, sprites.toString())
}

export default PackBundle