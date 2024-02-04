module.exports = {
  root: true,
  env: { browser: true, es2020: true, node: true},
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:react-hooks/recommended',
    "plugin:tailwindcss/recommended",
    "plugin:sonarjs/recommended",
    "plugin:jsx-a11y/recommended"
  ],
  ignorePatterns: ['dist', '.eslintrc.cjs', "src/components/ui/**/*"],
  parser: '@typescript-eslint/parser',
  plugins: ['react-refresh',"sonarjs","jsx-a11y"],
  rules: {
    'react-refresh/only-export-components': [
      'warn',
      { allowConstantExport: true },
    ],
  },
}
