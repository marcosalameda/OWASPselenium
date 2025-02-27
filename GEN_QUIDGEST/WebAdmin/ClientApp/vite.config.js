import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import path from 'path'

// Icons
import PackBundle from './svgstore.config'

function svgBundlePlugin() 
{
	return {
		name: 'svgbundle-plugin',
		buildStart: PackBundle
	}
}

export default defineConfig({
	base: './',
	root: './',
	resolve: {
		alias: {
			'@': path.resolve(__dirname, './src'),
			'vue-i18n': 'vue-i18n/dist/vue-i18n.cjs.js'
		},
		extensions: ['.js', '.json', '.vue']
	},
	build: {
		target: 'esnext',
		minify: true,
		manifest: false,
		sourcemap: false,
		outDir: 'dist',
		emptyOutDir: true,
		rollupOptions: {
			cache: true,
			treeshake: false
		},
		cssCodeSplit: false,
		reportCompressedSize: false,
		modulePreload: false
	},
	chunkSizeWarningLimit: 500,
	plugins: [
		vue(),
		svgBundlePlugin()
	],
	server: {
		open: false,
		port: 8202,
		proxy: {
			'/api': {
				target: 'http://localhost:5658/',
				secure: false
			}
		}
	}
})
