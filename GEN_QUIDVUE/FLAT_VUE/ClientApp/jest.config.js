module.exports = {
	preset: '@vue/cli-plugin-unit-jest/presets/default',
	setupFilesAfterEnv: ['./tests/matchers/index.js'],
	verbose: true,
	reporters: ['default', 'jest-junit'],
	collectCoverage: true,
	collectCoverageFrom: ['src/components/**/{!(index.js), (*.*)}']
}
